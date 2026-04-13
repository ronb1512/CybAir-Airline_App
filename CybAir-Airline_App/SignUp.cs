using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Text.RegularExpressions;
using CsvHelper;
using System.Net.Sockets;
using System.IO;
using System.Text.Json;
using System.Net.Http;
using System.Net.NetworkInformation;
namespace CybAir_Airline_App
{
    public partial class SignUp : Form
    {
        /// <summary>
        /// the constructor sets the rendering options
        /// </summary>
        public SignUp()
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
        private void SignUp_Load(object sender, EventArgs e)
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
            this.signup_background.Size = new Size(this.ClientSize.Width, this.ClientSize.Height);
            this.navbar_panel.Top = 0;
            this.navbar_panel.Width = this.ClientSize.Width;
            int screen_width = Screen.PrimaryScreen.WorkingArea.Width;
            int smaller_size = Math.Min(UI.calculate_size(this.ClientSize.Width, 0.4), UI.calculate_size(screen_width, 0.2));

            void signup_form_setup()
            {
                this.signup_form.Width = smaller_size;
                this.signup_form.Height = UI.calculate_size(smaller_size, 1.25);
                this.signup_form.Padding = new System.Windows.Forms.Padding(25);
                UI.RoundCorners(this.signup_form, 10, Color.White, 1);
                this.part1_signup.Size = this.signup_form.Size;
                this.part2_signup.Size = this.signup_form.Size;
                if (this.signup_btn.Text == "Next")
                {
                    this.part1_signup.Location = new Point(0, 0);
                    this.part2_signup.Location = new Point(this.part1_signup.Width, 0);
                }
                else
                {
                    this.part2_signup.Location = new Point(0, 0);
                    this.part1_signup.Location = new Point(-this.part1_signup.Width, 0);
                }
                
                //this.part2_signup.Location = new Point(0, 0);
            }
            void signup_btn_setup()
            {
                this.signup_btn.Width = this.signup_form.Width - 2 * this.signup_form.Padding.Left;
                this.signup_btn.Font = new Font(this.signup_btn.Font.FontFamily, UI.calculate_size(smaller_size, 0.015 * 2.5));
                int textHeight = TextRenderer.MeasureText(this.signup_btn.Text, this.signup_btn.Font).Height;
                this.signup_btn.Height = textHeight + 20;
                UI.RoundCorners(this.signup_btn, 40, Color.White, 1);
                this.signup_btn.Left = this.signup_form.Padding.Left;
                this.signup_btn.BringToFront();
            }
            void signup_header_setup()
            {
                this.signup_header.Font = new Font(this.signup_header.Font.FontFamily, UI.calculate_size(smaller_size, 0.018 * 2.5));
                UI.RoundCorners(this.signup_header, 20, Color.White, 1);
                this.signup_header.Location = new Point((this.signup_form.Width - this.signup_header.Width) / 2, -10);
                this.signup_header.BringToFront();
            }
            int top_pos = this.signup_header.Bottom + UI.calculate_size(this.signup_form.Height, 0.1);
            void textBoxes_setup(Panel p)
            {
                Panel[] all_textbox_containers = p.Controls.OfType<Panel>().ToArray();
                Array.Reverse(all_textbox_containers);
                foreach (Panel container in all_textbox_containers)
                {
                    container.Left = this.signup_form.Padding.Left;
                    container.Top = top_pos;

                    //textbox setup
                    Krypton.Toolkit.KryptonTextBox textbox = container.Controls.OfType<Krypton.Toolkit.KryptonTextBox>().FirstOrDefault();
                    textbox.Width = this.signup_btn.Width;
                    textbox.StateCommon.Content.Font = new Font(this.signup_btn.Font.FontFamily, this.signup_btn.Font.Size);
                    textbox.StateActive.Content.Font = new Font(this.signup_btn.Font.FontFamily, this.signup_btn.Font.Size);
                    textbox.CueHint.Font = new Font(this.signup_btn.Font.FontFamily, this.signup_btn.Font.Size);
                    textbox.Height = TextRenderer.MeasureText(textbox.Text, this.signup_btn.Font).Height;
                    //icon setup
                    IconPictureBox icon = container.Controls.OfType<IconPictureBox>().FirstOrDefault();
                    icon.IconSize = textbox.Height - 4;
                    icon.Location = new Point(this.signup_form.Padding.Left + textbox.Width - UI.calculate_size(icon.IconSize, 1.5), (container.Height - icon.Height) / 2);
                    icon.BackColor = Color.Transparent;

                    top_pos += textbox.Height + UI.calculate_size(this.signup_form.Height, 0.05);

                }
            }
            void has_account_setup()
            {

                this.has_account_label.Font = new Font(this.has_account_label.Font.FontFamily, UI.calculate_size(smaller_size, 0.012 * 2.5));
                this.has_account_btn.Font = new Font(this.has_account_label.Font.FontFamily, UI.calculate_size(smaller_size, 0.012 * 2.5), FontStyle.Bold);
                this.has_account_label.Left = (this.signup_form.Width - this.has_account_label.Width - this.has_account_btn.Width) / 2;
                this.has_account_btn.Left = this.has_account_label.Left + this.has_account_label.Width;
                this.has_account_btn.MouseHover += UI.nav_buttons_hover;
                this.has_account_btn.MouseLeave += UI.nav_buttons_stop_hover;
                this.has_account_label.Top = top_pos;
                int textHeight = TextRenderer.MeasureText(this.has_account_btn.Text, this.has_account_btn.Font).Height;
                this.has_account_btn.Top = this.has_account_label.Top - (this.has_account_btn.Height - textHeight) / 2;
                this.has_account_btn.BringToFront();
                this.has_account_label.BringToFront();
            }
            
            
            signup_form_setup();
            signup_btn_setup();
            signup_header_setup();
            textBoxes_setup(this.part1_signup);
            this.Password_textbox.PasswordChar = '●';
            top_pos += UI.calculate_size(this.signup_form.Height, 0.1);
            this.signup_btn.Top = top_pos;
            top_pos += this.signup_btn.Height + UI.calculate_size(this.signup_form.Height, 0.05);
            has_account_setup();
            this.signup_form.Location = new Point((this.ClientSize.Width - this.signup_form.Width) / 2, (this.ClientSize.Height - this.signup_form.Height) / 2);

