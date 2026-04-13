using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
//using static System.Net.Mime.MediaTypeNames;
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Net.Mail;
using System.Diagnostics;
using static CybAir_Airline_App.Data;
using System.Runtime.ConstrainedExecution;
using System.Windows.Shapes;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Drawing.Imaging;
using static System.Windows.Forms.LinkLabel;
using CsvHelper;
using System.Globalization;
using System.Windows.Interop;
using SkiaSharp;
using FontAwesome.Sharp;
using System.Security.Cryptography;
using System.Collections.Concurrent;


namespace CybAir_Airline_App
{

    public partial class Server : Form
    {
        public static readonly int port = 6000;
        public static readonly string IP = Dns.GetHostEntry(Dns.GetHostName()).AddressList.First(ip => ip.AddressFamily == AddressFamily.InterNetwork).ToString();
        public static CancellationTokenSource is_running = new CancellationTokenSource();
        public static readonly string users_file_path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Users.json");
        public static readonly string active_flights_path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "ActiveFlights.json");
        public static readonly RSA rsa = RSA.Create(2048);
        public static Queue<DateTime>connection_tracker = new Queue<DateTime>();
        public static int connections_limit = 5;
        public static List<ClientHandler> all_clients_handlers = new List<ClientHandler>();
        public static User current_chat_user { get; set; }
        /// <summary>
        /// the constructor sets the rendering options
        /// </summary>
        public Server()
        {
            
            InitializeComponent();
        }
        /// <summary>
        /// sets the screen size and call the set_components function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void Server_Load(object sender, EventArgs e)
        {
            UDP.denyOthers();
            TcpListener listener = new TcpListener(IPAddress.Any, port);
            listener.Server.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            listener.Start();
            UI.startThread(() =>
            {
                while (!is_running.IsCancellationRequested)
                {
                    
                    ClientHandler clientHandler = new ClientHandler(listener.AcceptTcpClient(), this);
                    all_clients_handlers.Add(clientHandler);
                }
            });
            
            this.FormClosed += formClosed;
            this.Size = new Size(
                UI.calculate_size(Screen.PrimaryScreen.WorkingArea.Width, 0.7),
                UI.calculate_size(Screen.PrimaryScreen.WorkingArea.Height, 0.75));
            set_components();
        }
        /// <summary>
        /// sets the style for all the different UI controls in the form relative to 
        /// the screen size
        /// </summary>
        private void set_components()
        {
            this.extention.Width = this.ClientSize.Width;
            this.extention.Height = UI.calculate_size(this.ClientSize.Height, 0.15);
            this.extention.Location = new Point(0, 0);
            this.dummy_btn.Select();
            UI.AttachClickHandlers(this.Controls);

            this.container.Size = new Size(UI.calculate_size(this.ClientSize.Width, 0.8), UI.calculate_size(this.ClientSize.Height - this.extention.Height/2, 0.9));
            this.container.Location = new Point(this.ClientSize.Width - this.container.Width-20, this.extention.Height/2 + 20);
            

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

            this.users_container.Parent = this.server_background;
            this.users_container.Size = new Size(this.container.Left-20, container.Height);
            this.users_container.Location = new Point(this.container.Left - this.users_container.Width, this.container.Top);
            
            
            

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
            Debug.WriteLine(neededHeight);
            this.textbox.Top -= Math.Min(Math.Max(neededHeight, min_height), max_height) - this.textbox.Height;
            this.textbox.Height = Math.Min(Math.Max(neededHeight, min_height), max_height);
            this.textbox_container.Height = textbox.Height + 10;
            this.textbox_container.Top = this.container.Height - this.textbox_container.Height;

        }
        /// <summary>
        /// closes and exists the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void formClosed(object sender, EventArgs e)
        {
            is_running.Cancel();
            Application.Exit();
            all_clients_handlers.ForEach(h =>
            {
                h.tcpClient.Close();
                h.user = null;
                h.is_user_active.Cancel();
            });
        }

