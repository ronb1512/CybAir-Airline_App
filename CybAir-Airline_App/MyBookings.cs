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
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using static CybAir_Airline_App.Data;
using System.Xml.Linq;
using System.Windows.Forms.VisualStyles;
using System.Reflection;
using System.Drawing.Drawing2D;
using QRCoder;
using System.Windows.Markup;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System.Net;
using System.Web;
using SkiaSharp;
using System.IO;
using static GMap.NET.Entity.OpenStreetMapRouteEntity;
using System.Drawing.Imaging;
namespace CybAir_Airline_App
{

    public partial class MyBookings : Form
    {
        static Dictionary<Control, (ActiveFlight,Seat)> flight_tickets = new Dictionary<Control, (ActiveFlight,Seat)>();
        /// <summary>
        /// the constructor sets the rendering options
        /// </summary>
        public MyBookings()
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
        private void MyBookings_Load(object sender, EventArgs e)
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


            this.navbar_panel.Top = 0;
            this.navbar_panel.Width = this.ClientSize.Width;
            Font btn_font = new Font(this.log_in_btn_nav.Font.FontFamily, UI.calculate_size(this.ClientSize.Width, 0.013));
            if (btn_font.Size > 15f)
            {
                btn_font = new Font(this.log_in_btn_nav.Font.FontFamily, 15f);
            }
            this.logout_btn.Top = this.navbar_panel.Bottom;
            this.logout_btn.Left = this.ClientSize.Width - this.logout_btn.Width - 30;
            this.logout_btn.IconSize = this.logout_btn.Font.Height;
            this.logout_btn.Font = btn_font;
            this.logout_btn.BringToFront();
            UI.set_navbar(this.navbar_panel, this.ClientSize, btn_font);

            this.bookings_label.Top = navbar_panel.Bottom + 30;
            this.bookings_label.Font = new Font(log_in_btn_nav.Font.FontFamily,btn_font.Size*2f,FontStyle.Bold);
            this.bookings_label.ForeColor = Color.White;
            this.bookings_label.Left = (this.ClientSize.Width - this.bookings_label.Width) / 2;

            int screen_width = Screen.PrimaryScreen.WorkingArea.Width;
            int smaller_size = Math.Min(UI.calculate_size(this.ClientSize.Width, 0.5), UI.calculate_size(screen_width, 0.35));
            this.tickets_container.Width = smaller_size;
            this.tickets_container.Top = this.bookings_label.Bottom + 30;
            this.tickets_container.Height = this.ClientSize.Height - this.tickets_container.Top-30;
            this.tickets_container.Left = (this.ClientSize.Width - this.tickets_container.Width) / 2;

            this.map_container.Size = new Size(UI.calculate_size(this.ClientSize.Width, 0.8), UI.calculate_size(this.ClientSize.Height, 0.8));
            this.map_container.Visible = false;
            this.map_container.BringToFront();
            this.map_container.Location = new Point((this.ClientSize.Width-this.map_container.Width)/2,(this.ClientSize.Height-this.map_container.Height)/2);
            
            this.info_label.Visible = false;
            this.info_label.Font = new Font(this.log_in_btn_nav.Font.FontFamily, this.home_btn_nav.Font.Size * 0.85f, FontStyle.Bold);

            this.exit_btn.Location = new Point(this.map_container.Width-this.exit_btn.Width, 0);
            this.exit_btn.BringToFront();
            this.exit_btn.Click += (sender, e) => { this.map_container.Visible = false; };
            
