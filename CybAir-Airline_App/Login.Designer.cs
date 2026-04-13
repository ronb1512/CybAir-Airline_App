namespace CybAir_Airline_App
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.login_background = new System.Windows.Forms.Panel();
            this.error_label = new System.Windows.Forms.Label();
            this.navbar_panel = new System.Windows.Forms.Panel();
            this.logout_btn = new FontAwesome.Sharp.IconButton();
            this.name_label = new System.Windows.Forms.Label();
            this.profile_picture = new FontAwesome.Sharp.IconButton();
            this.log_in_btn_nav = new System.Windows.Forms.Button();
            this.airline_logo = new System.Windows.Forms.Panel();
            this.home_btn_nav = new System.Windows.Forms.Button();
            this.about_btn_nav = new System.Windows.Forms.Button();
            this.flights_btn_nav = new System.Windows.Forms.Button();
            this.my_bookings_btn_nav = new System.Windows.Forms.Button();
            this.contact_btn_nav = new System.Windows.Forms.Button();
            this.login_form = new System.Windows.Forms.Panel();
            this.no_account_btn = new System.Windows.Forms.Button();
            this.no_account_label = new System.Windows.Forms.Label();
            this.login_header = new System.Windows.Forms.Label();
            this.login_btn = new FontAwesome.Sharp.IconButton();
            this.textbox_container2 = new System.Windows.Forms.Panel();
            this.password_icon = new FontAwesome.Sharp.IconPictureBox();
            this.Password_textbox = new Krypton.Toolkit.KryptonTextBox();
            this.textbox_container1 = new System.Windows.Forms.Panel();
            this.email_icon = new FontAwesome.Sharp.IconPictureBox();
            this.Email_textbox = new Krypton.Toolkit.KryptonTextBox();
            this.dummy_btn = new System.Windows.Forms.Button();
            this.login_background.SuspendLayout();
            this.navbar_panel.SuspendLayout();
            this.login_form.SuspendLayout();
            this.textbox_container2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.password_icon)).BeginInit();
            this.textbox_container1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.email_icon)).BeginInit();
            this.SuspendLayout();
            // 
            // login_background
            // 
            this.login_background.BackColor = System.Drawing.SystemColors.ControlLight;
            this.login_background.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("login_background.BackgroundImage")));
            this.login_background.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.login_background.Controls.Add(this.logout_btn);
            this.login_background.Controls.Add(this.error_label);
            this.login_background.Controls.Add(this.navbar_panel);
            this.login_background.Controls.Add(this.login_form);
            this.login_background.Dock = System.Windows.Forms.DockStyle.Fill;
            this.login_background.Location = new System.Drawing.Point(0, 0);
            this.login_background.Name = "login_background";
            this.login_background.Size = new System.Drawing.Size(787, 426);
            this.login_background.TabIndex = 0;
            // 
            // error_label
            // 
            this.error_label.AutoSize = true;
            this.error_label.BackColor = System.Drawing.Color.White;
            this.error_label.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.error_label.ForeColor = System.Drawing.Color.Red;
            this.error_label.Location = new System.Drawing.Point(423, 327);
            this.error_label.Name = "error_label";
            this.error_label.Padding = new System.Windows.Forms.Padding(20);
            this.error_label.Size = new System.Drawing.Size(364, 90);
            this.error_label.TabIndex = 12;
            this.error_label.Text = "User already exists";
            // 
            // navbar_panel
            // 
            this.navbar_panel.BackColor = System.Drawing.Color.Transparent;
            this.navbar_panel.Controls.Add(this.name_label);
            this.navbar_panel.Controls.Add(this.profile_picture);
            this.navbar_panel.Controls.Add(this.log_in_btn_nav);
            this.navbar_panel.Controls.Add(this.airline_logo);
            this.navbar_panel.Controls.Add(this.home_btn_nav);
            this.navbar_panel.Controls.Add(this.about_btn_nav);
            this.navbar_panel.Controls.Add(this.flights_btn_nav);
            this.navbar_panel.Controls.Add(this.my_bookings_btn_nav);
            this.navbar_panel.Controls.Add(this.contact_btn_nav);
            this.navbar_panel.Location = new System.Drawing.Point(0, 0);
            this.navbar_panel.Name = "navbar_panel";
            this.navbar_panel.Size = new System.Drawing.Size(796, 85);
            this.navbar_panel.TabIndex = 10;
            // 
            // logout_btn
            // 
            this.logout_btn.AutoSize = true;
            this.logout_btn.BackColor = System.Drawing.Color.White;
            this.logout_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logout_btn.FlatAppearance.BorderSize = 0;
            this.logout_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logout_btn.ForeColor = System.Drawing.Color.Red;
            this.logout_btn.IconChar = FontAwesome.Sharp.IconChar.RightFromBracket;
            this.logout_btn.IconColor = System.Drawing.Color.Red;
            this.logout_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.logout_btn.IconSize = 12;
            this.logout_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.logout_btn.Location = new System.Drawing.Point(703, 102);
            this.logout_btn.Name = "logout_btn";
            this.logout_btn.Size = new System.Drawing.Size(75, 23);
            this.logout_btn.TabIndex = 19;
            this.logout_btn.Text = "Log Out";
            this.logout_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.logout_btn.UseVisualStyleBackColor = false;
            this.logout_btn.Visible = false;
            this.logout_btn.Click += new System.EventHandler(this.logout_btn_Click);
            // 
            // name_label
            // 
            this.name_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.name_label.AutoSize = true;
            this.name_label.ForeColor = System.Drawing.Color.White;
            this.name_label.Location = new System.Drawing.Point(725, 76);
            this.name_label.Name = "name_label";
            this.name_label.Size = new System.Drawing.Size(34, 13);
            this.name_label.TabIndex = 21;
            this.name_label.Text = "Hello!";
            this.name_label.Visible = false;
            // 
            // profile_picture
            // 
            this.profile_picture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.profile_picture.BackColor = System.Drawing.SystemColors.ControlDark;
            this.profile_picture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.profile_picture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.profile_picture.FlatAppearance.BorderSize = 0;
            this.profile_picture.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
            this.profile_picture.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark;
            this.profile_picture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.profile_picture.IconChar = FontAwesome.Sharp.IconChar.UserAlt;
            this.profile_picture.IconColor = System.Drawing.Color.WhiteSmoke;
            this.profile_picture.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.profile_picture.IconSize = 55;
            this.profile_picture.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.profile_picture.Location = new System.Drawing.Point(703, 0);
            this.profile_picture.Margin = new System.Windows.Forms.Padding(0);
            this.profile_picture.Name = "profile_picture";
            this.profile_picture.Size = new System.Drawing.Size(84, 70);
            this.profile_picture.TabIndex = 20;
            this.profile_picture.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.profile_picture.UseVisualStyleBackColor = false;
            this.profile_picture.Visible = false;
            // 
            // log_in_btn_nav
            // 
            this.log_in_btn_nav.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.log_in_btn_nav.AutoSize = true;
            this.log_in_btn_nav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(157)))));
            this.log_in_btn_nav.Cursor = System.Windows.Forms.Cursors.Hand;
            this.log_in_btn_nav.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(157)))));
            this.log_in_btn_nav.FlatAppearance.BorderSize = 0;
            this.log_in_btn_nav.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.log_in_btn_nav.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.log_in_btn_nav.ForeColor = System.Drawing.Color.White;
            this.log_in_btn_nav.Location = new System.Drawing.Point(707, 19);
            this.log_in_btn_nav.Name = "log_in_btn_nav";
            this.log_in_btn_nav.Padding = new System.Windows.Forms.Padding(2);
            this.log_in_btn_nav.Size = new System.Drawing.Size(68, 31);
            this.log_in_btn_nav.TabIndex = 8;
            this.log_in_btn_nav.Text = "Log In";
            this.log_in_btn_nav.UseVisualStyleBackColor = false;
            // 
            // airline_logo
            // 
            this.airline_logo.BackColor = System.Drawing.Color.Transparent;
            this.airline_logo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("airline_logo.BackgroundImage")));
            this.airline_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.airline_logo.Location = new System.Drawing.Point(29, 10);
            this.airline_logo.Name = "airline_logo";
            this.airline_logo.Size = new System.Drawing.Size(155, 66);
            this.airline_logo.TabIndex = 3;
            // 
            // home_btn_nav
            // 
            this.home_btn_nav.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.home_btn_nav.AutoSize = true;
            this.home_btn_nav.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.home_btn_nav.BackColor = System.Drawing.Color.Transparent;
            this.home_btn_nav.Cursor = System.Windows.Forms.Cursors.Hand;
            this.home_btn_nav.FlatAppearance.BorderSize = 0;
            this.home_btn_nav.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.home_btn_nav.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.home_btn_nav.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.home_btn_nav.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.home_btn_nav.ForeColor = System.Drawing.Color.White;
            this.home_btn_nav.Location = new System.Drawing.Point(333, 34);
            this.home_btn_nav.Name = "home_btn_nav";
            this.home_btn_nav.Size = new System.Drawing.Size(50, 25);
            this.home_btn_nav.TabIndex = 2;
            this.home_btn_nav.Text = "Home";
            this.home_btn_nav.UseVisualStyleBackColor = false;
            // 
            // about_btn_nav
            // 
            this.about_btn_nav.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.about_btn_nav.AutoSize = true;
            this.about_btn_nav.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.about_btn_nav.BackColor = System.Drawing.Color.Transparent;
            this.about_btn_nav.Cursor = System.Windows.Forms.Cursors.Hand;
            this.about_btn_nav.FlatAppearance.BorderSize = 0;
            this.about_btn_nav.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.about_btn_nav.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.about_btn_nav.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.about_btn_nav.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.about_btn_nav.ForeColor = System.Drawing.Color.White;
            this.about_btn_nav.Location = new System.Drawing.Point(389, 34);
            this.about_btn_nav.Name = "about_btn_nav";
            this.about_btn_nav.Size = new System.Drawing.Size(50, 25);
            this.about_btn_nav.TabIndex = 3;
            this.about_btn_nav.Text = "About";
            this.about_btn_nav.UseVisualStyleBackColor = false;
            // 
            // flights_btn_nav
            // 
            this.flights_btn_nav.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.flights_btn_nav.AutoSize = true;
            this.flights_btn_nav.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flights_btn_nav.BackColor = System.Drawing.Color.Transparent;
            this.flights_btn_nav.Cursor = System.Windows.Forms.Cursors.Hand;
            this.flights_btn_nav.FlatAppearance.BorderSize = 0;
            this.flights_btn_nav.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.flights_btn_nav.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.flights_btn_nav.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.flights_btn_nav.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.flights_btn_nav.ForeColor = System.Drawing.Color.White;
            this.flights_btn_nav.Location = new System.Drawing.Point(445, 34);
            this.flights_btn_nav.Name = "flights_btn_nav";
            this.flights_btn_nav.Size = new System.Drawing.Size(52, 25);
            this.flights_btn_nav.TabIndex = 6;
            this.flights_btn_nav.Text = "Flights";
            this.flights_btn_nav.UseVisualStyleBackColor = false;
            // 
            // my_bookings_btn_nav
            // 
            this.my_bookings_btn_nav.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.my_bookings_btn_nav.AutoSize = true;
            this.my_bookings_btn_nav.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.my_bookings_btn_nav.BackColor = System.Drawing.Color.Transparent;
            this.my_bookings_btn_nav.Cursor = System.Windows.Forms.Cursors.Hand;
            this.my_bookings_btn_nav.FlatAppearance.BorderSize = 0;
            this.my_bookings_btn_nav.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.my_bookings_btn_nav.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.my_bookings_btn_nav.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.my_bookings_btn_nav.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.my_bookings_btn_nav.ForeColor = System.Drawing.Color.White;
            this.my_bookings_btn_nav.Location = new System.Drawing.Point(503, 34);
            this.my_bookings_btn_nav.Name = "my_bookings_btn_nav";
            this.my_bookings_btn_nav.Size = new System.Drawing.Size(86, 25);
            this.my_bookings_btn_nav.TabIndex = 4;
            this.my_bookings_btn_nav.Text = "My Bookings";
            this.my_bookings_btn_nav.UseVisualStyleBackColor = false;
            // 
            // contact_btn_nav
            // 
            this.contact_btn_nav.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.contact_btn_nav.AutoSize = true;
            this.contact_btn_nav.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.contact_btn_nav.BackColor = System.Drawing.Color.Transparent;
            this.contact_btn_nav.Cursor = System.Windows.Forms.Cursors.Hand;
            this.contact_btn_nav.FlatAppearance.BorderSize = 0;
            this.contact_btn_nav.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.contact_btn_nav.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.contact_btn_nav.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.contact_btn_nav.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.contact_btn_nav.ForeColor = System.Drawing.Color.White;
            this.contact_btn_nav.Location = new System.Drawing.Point(595, 34);
            this.contact_btn_nav.Name = "contact_btn_nav";
            this.contact_btn_nav.Size = new System.Drawing.Size(59, 25);
            this.contact_btn_nav.TabIndex = 5;
            this.contact_btn_nav.Text = "Contact";
            this.contact_btn_nav.UseVisualStyleBackColor = false;
            // 
            // login_form
            // 
            this.login_form.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.login_form.BackColor = System.Drawing.Color.White;
            this.login_form.Controls.Add(this.no_account_btn);
            this.login_form.Controls.Add(this.no_account_label);
            this.login_form.Controls.Add(this.login_header);
            this.login_form.Controls.Add(this.login_btn);
            this.login_form.Controls.Add(this.textbox_container2);
            this.login_form.Controls.Add(this.textbox_container1);
            this.login_form.Location = new System.Drawing.Point(220, 91);
            this.login_form.Name = "login_form";
            this.login_form.Size = new System.Drawing.Size(321, 320);
            this.login_form.TabIndex = 0;
            // 
            // no_account_btn
            // 
            this.no_account_btn.AutoSize = true;
            this.no_account_btn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.no_account_btn.BackColor = System.Drawing.Color.Transparent;
            this.no_account_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.no_account_btn.FlatAppearance.BorderSize = 0;
            this.no_account_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.no_account_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.no_account_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.no_account_btn.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.no_account_btn.Location = new System.Drawing.Point(207, 279);
            this.no_account_btn.Name = "no_account_btn";
            this.no_account_btn.Size = new System.Drawing.Size(73, 30);
            this.no_account_btn.TabIndex = 9;
            this.no_account_btn.Text = "Sign Up";
            this.no_account_btn.UseVisualStyleBackColor = false;
            // 
            // no_account_label
            // 
            this.no_account_label.AutoSize = true;
            this.no_account_label.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.no_account_label.Location = new System.Drawing.Point(23, 285);
            this.no_account_label.Name = "no_account_label";
            this.no_account_label.Size = new System.Drawing.Size(187, 20);
            this.no_account_label.TabIndex = 8;
            this.no_account_label.Text = "Don\'t have an account yet?";
            // 
            // login_header
            // 
            this.login_header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(25)))), ((int)(((byte)(54)))));
            this.login_header.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.login_header.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.login_header.ForeColor = System.Drawing.Color.White;
            this.login_header.Location = new System.Drawing.Point(111, -9);
            this.login_header.Name = "login_header";
            this.login_header.Size = new System.Drawing.Size(99, 64);
            this.login_header.TabIndex = 7;
            this.login_header.Text = "Login";
            this.login_header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // login_btn
            // 
            this.login_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(25)))), ((int)(((byte)(54)))));
            this.login_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.login_btn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(25)))), ((int)(((byte)(54)))));
            this.login_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(25)))), ((int)(((byte)(54)))));
            this.login_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(25)))), ((int)(((byte)(54)))));
            this.login_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.login_btn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.login_btn.ForeColor = System.Drawing.Color.White;
            this.login_btn.IconChar = FontAwesome.Sharp.IconChar.None;
            this.login_btn.IconColor = System.Drawing.Color.Black;
            this.login_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.login_btn.Location = new System.Drawing.Point(47, 232);
            this.login_btn.Name = "login_btn";
            this.login_btn.Size = new System.Drawing.Size(227, 38);
            this.login_btn.TabIndex = 6;
            this.login_btn.Text = "Sign In";
            this.login_btn.UseVisualStyleBackColor = false;
            this.login_btn.Click += new System.EventHandler(this.login_btn_Click);
            // 
            // textbox_container2
            // 
            this.textbox_container2.AutoSize = true;
            this.textbox_container2.Controls.Add(this.password_icon);
            this.textbox_container2.Controls.Add(this.Password_textbox);
            this.textbox_container2.Location = new System.Drawing.Point(47, 156);
            this.textbox_container2.Name = "textbox_container2";
            this.textbox_container2.Size = new System.Drawing.Size(227, 52);
            this.textbox_container2.TabIndex = 3;
            // 
            // password_icon
            // 
            this.password_icon.BackColor = System.Drawing.Color.Transparent;
            this.password_icon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.password_icon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(84)))));
            this.password_icon.IconChar = FontAwesome.Sharp.IconChar.Lock;
            this.password_icon.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(84)))));
            this.password_icon.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.password_icon.IconSize = 27;
            this.password_icon.Location = new System.Drawing.Point(195, 3);
            this.password_icon.Name = "password_icon";
            this.password_icon.Size = new System.Drawing.Size(29, 27);
            this.password_icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.password_icon.TabIndex = 3;
            this.password_icon.TabStop = false;
            this.password_icon.Click += new System.EventHandler(this.password_icon_Click);
            // 
            // Password_textbox
            // 
            this.Password_textbox.AlwaysActive = false;
            this.Password_textbox.CueHint.Color1 = System.Drawing.Color.Gray;
            this.Password_textbox.CueHint.CueHintText = "Password";
            this.Password_textbox.CueHint.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Password_textbox.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.Password_textbox.Location = new System.Drawing.Point(3, 3);
            this.Password_textbox.Name = "Password_textbox";
            this.Password_textbox.PasswordChar = '●';
            this.Password_textbox.Size = new System.Drawing.Size(218, 46);
            this.Password_textbox.StateActive.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Password_textbox.StateActive.Content.Padding = new System.Windows.Forms.Padding(5, 5, 40, 5);
            this.Password_textbox.StateCommon.Border.Color1 = System.Drawing.Color.Silver;
            this.Password_textbox.StateCommon.Border.Color2 = System.Drawing.Color.Silver;
            this.Password_textbox.StateCommon.Border.Rounding = 20F;
            this.Password_textbox.StateCommon.Border.Width = 1;
            this.Password_textbox.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            this.Password_textbox.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password_textbox.StateCommon.Content.Padding = new System.Windows.Forms.Padding(5, 5, 40, 5);
            this.Password_textbox.TabIndex = 2;
            this.Password_textbox.WordWrap = false;
            this.Password_textbox.Enter += new System.EventHandler(this.textbox_focus);
            this.Password_textbox.Leave += new System.EventHandler(this.textbox_leave);
            // 
            // textbox_container1
            // 
            this.textbox_container1.AutoSize = true;
            this.textbox_container1.Controls.Add(this.email_icon);
            this.textbox_container1.Controls.Add(this.Email_textbox);
            this.textbox_container1.Location = new System.Drawing.Point(47, 75);
            this.textbox_container1.Name = "textbox_container1";
            this.textbox_container1.Size = new System.Drawing.Size(230, 52);
            this.textbox_container1.TabIndex = 2;
            // 
            // email_icon
            // 
            this.email_icon.BackColor = System.Drawing.Color.Transparent;
            this.email_icon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(84)))));
            this.email_icon.IconChar = FontAwesome.Sharp.IconChar.Envelope;
            this.email_icon.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(84)))));
            this.email_icon.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.email_icon.IconSize = 27;
            this.email_icon.Location = new System.Drawing.Point(198, 0);
            this.email_icon.Name = "email_icon";
            this.email_icon.Size = new System.Drawing.Size(29, 27);
            this.email_icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.email_icon.TabIndex = 3;
            this.email_icon.TabStop = false;
            // 
            // Email_textbox
            // 
            this.Email_textbox.AlwaysActive = false;
            this.Email_textbox.CueHint.Color1 = System.Drawing.Color.Gray;
            this.Email_textbox.CueHint.CueHintText = "Email";
            this.Email_textbox.CueHint.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Email_textbox.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.Email_textbox.Location = new System.Drawing.Point(3, 3);
            this.Email_textbox.Name = "Email_textbox";
            this.Email_textbox.Size = new System.Drawing.Size(218, 46);
            this.Email_textbox.StateActive.Border.Color1 = System.Drawing.Color.Silver;
            this.Email_textbox.StateActive.Border.Color2 = System.Drawing.Color.Silver;
            this.Email_textbox.StateActive.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.Email_textbox.StateActive.Border.Rounding = 20F;
            this.Email_textbox.StateActive.Border.Width = 1;
            this.Email_textbox.StateActive.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Email_textbox.StateActive.Content.Padding = new System.Windows.Forms.Padding(5, 5, 40, 5);
            this.Email_textbox.StateCommon.Border.Color1 = System.Drawing.Color.Silver;
            this.Email_textbox.StateCommon.Border.Color2 = System.Drawing.Color.Silver;
            this.Email_textbox.StateCommon.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.Email_textbox.StateCommon.Border.Rounding = 20F;
            this.Email_textbox.StateCommon.Border.Width = 1;
            this.Email_textbox.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            this.Email_textbox.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Email_textbox.StateCommon.Content.Padding = new System.Windows.Forms.Padding(5, 5, 40, 5);
            this.Email_textbox.StateNormal.Border.Color1 = System.Drawing.Color.Silver;
            this.Email_textbox.StateNormal.Border.Color2 = System.Drawing.Color.Silver;
            this.Email_textbox.StateNormal.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.Email_textbox.StateNormal.Border.Rounding = 20F;
            this.Email_textbox.StateNormal.Border.Width = 1;
            this.Email_textbox.TabIndex = 2;
            this.Email_textbox.WordWrap = false;
            this.Email_textbox.Enter += new System.EventHandler(this.textbox_focus);
            this.Email_textbox.Leave += new System.EventHandler(this.textbox_leave);
            // 
            // dummy_btn
            // 
            this.dummy_btn.Location = new System.Drawing.Point(40, 311);
            this.dummy_btn.Name = "dummy_btn";
            this.dummy_btn.Size = new System.Drawing.Size(32, 17);
            this.dummy_btn.TabIndex = 1;
            this.dummy_btn.TabStop = false;
            this.dummy_btn.Text = "button1";
            this.dummy_btn.UseVisualStyleBackColor = true;
            this.dummy_btn.Visible = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 426);
            this.Controls.Add(this.dummy_btn);
            this.Controls.Add(this.login_background);
            this.Name = "Login";
            this.Text = "Login";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formClosed);
            this.Load += new System.EventHandler(this.Login_Load);
            this.Shown += new System.EventHandler(this.Login_Shown);
            this.Resize += new System.EventHandler(this.Login_Resize);
            this.login_background.ResumeLayout(false);
            this.login_background.PerformLayout();
            this.navbar_panel.ResumeLayout(false);
            this.navbar_panel.PerformLayout();
            this.login_form.ResumeLayout(false);
            this.login_form.PerformLayout();
            this.textbox_container2.ResumeLayout(false);
            this.textbox_container2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.password_icon)).EndInit();
            this.textbox_container1.ResumeLayout(false);
            this.textbox_container1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.email_icon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel login_background;
        private System.Windows.Forms.Panel login_form;
        private System.Windows.Forms.Button dummy_btn;
        private System.Windows.Forms.Panel textbox_container1;
        private FontAwesome.Sharp.IconPictureBox email_icon;
        private Krypton.Toolkit.KryptonTextBox Email_textbox;
        private System.Windows.Forms.Panel textbox_container2;
        private FontAwesome.Sharp.IconPictureBox password_icon;
        private Krypton.Toolkit.KryptonTextBox Password_textbox;
        private FontAwesome.Sharp.IconButton login_btn;
        private System.Windows.Forms.Label login_header;
        private System.Windows.Forms.Panel navbar_panel;
        private System.Windows.Forms.Button log_in_btn_nav;
        private System.Windows.Forms.Panel airline_logo;
        private System.Windows.Forms.Button home_btn_nav;
        private System.Windows.Forms.Button about_btn_nav;
        private System.Windows.Forms.Button flights_btn_nav;
        private System.Windows.Forms.Button contact_btn_nav;
        private System.Windows.Forms.Button my_bookings_btn_nav;
        private System.Windows.Forms.Button no_account_btn;
        private System.Windows.Forms.Label no_account_label;
        private System.Windows.Forms.Label error_label;
        private FontAwesome.Sharp.IconButton logout_btn;
        private System.Windows.Forms.Label name_label;
        private FontAwesome.Sharp.IconButton profile_picture;
    }
}