            top_pos = this.signup_header.Bottom + UI.calculate_size(this.signup_form.Height, 0.07);
            void set_part2_signup()
            {
                int left_pos = this.signup_btn.Left;
                void set_birth_date()
                {
                    this.birth_date_label.Location = new Point(left_pos, top_pos);
                    this.birth_date_label.Font = new Font(this.birth_date_label.Font.FontFamily, this.signup_btn.Font.Size);
                    top_pos += this.birth_date_label.Height;

                    //day setup
                    this.Day_combobox.Location = new Point(left_pos, top_pos);
                    this.Day_combobox.Width = (this.part2_signup.Width - 2 * left_pos) / 3 - 15;
                    List<int> daysList = Enumerable.Range(1, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)).ToList();
                    this.Day_combobox.DataSource = daysList;
                    this.Day_combobox.SelectedItem = DateTime.Now.AddDays(-1).Day;

                    //month setup
                    this.Month_combobox.Location = new Point(left_pos + this.Day_combobox.Width + 5, top_pos);
                    this.Month_combobox.Width = this.Day_combobox.Width + 30;
                    string[] monthsList = new CultureInfo("en-US").DateTimeFormat.MonthNames.Where(m => !string.IsNullOrEmpty(m)).ToArray();
                    this.Month_combobox.DataSource = monthsList;
                    this.Month_combobox.SelectedItem = monthsList[DateTime.Now.AddDays(-1).Month - 1];

                    //year setup
                    this.Year_combobox.Location = new Point(this.Month_combobox.Left + this.Month_combobox.Width + 5, top_pos);
                    this.Year_combobox.Width = this.Day_combobox.Width;
                    List<int> yearsList = Enumerable.Range(DateTime.Now.Year - 150, 151).Reverse().ToList();
                    this.Year_combobox.DataSource = yearsList;
                    this.Year_combobox.SelectedItem = DateTime.Now.AddDays(-1).Year;
                }

                set_birth_date();
                top_pos += UI.calculate_size(this.signup_form.Height, 0.1);
                textBoxes_setup(this.part2_signup);
                List<Data.City> citysList = Data.getWorldCities();
                List<string>addresses = new List<string>();
                foreach (Data.City city in citysList)
                {
                    if(city.city!="" && city.country !="")
                    addresses.Add($"{city.city}, {city.country}");
                    
                }
                this.Address_textbox.AutoCompleteMode = AutoCompleteMode.Suggest;
                this.Address_textbox.AutoCompleteSource= AutoCompleteSource.CustomSource;
                this.Address_textbox.AutoCompleteCustomSource.AddRange(addresses.ToArray());
                this.profile_picture_label.Font = this.birth_date_label.Font;
                this.profile_picture_label.Location = new Point((this.part2_signup.Width - this.profile_picture_label.Width) / 2, top_pos);
                top_pos += this.profile_picture_label.Height;
                this.profile_picture.Height = UI.calculate_size(this.part2_signup.Height,0.2);
                this.profile_picture.Width = this.profile_picture.Height;
                this.profile_picture.Location = new Point((this.part2_signup.Width - this.profile_picture.Width)/2,top_pos);
                this.profile_picture.IconSize = UI.calculate_size(profile_picture.Height,0.8);
                UI.RoundCorners(this.profile_picture, this.profile_picture.Height, Color.White, 1);
            }

