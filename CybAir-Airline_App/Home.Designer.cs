using System.Windows.Forms;

namespace CybAir_Airline_App
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.Home_panel = new System.Windows.Forms.Panel();
            this.bottom_panel = new System.Windows.Forms.Panel();
            this.move_right_btn = new FontAwesome.Sharp.IconButton();
            this.move_left_btn = new FontAwesome.Sharp.IconButton();
            this.place_cards_container = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.home_background = new System.Windows.Forms.Panel();
            this.logout_btn = new FontAwesome.Sharp.IconButton();
            this.sign_up_btn = new System.Windows.Forms.Button();
            this.learn_more_btn = new System.Windows.Forms.Button();
            this.navbar_panel = new System.Windows.Forms.Panel();
            this.name_label = new System.Windows.Forms.Label();
            this.profile_picture = new FontAwesome.Sharp.IconButton();
            this.log_in_btn_nav = new System.Windows.Forms.Button();
            this.airline_logo = new System.Windows.Forms.Panel();
            this.home_btn_nav = new System.Windows.Forms.Button();
            this.about_btn_nav = new System.Windows.Forms.Button();
            this.flights_btn_nav = new System.Windows.Forms.Button();
            this.my_bookings_btn_nav = new System.Windows.Forms.Button();
            this.contact_btn_nav = new System.Windows.Forms.Button();
            this.Home_panel.SuspendLayout();
            this.bottom_panel.SuspendLayout();
            this.home_background.SuspendLayout();
            this.navbar_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Home_panel
            // 
            this.Home_panel.AutoScroll = true;
            this.Home_panel.BackColor = System.Drawing.Color.White;
            this.Home_panel.Controls.Add(this.bottom_panel);
            this.Home_panel.Controls.Add(this.label5);
            this.Home_panel.Controls.Add(this.label4);
            this.Home_panel.Controls.Add(this.label3);
            this.Home_panel.Controls.Add(this.label2);
            this.Home_panel.Controls.Add(this.label1);
            this.Home_panel.Controls.Add(this.home_background);
            this.Home_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Home_panel.Location = new System.Drawing.Point(0, 0);
            this.Home_panel.MinimumSize = new System.Drawing.Size(400, 400);
            this.Home_panel.Name = "Home_panel";
            this.Home_panel.Size = new System.Drawing.Size(816, 499);
            this.Home_panel.TabIndex = 0;
            // 
            // bottom_panel
            // 
            this.bottom_panel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bottom_panel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bottom_panel.BackgroundImage")));
            this.bottom_panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bottom_panel.Controls.Add(this.move_right_btn);
            this.bottom_panel.Controls.Add(this.move_left_btn);
            this.bottom_panel.Controls.Add(this.place_cards_container);
            this.bottom_panel.Controls.Add(this.label6);
            this.bottom_panel.Location = new System.Drawing.Point(3, 500);
            this.bottom_panel.Name = "bottom_panel";
            this.bottom_panel.Size = new System.Drawing.Size(793, 443);
            this.bottom_panel.TabIndex = 15;
            // 
            // move_right_btn
            // 
            this.move_right_btn.AutoSize = true;
            this.move_right_btn.BackColor = System.Drawing.Color.Transparent;
            this.move_right_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.move_right_btn.FlatAppearance.BorderSize = 0;
            this.move_right_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.move_right_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.move_right_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.move_right_btn.IconChar = FontAwesome.Sharp.IconChar.AngleRight;
            this.move_right_btn.IconColor = System.Drawing.Color.Gray;
            this.move_right_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.move_right_btn.Location = new System.Drawing.Point(685, 229);
            this.move_right_btn.Name = "move_right_btn";
            this.move_right_btn.Size = new System.Drawing.Size(75, 56);
            this.move_right_btn.TabIndex = 5;
            this.move_right_btn.UseVisualStyleBackColor = false;
            this.move_right_btn.Click += new System.EventHandler(this.move_right_btn_Click);
            // 
            // move_left_btn
            // 
            this.move_left_btn.AutoSize = true;
            this.move_left_btn.BackColor = System.Drawing.Color.Transparent;
            this.move_left_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.move_left_btn.FlatAppearance.BorderSize = 0;
            this.move_left_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.move_left_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.move_left_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.move_left_btn.IconChar = FontAwesome.Sharp.IconChar.AngleLeft;
            this.move_left_btn.IconColor = System.Drawing.Color.Gray;
            this.move_left_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.move_left_btn.Location = new System.Drawing.Point(29, 229);
            this.move_left_btn.Name = "move_left_btn";
            this.move_left_btn.Size = new System.Drawing.Size(75, 56);
            this.move_left_btn.TabIndex = 4;
            this.move_left_btn.UseVisualStyleBackColor = false;
            this.move_left_btn.Click += new System.EventHandler(this.move_left_btn_Click);
            // 
            // place_cards_container
            // 
            this.place_cards_container.BackColor = System.Drawing.Color.Transparent;
            this.place_cards_container.Location = new System.Drawing.Point(135, 179);
            this.place_cards_container.Name = "place_cards_container";
            this.place_cards_container.Size = new System.Drawing.Size(523, 232);
            this.place_cards_container.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(127)))));
            this.label6.Location = new System.Drawing.Point(175, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(466, 65);
            this.label6.TabIndex = 0;
            this.label6.Text = "Explore New Places";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(126)))), ((int)(((byte)(126)))));
            this.label5.Location = new System.Drawing.Point(60, 323);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(190, 30);
            this.label5.TabIndex = 12;
            this.label5.Text = "With Our Flights!";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(126)))), ((int)(((byte)(126)))));
            this.label4.Location = new System.Drawing.Point(51, 293);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(215, 30);
            this.label4.TabIndex = 11;
            this.label4.Text = "Discover The World";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(157)))));
            this.label3.Location = new System.Drawing.Point(42, 239);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(224, 54);
            this.label3.TabIndex = 9;
            this.label3.Text = "TAKE-OFF?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(127)))));
            this.label2.Location = new System.Drawing.Point(42, 194);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(241, 54);
            this.label2.TabIndex = 10;
            this.label2.Text = "READY FOR";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(127)))));
            this.label1.Location = new System.Drawing.Point(42, 140);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 54);
            this.label1.TabIndex = 8;
            this.label1.Text = "ARE YOU";
            // 
            // home_background
            // 
            this.home_background.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("home_background.BackgroundImage")));
            this.home_background.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.home_background.Controls.Add(this.logout_btn);
            this.home_background.Controls.Add(this.sign_up_btn);
            this.home_background.Controls.Add(this.learn_more_btn);
            this.home_background.Controls.Add(this.navbar_panel);
            this.home_background.Location = new System.Drawing.Point(0, 0);
            this.home_background.Name = "home_background";
            this.home_background.Size = new System.Drawing.Size(796, 497);
            this.home_background.TabIndex = 2;
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
            this.logout_btn.Location = new System.Drawing.Point(691, 102);
            this.logout_btn.Name = "logout_btn";
            this.logout_btn.Size = new System.Drawing.Size(75, 23);
            this.logout_btn.TabIndex = 10;
            this.logout_btn.Text = "Log Out";
            this.logout_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.logout_btn.UseVisualStyleBackColor = false;
            this.logout_btn.Visible = false;
            this.logout_btn.Click += new System.EventHandler(this.logout_btn_Click);
            // 
            // sign_up_btn
            // 
            this.sign_up_btn.AutoSize = true;
            this.sign_up_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sign_up_btn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(127)))));
            this.sign_up_btn.FlatAppearance.BorderSize = 3;
            this.sign_up_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sign_up_btn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.sign_up_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(127)))));
            this.sign_up_btn.Location = new System.Drawing.Point(175, 377);
            this.sign_up_btn.Name = "sign_up_btn";
            this.sign_up_btn.Size = new System.Drawing.Size(75, 35);
            this.sign_up_btn.TabIndex = 1;
            this.sign_up_btn.Text = "Sign Up";
            this.sign_up_btn.UseVisualStyleBackColor = true;
            // 
            // learn_more_btn
            // 
            this.learn_more_btn.AutoSize = true;
            this.learn_more_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(157)))));
            this.learn_more_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.learn_more_btn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(157)))));
            this.learn_more_btn.FlatAppearance.BorderSize = 0;
            this.learn_more_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.learn_more_btn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.learn_more_btn.ForeColor = System.Drawing.Color.White;
            this.learn_more_btn.Location = new System.Drawing.Point(56, 377);
            this.learn_more_btn.Name = "learn_more_btn";
            this.learn_more_btn.Padding = new System.Windows.Forms.Padding(2);
            this.learn_more_btn.Size = new System.Drawing.Size(87, 35);
            this.learn_more_btn.TabIndex = 0;
            this.learn_more_btn.Text = "Learn More";
            this.learn_more_btn.UseVisualStyleBackColor = false;
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
            this.navbar_panel.Size = new System.Drawing.Size(796, 96);
            this.navbar_panel.TabIndex = 9;
            // 
            // name_label
            // 
            this.name_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.name_label.AutoSize = true;
            this.name_label.ForeColor = System.Drawing.Color.White;
            this.name_label.Location = new System.Drawing.Point(713, 76);
            this.name_label.Name = "name_label";
            this.name_label.Size = new System.Drawing.Size(34, 13);
            this.name_label.TabIndex = 18;
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
            this.profile_picture.Location = new System.Drawing.Point(691, 0);
            this.profile_picture.Margin = new System.Windows.Forms.Padding(0);
            this.profile_picture.Name = "profile_picture";
            this.profile_picture.Size = new System.Drawing.Size(84, 70);
            this.profile_picture.TabIndex = 17;
            this.profile_picture.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.profile_picture.UseVisualStyleBackColor = false;
            this.profile_picture.Visible = false;
            this.profile_picture.Click += new System.EventHandler(this.profile_picture_Click);
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
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(816, 499);
            this.Controls.Add(this.Home_panel);
            this.DoubleBuffered = true;
            this.Name = "Home";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formClosed);
            this.Load += new System.EventHandler(this.Home_Load);
            this.Shown += new System.EventHandler(this.Home_Shown);
            this.Resize += new System.EventHandler(this.Home_Resize);
            this.Home_panel.ResumeLayout(false);
            this.Home_panel.PerformLayout();
            this.bottom_panel.ResumeLayout(false);
            this.bottom_panel.PerformLayout();
            this.home_background.ResumeLayout(false);
            this.home_background.PerformLayout();
            this.navbar_panel.ResumeLayout(false);
            this.navbar_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Home_panel;
        private System.Windows.Forms.Panel home_background;
        private System.Windows.Forms.Panel airline_logo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel bottom_panel;
        private System.Windows.Forms.Label label6;
        private Button sign_up_btn;
        private Button learn_more_btn;
        private Button home_btn_nav;
        private Button contact_btn_nav;
        private Button my_bookings_btn_nav;
        private Button about_btn_nav;
        private Button flights_btn_nav;
        private Button log_in_btn_nav;
        private Panel place_cards_container;
        private FontAwesome.Sharp.IconButton move_left_btn;
        private FontAwesome.Sharp.IconButton move_right_btn;
        private Panel navbar_panel;
        private FontAwesome.Sharp.IconButton profile_picture;
        private FontAwesome.Sharp.IconButton logout_btn;
        private Label name_label;
    }
}