            this.options_panel.Visible = false;
            this.options_panel.Width = this.tickets_container.Width/2;
            this.options_panel.Width = UI.calculate_size(this.tickets_container.Height, 0.43);
            foreach(Control c in this.options_panel.Controls)
            {
                c.Font = this.log_in_btn_nav.Font;
                c.Height = this.options_panel.Height/3;
                c.Width = this.options_panel.Width;
                c.Left = 0;
                c.Top = c.Height*this.options_panel.Controls.IndexOf(c);
            }
            UI.AttachClickHandlers(this.Controls);

        }
        /// <summary>
        /// closes and exists the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyBookings_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// asks the server for all the bookings and displays them if the response is successful with show_bookings
        /// </summary>
        /// <returns></returns>
        private async Task get_bookings()
        {
            try
            {
                ConnectionManager.security.writeEncrypted(all_messages.RESERVATIONS.ToString());
                UI.startThread(new Action(() =>
                {
                    string message = ConnectionManager.security.readEncrypted();
                    if (message.StartsWith(all_messages.SUCCESSFULL.ToString()))
                    {
                        List<ActiveFlight> flights = JsonSerializer.Deserialize<List<ActiveFlight>>(message.Split('~')[1]);
                        List<BookedFlight> booked_flights = JsonSerializer.Deserialize<List<BookedFlight>>(message.Split('~')[2]);
                        this.Invoke(new Action(() => show_bookings(flights, booked_flights)));
                    }

                }));
                await Task.Delay(10);
            }
            catch
            {
                UI.server_disconnect(my_bookings_background);
            }
        }
        /// <summary>
        /// first displays the profile picture using the UI.set_profile_picture
        /// then gets all the bookings of the user with get_bookings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void MyBookings_Shown(object sender, EventArgs e)
        {
            Dictionary<string, Control> controls_dict = new Dictionary<string, Control>();
            UI.registerControls(this.Controls, controls_dict);
            async Task first_send()
            {
                await UI.set_profile_picture(controls_dict);
                await Task.Delay(10);
            }
            
            await first_send();
            await get_bookings();    

            
        }
        /// <summary>
        /// creates all the tickets with the bookings of the user and displays them on the form
        /// adds click event to each ticket which opens the option menu
        /// </summary>
        /// <param name="flights"></param>
        /// <param name="booked_flights"></param>
        private void show_bookings(List<ActiveFlight> flights, List<BookedFlight> booked_flights)
        {
            //creates a flight ticket with all the necsecary data in it. returns the panel of the ticket
            Panel create_ticket(ActiveFlight flight,Seat seat)
            {
                Dictionary<string, string> flight_data = new Dictionary<string, string>()
                {
                    {"Passenger",seat.name},
                    {"Flight",flight.flight_number },
                    {"Date",flight.date.ToString("dd/MMM/yyyy") },
                    {"Time",flight.time },
                    {"Seat",$"{seat.row+ 1}{(char)('A' + seat.column)}" },
                };


                Panel ticket = new Panel();
                ticket.Parent = this.tickets_container;
                ticket.Height = UI.calculate_size(this.tickets_container.Height, 0.43);
                ticket.Width = this.tickets_container.Width - SystemInformation.VerticalScrollBarWidth;
                ticket.BackColor = Color.White;
                ticket.Left = 0;
                ticket.Cursor = System.Windows.Forms.Cursors.Hand;
                UI.RoundCorners(ticket, 20, Color.Transparent, 1);
                this.tickets_container.Controls.Add(ticket);

                

                Panel part1= new Panel();
                part1.Parent = ticket;
                part1.Height=ticket.Height;
                part1.Width = UI.calculate_size(ticket.Width,0.8);
                part1.BackColor = Color.Transparent;
                part1.Left = 0;
                part1.Cursor = System.Windows.Forms.Cursors.Hand;
                part1.Click += handle_ticket_click;
                ticket.Controls.Add(part1);

                Panel part2 = new Panel();
                part2.Parent = ticket;
                part2.Height = ticket.Height;
                part2.Width = UI.calculate_size(ticket.Width, 0.2);
                part2.BackColor = Color.Transparent;
                part2.Left = part1.Right;
                part2.Cursor = System.Windows.Forms.Cursors.Hand;
                part2.Click += handle_ticket_click;
                ticket.Controls.Add(part2);


                Label origin_city = new Label();
                origin_city.Parent = part1;
                origin_city.AutoSize = true;
                origin_city.Text = $"{flight.origin_city} ({flight.origin_airport})";
                origin_city.Font = new Font(this.log_in_btn_nav.Font.FontFamily, this.log_in_btn_nav.Font.Size*1.1f, FontStyle.Bold);
                origin_city.ForeColor = Color.FromArgb(0, 70, 127);
                origin_city.Location = new Point(20, part1.Height / 2 - origin_city.Height - 20);
                part1.Controls.Add(origin_city);


                Label origin_country = new Label();
                origin_country.Parent = part1;
                origin_country.AutoSize = true;
                origin_country.Text = flight.origin_country;
                origin_country.Font = origin_city.Font;
                origin_country.ForeColor = Color.FromArgb(0, 172, 157);
                origin_country.Location = new Point(20, part1.Height / 2 - 25);
                part1.Controls.Add(origin_country);

                Label destination_city = new Label();
                destination_city.Parent = part1;
                destination_city.AutoSize = true;
                destination_city.Text = $"{flight.destination_city} ({flight.destination_airport})";
                destination_city.Font = new Font(this.log_in_btn_nav.Font.FontFamily, this.log_in_btn_nav.Font.Size*1.1f, FontStyle.Bold);
                destination_city.ForeColor = Color.FromArgb(0, 70, 127);
                destination_city.Location = new Point(part1.Right - destination_city.Width - 20, origin_city.Top);
                part1.Controls.Add(destination_city);


                Label destination_country = new Label();
                destination_country.Parent = part1;
                destination_country.AutoSize = true;
                destination_country.Text = flight.destination_country;
                destination_country.Font = destination_city.Font;
                destination_country.ForeColor = Color.FromArgb(0, 172, 157);
                destination_country.Location = new Point(destination_city.Left, origin_country.Top);
                part1.Controls.Add(destination_country);


                IconPictureBox arrow_right = new IconPictureBox();
                arrow_right.SizeMode = PictureBoxSizeMode.AutoSize;
                arrow_right.IconChar = IconChar.Plane;
                arrow_right.Width = UI.calculate_size(part1.Width, 0.3);
                arrow_right.Height = part1.Height / 4;
                arrow_right.IconSize = part1.Height / 4;
                arrow_right.Location = new Point((part1.Width - arrow_right.IconSize) / 2, (part1.Height - arrow_right.IconSize) / 2);
                arrow_right.Parent = part1;
                arrow_right.BackColor = Color.Transparent;
                part1.Controls.Add(arrow_right);


                int left_pos = 20;
                foreach (KeyValuePair<string, string> kvp in flight_data)
                {
                    
                    Label label1 = new Label();
                    label1.Parent = part1;
                    label1.AutoSize = true;
                    label1.Text = kvp.Key;
                    label1.Font = this.home_btn_nav.Font;
                    label1.ForeColor = Color.DarkGray;
                    label1.Location = new Point(left_pos, origin_country.Bottom + 20);
                    part1.Controls.Add(label1);

                    Label label2 = new Label();
                    label2.Parent = part1;
                    label2.AutoSize = true;
                    label2.Text = kvp.Value;
                    label2.Font = this.home_btn_nav.Font;
                    label2.ForeColor = Color.Black;
                    label2.Location = new Point(left_pos, label1.Bottom);
                    part1.Controls.Add(label2);

                    left_pos += Math.Max(label1.Width, label2.Width) + 10;
                }


                Panel ticket_top = new Panel();
                ticket_top.Parent = ticket;
                ticket_top.AutoSize = true;
                ticket_top.Width = part1.Width;
                ticket_top.Height = origin_city.Top - 20;
                ticket_top.Location = new Point(0, 0);
                ticket_top.BringToFront();
                ticket_top.BackColor = Color.FromArgb(0, 70, 127);
                part1.Controls.Add(ticket_top);
                ticket_top = new Panel();
                ticket_top.Parent = ticket;
                ticket_top.AutoSize = true;
                ticket_top.Width = part2.Width;
                ticket_top.Height = origin_city.Top - 20;
                ticket_top.Location = new Point(0, 0);
                ticket_top.BringToFront();
                ticket_top.BackColor = Color.FromArgb(0, 70, 127);
                part2.Controls.Add(ticket_top);

                part2.Paint += (sender, e) =>
                {
                    Graphics g = e.Graphics;

                    
                    using (Pen dottedPen = new Pen(Color.Gray, 7))
                    {
                        dottedPen.DashStyle = DashStyle.Dot;

                        g.DrawLine(dottedPen, 0, 0, 0, part2.Bottom);
                    }
                };

                string data = "";
                foreach(KeyValuePair<string,string>kvp in flight_data)
                {
                    data += $"{kvp.Key}: {kvp.Value}\n";
                }
                data += flight.code;
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrImage = qrCode.GetGraphic(20);

                PictureBox qr_code_image = new PictureBox();
                qr_code_image.Parent = part2;
                qr_code_image.Size = new Size(UI.calculate_size(part2.Width, 0.8), UI.calculate_size(part2.Width, 0.8));
                qr_code_image.SizeMode = PictureBoxSizeMode.Zoom;
                qr_code_image.Image = qrImage;
                qr_code_image.Location = new Point((part2.Width - qr_code_image.Width) / 2, (part2.Height - qr_code_image.Height) / 2);
                qr_code_image.BackColor = Color.White;
                part2.Controls.Add(qr_code_image);

                return ticket;
            }
            int top_pos = 0;
            this.tickets_container.Controls.Clear();
            for(int i=0; i<flights.Count; i++)
            {
                foreach (Seat seat in booked_flights[i].seats)
                {
                    Panel ticket = create_ticket(flights[i], seat);
                    flight_tickets[ticket] = (flights[i],seat);
                    ticket.Top = top_pos;
                    top_pos += ticket.Height + 10;
                }
                top_pos += 20;
                
            }
            this.view_map_btn.Click -= handle_option_click;
            this.view_map_btn.Click += handle_option_click;
            this.cancel_ticket_btn.Click -= handle_option_click;
            this.cancel_ticket_btn.Click += handle_option_click;
            this.save_ticket_btn.Click -= handle_option_click;
            this.save_ticket_btn.Click += handle_option_click;

        }
        /// <summary>
        /// toggles the options menu. if its visible, hides it
        /// if it is not visible it updates the posiotion and shows it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void handle_ticket_click(object sender, EventArgs e)
        {
            this.options_panel.Visible = true;
            this.options_panel.Parent = (sender as Control).Parent;
            this.options_panel.BringToFront();
            this.options_panel.Top = 0;
            this.options_panel.Left = this.options_panel.Parent.Right - this.options_panel.Width;

        }
        /// <summary>
        /// directs to the correct function according to the clicked option
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void handle_option_click(object sender, EventArgs e)
        {
            Control btn = sender as Control;
            Control ticket = btn.Parent.Parent;
            ActiveFlight flight = flight_tickets[ticket].Item1;
            Seat seat = flight_tickets[ticket].Item2;
            if (btn.Name.Contains("map")){
                get_map_data(flight);
            }
            else if (btn.Name.Contains("cancel")){
                cancel_ticket(flight, seat, ticket);
            }
            else{
                save_ticket(ticket);
            }

            
        }
        /// <summary>
        /// turns the ticket into a bitmap and opens the save dialog to allow the user to save the ticket as an image
        /// on his own computer
        /// </summary>
        /// <param name="ticket"></param>
        private void save_ticket(Control ticket)
        {
            Bitmap bitmap = new Bitmap(ticket.Width, ticket.Height);
            ticket.DrawToBitmap(bitmap, new Rectangle(0, 0, ticket.Width, ticket.Height));
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PNG Image|*.png";
                saveFileDialog.Title = "Save Flight Ticket";
                saveFileDialog.FileName = "Flight Ticket.png";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    bitmap.Save(saveFileDialog.FileName, ImageFormat.Png);
                }
            }

            bitmap.Dispose();
        }
        /// <summary>
        /// sends the server a message to cancel the seat in a particular flight
        /// if the server responds with a successful message the ticket gets deleted and
        /// the window displays the updated bookings without it
        /// </summary>
        /// <param name="flight"></param>
        /// <param name="seat"></param>
        /// <param name="ticket"></param>
        private void cancel_ticket(ActiveFlight flight,Seat seat,Control ticket)
        {
            try
            {
                ConnectionManager.security.writeEncrypted($"{all_messages.CANCEL.ToString()}{JsonSerializer.Serialize(flight)}|{JsonSerializer.Serialize(seat)}");
                UI.startThread(new Action(() =>
                {
                    string message = ConnectionManager.security.readEncrypted();
                    
                    if (message.StartsWith(all_messages.SUCCESSFULL.ToString()))
                    {
                        
                        this.Invoke(new Action(async () => {
                            this.tickets_container.Controls.Remove(ticket);
                            flight_tickets.Remove(ticket);
                            await get_bookings(); 
                        }));
                    }
                }));
            }
            catch
            {
                UI.server_disconnect(my_bookings_background);
            }
        }
        /// <summary>
        /// sends the server a message to get the data about other users in the flight
        /// if the message recieved is successful it displays the map with the data
        /// </summary>
        /// <param name="flight"></param>
        private void get_map_data(ActiveFlight flight)
        {
            if (map_container.Visible) return;
            try{
                ConnectionManager.security.writeEncrypted($"{all_messages.MAP.ToString()}{JsonSerializer.Serialize(flight)}");
                UI.startThread(new Action(() =>
                {
                    string message = ConnectionManager.security.readEncrypted();
                    if (message.StartsWith(all_messages.SUCCESSFULL.ToString()))
                    {
                        message = message.Substring(all_messages.SUCCESSFULL.ToString().Length);
                        List<User> users = JsonSerializer.Deserialize<List<User>>(message);
                        this.Invoke(new Action(() => { display_map(users,flight); }));
                    }
                }));
            }
            catch
            {
                UI.server_disconnect(my_bookings_background);
            }
        }
        /// <summary>
        /// creates a visual map control with GMapControl from GMap.NET
        /// ittirates through all the users recieved and displays their profile picture
        /// gets the geographic location of the user by his address and positions the profile picture on that location as a GMap marker
        /// adds a tag with the information to the marker
        /// displays the two markers of the origin city and the destination city of the flight and connects between them to show the route
        /// adds different events to the markers and the map
        /// </summary>
        /// <param name="users"></param>
        /// <param name="flight"></param>
        private void display_map(List<User>users,ActiveFlight flight)
        {
            this.map_container.Visible = true;
            GMapControl previous_map = this.map_container.Controls.OfType<GMapControl>().FirstOrDefault();
            if (previous_map != null)
                this.map_container.Controls.Remove(previous_map);
            try
            {
                GMapControl gmap = new GMapControl
                {
                    Dock = DockStyle.Fill
                };
                this.map_container.Controls.Add(gmap);
                this.exit_btn.BringToFront();
                gmap.MapProvider = GMap.NET.MapProviders.OpenStreetMapProvider.Instance;
                GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
                GMap.NET.MapProviders.GMapProvider.WebProxy = null;
                gmap.MinZoom = 3;
                gmap.MaxZoom = 18;
                gmap.Zoom = 3;
                gmap.ShowCenter = false;
                gmap.CanDragMap = true;
                gmap.DragButton = MouseButtons.Left;
                GMapOverlay markersOverlay = new GMapOverlay("markers");
                
                foreach (User user in users)
                {
                    Image img;
                    using (MemoryStream ms = new MemoryStream(user.profile_picture))
                    {
                        img = Image.FromStream(ms);
                        img = (Image)img.Clone();
                    }
                    Bitmap bitmap = new Bitmap(img);
                    Bitmap ResizeBitmap(Bitmap source, int width, int height)
                    {
                        Bitmap result = new Bitmap(width, height);
                        using (Graphics g = Graphics.FromImage(result))
                        {
                            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                            g.DrawImage(source, 0, 0, width, height);
                        }
                        return result;
                    }
                    Bitmap MakeCircularBitmap(Bitmap original, int size)
                    {
                        Bitmap output = new Bitmap(size, size);

                        using (Graphics g = Graphics.FromImage(output))
                        {
                            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                            using (Brush brush = new TextureBrush(original))
                            {
                                using (GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath())
                                {
                                    path.AddEllipse(0, 0, size, size);
                                    g.FillPath(brush, path);
                                }
                            }
                        }

                        return output;
                    }
                    bitmap = ResizeBitmap(bitmap, 32, 32);
                    bitmap = MakeCircularBitmap(bitmap, 32);
                    List<City> cities = getWorldCities();
                    double lng=0;
                    double lat=0;
                    
                    foreach (City city in cities)
                    {
                        if (city.city.Equals(user.address.Split(',')[0]))
                        {
                            if (city.country.Equals(user.address.Split(',')[1].Trim()))
                            {
                                lng = city.lng;
                                lat = city.lat;
                            }
                        }
                    }
                    foreach(var m in markersOverlay.Markers)
                    {
                        if(m.Position.Lat==lat && m.Position.Lng == lng)
                        {
                            lng += 0.005;
                            lat += 0.005;
                        }
                    }
                    GMapMarker marker = new GMarkerGoogle(new PointLatLng(lat, lng), bitmap);
                    marker.Tag = $"Name: {user.name}\nAge: {(int)((DateTime.Now - user.birth_date).TotalDays / 365)}";
                    markersOverlay.Markers.Add(marker);
                    

                }

                List<City> cities2 = getWorldCities();
                List<PointLatLng> points = new List<PointLatLng>();
                foreach (City city in cities2)
                {
                    if (city.city.Equals(flight.origin_city) && city.country.Equals(flight.origin_country))
                    {

                        GMapMarker origin = new GMarkerGoogle(new PointLatLng(city.lat, city.lng), GMarkerGoogleType.red_dot);
                        origin.Tag = $"Origin:\n{flight.origin_city}, {flight.origin_country}";
                        markersOverlay.Markers.Add(origin);
                        points.Add(origin.Position);
                    }
                    if (city.city.Equals(flight.destination_city) && city.country.Equals(flight.destination_country))
                    {
                        GMapMarker destination = new GMarkerGoogle(new PointLatLng(city.lat, city.lng), GMarkerGoogleType.red_dot);
                        destination.Tag = $"Destination:\n{flight.destination_city}, {flight.destination_country}";
                        markersOverlay.Markers.Add(destination);
                        points.Add(destination.Position);
                    }
                }
                gmap.Overlays.Add(markersOverlay);
                GMapOverlay routes = new GMapOverlay("routes");
                gmap.Overlays.Add(routes);
                GMapRoute route = new GMapRoute(points, "LineBetweenMarkers");
                route.Stroke = new Pen(Color.Blue, 3);
                routes.Routes.Add(route);
                gmap.ZoomAndCenterMarkers("markers");
                GMapMarker current = markersOverlay.Markers[0];
                gmap.OnMarkerClick += (sender,e)=> { Gmap_OnMarkerClick(sender, gmap); current = sender; };
                gmap.OnMapClick += Gmap_OnMapClick;
                gmap.OnMapZoomChanged += () => { update_label_position(current, gmap); };
                gmap.OnPositionChanged += (Point) => { update_label_position(current, gmap); };

                gmap.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }
        /// <summary>
        /// hides the information label
        /// </summary>
        /// <param name="pointClick"></param>
        /// <param name="e"></param>
        private void Gmap_OnMapClick(PointLatLng pointClick, System.Windows.Forms.MouseEventArgs e)
        {
            this.info_label.Visible = false;
        }
        /// <summary>
        /// updates the position of the label using update+label_position
        /// shows the information label and updates the data in the label to match the clicked user
        /// </summary>
        /// <param name="item"></param>
        /// <param name="gmap"></param>
        private void Gmap_OnMarkerClick(GMapMarker item, GMapControl gmap)
        {
            
                this.info_label.Visible = true;
                this.info_label.Text = item.Tag.ToString();
                update_label_position(item, gmap);
            
        }
        /// <summary>
        /// updates the location of the label
        /// </summary>
        /// <param name="item"></param>
        /// <param name="gmap"></param>
        private void update_label_position(GMapMarker item ,GMapControl gmap)
        {
            GPoint gpoint = gmap.FromLatLngToLocal(item.Position);
            Point localPoint = new Point((int)gpoint.X, (int)gpoint.Y);
            this.info_label.Location = new Point(localPoint.X, localPoint.Y);
        }
        /// <summary>
        /// if the form is not in the minimized state it displays all the controls again with set_components
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyBookings_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized) return;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.UpdateStyles();
            set_components();
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
