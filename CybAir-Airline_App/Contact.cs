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
using Krypton.Toolkit;
using System.Threading;

namespace CybAir_Airline_App
{
    public partial class Contact : Form
    {
        /// <summary>
        /// the constructor sets the rendering options
        /// </summary>
        public Contact()
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
        private void Contact_Load(object sender, EventArgs e)
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
            this.navbar_panel.Top = 0;
            this.navbar_panel.Left = 0;
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

            this.container.Size = new Size(UI.calculate_size(this.ClientSize.Width, 0.8), UI.calculate_size(this.ClientSize.Height - this.navbar_panel.Height, 0.9));
            this.container.Location = new Point((this.ClientSize.Width - this.container.Width) / 2, this.navbar_panel.Bottom + 20);

            this.extention.Top = this.navbar_panel.Bottom;
            this.extention.Left = 0;
            this.extention.Width = this.ClientSize.Width;
            this.extention.Height = this.navbar_panel.Height;

            this.textbox_container.Height = textbox.Height + 10;
            this.textbox_container.Top = this.container.Height - this.textbox_container.Height;
            this.textbox_container.Left = 0;
            this.textbox_container.BringToFront();

            this.send_btn.IconSize = textbox.Height;
            this.send_btn.Top = 5;

            textbox.Multiline = true;
            textbox.WordWrap = true;
            textbox.ScrollBars = RichTextBoxScrollBars.Vertical;
            textbox.RightMargin = 0;
            textbox.Top = 5;