            set_part2_signup();
            this.error_label.Font = log_in_btn_nav.Font;
            this.error_label.Location = new Point((this.ClientSize.Width - this.error_label.Width) / 2, signup_form.Bottom + UI.calculate_size(this.ClientSize.Height,0.02));
            this.error_label.Visible = false;
            UI.RoundCorners(error_label,10,Color.White,1);
            Font btn_font = new Font(this.signup_btn.Font.FontFamily, UI.calculate_size(this.ClientSize.Width, 0.013));
            
            if (btn_font.Size > 15f)
            {
                btn_font = new Font(this.signup_btn.Font.FontFamily, 15f);
            }

            this.logout_btn.Top = this.navbar_panel.Bottom;
            this.logout_btn.Left = this.ClientSize.Width - this.logout_btn.Width - 30;
            this.logout_btn.IconSize = this.logout_btn.Font.Height;
            this.logout_btn.Font = btn_font;
            this.logout_btn.BringToFront();
            UI.set_navbar(this.navbar_panel, this.ClientSize, btn_font);

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
        /// if the form is not in the minimized state it displays all the controls again with set_components
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SignUp_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized) return;
            this.set_components();
        }
        /// <summary>
        /// toggles the mode of text from passward to regular and backwards
        /// toggles the icon of lock to eye and backwards
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void password_icon_Click(object sender, EventArgs e)
        {
            this.password_icon.IconChar = this.Password_textbox.PasswordChar == '\0' ? IconChar.Lock : IconChar.Eye;
            this.Password_textbox.PasswordChar = this.Password_textbox.PasswordChar == '\0' ? '●' : '\0';
        }
        /// <summary>
        /// makes sure that the date is always logically correct
        /// updates the days list to match the month and the year
        /// doesnt allow the date chosen to be after todays date
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void update_dates(object sender, EventArgs e)
        {
            
            int selected_day = Day_combobox.SelectedIndex+1;
            string selected_month = Month_combobox.SelectedItem.ToString();
            int selected_month_index = Month_combobox.SelectedIndex;
            int selected_year = int.Parse(Year_combobox.SelectedItem.ToString());
            List<int> daysList = Enumerable.Range(1, DateTime.DaysInMonth(selected_year, selected_month_index+1)).ToList();
            this.Day_combobox.DataSource = daysList;
            if (selected_day > daysList.Count)
            {
                this.Day_combobox.SelectedIndex = 0;
                return;
            }
            DateTime birth_date = new DateTime(selected_year, selected_month_index + 1, selected_day);
            if(birth_date > DateTime.Now)
            {
                birth_date = DateTime.Now.AddDays(-1);
                daysList = Enumerable.Range(1, DateTime.DaysInMonth(birth_date.Year, birth_date.Month)).ToList();
                this.Day_combobox.DataSource = daysList;
                this.Day_combobox.Focus();
                this.Day_combobox.SelectedItem = birth_date.Day;
                this.Month_combobox.SelectedIndex = birth_date.Month - 1;
                this.Month_combobox.Focus();
                this.Year_combobox.SelectedItem = birth_date.Year;
                this.Year_combobox.Focus();
                this.dummy_btn.Focus();

                return;
            }
            this.Day_combobox.SelectedIndex = selected_day - 1;


        }
        
        private void signup_form_Paint(object sender, PaintEventArgs e)
        {

        }
        /// <summary>
        /// allows the user to pick an image from their file browser as their profile picture
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void profile_picture_Click(object sender, EventArgs e)
        {
            if (this.profile_picture.BackgroundImage != null)
            {
                this.profile_picture.BackgroundImage = null;
                this.profile_picture.IconChar = IconChar.UserAlt;
                return;
            }
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select Profile Picture";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png";  
                openFileDialog.FilterIndex = 1;  

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.profile_picture.IconChar = IconChar.None;
                    this.profile_picture.BackgroundImage = Image.FromFile(openFileDialog.FileName);
                }
            }
        }
        /// <summary>
        /// checks that all the data entered by the user is valid with validate_part1 and validate_part2
        /// if the data is valid it initializes the ConnectionManager class with a new TCP connection
        /// sends the data to the server
        /// recieves response and logs in if positive otherwise shows message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void signup_btn_Click(object sender, EventArgs e)
        {

            if (this.signup_btn.Text.Equals("Next") && this.validate_part1())
            {
                this.part2_signup.Left = 0;
                this.part1_signup.Left = -part1_signup.Width;
                this.signup_btn.Text = "Register";
                return;
            }
            if (this.signup_btn.Text.Equals("Register") && this.validate_part2())
            {
                this.error_label.Visible = false;
                string name = this.Name_textbox.Text;
                string email = this.Email_textbox.Text;
                string password = this.Password_textbox.Text;
                DateTime birth_date = new DateTime((int)Year_combobox.SelectedItem, Month_combobox.SelectedIndex + 1, (int)Day_combobox.SelectedItem);
                string address = this.Address_textbox.Text;
                byte[] picture_bytes = convert_image(this.profile_picture);
                Data.User user = new Data.User(name, email, password, birth_date, address, picture_bytes);
                
                //sends the message to the server
                void send_message()
                {
                    
                    if (ConnectionManager.tcp_client == null)
                    {
                        
                        ConnectionManager.tcp_client = new TcpClient(ConnectionManager.server_ip, Server.port);
                        ConnectionManager.tcp_client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
                        ConnectionManager.tcp_stream = ConnectionManager.tcp_client.GetStream();
                        (ConnectionManager.reader, ConnectionManager.writer) = ConnectionManager.get_reader_writer(ConnectionManager.tcp_client);
                       
                    }
                    ConnectionManager.security.writeEncrypted($"{all_messages.SIGNUP}{JsonSerializer.Serialize(user)}");
                    try
                    {
                        recieveAnswer();
                    }
                    catch {
                        throw;
                    }

                }
                try
                {
                    send_message();
                }
                catch
                {
                    this.part1_signup.Left = 0;
                    this.part2_signup.Left = part1_signup.Width;
                    this.signup_btn.Text = "Next";
                    ConnectionManager.log_out();
                    this.error_label.Text = "Unable To Register";
                    this.error_label.Visible = true;
                    this.error_label.Left = (this.ClientSize.Width - error_label.Width) / 2;
                }
                
                //recieves the message from the server
                void recieveAnswer()
                {
                    string messege = "";

                    messege = ConnectionManager.security.readEncrypted();

                    if (messege.Equals(all_messages.SUCCESSFULL.ToString()))
                    {
                        this.Hide();
                        new Home().Show();

                    }
                    else
                    {
                        
                       this.part1_signup.Left = 0;
                       this.part2_signup.Left = part1_signup.Width;
                       this.signup_btn.Text = "Next";
                        ConnectionManager.log_out();
                        if (messege.Equals(all_messages.EXISTS.ToString()))
                        {
                            this.error_label.Text = "User Already Exists";
                            this.error_label.Visible = true;
                            this.error_label.Left = (this.ClientSize.Width - error_label.Width) / 2;
                        }
                        if (messege.Equals(all_messages.FAILED.ToString()))
                        {
                            this.error_label.Text = "Unable To Register";
                            this.error_label.Visible = true;
                            this.error_label.Left = (this.ClientSize.Width - error_label.Width) / 2;

                        }


                    }
                }

                return;
            }

        }
        /// <summary>
        /// gets an image and turns it into Base64 bytes so that it can be sent over the network
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        private byte[] convert_image(Control control)
        {
            if (control.BackgroundImage != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    control.BackgroundImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] imageBytes = ms.ToArray();
                    return imageBytes;
                }
            }
            return null;
        }
        /// <summary>
        /// returns true if the name, email, and password are all valid otherwise returns false
        /// </summary>
        /// <returns></returns>
        private bool validate_part1() {
            bool isValid = true;
            Krypton.Toolkit.KryptonTextBox[] textboxes = {this.Email_textbox,this.Password_textbox,this.Name_textbox };
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
            string email = this.Email_textbox.Text;
            Label email_label = this.Email_textbox.Parent.Controls.OfType<Label>().FirstOrDefault();
            string password = this.Password_textbox.Text;
            Label password_label = this.Password_textbox.Parent.Controls.OfType<Label>().FirstOrDefault();
            string name = this.Name_textbox.Text;
            Label name_label = this.Name_textbox.Parent.Controls.OfType<Label>().FirstOrDefault();
            foreach (Krypton.Toolkit.KryptonTextBox textbox in textboxes)
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
            }
            if (!string.IsNullOrWhiteSpace(this.Email_textbox.Text))
            {
                try
                {
                    MailAddress valid_email = new MailAddress(email);
                    email_label.Text = "Email";
                    email_label.ForeColor = Color.FromArgb(83, 83, 84);
                }
                catch
                {
                    string error = "Invalid Email Address";
                    setError(email_label, error);
                    isValid = false;
                }    
                
            }
            if (!string.IsNullOrWhiteSpace(this.Name_textbox.Text))
            {
                string pattern = @"^[A-Za-z]{2,} [A-Za-z]{2,}$";
                if (!Regex.IsMatch(name.Trim(), pattern)) {
                    string error = "Invalid Full Name";
                    setError(name_label, error);
                    isValid = false;    
                }
                else
                {
                    name_label.Text = "Full Name";
                    name_label.ForeColor = Color.FromArgb(83,83,84);
                }
            }
            //if (!string.IsNullOrWhiteSpace(this.Password_textbox.Text))
            //{
            //    string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\w\s]).{8,}$";
            //    if (!Regex.IsMatch(name.Trim(), pattern))
            //    {
            //        string error = "Invalid Password";
            //        setError(password_label, error);
            //        isValid = false;
            //    }
            //    else
            //    {
            //        password_label.Text = "Password";
            //        password_label.ForeColor = Color.FromArgb(83, 83, 84);
            //    }
            //}

            return isValid;
        }
        /// <summary>
        /// returns true if the date is valid and user is over 18 and if entered, checks that the
        /// address and profile pictures are valid aswell
        /// if one of them is not valid (can be empty except the date) returns false
        /// </summary>
        /// <returns></returns>
        private bool validate_part2()
        {
            
            bool isValid = true;
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
            this.Address_textbox.StateNormal.Border.Color1 = Color.Silver;
            this.Address_textbox.StateNormal.Border.Color2 = Color.Silver;
            this.Address_textbox.StateActive.Border.Color1 = Color.Silver;
            this.Address_textbox.StateActive.Border.Color2 = Color.Silver;
            Label address_label = this.Address_textbox.Parent.Controls.OfType<Label>().FirstOrDefault();
            if (!string.IsNullOrWhiteSpace(this.Address_textbox.Text))
            {
                List<Data.City> citysList = Data.getWorldCities();
                List<string> addresses = new List<string>();
                foreach (Data.City city in citysList)
                {
                    if (city.city != "" && city.country != "")
                        addresses.Add($"{city.city}, {city.country}");

                }
                if(!addresses.Contains(this.Address_textbox.Text.Trim())){
                    isValid = false;
                    setError(address_label,"Invalid Address");
                }
            }
            int day = this.Day_combobox.SelectedIndex+1;
            int year = (int)this.Year_combobox.SelectedItem;
            int month = this.Month_combobox.SelectedIndex+1;
            DateTime birth_date = new DateTime(year,month,day);
            if((DateTime.Now - birth_date).Days < 18 * 365)
            {
                isValid = false;
                this.birth_date_label.Text = "Birth Date - Only 18 And Over";
                this.birth_date_label.ForeColor = Color.Red;
            }
            else
            {
                this.birth_date_label.Text = "Birth Date";
                this.birth_date_label.ForeColor = Color.Gray;
            }
            byte[] picture_bytes = convert_image(this.profile_picture);
            if (picture_bytes != null && picture_bytes.Length > 1 * 1024 * 1024)
            {
                isValid = false;
                setError(this.profile_picture_label, "Image too large (Over 1MB)");
            }
            else
            {
                this.profile_picture_label.Text = "Profile Picture";
                this.profile_picture_label.ForeColor = Color.Gray;
            }
            return isValid;
        }
        /// <summary>
        /// closes and exists the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void formClosed(object sender, FormClosedEventArgs e)
        {
            
            UI.logout(this);
            Application.Exit();
            Environment.Exit(0);
            
        }
        /// <summary>
        /// calls the UI.set_profile_picture function to display the profile picture
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void SignUp_Shown(object sender, EventArgs e)
        {
            Dictionary<string, Control> controls_dict = new Dictionary<string, Control>();
            UI.registerControls(this.Controls, controls_dict);
            await UI.set_profile_picture(controls_dict);
            this.has_account_btn.Click +=(Object obj,EventArgs ev) => { this.Hide(); new Login().Show(); };
            
            
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
    }
}
