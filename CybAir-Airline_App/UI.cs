using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Remoting.Channels;
using System.Web.Configuration;

namespace CybAir_Airline_App
{
    static class UI
    {
        /// <summary>
        /// creates a thread with the given action that runs in the background
        /// </summary>
        /// <param name="act"></param>
        public static void startThread(Action act)
        {
            new Thread(() => act()) { IsBackground = true }.Start();
        }
        public static Dictionary<string, Control> all_controls = new Dictionary<string, Control>();
        /// <summary>
        /// does custom painting on the control by rounding its corners
        /// </summary>
        /// <param name="control"></param>
        /// <param name="radius"></param>
        /// <param name="color"></param>
        /// <param name="width"></param>
        public static void RoundCorners(Control control, int radius, Color color, int width)

        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(control.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(control.Width - radius, control.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, control.Height - radius, radius, radius, 90, 90);
            control.Paint += (sender, e) =>
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                Pen pen = new Pen(color, width);
                g.DrawPath(pen, path);
            };
            path.CloseFigure();

            control.Region = new Region(path);

        }
        /// <summary>
        /// returns an integer that represents the result of an integer multiplied by a double
        /// used for sizes and positions calculations in the UI
        /// </summary>
        /// <param name="num"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int calculate_size(int num, double value)
        {
            return (int)(num * value);
        }
        /// <summary>
        /// sets the navbar in the form
        /// </summary>
        /// <param name="navbar"></param>
        /// <param name="clientSize"></param>
        /// <param name="btn_font"></param>
        public static void set_navbar(Panel navbar, Size clientSize, Font btn_font)
        {
            int left_pos = calculate_size(clientSize.Width, 0.37);
            int top_pos = calculate_size(clientSize.Height, 0.02);
            Control[] navbar_controls = navbar.Controls.Cast<Control>().ToArray();
            navbar_controls.Reverse();

            foreach (Control ctrl in navbar.Controls)
            {

                if (ctrl is Button || ctrl is IconButton)
                {
                    ctrl.Top = top_pos;
                    ctrl.Font = btn_font;
                    ctrl.Enabled = true;

                    if (!ctrl.Name.Contains("log_in") && !ctrl.Name.Contains("picture"))
                    {
                        ctrl.Left = left_pos;
                        left_pos += ctrl.Width;

                        ctrl.MouseHover += nav_buttons_hover;
                        ctrl.MouseLeave += nav_buttons_stop_hover;

                    }

                }
                else
                {
                    ctrl.Font = new Font(btn_font.FontFamily, btn_font.Size * 0.6f);


                }
            }




        }
        /// <summary>
        /// if the current form is the contact form then sends an exist chat message to the server
        /// if the user is not loged in then every button in the navbar that is not  the home or about pages will
        /// lead to the login page
        /// otherwise the buttons in the navbar will lead to the correct page
        /// displays the name of the user and the profile picture in the navbar
        /// </summary>
        /// <param name="controls_dict"></param>
        /// <returns></returns>
        public static async Task set_profile_picture(Dictionary<string, Control> controls_dict)
        {

            Form form = controls_dict.First().Value.FindForm();
            if (ConnectionManager.listening_for_messages)
            {
                try
                {
                    ConnectionManager.security.writeEncrypted(all_messages.EXITCHAT.ToString());

                }
                catch
                {
                    server_disconnect(form.Controls.OfType<Panel>().First());
                }
                while (ConnectionManager.listening_for_messages)
                {
                    await Task.Delay(5);
                }
            }

            form.Invoke(new Action(() => {
                controls_dict["about_btn_nav"].Click += (Object obj, EventArgs ev) => { form.Hide(); new About().Show(); };
                if (controls_dict.ContainsKey("sign_up_btn"))
                {
                    controls_dict["sign_up_btn"].Click += (Object obj, EventArgs ev) => { form.Hide(); new SignUp().Show(); };

                }
                controls_dict["log_in_btn_nav"].Click += (Object obj, EventArgs ev) => { form.Hide(); new Login().Show(); };
                controls_dict["home_btn_nav"].Click += (Object obj, EventArgs ev) => { form.Hide(); new Home().Show(); };

            }));
            if (ConnectionManager.tcp_client == null)
            {
                form.Invoke(new Action(() => {
                    controls_dict["flights_btn_nav"].Click += (Object obj, EventArgs ev) => { form.Hide(); new Login().Show(); };
                    controls_dict["my_bookings_btn_nav"].Click += (Object obj, EventArgs ev) => { form.Hide(); new Login().Show(); };
                    controls_dict["contact_btn_nav"].Click += (Object obj, EventArgs ev) => { form.Hide(); new Login().Show(); };
                }));
            }
            else
            {
                try
                {

                    ConnectionManager.security.writeEncrypted(all_messages.PROFILE_PICTURE.ToString());
                    await Task.Run(() =>
                    {
                        string message = ConnectionManager.security.readEncrypted();

                        form.Invoke(new Action(() =>
                        {

                            if (controls_dict.ContainsKey("sign_up_btn"))
                            {

                                controls_dict["sign_up_btn"].Enabled = false;

                            }

                            controls_dict["log_in_btn_nav"].Enabled = false;
                            if (message.StartsWith(all_messages.SUCCESSFULL.ToString()))
                            {
                                controls_dict["flights_btn_nav"].Click += (Object obj, EventArgs ev) => { form.Hide(); new Flights().Show(); };
                                controls_dict["my_bookings_btn_nav"].Click += (Object obj, EventArgs ev) => { form.Hide(); new MyBookings().Show(); };
                                controls_dict["contact_btn_nav"].Click += (Object obj, EventArgs ev) => { form.Hide(); new Contact().Show(); };
                                message = message.Substring(all_messages.SUCCESSFULL.ToString().Length);
                                string name = message.Split(',')[0];
                                try
                                {
                                    string picture = message.Split(',')[1];
                                    Image img;
                                    byte[] receivedBytes = Convert.FromBase64String(picture);
                                    using (MemoryStream ms = new MemoryStream(receivedBytes))
                                    {
                                        img = Image.FromStream(ms);
                                        img = (Image)img.Clone();
                                    }
                                    form.Invoke(new Action(() =>
                                    {
                                        UI.display_profile_picture(controls_dict["profile_picture"] as IconButton, img, controls_dict["name_label"] as Label, name, controls_dict["logout_btn"] as IconButton);
                                    }));
                                }
                                catch
                                {
                                    form.Invoke(new Action(() =>
                                    {
                                        UI.display_profile_picture(controls_dict["profile_picture"] as IconButton, null, controls_dict["name_label"] as Label, name, controls_dict["logout_btn"] as IconButton);
                                    }));
                                }

                            }
                            else
                            {
                                controls_dict["log_in_btn_nav"].Visible = true;
                                controls_dict["log_in_btn_nav"].Enabled = true;
                            }
                        }));
                    });
                    form.Invoke(new Action(() =>
                    {
                        controls_dict["log_in_btn_nav"].Visible = false;
                    }));
                }
                catch (Exception ex) {
                    server_disconnect(form.Controls.OfType<Panel>().First());
                }
            }


        }
        /// <summary>
        /// displays the actual controls of the profile picture and name in the navbar
        /// </summary>
        /// <param name="profile_picture"></param>
        /// <param name="img"></param>
        /// <param name="name_label"></param>
        /// <param name="name"></param>
        /// <param name="logout_btn"></param>
        public static void display_profile_picture(IconButton profile_picture, Image img, Label name_label, string name, IconButton logout_btn)
        {

            Panel navbar = (Panel)profile_picture.Parent;
            profile_picture.Height = UI.calculate_size(navbar.Height, 0.6);
            profile_picture.Width = profile_picture.Height;
            profile_picture.Location = new Point(navbar.Right - (int)(profile_picture.Width * 1.5), (navbar.Height - profile_picture.Height) / 2 - 10);
            profile_picture.Visible = true;
            profile_picture.Click += (sender, e) => { logout_btn.Visible = !logout_btn.Visible; };
            UI.RoundCorners(profile_picture, profile_picture.Height, Color.Black, 1);
            if (img == null)
            {
                profile_picture.IconChar = IconChar.UserAlt;
                profile_picture.BackColor = SystemColors.ControlDark;
                profile_picture.IconColor = Color.WhiteSmoke;
                profile_picture.IconSize = UI.calculate_size(profile_picture.Height, 0.8);
            }
            else
            {
                try
                {

                    profile_picture.BackgroundImage = img;
                    profile_picture.BackgroundImageLayout = ImageLayout.Stretch;
                    profile_picture.IconChar = IconChar.None;
                }
                catch
                {
                    profile_picture.IconChar = IconChar.UserAlt;
                    profile_picture.BackColor = SystemColors.ControlDark;
                    profile_picture.IconColor = Color.WhiteSmoke;
                    profile_picture.IconSize = UI.calculate_size(profile_picture.Height, 0.8);
                }

            }
            name_label.Visible = true;
            name_label.Text = $"Hello {name}!";
            name_label.Top = profile_picture.Bottom + 5;
            name_label.Left = logout_btn.Right - name_label.Width;

        }
        /// <summary>
        /// when the button is hovered then an underline will appear
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void nav_buttons_hover(object sender, EventArgs e)
        {
            Button target_btn = (Button)sender;
            target_btn.Font = new Font(target_btn.Font.FontFamily, target_btn.Font.Size, FontStyle.Underline | target_btn.Font.Style);
            target_btn.BackColor = Color.Transparent;
        }
        /// <summary>
        /// when the hover on the button stops the underline will dissappear
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void nav_buttons_stop_hover(object sender, EventArgs e)
        {
            Button target_btn = sender as Button;
            target_btn.Font = new Font(target_btn.Font.FontFamily, target_btn.Font.Size, target_btn.Font.Style & ~FontStyle.Underline);
        }
        /// <summary>
        /// for every control in  the form: if the controls is clicked and can focus then focus on it
        /// otherwise focus on the dummy button
        /// </summary>
        /// <param name="controls"></param>
        public static void AttachClickHandlers(Control.ControlCollection controls)
        {
            Button dummy_btn = controls.OfType<Button>().FirstOrDefault();
            Dictionary<string, Control> controls_dict = new Dictionary<string, Control>();
            UI.registerControls(controls, controls_dict);
            Control found = null;
            if (controls_dict.ContainsKey("options_panel"))
                found = controls_dict["options_panel"];
            foreach (Control ctrl in controls)
            {

                ctrl.Click += (sender, e) =>
                {
                    Control clicked = sender as Control;
                    if (clicked.CanFocus)
                    {
                        clicked.Focus();
                    }
                    else
                    {
                        dummy_btn.Select();
                    }
                    if (found != null)
                    {
                        found.Visible = false;
                    }

                };
                if (ctrl.HasChildren)
                {
                    AttachClickHandlers(ctrl.Controls);
                }
            }
        }
        /// <summary>
        /// updates the controls dicionary so that it contains the name of every control as key and the controls itself as value
        /// </summary>
        /// <param name="controls"></param>
        /// <param name="dict"></param>
        public static void registerControls(Control.ControlCollection controls, Dictionary<string, Control> dict)
        {

            foreach (Control item in controls)
            {
                dict[item.Name] = item;
                if (item.Controls.Count > 0)
                {
                    registerControls(item.Controls, dict);
                }
            }
        }
        /// <summary>
        /// sends a message to the server to log out and activates the ConnectionManager.logout function if successful
        /// </summary>
        /// <param name="form"></param>
        public static void logout(Form form)
        {
            if (ConnectionManager.tcp_client == null) return;
            try
            {
                ConnectionManager.security.writeEncrypted(all_messages.LOGOUT.ToString());
                ConnectionManager.listening_for_messages = false;
                ConnectionManager.log_out();
                form.Invoke(new Action(() => {
                    new Home().Show();
                    form.Hide();
                }));
            }
            catch
            {
                ConnectionManager.listening_for_messages = false;
                ConnectionManager.log_out();
                form.Invoke(new Action(() => {
                    new Home().Show();
                    form.Hide();
                }));
            }
        }
        public static void server_disconnect(Control parent)
        {
            Form form = parent.FindForm();
            
            form.Invoke(new Action(() => {
                show_message(parent, "Connection Lost...", false);
            }));
        }
        public static void show_message(Control parent, string message, bool positive)
        {
            show_message(parent, message, positive, 0);
        }
        public static async Task show_message(Control parent, string message, bool positive, int timeout)
        {
            Form form = parent.FindForm();
            Panel msg_background = new Panel();
            
            msg_background.Parent = parent;
            msg_background.BackColor = Color.FromArgb(50,0,0,0);
            msg_background.Size = parent.Size;
            parent.Controls.Add(msg_background);
            msg_background.BringToFront();

            Panel msg_container = new Panel();
            msg_container.Parent = msg_background;
            msg_container.Size = new Size(calculate_size(msg_background.Width,0.4),calculate_size(msg_background.Height,0.4));
            msg_container.BackColor = Color.White;
            msg_container.Location = new Point((msg_background.Width - msg_container.Width)/2, (msg_background.Height - msg_container.Height) / 2);
            msg_background.Controls.Add(msg_container);

            Label msg = new Label();
            msg.Parent = msg_container;
            msg.AutoSize = true;
            msg.Text = message;
            msg.TextAlign = ContentAlignment.MiddleCenter;
            msg.Font = new Font("Segoe UI",calculate_size(msg_container.Height,0.08),FontStyle.Bold);
            msg.ForeColor = positive ? Color.Green : Color.Red;
            msg.Left = (msg_container.Width - msg.Width) / 2;
            msg.Top = calculate_size(msg_container.Height, 0.17);
            msg_container.Controls.Add(msg);

            IconButton icon = new IconButton();
            icon.Parent = msg_container;
            icon.AutoSize = true;
            icon.FlatAppearance.BorderSize = 0;
            icon.FlatStyle = FlatStyle.Flat;
            icon.FlatAppearance.MouseOverBackColor = Color.White;
            icon.FlatAppearance.CheckedBackColor = Color.White;
            icon.IconChar = positive ? IconChar.CircleCheck : IconChar.CircleXmark;
            icon.IconColor = positive ? Color.Green : Color.Red;
            icon.IconSize = calculate_size(icon.Parent.Height,0.5);
            icon.Top = msg.Bottom;
            icon.Left = (msg_container.Width - icon.Width)/2;
            msg_container.Controls.Add(icon);
            
            if (timeout==0)
            {
                Button exit = new Button();
                exit.Text = "X";
                exit.Cursor= Cursors.Hand;
                exit.BackColor = Color.Red;
                exit.ForeColor = Color.White;
                exit.FlatAppearance.BorderSize = 0;
                exit.FlatStyle = FlatStyle.Flat;
                exit.AutoSize = true;
                exit.Parent = msg_container;
                exit.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                exit.Location = new Point(exit.Parent.Width - exit.Width, 0);
                exit.Click += (sender, e) => {
                    msg_background.Dispose();
                    logout(form);
                };
                msg_container.Controls.Add(exit);
            }
            else
            {
                await Task.Delay(timeout);
                msg_background.Dispose();
            }
        }
    }

}
