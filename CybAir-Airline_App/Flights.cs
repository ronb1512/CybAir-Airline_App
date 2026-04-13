using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Xml.Linq;
using static CybAir_Airline_App.Data;

namespace CybAir_Airline_App
{
    public partial class Flights : Form
    {
        private ActiveFlight ordered_flight { get; set; }
        private List<Seat> current_booked_seats { get; set; }
        /// <summary>
        /// the constructor sets the rendering options
        /// </summary>
        public Flights()
        {

            InitializeComponent();
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint |
                          ControlStyles.ResizeRedraw, true);
            this.UpdateStyles();
        }
        /// <summary>
        /// sets the screen size and call the set_components function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Flights_Load(object sender, EventArgs e)
        {
            this.Size = new Size(
                UI.calculate_size(Screen.PrimaryScreen.WorkingArea.Width, 0.7),
                UI.calculate_size(Screen.PrimaryScreen.WorkingArea.Height, 0.75));
            this.set_components();

        }
        /// <summary>
        /// overrides and changes a property for better painting and renderring
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleparam = base.CreateParams;
                handleparam.ExStyle |= 0x02000000;
                return handleparam;
            }
        }
        /// <summary>
        /// sets the style for all the different UI controls in the form relative to 
        /// the screen size
        /// </summary>
        private void set_components()
        {
            
            this.dummy_btn.Select();
            UI.AttachClickHandlers(this.Controls);
            this.Flights_background.Size = new Size(this.ClientSize.Width, this.ClientSize.Height);
            this.navbar_panel.Top = 0;
            this.navbar_panel.Width = this.ClientSize.Width;
            this.log_in_btn_nav.Visible = false;
            int screen_width = Screen.PrimaryScreen.WorkingArea.Width;
            int smaller_size = Math.Min(UI.calculate_size(this.ClientSize.Width, 0.5), UI.calculate_size(screen_width, 0.4));

            
            void search_form_setup()
            {
                this.search_form.Width = smaller_size;
                this.search_form.Height = UI.calculate_size(smaller_size, 0.43);
                this.search_form.Padding = new System.Windows.Forms.Padding(17);
                UI.RoundCorners(this.search_form, 10, Color.White, 1);
                this.search_form.Location = new Point(
                    (this.ClientSize.Width - this.search_form.Width) / 2,
                    UI.calculate_size(this.ClientSize.Height, 0.1));
            }

            
            void search_btn_setup()
            {
                this.search_btn.Width = this.search_form.Width / 2;
                this.search_btn.Font = new Font(this.search_btn.Font.FontFamily, UI.calculate_size(smaller_size, 0.022));
                int textHeight = TextRenderer.MeasureText(this.search_btn.Text, this.search_btn.Font).Height;
                this.search_btn.Height = textHeight + 15;
                UI.RoundCorners(this.search_btn, 40, Color.White, 1);
                this.search_btn.Left = (this.search_form.Width - this.search_btn.Width) / 2;
                this.search_btn.BringToFront();
            }
            int top_pos = UI.calculate_size(this.search_form.Height, 0.1);
            int left_pos = this.search_form.Padding.Left;

            
            void textBoxes_setup(Panel p)
            {
                Panel[] all_textbox_containers = p.Controls.OfType<Panel>().ToArray();
                Array.Reverse(all_textbox_containers);
                foreach (Panel container in all_textbox_containers)
                {
                    container.Left = left_pos;
                    container.Top = top_pos;

                    
                    Krypton.Toolkit.KryptonTextBox textbox = container.Controls.OfType<Krypton.Toolkit.KryptonTextBox>().FirstOrDefault();
                    if (textbox != null)
                    {
                        textbox.Width = this.search_btn.Width - this.search_form.Padding.Left - 5;
                        textbox.StateCommon.Content.Font = new Font(this.search_btn.Font.FontFamily, this.search_btn.Font.Size * 0.9f);
                        textbox.StateActive.Content.Font = new Font(this.search_btn.Font.FontFamily, this.search_btn.Font.Size * 0.9f);
                        textbox.CueHint.Font = new Font(this.search_btn.Font.FontFamily, this.search_btn.Font.Size * 0.9f);
                        textbox.Height = TextRenderer.MeasureText(textbox.Text, this.To_textbox.StateCommon.Content.Font).Height;

                        
                        IconPictureBox icon = container.Controls.OfType<IconPictureBox>().FirstOrDefault();
                        icon.IconSize = textbox.Height - 4;
                        icon.Location = new Point(this.search_form.Padding.Left + textbox.Width - UI.calculate_size(icon.IconSize, 1.5), (container.Height - icon.Height) / 2);
                        icon.BackColor = Color.Transparent;
                        if (p != this.payment_container)
                            left_pos += textbox.Width + 10;
                        else
                            top_pos += textbox.Height + 15;
                    }



                }

                
                if (!this.payment_form.Visible)
                {
                    List<Data.City> citysList = Data.getWorldCities();
                    List<string> addresses = new List<string>();
                    foreach (Data.City city in citysList)
                    {
                        if (city.city != "" && city.country != "")
                            addresses.Add($"{city.city}, {city.country}");

                    }
                    this.From_textbox.AutoCompleteMode = AutoCompleteMode.Suggest;
                    this.From_textbox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    this.From_textbox.AutoCompleteCustomSource.AddRange(addresses.ToArray());

                    this.To_textbox.AutoCompleteMode = AutoCompleteMode.Suggest;
                    this.To_textbox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    this.To_textbox.AutoCompleteCustomSource.AddRange(addresses.ToArray());
                }
            }
            search_form_setup();
            search_btn_setup();
            textBoxes_setup(this.search_form);

            
            Label[] all_labels = this.search_form.Controls.OfType<Label>().ToArray();
            top_pos = this.To_textbox.Parent.Bottom;
            for (int i = 0; i < all_labels.Length; i++)
            {
                Label label = all_labels[i];
                label.Font = this.To_textbox.CueHint.Font;
                label.BringToFront();
                label.Top = top_pos;
                if (i % 2 == 0)
                {
                    label.Left = this.From_textbox.Parent.Left + 10;
                }
                else
                {
                    label.Left = this.To_textbox.Parent.Left + 10;
                }
            }
            top_pos = this.departure_date_label.Bottom;
            left_pos = this.departure_date_label.Left;

            
            void set_dates()
            {
                List<MaterialSkin.Controls.MaterialComboBox> all_comboboxes = this.search_form.Controls.OfType<MaterialSkin.Controls.MaterialComboBox>().ToList();
                all_comboboxes.Remove(this.class_combobox);
                all_comboboxes.Remove(this.passengers_combobox);
                all_comboboxes.Reverse();
                for (int i = 0; i < all_comboboxes.Count; i++)
                {
                    MaterialSkin.Controls.MaterialComboBox combobox = all_comboboxes[i];
                    combobox.Top = top_pos;
                    combobox.Left = left_pos;
                    if (i % 3 == 0)
                    {
                        combobox.Width = (this.search_form.Width - 2 * this.search_form.Padding.Left) / 6 - 30;
                        List<int> daysList = Enumerable.Range(1, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)).ToList();
                        combobox.DataSource = daysList;
                        combobox.SelectedItem = DateTime.Now.AddDays(i / 3 + 1).Day;

                    }
                    if (i % 3 == 1)
                    {

                        combobox.Width = this.Day_combobox.Width + 55;
                        string[] monthsList = new CultureInfo("en-US").DateTimeFormat.MonthNames.Where(m => !string.IsNullOrEmpty(m)).ToArray();
                        combobox.DataSource = monthsList;
                        combobox.SelectedItem = monthsList[DateTime.Now.AddDays((i - 1) / 3 + 1).Month - 1];
                    }
                    if (i % 3 == 2)
                    {
                        combobox.Width = this.Day_combobox.Width + 20;
                        List<int> yearsList = Enumerable.Range(DateTime.Now.Year, 10).Reverse().ToList();
                        combobox.DataSource = yearsList;
                        combobox.SelectedItem = DateTime.Now.AddDays((i - 1) / 3 + 1).Year;

                    }

                    left_pos = i == 2 ? this.return_date_label.Left : left_pos + combobox.Width;
                }
            }
            set_dates();

            
            void other_setup()
            {
                top_pos = Day2_combobox.Bottom + UI.calculate_size(this.search_form.Height, 0.05);
                this.passengers_number_label.Location = new Point(this.search_form.Width / 2 - this.passengers_number_label.Width - 25, top_pos);
                this.class_label.Location = new Point(this.search_form.Width / 2 + 25, top_pos);
                top_pos = this.passengers_number_label.Bottom;
                this.passengers_combobox.Location = new Point(this.passengers_number_label.Left, top_pos);
                this.passengers_combobox.DataSource = Enumerable.Range(1, 8).ToList();
                this.class_combobox.Location = new Point(this.class_label.Left, top_pos);
                string[] classes = { "Economy", "Buissnes", "First" };
                this.class_combobox.DataSource = classes;
                this.class_combobox.Width = UI.calculate_size(this.passengers_combobox.Width, 1.5);
                top_pos = this.passengers_combobox.Bottom + UI.calculate_size(this.search_form.Height, 0.05);
                this.search_btn.Top = top_pos;
                Font btn_font = new Font(this.search_btn.Font.FontFamily, UI.calculate_size(this.ClientSize.Width, 0.013));
                if (btn_font.Size > 15f)
                {
                    btn_font = new Font(this.search_btn.Font.FontFamily, 15f);
                }
                this.logout_btn.Top = this.navbar_panel.Bottom;
                this.logout_btn.Left = this.ClientSize.Width - this.logout_btn.Width - 30;
                this.logout_btn.IconSize = this.logout_btn.Font.Height;
                this.logout_btn.Font = btn_font;
                this.logout_btn.BringToFront();
                UI.set_navbar(this.navbar_panel, this.ClientSize, btn_font);

                this.tickets_container.Width = UI.calculate_size(this.search_form.Width, 0.9);
                this.tickets_container.Location = new Point((this.ClientSize.Width - this.tickets_container.Width) / 2, this.search_form.Bottom + 20);
                this.tickets_container.Height = this.ClientSize.Height - this.tickets_container.Top - 20;
                this.tickets_container.BackColor = Color.Transparent;

                
                this.plane_panel.Location = new Point(0, 0);
                this.plane_panel.Visible = false;
                this.plane_panel.Width = this.ClientSize.Width;
                this.plane_panel.Height = this.ClientSize.Height;
                this.cabin.Height = UI.calculate_size(plane_panel.Height, 0.5);
                this.cabin.Width = UI.calculate_size(this.plane_panel.Width, 1.1);
                UI.RoundCorners(cabin, cabin.Height, Color.White, 1);
                this.cabin.Left = -cabin.Height / 2;
                this.cabin.Top = (this.plane_panel.Height - cabin.Height) / 2;

                this.wing_top.Height = this.ClientSize.Height;
                this.wing_bottom.Height = this.ClientSize.Height;
                this.wing_top.Top = this.cabin.Top - this.wing_top.Height;
                this.wing_bottom.Top = this.cabin.Bottom;
                this.wing_top.Width = this.ClientSize.Width / 3;
                this.wing_bottom.Width = this.ClientSize.Width / 3;
                this.wing_top.Left = (this.ClientSize.Width - this.wing_top.Width) / 2;
                this.wing_bottom.Left = this.wing_top.Left;
                this.wing_top.BackColor = Color.Transparent;
                this.wing_bottom.BackColor = Color.Transparent;

                
                this.wing_top.Paint += (sender1, e1) =>
                {
                    Panel panel = (Panel)sender1;
                    Graphics g = e1.Graphics;
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    Point[] trianglePoints = new Point[]
                    {
                new Point(0,0),
                new Point(0, panel.Height),
                new Point(panel.Width, panel.Height)
                    };

                    Brush triangleBrush = new SolidBrush(Color.White);
                    g.FillPolygon(triangleBrush, trianglePoints);
                };

                
                this.wing_bottom.Paint += (sender, e) =>
                {
                    Panel panel = (Panel)sender;
                    Graphics g = e.Graphics;
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    Point[] trianglePoints = new Point[]
                    {
                new Point(0, panel.Height),
                new Point(0, 0),
                new Point(panel.Width, 0)
                    };

                    Brush triangleBrush = new SolidBrush(Color.White);
                    g.FillPolygon(triangleBrush, trianglePoints);
                };

                this.book_flight_btn.BringToFront();
                this.select_seats_label.Top = this.cabin.Top / 2;
                this.select_seats_label.BackColor = Color.White;
                this.select_seats_label.Left = this.wing_top.Left;
                this.select_seats_label.Font = new Font(this.select_seats_label.Font.FontFamily, this.search_btn.Font.Size * 1.5f);

                
                this.payment_form.Size = new Size(UI.calculate_size(ClientSize.Width, 0.25) + 20, UI.calculate_size(ClientSize.Height, 0.5));

                this.payment_form.BringToFront();
                this.payment_form.Location = new Point((this.ClientSize.Width - this.payment_form.Width) / 2, (this.ClientSize.Height - this.payment_form.Height) / 2);

                this.price_label.Font = this.payment_label.Font;
                this.price_label.Top = this.payment_label.Bottom;
                this.price_label.Left = (this.payment_form.Width - this.price_label.Width) / 2;
                this.price_label.Text = "1000$";
                this.price_label.ForeColor = payment_form.BackColor;


                this.payment_container.Location = new Point(0, this.price_label.Bottom + 15);
                this.payment_container.Width = this.payment_form.Width;
                this.payment_container.Height = this.payment_btn.Top - this.price_label.Bottom - 25;

                left_pos = 10;
                top_pos = 0;
                textBoxes_setup(this.payment_container);
                this.payment_form.Visible = false;

                
                List<int> monthsList = Enumerable.Range(1, 12).ToList();
                List<int> yearsList = Enumerable.Range(DateTime.Now.Year, 10).ToList();
                this.payment_month.Parent.Width = this.payment_form.Width - 10;
                this.payment_month.DataSource = monthsList;
                this.payment_year.DataSource = yearsList;
                this.payment_year.SelectedIndex = 0;
                this.payment_month.SelectedIndex = DateTime.Now.AddDays(1).Month - 1;

                this.payment_month.Width = UI.calculate_size(this.payment_form.Width, 0.25);
                this.payment_month.Left = this.payment_form.Width/2 - payment_month.Width;
                this.payment_year.Width = UI.calculate_size(this.payment_form.Width, 0.25);
                this.payment_year.Left = this.payment_month.Right;

                
                this.order_status.Visible = false;
            }
            other_setup();
        }
        /// <summary>
        /// displays all the outbound flights and all the return flights as tickets with data
        /// adds a click event to each ticket
        /// </summary>
        /// <param name="departure_flights"></param>
        /// <param name="return_flights"></param>
        private void set_tickets(List<ActiveFlight> departure_flights, List<ActiveFlight> return_flights)
        {
            for (int i = tickets_container.Controls.Count - 1; i >= 0; i--)
            {
                Control c = tickets_container.Controls[i];
                tickets_container.Controls.RemoveAt(i);
                c.Dispose();
            }

            ///creates a panel with different flight data
            Panel create_ticket(ActiveFlight flight)
            {
                Panel ticket = new Panel();
                ticket.Parent = this.tickets_container;
                ticket.Height = UI.calculate_size(this.tickets_container.Height, 0.5);
                ticket.Width = this.tickets_container.Width - SystemInformation.VerticalScrollBarWidth;
                ticket.BackColor = Color.White;
                ticket.Left = 0;
                ticket.Cursor = System.Windows.Forms.Cursors.Hand;
                UI.RoundCorners(ticket, 20, Color.Transparent, 1);
                ticket.Click += (sender, e) => { set_plane_cabin(flight); };
                this.tickets_container.Controls.Add(ticket);

                
                IconPictureBox arrow_right = new IconPictureBox();
                arrow_right.SizeMode = PictureBoxSizeMode.AutoSize;
                arrow_right.IconChar = IconChar.Plane;
                arrow_right.Width = UI.calculate_size(ticket.Width, 0.3);
                arrow_right.Height = ticket.Height / 4;
                arrow_right.IconSize = ticket.Height / 4;
                arrow_right.Location = new Point((ticket.Width - arrow_right.IconSize) / 2, (ticket.Height - arrow_right.IconSize) / 2);
                arrow_right.Parent = ticket;
                arrow_right.BackColor = Color.Transparent;
                ticket.Controls.Add(arrow_right);

                
                Label origin_city = new Label();
                origin_city.Parent = ticket;
                origin_city.AutoSize = true;
                origin_city.Text = $"{flight.origin_city} ({flight.origin_airport})";
                origin_city.Font = new Font(this.search_btn.Font.FontFamily, this.search_btn.Font.Size * 1.2f, FontStyle.Bold);
                origin_city.ForeColor = Color.FromArgb(0, 70, 127);
                origin_city.Location = new Point(10, ticket.Height / 2 - origin_city.Height - 20);
                ticket.Controls.Add(origin_city);

                
                Label origin_country = new Label();
                origin_country.Parent = ticket;
                origin_country.AutoSize = true;
                origin_country.Text = flight.origin_country;
                origin_country.Font = origin_city.Font;
                origin_country.ForeColor = Color.FromArgb(0, 172, 157);
                origin_country.Location = new Point(10, ticket.Height / 2 - 25);
                ticket.Controls.Add(origin_country);

               
                Label destination_city = new Label();
                destination_city.Parent = ticket;
                destination_city.AutoSize = true;
                destination_city.Text = $"{flight.destination_city} ({flight.destination_airport})";
                destination_city.Font = new Font(this.search_btn.Font.FontFamily, this.search_btn.Font.Size * 1.2f, FontStyle.Bold);
                destination_city.ForeColor = Color.FromArgb(0, 70, 127);
                destination_city.Location = new Point(ticket.Right - destination_city.Width - 10, origin_city.Top);
                ticket.Controls.Add(destination_city);

                
                Label destination_country = new Label();
                destination_country.Parent = ticket;
                destination_country.AutoSize = true;
                destination_country.Text = flight.destination_country;
                destination_country.Font = destination_city.Font;
                destination_country.ForeColor = Color.FromArgb(0, 172, 157);
                destination_country.Location = new Point(destination_city.Left, origin_country.Top);
                ticket.Controls.Add(destination_country);

                
                Label date_time = new Label();
                date_time.Parent = ticket;
                date_time.AutoSize = true;
                date_time.Text = $"{flight.date.ToString("dd/MM/yyyy")}\n{flight.time}";
                date_time.Font = new Font(this.search_btn.Font.FontFamily, this.search_btn.Font.Size * 1.1f);
                date_time.ForeColor = Color.Black;
                date_time.Location = new Point((origin_city.Width - date_time.Width) / 2, origin_country.Bottom + 10);
                ticket.Controls.Add(date_time);

                
                Label flight_class = new Label();
                flight_class.Parent = ticket;
                flight_class.AutoSize = true;
                flight_class.Text = this.class_combobox.Text;
                flight_class.Font = new Font(this.search_btn.Font.FontFamily, this.search_btn.Font.Size * 1.2f);
                flight_class.Location = new Point(destination_city.Left + (destination_city.Width - flight_class.Width) / 2, date_time.Top + (date_time.Height - flight_class.Height) / 2);
                flight_class.BringToFront();
                ticket.Controls.Add(flight_class);

                
                Label price = new Label();
                price.Parent = ticket;
                price.AutoSize = true;
                price.Text = (flight.price * (class_combobox.SelectedIndex + 1)).ToString() + "$";
                price.Font = new Font(this.search_btn.Font.FontFamily, this.search_btn.Font.Size * 1.3f, FontStyle.Bold);
                price.ForeColor = Color.Black;
                price.Location = new Point((ticket.Width - price.Width) / 2, date_time.Top + (date_time.Height - price.Height) / 2);
                price.BringToFront();
                ticket.Controls.Add(flight_class);

                
                Panel ticket_top = new Panel();
                ticket_top.Parent = ticket;
                ticket_top.AutoSize = true;
                ticket_top.Width = ticket.Width;
                ticket_top.Height = origin_city.Top - 10;
                ticket_top.Location = new Point(0, 0);
                ticket_top.BringToFront();
                ticket_top.BackColor = Color.FromArgb(0, 70, 127);
                ticket.Controls.Add(ticket_top);

                return ticket;
            }

            
            Label tickets_label1 = new Label();
            tickets_label1.Parent = tickets_container;
            tickets_label1.AutoSize = true;
            tickets_label1.Text = $"Outbound Flights: {(departure_flights.Count == 0 ? "  No Available Flights" : "")}";
            tickets_label1.Font = new Font(this.search_btn.Font.FontFamily, this.search_btn.Font.Size * 1.5f, FontStyle.Bold);
            tickets_label1.ForeColor = Color.Black;
            tickets_label1.Location = new Point(0, 0);
            tickets_container.Controls.Add(tickets_label1);
            int top_pos = tickets_label1.Height + 20;
            foreach (ActiveFlight flight in departure_flights)
            {
                Panel ticket = create_ticket(flight);
                ticket.Top = top_pos;
                top_pos += ticket.Height + 5;
            }
            Label tickets_label2 = new Label();
            tickets_label2.Parent = tickets_container;
            tickets_label2.AutoSize = true;
            tickets_label2.Text = $"Return Flights: {(return_flights.Count == 0 ? "  No Available Flights" : "")}";
            tickets_label2.Font = new Font(this.search_btn.Font.FontFamily, this.search_btn.Font.Size * 1.5f, FontStyle.Bold);
            tickets_label2.ForeColor = Color.Black;
            tickets_label2.Location = new Point(0, top_pos);
            tickets_container.Controls.Add(tickets_label2);
            top_pos = tickets_label2.Bottom + 20;
            foreach (ActiveFlight flight in return_flights)
            {
                Panel ticket = create_ticket(flight);
                ticket.Top = top_pos;
                top_pos += ticket.Height + 5;
            }
        }

        /// <summary>
        /// closes and exists the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void formClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// if the form is not in the minimized state it displays all the controls again with set_components
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Flights_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized) return;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.UpdateStyles();
            set_components();
        }

        private void birth_date_label_Click(object sender, EventArgs e)
        {

        }
        
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        /// <summary>
        /// makes sure that the dates are logically valid all the time 
        /// if the departure date is after the return date it makes the return date be the day after the departure date
        /// keeps updating the days in the month list when ever there is a change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void update_dates(object sender, EventArgs e)
        {

            int selected_day = Day_combobox.SelectedIndex + 1;
            string selected_month = Month_combobox.SelectedItem.ToString();
            int selected_month_index = Month_combobox.SelectedIndex;
            int selected_year = int.Parse(Year_combobox.SelectedItem.ToString());
            List<int> daysList = Enumerable.Range(1, DateTime.DaysInMonth(selected_year, selected_month_index + 1)).ToList();
            this.Day_combobox.DataSource = daysList;
            if (selected_day > daysList.Count)
            {
                this.Day_combobox.SelectedIndex = 0;
                selected_day = 1;
            }
            DateTime departure_date = new DateTime(selected_year, selected_month_index + 1, selected_day);

            
            if (departure_date <= DateTime.Now.AddDays(1))
            {

                departure_date = DateTime.Now.AddDays(1);
                daysList = Enumerable.Range(1, DateTime.DaysInMonth(departure_date.Year, departure_date.Month)).ToList();
                this.Day_combobox.DataSource = daysList;
                this.Day_combobox.SelectedItem = departure_date.Day;
                this.Day_combobox.Focus();
                this.Month_combobox.SelectedIndex = departure_date.Month - 1;
                this.Month_combobox.Focus();
                this.Year_combobox.SelectedItem = departure_date.Year;
                this.Year_combobox.Focus();
                return;
            }
            int selected_day2 = Day2_combobox.SelectedIndex + 1;
            string selected_month2 = Month2_combobox.SelectedItem.ToString();
            int selected_month_index2 = Month2_combobox.SelectedIndex;
            int selected_year2 = int.Parse(Year2_combobox.SelectedItem.ToString());
            List<int> daysList2 = Enumerable.Range(1, DateTime.DaysInMonth(selected_year2, selected_month_index2 + 1)).ToList();
            this.Day2_combobox.DataSource = daysList2;
            if (selected_day2 > daysList2.Count)
            {

                this.Day2_combobox.SelectedIndex = 0;
                selected_day2 = 1;
            }
            DateTime return_date = new DateTime(selected_year2, selected_month_index2 + 1, selected_day2);

            
            if (return_date <= departure_date)
            {

                return_date = departure_date.AddDays(1);
                daysList2 = Enumerable.Range(1, DateTime.DaysInMonth(return_date.Year, return_date.Month)).ToList();
                this.Day2_combobox.DataSource = daysList2;
                this.Day2_combobox.SelectedItem = return_date.Day;
                this.Month2_combobox.SelectedIndex = return_date.Month - 1;
                this.Month2_combobox.Focus();
                this.dummy_btn.Select();
                this.Day2_combobox.SelectedItem = return_date.Day;
                this.Day_combobox.Focus();
                this.Year2_combobox.SelectedItem = return_date.Year;
                this.Year2_combobox.Focus();
                this.Day_combobox.SelectedIndex = selected_day - 1;
                this.dummy_btn.Select();
                return;
            }

            this.Day_combobox.SelectedIndex = selected_day - 1;
            this.Day2_combobox.SelectedIndex = selected_day2 - 1;

        }

       /// <summary>
       /// creates a floating label with the value of the cue and changes the style of the textbox
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private async void textbox_focus(object sender, EventArgs e)
        {
            Krypton.Toolkit.KryptonTextBox textBox = sender as Krypton.Toolkit.KryptonTextBox;
            textBox.CueHint.CueHintText = "";
            textBox.StateActive.Border.Color1 = Color.FromArgb(83, 83, 84);
            textBox.StateActive.Border.Color2 = Color.FromArgb(83, 83, 84);
            textBox.StateActive.Border.Width = 2;
            if (textBox.Text != null && textBox.Text != "")
            {
                return;
            }
            Label label = new Label();

           
            void create_label()
            {
                label.AutoSize = true;
                textBox.Parent.Controls.Add(label);
                label.Text = textBox.Name.Replace("_textbox", "");
                label.ForeColor = Color.FromArgb(83, 83, 84);
                label.BackColor = Color.Transparent;
                label.Font = new Font(textBox.StateCommon.Content.Font.FontFamily, textBox.StateCommon.Content.Font.Size * 0.7f);
                label.Location = new Point(0, (textBox.Parent.Height - label.Height) / 2);
                label.BringToFront();
            }
            create_label();
            await this.move_labels_animation(label, new Point(0, 0));

        }

        /// <summary>
        /// moves the floating label from its current location to the finishing position
        /// </summary>
        /// <param name="label"></param>
        /// <param name="finish_pos"></param>
        /// <returns></returns>
        private async Task move_labels_animation(Label label, Point finish_pos)
        {
            int step_size = 4;
            int num = Math.Abs(label.Top - finish_pos.Y) / step_size + 1;
            if (label.Top < finish_pos.Y)
            {
                step_size = -step_size;
            }
            for (int i = 0; i < num; i++)
            {

                label.Left += step_size;
                label.Top -= step_size;
                await Task.Delay(5);
            }

        }

        /// <summary>
        /// deletes the floating label and changes the style of the textbox back to normal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void textbox_leave(object sender, EventArgs e)
        {
            Krypton.Toolkit.KryptonTextBox textBox = sender as Krypton.Toolkit.KryptonTextBox;
            textBox.CueHint.CueHintText = textBox.Name.Replace("_textbox", "");
            textBox.CueHint.Color1 = Color.White;
            textBox.StateNormal.Border.Color1 = Color.Silver;
            textBox.StateNormal.Border.Color2 = Color.Silver;
            textBox.StateActive.Border.Color1 = Color.Silver;
            textBox.StateActive.Border.Color2 = Color.Silver;
            textBox.StateActive.Border.Width = -1;
            Label label = textBox.Parent.Controls.OfType<Label>().FirstOrDefault();
            if (textBox.Text == "" || textBox.Text == null)
            {
                await this.move_labels_animation(label, new Point(0, (textBox.Height - label.Height) / 2));
                textBox.Parent.Controls.Remove(label);
                textBox.CueHint.Color1 = Color.Gray;
                label.Dispose();
            }
        }
        /// <summary>
        /// calls the UI.set_profile_picture function to display the profile picture
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Flights_Shown(object sender, EventArgs e)
        {
            Dictionary<string, Control> controls_dict = new Dictionary<string, Control>();
            UI.registerControls(this.Controls, controls_dict);
            await UI.set_profile_picture(controls_dict);
        }

        /// <summary>
        /// calls the UI.logout function to disconnect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void logout_btn_Click(object sender, EventArgs e)
        {
            UI.logout(this);
        }

        /// <summary>
        /// sends all the search data to the server if it is valid
        /// takes the response and displays the results with set_tickets
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void search_btn_Click(object sender, EventArgs e)
        {
            if (this.validate())
            {
                if (ConnectionManager.tcp_client == null) return;

                Data.FlightSearchData data = new Data.FlightSearchData(
                    this.From_textbox.Text,
                    this.To_textbox.Text,
                    new DateTime(int.Parse(Year_combobox.Text), Month_combobox.SelectedIndex + 1, int.Parse(Day_combobox.Text)),
                    new DateTime(int.Parse(Year2_combobox.Text), Month2_combobox.SelectedIndex + 1, int.Parse(Day2_combobox.Text)),
                    this.passengers_combobox.SelectedIndex + 1,
                    this.class_combobox.SelectedItem.ToString()
                    );
                try
                {
                    ConnectionManager.security.writeEncrypted($"{all_messages.SEARCH.ToString()}{JsonSerializer.Serialize(data)}");

                    UI.startThread(new Action(() =>
                    {
                        string message = ConnectionManager.security.readEncrypted();
                        if (message.StartsWith(all_messages.SUCCESSFULL.ToString()))
                        {
                            message = message.Substring(all_messages.SUCCESSFULL.ToString().Length);

                            List<ActiveFlight> departure_flights = JsonSerializer.Deserialize<List<ActiveFlight>>(message.Split('|')[0]);
                            List<ActiveFlight> return_flights = JsonSerializer.Deserialize<List<ActiveFlight>>(message.Split('|')[1]);

                            this.Invoke(new Action(() => set_tickets(departure_flights, return_flights)));
                        }
                        else
                        {
                        }

                    }));
                }
                catch
                {
                    UI.server_disconnect(Flights_background);
                }
                
            }
        }
        /// <summary>
        /// makes sure the values in the From and To fields are valid and exist as real adresses
        /// as well as the other values in the form
        /// </summary>
        /// <returns></returns>
        private bool validate()
        {
            bool valid = true;

            void setError(Label label, string error)
            {
                Krypton.Toolkit.KryptonTextBox textbox = label.Parent.Controls.OfType<Krypton.Toolkit.KryptonTextBox>().FirstOrDefault();
                label.Text = $"{textbox.Name.Replace("_textbox", "")} - {error}";
                label.ForeColor = Color.Red;

                textbox.StateNormal.Border.Color1 = Color.Red;
                textbox.StateNormal.Border.Color2 = Color.Red;
                textbox.StateActive.Border.Color1 = Color.Red;
                textbox.StateActive.Border.Color2 = Color.Red;
            }

            this.From_textbox.StateNormal.Border.Color1 = Color.Silver;
            this.From_textbox.StateNormal.Border.Color2 = Color.Silver;
            this.From_textbox.StateActive.Border.Color1 = Color.Silver;
            this.From_textbox.StateActive.Border.Color2 = Color.Silver;
            this.To_textbox.StateNormal.Border.Color1 = Color.Silver;
            this.To_textbox.StateNormal.Border.Color2 = Color.Silver;
            this.To_textbox.StateActive.Border.Color1 = Color.Silver;
            this.To_textbox.StateActive.Border.Color2 = Color.Silver;

            Label from_label = this.From_textbox.Parent.Controls.OfType<Label>().FirstOrDefault();
            Label to_label = this.To_textbox.Parent.Controls.OfType<Label>().FirstOrDefault();

            if (string.IsNullOrWhiteSpace(this.From_textbox.Text))
            {
                valid = false;
                this.From_textbox.StateNormal.Border.Color1 = Color.Red;
                this.From_textbox.StateNormal.Border.Color2 = Color.Red;
                this.From_textbox.StateActive.Border.Color1 = Color.Red;
                this.From_textbox.StateActive.Border.Color2 = Color.Red;
            }
            else
            {
                from_label.Text = "From";
                from_label.ForeColor = Color.FromArgb(83, 83, 84);

                List<Data.City> citysList = Data.getWorldCities();
                List<string> addresses = new List<string>();
                foreach (Data.City city in citysList)
                {
                    if (city.city != "" && city.country != "")
                        addresses.Add($"{city.city}, {city.country}");
                }
                if (!addresses.Contains(this.From_textbox.Text.Trim()))
                {
                    valid = false;
                    setError(from_label, "Invalid Address");
                }
            }

            if (string.IsNullOrWhiteSpace(this.To_textbox.Text))
            {
                valid = false;
                this.To_textbox.StateNormal.Border.Color1 = Color.Red;
                this.To_textbox.StateNormal.Border.Color2 = Color.Red;
                this.To_textbox.StateActive.Border.Color1 = Color.Red;
                this.To_textbox.StateActive.Border.Color2 = Color.Red;
            }
            else
            {
                to_label.Text = "To";
                to_label.ForeColor = Color.FromArgb(83, 83, 84);

                List<Data.City> citysList = Data.getWorldCities();
                List<string> addresses = new List<string>();
                foreach (Data.City city in citysList)
                {
                    if (city.city != "" && city.country != "")
                        addresses.Add($"{city.city}, {city.country}");
                }
                if (!addresses.Contains(this.To_textbox.Text.Trim()))
                {
                    valid = false;
                    setError(to_label, "Invalid Address");
                }
            }

            if (this.From_textbox.Text.Equals(this.To_textbox.Text) && !string.IsNullOrWhiteSpace(this.From_textbox.Text))
            {
                setError(to_label, "The Origin And Destination Must Be Different");
                setError(from_label, "The Origin And Destination Must Be Different");
                valid = false;
            }

            return valid;
        }
        /// <summary>
        /// displays the visual map of the plane seats
        /// changes the color of each seat based on the availability
        /// and adds a click event to each seat
        /// </summary>
        /// <param name="flight"></param>
        private void set_plane_cabin(ActiveFlight flight)
        {
            foreach (Control c in plane_panel.Controls)
            {
                c.Show();
            }
            payment_form.Hide();
            foreach (Control c in cabin.Controls.Cast<Control>().ToList())
            {
                c.Dispose();
                cabin.Controls.Remove(c);
            }
            this.dummy_btn.Focus();
            this.dummy_btn.Select();
            this.plane_panel.Visible = true;
            this.book_flight_btn.Visible = false;
            this.payment_form.Visible=false;
            Panel[] containers = this.payment_container.Controls.OfType<Panel>().ToArray();
            for (int i = 0; i < containers.Length; i++)
            {
                Krypton.Toolkit.KryptonTextBox textbox = containers[i].Controls.OfType<Krypton.Toolkit.KryptonTextBox>().FirstOrDefault();
                if (textbox != null)
                {
                    textbox.Text = "";
                }
                containers[i].Visible = true;
            }
            int seats_per_row = flight.seats_per_row;
            int first_class_rows = flight.first_class_rows;
            int buissness_class_rows = flight.buissness_class_rows;
            int economy_class_rows = flight.economy_class_rows;
            int total_rows = first_class_rows+buissness_class_rows+economy_class_rows;
            int space_between_classes = 15;
            int space_between_seats = 5;
            int hallway_space = 10;
            int left_pos = cabin.Height/2+20;
            int top_pos = 0;
            int cabin_width = cabin.Width - cabin.Height;
            int seat_width = (cabin_width - total_rows * space_between_seats - 2 * space_between_classes) / total_rows;
            string chosen_class = class_combobox.SelectedValue.ToString();
            string current_class = "Economy";
            Font font = new Font(log_in_btn_nav.Font.FontFamily, log_in_btn_nav.Font.Size * 0.8f);
            int seat_height = (UI.calculate_size(cabin.Height, 0.85)-space_between_seats*seats_per_row)/seats_per_row;
            List <Seat>selected_seats = new List <Seat>();
            for (int row = total_rows; row >= 1; row--)
            {
                Label row_label = new Label();
                
                row_label.AutoSize = true;
                row_label.Text = row.ToString();
                row_label.Font = font;
                row_label.ForeColor = Color.Gray;
                row_label.Left = left_pos;
                row_label.Top = top_pos;
                cabin.Controls.Add(row_label);
                top_pos += row_label.Height+space_between_seats;
                //creates a visual seat based on the position and flight class
                void create_seat(int j,int i,string flight_class)
                {
                    Button seat = new Button();
                    seat.Font = font;
                    seat.FlatStyle = FlatStyle.Flat;
                    seat.FlatAppearance.BorderSize = 0;
                    seat.ForeColor = Color.White;
                    seat.Text = ((char)('A' + j)).ToString();
                    seat.TextAlign = ContentAlignment.MiddleCenter;
                    seat.Height = seat_height;
                    seat.Width = seat_width;
                    seat.Left = left_pos;
                    seat.Top = top_pos;
                    if (current_class != chosen_class || flight.seats.Values.SelectMany(list=>list).ElementAt(row-1)[j] == true)
                    {
                        //not available
                        seat.BackColor = Color.FromArgb(83, 84, 84);
                        seat.ForeColor = Color.White;
                        seat.Enabled = false;

                    }
                    else
                    {
                        //available
                        seat.BackColor = Color.Green;
                        seat.Cursor = System.Windows.Forms.Cursors.Hand;
                    }
                    ///checks if the seat is already selected
                    ///if it is then it de-selects it and removes from the list
                    ///otherwise it gets added to the list
                    ///if the amount of selected seats matches the number of passengers selected then the book flight button appears
                    seat.Click += (sender, e) => {
                        if (!payment_container.Visible)
                        {
                            if (selected_seats.Count < passengers_combobox.SelectedIndex + 1)
                            {
                                if (!selected_seats.Any(s => s.row == i - 1 && s.column == j))
                                {
                                    seat.BackColor = Color.FromArgb(255, 205, 17);
                                    selected_seats.Add(new Seat(i - 1, j, flight_class));
                                }
                                else
                                {
                                    Seat seat1 = null;
                                    this.book_flight_btn.Visible = false;
                                    seat.BackColor = Color.Green;
                                    foreach (Seat s in selected_seats)
                                    {
                                        if (s.row == i - 1 && s.column == j)
                                        {
                                            seat1 = s;
                                        }
                                    }
                                    selected_seats.Remove(seat1);
                                }
                                if (selected_seats.Count == passengers_combobox.SelectedIndex + 1)
                                {
                                    this.ordered_flight = flight;
                                    this.current_booked_seats = selected_seats;
                                    this.book_flight_btn.Visible = true;
                                    
                                    
                                }
                            }
                            else if (seat.BackColor != Color.Green)
                            {
                                Seat seat1 = null;
                                this.book_flight_btn.Visible = false;
                                seat.BackColor = Color.Green;
                                foreach (Seat s in selected_seats)
                                {
                                    if (s.row == i - 1 && s.column == j)
                                    {
                                        seat1 = s;
                                    }
                                }
                                selected_seats.Remove(seat1);
                            }
                        }
                        

                    };
                    cabin.Controls.Add(seat);
                    top_pos += seat.Height + space_between_seats;
                }
                //first part, before the hallway
                for(int j=0; j < seats_per_row/2; j++)
                {
                    create_seat(j,row,current_class);
                }
                top_pos += hallway_space;
                //second part, after the hallway
                for (int j = seats_per_row/2; j < seats_per_row; j++)
                {
                    create_seat(j,row,current_class);
                }
                left_pos += seat_width+space_between_seats;
                top_pos = 0;
                if(row-1==total_rows-economy_class_rows)
                {
                    current_class = "Buissnes";
                    left_pos += space_between_classes;
                }
                if (row-1 == total_rows - economy_class_rows -buissness_class_rows)
                {
                    current_class = "First";
                    left_pos += space_between_classes;
                }
            }
            

        }
        /// <summary>
        /// hides the map of the plane
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exit_plane_btn_Click(object sender, EventArgs e)
        {
            this.plane_panel.Visible = false;
        }
        /// <summary>
        /// displays the form of names and payment information
        /// </summary>
        /// <param name="flight"></param>
        /// <param name="selected_seats"></param>
        private void complete_booking(ActiveFlight flight, List<Seat> selected_seats)
        {
            foreach (Control c in plane_panel.Controls)
            {
                c.Hide();
            }
            this.payment_form.Visible = true;
            this.exit_plane_btn.Visible = true;
            this.price_label.Text = (flight.price * (class_combobox.SelectedIndex + 1) * (passengers_combobox.SelectedIndex+1)).ToString() + "$"; ;
            Panel[] containers = this.payment_container.Controls.OfType<Panel>().ToArray();
            if (this.passengers_combobox.SelectedIndex == 0)
            {
                this.price_label.ForeColor = Color.Black;
                this.payment_label.Text = "Enter Payment Details";
                
                for (int i = 0; i < containers.Length; i++)
                {
                    if (i < 3)
                    {
                        containers[i].Visible = true;
                        containers[i].Top -= containers[2].Top;
                    }
                    else
                    {
                        containers[i].Visible = false;

                    }
                }
                //payment_btn_click(flight,selected_seats);
                this.payment_btn.Text = "Pay Now";
            }
            else
            {
                this.price_label.ForeColor = this.payment_form.BackColor;
                this.payment_btn.Text = "Proceed To Payment";
                this.payment_label.Text = "Enter Passangers Names";
                for (int i = 0; i < containers.Length - this.passengers_combobox.SelectedIndex; i++)
                {
                    containers[i].Visible = false;
                }
            }
            
            
        }
        /// <summary>
        /// checks that all the names of the other passengers are valid
        /// checks that the payment information is valid
        /// if they are valid it sends the flight and the selected seats to the server to book the flight
        /// </summary>
        /// <param name="flight"></param>
        /// <param name="selected_seats"></param>
        private async Task payment_btn_click(ActiveFlight flight,List<Seat>selected_seats)
        {
            List<string>names = new List<string>();
            names.Add(this.name_label.Text.Replace("Hello ","").Replace("!",""));
            void setError(Label label, string error)
            {
                Krypton.Toolkit.KryptonTextBox textbox = label.Parent.Controls.OfType<Krypton.Toolkit.KryptonTextBox>().FirstOrDefault();
                label.Text = $"{textbox.Name.Replace("_textbox", "")} - {error}";
                label.ForeColor = Color.Red;

                textbox.StateNormal.Border.Color1 = Color.Red;
                textbox.StateNormal.Border.Color2 = Color.Red;
                textbox.StateActive.Border.Color1 = Color.Red;
                textbox.StateActive.Border.Color2 = Color.Red;
            }
            bool isValid = true;
            void validate()
            {
                List<Panel> containers = this.payment_container.Controls.OfType<Panel>().ToList();
                foreach (Panel container in containers)
                {
                    if (container.Visible)
                    {
                        Krypton.Toolkit.KryptonTextBox textbox = container.Controls.OfType<Krypton.Toolkit.KryptonTextBox>().FirstOrDefault();
                        if(textbox != null)
                        {
                            textbox.StateNormal.Border.Color1 = Color.Silver;
                            textbox.StateNormal.Border.Color2 = Color.Silver;
                            textbox.StateActive.Border.Color1 = Color.Silver;
                            textbox.StateActive.Border.Color2 = Color.Silver;
                            if (string.IsNullOrWhiteSpace(textbox.Text))
                            {
                                isValid = false;
                                textbox.StateNormal.Border.Color1 = Color.Red;
                                textbox.StateNormal.Border.Color2 = Color.Red;
                                textbox.StateActive.Border.Color1 = Color.Red;
                                textbox.StateActive.Border.Color2 = Color.Red;
                            }
                            else
                            {
                                Label label = container.Controls.OfType<Label>().FirstOrDefault();
                                string pattern = "";
                                string name = "";
                                if (textbox.Name.Contains("CVV"))
                                {
                                    pattern = @"^\d{3}$";
                                    name = "CVV";
                                }
                                if (textbox.Name.Contains("Number"))
                                {
                                    pattern = @"^\d{16}$";
                                    name = "Credit Card Number";
                                }
                                if (textbox.Name.Contains("Name"))
                                {
                                    pattern = @"^[A-Za-z]{2,} [A-Za-z]{2,}$";
                                    name = "Name";
                                }

                                if (!Regex.IsMatch(textbox.Text.Trim(), pattern))
                                {
                                    string error = $"Invalid {name}";
                                    setError(label, error);
                                    isValid = false;
                                }
                                else
                                {
                                    label.Text = textbox.Name.Replace("_textbox", "");
                                    label.ForeColor = Color.FromArgb(83, 83, 84);
                                }

                            }
                        }
                        
                    }

                }

            }
            if (payment_btn.Text.Contains("Proceed"))
            {
                validate();
                if (isValid)
                {
                    this.payment_btn.Text = "Pay Now";
                    this.payment_label.Text = "Enter Credit Card Details";
                    this.price_label.ForeColor = Color.Black;
                    Panel[] containers = this.payment_container.Controls.OfType<Panel>().ToArray();
                    for (int i = 0; i < containers.Length; i++)
                    {
                        if (i < 3)
                        {
                            containers[i].Visible = true;
                            containers[i].Top -= containers[2].Top;
                        }
                        else
                        {
                            containers[i].Visible = false;

                        }
                    }
                }
            }
            else
            {
                
                isValid = true;
                validate();
                if (isValid)
                {
                    Panel[] containers = this.payment_container.Controls.OfType<Panel>().ToArray();
                    for (int i = containers.Length-selected_seats.Count+1; i < containers.Length; i++)
                    {
                        
                            Krypton.Toolkit.KryptonTextBox textbox = containers[i].Controls.OfType<Krypton.Toolkit.KryptonTextBox>().FirstOrDefault();
                            
                            names.Add(textbox.Text);
                        
                        
                    }
                    for (int i = 0; i < selected_seats.Count; i++)
                    {
                        selected_seats[i]=new Seat(selected_seats[i].row, selected_seats[i].column, selected_seats[i].flight_class, names[i]);
                    }
                    
                    try
                    {
                        ConnectionManager.security.writeEncrypted($"{all_messages.BOOK.ToString()}{JsonSerializer.Serialize(flight)}|{JsonSerializer.Serialize(selected_seats)}");
                        string msg_text = "";
                        bool positive = true;
                        UI.startThread(new Action(() =>
                        {
                            string message = ConnectionManager.security.readEncrypted();
                            
                            if (message.StartsWith(all_messages.SUCCESSFULL.ToString()))
                            {

                                msg_text = "Order Completed Successfuly!";
                            }
                            else
                            {
                                if (message.Contains(all_messages.BOOK.ToString()))
                                {
                                    msg_text = "Flight Already Booked";
                                    positive = false;
                                }
                                else
                                {
                                    if (message.StartsWith(all_messages.EXISTS.ToString()))
                                    {
                                        msg_text = "Seats Are No More Unavailable";
                                        positive = false;
                                    }
                                    else
                                    {
                                        msg_text = "Something Went Wrong...";
                                        positive = false;
                                    }
                                }
                            }

                            
                        }));
                        while (msg_text.Equals(""))
                        {
                            await Task.Delay(5);
                        }
                        await UI.show_message(plane_panel.Parent, msg_text, positive, 3000);
                        this.payment_form.Visible = false;
                        this.plane_panel.Visible = false;
                        
                    }
                    catch {
                        UI.server_disconnect(Flights_background);
                    }
                }
            }
        }
        /// <summary>
        /// on every change of the date makes sure that the date is not before todays date
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void update_payment_dates(object sender, EventArgs e)
        {        
            int selected_month = payment_month.SelectedIndex+1;
            int selected_year = int.Parse(payment_year.SelectedItem.ToString());
            DateTime expire_date = new DateTime(selected_year, selected_month, 1);
            if (expire_date < DateTime.Now)
            {
                expire_date = DateTime.Now.AddDays(1);
                
                this.payment_month.SelectedIndex = expire_date.Month;
                this.payment_month.Focus();
                this.payment_year.SelectedItem = expire_date.Year;
                this.payment_year.Focus();
                this.dummy_btn.Focus();

                return;
            }
        }

        private void book_flight_btn_Click(object sender, EventArgs e)
        {
            complete_booking(this.ordered_flight,this.current_booked_seats);
        }

        private async void payment_btn_Click(object sender, EventArgs e)
        {
            await payment_btn_click(this.ordered_flight, this.current_booked_seats);
        }
    }
}
