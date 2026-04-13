using FontAwesome.Sharp;
using Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace CybAir_Airline_App
{
    public partial class Login : Form
    {
        /// <summary>
        /// the constructor sets the rendering options
        /// </summary>
        public Login()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint|
                          ControlStyles.ResizeRedraw,true);
            this.UpdateStyles();
        }
        /// <summary>
        /// sets the screen size and call the set_components function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Login_Load(object sender, EventArgs e)
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
            this.login_background.Size = new Size(this.ClientSize.Width,this.ClientSize.Height);
            this.navbar_panel.Top = 0;
            this.navbar_panel.Width = this.ClientSize.Width;
            
            int screen_width = Screen.PrimaryScreen.WorkingArea.Width;
            int smaller_size = Math.Min(UI.calculate_size(this.ClientSize.Width, 0.4), UI.calculate_size(screen_width, 0.2));
             
            void login_form_setup()
            {
                this.login_form.Width = smaller_size;
                this.login_form.Height = UI.calculate_size(smaller_size, 1.05);
                this.login_form.Padding = new System.Windows.Forms.Padding(25);
                UI.RoundCorners(this.login_form, 10, Color.White, 0);
            }   
            void login_btn_setup()
            {
                this.login_btn.Width = this.login_form.Width - 2 * this.login_form.Padding.Left;
                this.login_btn.Font = new Font(this.login_btn.Font.FontFamily, UI.calculate_size(smaller_size, 0.015 * 2.5));
                int textHeight = TextRenderer.MeasureText(this.login_btn.Text, this.login_btn.Font).Height;
                this.login_btn.Height = textHeight + 20;
                UI.RoundCorners(this.login_btn, 40, this.login_btn.BackColor, 5);
                this.login_btn.Left = this.login_form.Padding.Left;
            }
            void login_header_setup()
            {
                this.login_header.Font = new Font(this.login_header.Font.FontFamily, UI.calculate_size(smaller_size, 0.018 * 2.5));
                UI.RoundCorners(this.login_header, 20, this.login_btn.BackColor, 1);
                this.login_header.Location = new Point((this.login_form.Width - this.login_header.Width) / 2, -10);
            }
            int top_pos = this.login_header.Bottom + UI.calculate_size(this.login_form.Height, 0.1);
            void textBoxes_setup()
            {
                Panel[] all_textbox_containers = this.login_form.Controls.OfType<Panel>().ToArray();
                Array.Reverse(all_textbox_containers);
                foreach (Panel container in all_textbox_containers)
                {

                    container.Left = this.login_form.Padding.Left;
                    container.Top = top_pos;

                    //textbox setup
                    Krypton.Toolkit.KryptonTextBox textbox = container.Controls.OfType<Krypton.Toolkit.KryptonTextBox>().FirstOrDefault();
                    textbox.Width = this.login_btn.Width;
                    textbox.StateCommon.Content.Font = new Font(this.login_btn.Font.FontFamily, this.login_btn.Font.Size);
                    textbox.StateActive.Content.Font = new Font(this.login_btn.Font.FontFamily, this.login_btn.Font.Size);
                    textbox.CueHint.Font = new Font(this.login_btn.Font.FontFamily, this.login_btn.Font.Size);
                    textbox.Height = TextRenderer.MeasureText(textbox.Text, this.login_btn.Font).Height;
                    //icon setup
                    IconPictureBox icon = container.Controls.OfType<IconPictureBox>().FirstOrDefault();
                    icon.IconSize = textbox.Height - 4;
                    icon.Location = new Point(this.login_form.Padding.Left + textbox.Width - UI.calculate_size(icon.IconSize, 1.5), (container.Height - icon.Height) / 2);
                    icon.BackColor = Color.Transparent;

                    top_pos += textbox.Height + UI.calculate_size(this.login_form.Height, 0.05);

                }
            }
            void no_account_setup()
            {
                
                this.no_account_label.Font = new Font(this.no_account_label.Font.FontFamily, UI.calculate_size(smaller_size, 0.012 * 2.5));
                this.no_account_btn.Font = new Font(this.no_account_label.Font.FontFamily, UI.calculate_size(smaller_size, 0.012 * 2.5), FontStyle.Bold);
                this.no_account_label.Left = (this.login_form.Width - this.no_account_label.Width - this.no_account_btn.Width) / 2;
                this.no_account_btn.Left = this.no_account_label.Left+this.no_account_label.Width;
                this.no_account_btn.MouseHover += UI.nav_buttons_hover;
                this.no_account_btn.MouseLeave += UI.nav_buttons_stop_hover;
                this.no_account_label.Top = top_pos;
                int textHeight = TextRenderer.MeasureText(this.no_account_btn.Text, this.no_account_btn.Font).Height;
                this.no_account_btn.Top = this.no_account_label.Top - (this.no_account_btn.Height - textHeight)/2;

            }
            login_form_setup();
            login_btn_setup();
            login_header_setup();
            textBoxes_setup();
 
            this.Password_textbox.PasswordChar = '●';
            top_pos += UI.calculate_size(this.login_form.Height, 0.07);
            this.login_btn.Top = top_pos;
            top_pos += UI.calculate_size(this.login_form.Height, 0.2);
            no_account_setup();
            this.login_form.Location = new Point((this.ClientSize.Width - this.login_form.Width) / 2, (this.ClientSize.Height - this.login_form.Height) / 2);

            this.error_label.Font = log_in_btn_nav.Font;
            this.error_label.Location = new Point((this.ClientSize.Width - this.error_label.Width) / 2, login_form.Bottom + UI.calculate_size(this.ClientSize.Height, 0.02));
            this.error_label.Visible = false;

            Font btn_font = new Font(this.login_btn.Font.FontFamily, UI.calculate_size(this.ClientSize.Width, 0.013));
            if (btn_font.Size > 15f)
            {
                btn_font = new Font(this.login_btn.Font.FontFamily, 15f);
            }
            this.logout_btn.Top = this.navbar_panel.Bottom;
            this.logout_btn.Left = this.ClientSize.Width - this.logout_btn.Width - 30;
            this.logout_btn.IconSize = this.logout_btn.Font.Height;
            this.logout_btn.Font = btn_font;
            this.logout_btn.BringToFront();
            UI.set_navbar(this.navbar_panel,this.ClientSize,btn_font);
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
            textBox.StateActive.Border.Color1 = Color.FromArgb(83,83,84);
            textBox.StateActive.Border.Color2 = Color.FromArgb(83, 83, 84);
            textBox.StateActive.Border.Width = 2;
            if (textBox.Text != null && textBox.Text!="")
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
            await this.move_labels_animation(label, new Point(0,0));


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
            int num = Math.Abs(label.Top - finish_pos.Y)/step_size+1;
            if (label.Top < finish_pos.Y) {
                step_size = -step_size;
            }
            for (int i = 0; i < num; i++) {
            
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
            textBox.StateActive.Border.Color1 = Color.Silver;
            textBox.StateActive.Border.Color2 = Color.Silver;
            textBox.StateActive.Border.Width = -1;
            Label label = textBox.Parent.Controls.OfType<Label>().FirstOrDefault();
            if (textBox.Text==""||textBox.Text==null)
            {
                await this.move_labels_animation(label, new Point(0, (textBox.Height - label.Height) / 2));
                textBox.Parent.Controls.Remove(label);
                textBox.CueHint.Color1 = Color.Silver;
                label.Dispose();
            }
            

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
        /// if the form is not in the minimized state it displays all the controls again with set_components
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Login_Resize(object sender, EventArgs e)
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
        /// checks that all the data entered by the user is valid with validate
        /// if the data is valid it initializes the ConnectionManager class with a new TCP connection
        /// sends the data to the server
        /// recieves response and logs in if positive otherwise show message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void login_btn_Click(object sender, EventArgs e)
        {
            if (this.validate())
            {
                
                string email = this.Email_textbox.Text;
                string password = this.Password_textbox.Text;
                Dictionary<string,string>data = new Dictionary<string,string>();
                data[email] = password;
                
                void send_message()
                {

                    if (ConnectionManager.tcp_client == null)
                    {
                        
                        ConnectionManager.tcp_client = new TcpClient(ConnectionManager.server_ip, Server.port);
                        ConnectionManager.tcp_client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
                        ConnectionManager.tcp_stream = ConnectionManager.tcp_client.GetStream();
                        (ConnectionManager.reader, ConnectionManager.writer) = ConnectionManager.get_reader_writer(ConnectionManager.tcp_client);

                    }
                    ConnectionManager.security.writeEncrypted($"{all_messages.LOGIN}{JsonSerializer.Serialize(data)}");
                    try
                    {
                        recieveAnswer();

                    }
                    catch
                    {
                        throw;
                    }

                }
                try
                {
                    send_message();
                }
                catch {
                    ConnectionManager.log_out();
                    this.error_label.Text = "Unable To Login";
                    this.error_label.Visible = true;
                    this.error_label.Left = (this.ClientSize.Width - error_label.Width) / 2;
                }
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
                        ConnectionManager.log_out();
                        
                        if (messege.Equals(all_messages.EXISTS.ToString()))
                        {
                            this.error_label.Text = "User Already Logged In On Another Device";
                            this.error_label.Visible = true;
                            this.error_label.Left = (this.ClientSize.Width - error_label.Width) / 2;
                        }
                        if (messege.Equals(all_messages.FAILED.ToString()))
                        {
                            this.error_label.Text = "Invalid Login Information";
                            this.error_label.Visible = true;
                            this.error_label.Left = (this.ClientSize.Width - error_label.Width) / 2;

                        }


                    }
                }
                return;
            }
        }
        /// <summary>
        /// returns true if the data enered by the user is valid and false if its not
        /// </summary>
        /// <returns></returns>
        private bool validate() {
            bool isValid = true;
            Krypton.Toolkit.KryptonTextBox[] textboxes = { this.Email_textbox, this.Password_textbox};
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
            return isValid;
        }
        /// <summary>
        /// calls the UI.set_profile_picture function to display the profile picture
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Login_Shown(object sender, EventArgs e)
        {
            Dictionary<string, Control> controls_dict = new Dictionary<string, Control>();
            UI.registerControls(this.Controls, controls_dict);
            await UI.set_profile_picture(controls_dict);
            this.no_account_btn.Click += (Object obj, EventArgs ev) => { this.Hide(); new SignUp().Show(); };
            
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