            this.messages_container.Top = 0;
            this.messages_container.Width = container.Width;
            this.messages_container.Height = this.textbox_container.Top;
            this.messages_container.SendToBack();
        }
        /// <summary>
        /// sends the server a exit chat message
        /// closes and exists the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Contact_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                ConnectionManager.security.writeEncrypted(all_messages.EXITCHAT.ToString());

            }
            catch
            {
                ConnectionManager.listening_for_messages = false;
            }
            while (ConnectionManager.listening_for_messages)
            {
                await Task.Delay(10);
            }
            Application.Exit();
        }
        /// <summary>
        /// if the form is not in the minimized state it displays all the controls again with set_components
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Contact_Resize(object sender, EventArgs e)
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
        /// sends the server an exist chat message
        /// calls the UI.logout function to disconnect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void logout_btn_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectionManager.security.writeEncrypted(all_messages.EXITCHAT.ToString());
            }
            catch {
                ConnectionManager.listening_for_messages = false;
            }
            while (ConnectionManager.listening_for_messages)
            {
                await Task.Delay(10);
            }
            UI.logout(this);
        }

        /// <summary>
        /// calls the UI.set_profile_picture function to display the profile picture
        /// displays all the messages from previous conversations
        /// starts activly listening to messages
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Contact_Shown(object sender, EventArgs e)
        {
            Dictionary<string, Control> controls_dict = new Dictionary<string, Control>();
            UI.registerControls(this.Controls, controls_dict);

            async Task get_profile_picture()
            {
                await UI.set_profile_picture(controls_dict);
                await Task.Delay(10);
            }

            async Task get_all_messages()
            {
                try
                {
                    ConnectionManager.security.writeEncrypted(all_messages.MESSAGES.ToString());
                    string message = await Task.Run(() =>
                    {
                        return ConnectionManager.security.readEncrypted();
                    });

                    if (message.StartsWith(all_messages.SUCCESSFULL.ToString()))
                    {
                        message = message.Substring(all_messages.SUCCESSFULL.ToString().Length);
                        List<ChatMessage> messages = JsonSerializer.Deserialize<List<ChatMessage>>(message);
                        foreach (ChatMessage msg in messages)
                        {
                            this.Invoke(new Action(() => { create_message(msg.message, msg.role); }));
                        }
                    }
                }
                catch
                {
                    UI.server_disconnect(contact_background);
                }
            }

            await get_profile_picture();
            await get_all_messages();
            try
            {
                listen_to_messages();
            }
            catch
            {
                UI.server_disconnect(contact_background);
                
            }
            
        }
        /// <summary>
        /// updates the height of the main textbox according to the text inside it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textbox_TextChanged(object sender, EventArgs e)
        {
            int min_height = 30;
            int max_height = 150;
            int margin = 10;

            int lineCount = this.textbox.GetLineFromCharIndex(this.textbox.TextLength) + 1;
            int lineHeight = TextRenderer.MeasureText("A", this.textbox.Font).Height;
            int neededHeight = (lineCount + 1) * lineHeight + margin * 2;

            this.textbox.Top -= Math.Min(Math.Max(neededHeight, min_height), max_height) - this.textbox.Height;
            this.textbox.Height = Math.Min(Math.Max(neededHeight, min_height), max_height);

            this.textbox_container.Height = textbox.Height + 10;
            this.textbox_container.Top = this.container.Height - this.textbox_container.Height;
        }
        /// <summary>
        /// displays a label with the recieved text, in the position and color according to the role
        /// if the role is server then the message will be on the left and in grey
        /// otherwise it would be on the write and in blue
        /// </summary>
        /// <param name="text"></param>
        /// <param name="role"></param>
        private void create_message(string text, string role)
        {
            this.textbox.Text = "";
            List<Label> messages = this.messages_container.Controls.OfType<Label>().ToList();
            Label message = new Label();

            message.AutoSize = false;
            int maxWidth = UI.calculate_size(this.messages_container.Width, 0.4);
            message.MaximumSize = new Size(maxWidth, 0);
            message.Text = text;
            message.Font = home_btn_nav.Font;
            message.Padding = new Padding(10);

            Size preferred = TextRenderer.MeasureText(
                message.Text,
                message.Font,
                new Size(maxWidth - message.Padding.Horizontal, 0),
                TextFormatFlags.WordBreak | TextFormatFlags.TextBoxControl);

            preferred.Width += message.Padding.Horizontal;
            preferred.Height += message.Padding.Vertical;
            message.Size = new Size(preferred.Width, preferred.Height);

            message.BackColor = role.Equals("client") ? Color.FromArgb(57, 161, 249) : Color.FromArgb(229, 229, 234);
            message.ForeColor = role.Equals("client") ? Color.White : Color.Black;

            message.Left = role.Equals("client")
                ? container.Width - message.Width - SystemInformation.VerticalScrollBarWidth - 10
                : SystemInformation.VerticalScrollBarWidth + 10;

            message.Top = messages.Count == 0 ? 10 : messages[messages.Count - 1].Bottom + 10;

            message.Parent = this.container;
            UI.RoundCorners(message, Math.Min(20, message.Height / 2), message.BackColor, 1);
            this.messages_container.Controls.Add(message);
        }
        /// <summary>
        /// opens a thread that activly listens to messages from the server
        /// the thread is active until the user leaves the app, goes to a new form or closes the window
        /// if the message recieved starts with chat then it will be displayed on the screen
        /// </summary>
        private void listen_to_messages()
        {
            ConnectionManager.listening_for_messages = true;

            UI.startThread(new Action(() =>
            {
                while (ConnectionManager.listening_for_messages)
                {
                    string message = ConnectionManager.security.readEncrypted();
                    if (message != null)
                    {
                        if (message.Equals(all_messages.EXITCHAT.ToString()))
                        {
                            ConnectionManager.listening_for_messages = false;
                        }
                        else if (message.StartsWith(all_messages.CHAT.ToString()))
                        {
                            message = message.Replace(all_messages.CHAT.ToString(), "");
                            ChatMessage msg = JsonSerializer.Deserialize<ChatMessage>(message);

                            if (ConnectionManager.listening_for_messages)
                                this.Invoke(new Action(() => { create_message(msg.message, msg.role); }));
                        }
                    }
                }
            }));
        }
        /// <summary>
        /// if the message is not empty it will be sent to the server and displayed on the client's screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void send_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.textbox.Text) || string.IsNullOrWhiteSpace(this.textbox.Text)) return;
            try
            {
                ConnectionManager.security.writeEncrypted($"{all_messages.CHAT.ToString()}{JsonSerializer.Serialize(new ChatMessage(this.textbox.Text, "client"))}");

            }
            catch
            {
                UI.server_disconnect(contact_background);
            }
            this.Invoke(new Action(() => { create_message(this.textbox.Text, "client"); }));
        }

        
    }
}