        /// <summary>
        /// creates a panel for every user that contains the profile picture, name, and email for the server
        /// to be able to identify the user and make changes if needed
        /// </summary>
        /// <param name="u"></param>
        /// <param name="form"></param>
        public void create_chat_user(User u,Server form)
        {

            Panel user_chat = new Panel();
            user_chat.Width = form.users_container.Width;
            user_chat.Height = form.users_container.Height / 10;
            user_chat.Left = 0;
            List<Panel> panels = form.users_container.Controls.OfType<Panel>().ToList();
            user_chat.BackColor = Color.Transparent;
            user_chat.BorderStyle = BorderStyle.FixedSingle;
            user_chat.AutoScroll = true;
            user_chat.VerticalScroll.Visible = false;
            user_chat.Cursor = Cursors.Hand;
            //if the panel is clicked then the chat with the user is opened and all the previous messages are
            //displayd with create_message
            //if the server has notifications from the server, they get removed
            user_chat.Click += (sender, e) =>
            {
                List<User>users = Users.get_users(users_file_path);

                foreach (User u2 in users)
                {
                    if (u2.email.Equals(u.email, StringComparison.OrdinalIgnoreCase))
                    {
                        current_chat_user = u2;  
                    }
                }
                List<Label> labels = user_chat.Controls.OfType<Label>().ToList();
                if (labels.Count > 1)
                {
                    labels[1].Dispose();
                }
                form.messages_container.Controls.Clear();
                //displays the actual chat
                void setup()
                {
                    IconPictureBox profile_picture_main = new IconPictureBox();
                    
                    profile_picture_main.Parent = form.messages_container;
                    profile_picture_main.Left = (form.messages_container.Width - profile_picture_main.Width) / 2;
                    profile_picture_main.Height = UI.calculate_size(form.messages_container.Height, 0.15);
                    profile_picture_main.Width = profile_picture_main.Height;
                    profile_picture_main.Top = 10;
                    profile_picture_main.BackgroundImageLayout = ImageLayout.Stretch;

                    UI.RoundCorners(profile_picture_main, profile_picture_main.Height, Color.White, 1);
                    Image img2;
                    if (u.profile_picture == null)
                    {
                        profile_picture_main.IconChar = IconChar.UserAlt;
                        profile_picture_main.BackColor = SystemColors.ControlDark;
                        profile_picture_main.IconColor = Color.WhiteSmoke;
                        profile_picture_main.IconSize = UI.calculate_size(profile_picture_main.Height, 0.8);
                        profile_picture_main.SizeMode = PictureBoxSizeMode.CenterImage;

                    }
                    else
                    {
                        using (MemoryStream ms = new MemoryStream(u.profile_picture))
                        {
                            img2 = Image.FromStream(ms);
                            img2 = (Image)img2.Clone();
                        }
                        profile_picture_main.BackgroundImage = img2;
                    }
                    form.messages_container.Controls.Add(profile_picture_main);
                    Label l = new Label();
                    l.Parent = messages_container;
                    l.AutoSize = true;
                    l.Text = $"{u.name}\n{u.email}";
                    l.TextAlign = ContentAlignment.MiddleCenter;
                    l.Font = new Font("Segoe UI", 16);
                    l.ForeColor = Color.Black;
                    l.Left = profile_picture_main.Left;
                    l.Top = profile_picture_main.Bottom + 10;
                    form.messages_container.Controls.Add(l);


                }
                setup();
                u = Users.get_user(users, u.email);
                foreach (ChatMessage msg in u.chat_messages)
                {
                    create_message(msg.message, msg.role, form);
                }
                List<Label> messages = form.messages_container.Controls.OfType<Label>().ToList();

            };

            if (panels.Count == 0)
                user_chat.Top = 0;
            else user_chat.Top = panels[panels.Count - 1].Bottom;
            form.users_container.Controls.Add(user_chat);

            IconPictureBox profile_picture = new IconPictureBox();
            profile_picture.Parent = user_chat;
            profile_picture.Left = user_chat.Width / 20;
            profile_picture.Height = UI.calculate_size(user_chat.Height, 0.8);
            profile_picture.Width = profile_picture.Height;
            profile_picture.Top = (user_chat.Height - profile_picture.Height) / 2;
            profile_picture.BackgroundImageLayout = ImageLayout.Stretch;

            UI.RoundCorners(profile_picture, profile_picture.Height, Color.Black, 1);
            Image img;
            if (u.profile_picture == null)
            {
                profile_picture.IconChar = IconChar.UserAlt;
                profile_picture.BackColor = SystemColors.ControlDark;
                profile_picture.IconColor = Color.WhiteSmoke;
                profile_picture.IconSize = UI.calculate_size(profile_picture.Height, 0.8);
                profile_picture.SizeMode = PictureBoxSizeMode.CenterImage;
            }
            else
            {
                using (MemoryStream ms = new MemoryStream(u.profile_picture))
                {
                    img = Image.FromStream(ms);
                    img = (Image)img.Clone();
                }
                profile_picture.BackgroundImage = img;
            }
            user_chat.Controls.Add(profile_picture);

            Label data = new Label();
            data.AutoSize = true;
            data.Text = $"{u.name}\n{u.email}";
            data.TextAlign = ContentAlignment.MiddleCenter;
            data.Font = new Font("Segoe UI", 12);
            data.ForeColor = Color.Black;
            data.Left = profile_picture.Right + 2;
            data.Top = user_chat.Height / 20;
            user_chat.Controls.Add(data);

        }
        /// <summary>
        /// displays a label with the recieved text, in the position and color according to the role
        /// if the role is client then the message will be on the left and in grey
        /// otherwise it would be on the write and in blue
        /// </summary>
        /// <param name="text"></param>
        /// <param name="role"></param>
        /// <param name="form"></param>
        public void create_message(string text, string role,Server form)
        {

            if (role.Equals("server"))
                form.textbox.Text = "";
            List<Label> messages = form.messages_container.Controls.OfType<Label>().ToList();

            Label message = new Label();
            message.AutoSize = false;
            int maxWidth = UI.calculate_size(form.messages_container.Width, 0.4);
            message.MaximumSize = new Size(maxWidth, 0);
            message.Text = text;
            Font btn_font = new Font("Segoe UI", UI.calculate_size(form.ClientSize.Width, 0.013));
            if (btn_font.Size > 15f)
            {
                btn_font = new Font("Segoe UI", 15f);
            }
            message.Font = btn_font;
            message.Padding = new Padding(10);
            Size preferred = TextRenderer.MeasureText(
                message.Text,
                message.Font,
                new Size(maxWidth - message.Padding.Horizontal, 0),
                TextFormatFlags.WordBreak | TextFormatFlags.TextBoxControl
            );
            message.Parent = form.messages_container;
            preferred.Width += message.Padding.Horizontal;
            preferred.Height += message.Padding.Vertical;
            message.Size = new Size(preferred.Width, preferred.Height);
            message.BackColor = role.Equals("server") ? Color.FromArgb(57, 161, 249) : Color.FromArgb(229, 229, 234);
            message.ForeColor = role.Equals("server") ? Color.White : Color.Black;
            message.Left = role.Equals("server") ? form.messages_container.Width - message.Width- SystemInformation.VerticalScrollBarWidth - 10 : 10 + SystemInformation.VerticalScrollBarWidth;
            message.Top = messages.Count == 0 ? 10 : messages[messages.Count - 1].Bottom + 10;
            UI.RoundCorners(message, Math.Min(20, message.Height / 2), message.BackColor, 1);
            form.messages_container.Controls.Add(message);
            
        }
        /// <summary>
        /// identifies the current user, adds the message to the chat data of the user
        /// displays the message on the screen of the server
        /// if the user is online in the chat, the server finds the connection with the server using the OnlineUsersManager class
        /// and sends the message to the client with the TCP connection and the aes encryption
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void send_btn_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(this.textbox.Text) || string.IsNullOrWhiteSpace(this.textbox.Text)) return;
            
            if (current_chat_user == null) return;
            current_chat_user = Users.get_user(Users.get_users(users_file_path),current_chat_user.email);
            Users.remove_user(users_file_path, current_chat_user);
            current_chat_user.chat_messages.Add(new ChatMessage(this.textbox.Text, "server"));
            Users.add_user(current_chat_user, users_file_path);
            if (current_chat_user.chat_online && OnlineUsersManager.Contains(current_chat_user.email))
            {
                
                (TcpClient client,SecurityManager security) = OnlineUsersManager.getConnection(current_chat_user.email);
                if (client != null)
                {
                    ConnectionManager.tcp_client = client;
                    ConnectionManager.tcp_stream = client.GetStream();
                    ConnectionManager.writer = new StreamWriter(ConnectionManager.tcp_stream, new UTF8Encoding(false)) { AutoFlush = true };
                    
                    security.writeEncrypted(all_messages.CHAT.ToString() + JsonSerializer.Serialize(new ChatMessage(this.textbox.Text, "server")));
                }
            }

            create_message(this.textbox.Text, "server", this);

        }
        /// <summary>
        /// finds the panel of the user and updates the notification so the server knows that he got a message
        /// if there is a notification already it adds 1 to the number of new messages
        /// otherwise it creates a new notification with 1 new message
        /// </summary>
        /// <param name="form"></param>
        /// <param name="user"></param>
        public void add_notification(Server form,User user)
        {
            foreach (Control chat_user in form.users_container.Controls)
            {

                List<Label> labels = chat_user.Controls.OfType<Label>().ToList();
                
                    if (labels.Count == 1 && labels[0].Text.Contains(user.email))
                    {
                        
                        Label notification = new Label
                        {
                            Parent = chat_user,
                            AutoSize = true,
                            Text = "1",
                            BackColor = Color.Red,
                            ForeColor = Color.White,
                            Padding = new Padding(2),
                            Font = new Font("Segoe UI", 8)
                        };
                        notification.BringToFront();
                        notification.Location = new Point(chat_user.Width - notification.Width-10, 1);
                        UI.RoundCorners(notification, notification.Height, Color.Red, 1);
                        chat_user.Controls.Add(notification);
                    }
                    else
                    {

                        if (labels[0].Text.Contains(user.email))
                        {
                            labels[1].Text = (int.Parse(labels[1].Text) + 1).ToString();
                            labels[1].BringToFront();
                        }
                    }
            }

        }
        /// <summary>
        /// if the form is not in the minimized state it displays all the controls again with set_components
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Server_Resize(object sender, EventArgs e)
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
        /// displays all the user chats using create_chat_user for each user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Server_Shown(object sender, EventArgs e)
        {
            List<User> users = Users.get_users(users_file_path);
            foreach (User u in users)
            {
                create_chat_user(u, this);
            }
        }
        

        
    }
}
