namespace CybAir_Airline_App
{
    partial class MyBookings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyBookings));
            this.my_bookings_background = new System.Windows.Forms.Panel();
            this.options_panel = new System.Windows.Forms.Panel();
            this.save_ticket_btn = new FontAwesome.Sharp.IconButton();
            this.view_map_btn = new FontAwesome.Sharp.IconButton();
            this.cancel_ticket_btn = new FontAwesome.Sharp.IconButton();
            this.map_container = new System.Windows.Forms.Panel();
            this.exit_btn = new System.Windows.Forms.Button();
            this.info_label = new System.Windows.Forms.Label();
            this.bookings_label = new System.Windows.Forms.Label();
            this.tickets_container = new System.Windows.Forms.Panel();
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
            this.dummy_btn = new System.Windows.Forms.Button();
            this.logout_btn = new FontAwesome.Sharp.IconButton();
            this.my_bookings_background.SuspendLayout();
            this.options_panel.SuspendLayout();
            this.map_container.SuspendLayout();
            this.navbar_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // my_bookings_background
            // 
            this.my_bookings_background.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("my_bookings_background.BackgroundImage")));
            this.my_bookings_background.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.my_bookings_background.Controls.Add(this.options_panel);
            this.my_bookings_background.Controls.Add(this.map_container);
            this.my_bookings_background.Controls.Add(this.bookings_label);
            this.my_bookings_background.Controls.Add(this.tickets_container);
            this.my_bookings_background.Controls.Add(this.navbar_panel);
            this.my_bookings_background.Dock = System.Windows.Forms.DockStyle.Fill;
            this.my_bookings_background.Location = new System.Drawing.Point(0, 0);
            this.my_bookings_background.Name = "my_bookings_background";
            this.my_bookings_background.Size = new System.Drawing.Size(800, 450);
            this.my_bookings_background.TabIndex = 0;
            // 
            // options_panel
            // 
            this.options_panel.Controls.Add(this.save_ticket_btn);
            this.options_panel.Controls.Add(this.view_map_btn);
            this.options_panel.Controls.Add(this.cancel_ticket_btn);
            this.options_panel.Location = new System.Drawing.Point(563, 212);
            this.options_panel.Name = "options_panel";
            this.options_panel.Size = new System.Drawing.Size(164, 114);
            this.options_panel.TabIndex = 15;
            this.options_panel.Visible = false;
            // 
            // save_ticket_btn
            // 
            this.save_ticket_btn.BackColor = System.Drawing.Color.White;
            this.save_ticket_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.save_ticket_btn.FlatAppearance.BorderSize = 0;
            this.save_ticket_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save_ticket_btn.IconChar = FontAwesome.Sharp.IconChar.Download;
            this.save_ticket_btn.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.save_ticket_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.save_ticket_btn.IconSize = 25;
            this.save_ticket_btn.Location = new System.Drawing.Point(0, 75);
            this.save_ticket_btn.Name = "save_ticket_btn";
            this.save_ticket_btn.Size = new System.Drawing.Size(164, 39);
            this.save_ticket_btn.TabIndex = 18;
            this.save_ticket_btn.Text = "Save Ticket";
            this.save_ticket_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.save_ticket_btn.UseVisualStyleBackColor = false;
            // 
            // view_map_btn
            // 
            this.view_map_btn.BackColor = System.Drawing.Color.White;
            this.view_map_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.view_map_btn.FlatAppearance.BorderSize = 0;
            this.view_map_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.view_map_btn.IconChar = FontAwesome.Sharp.IconChar.MapLocationDot;
            this.view_map_btn.IconColor = System.Drawing.Color.Green;
            this.view_map_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.view_map_btn.IconSize = 25;
            this.view_map_btn.Location = new System.Drawing.Point(0, 38);
            this.view_map_btn.Name = "view_map_btn";
            this.view_map_btn.Size = new System.Drawing.Size(164, 39);
            this.view_map_btn.TabIndex = 17;
            this.view_map_btn.Text = "View Map";
            this.view_map_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.view_map_btn.UseVisualStyleBackColor = false;
            // 
            // cancel_ticket_btn
            // 
            this.cancel_ticket_btn.BackColor = System.Drawing.Color.White;
            this.cancel_ticket_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancel_ticket_btn.FlatAppearance.BorderSize = 0;
            this.cancel_ticket_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel_ticket_btn.IconChar = FontAwesome.Sharp.IconChar.X;
            this.cancel_ticket_btn.IconColor = System.Drawing.Color.Red;
            this.cancel_ticket_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.cancel_ticket_btn.IconSize = 25;
            this.cancel_ticket_btn.Location = new System.Drawing.Point(0, 0);
            this.cancel_ticket_btn.Name = "cancel_ticket_btn";
            this.cancel_ticket_btn.Size = new System.Drawing.Size(164, 39);
            this.cancel_ticket_btn.TabIndex = 16;
            this.cancel_ticket_btn.Text = "Cancel Ticket";
            this.cancel_ticket_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.cancel_ticket_btn.UseVisualStyleBackColor = false;
            // 
            // map_container
            // 
            this.map_container.BackColor = System.Drawing.Color.Transparent;
            this.map_container.Controls.Add(this.exit_btn);
            this.map_container.Controls.Add(this.info_label);
            this.map_container.Location = new System.Drawing.Point(41, 246);
            this.map_container.Name = "map_container";
            this.map_container.Size = new System.Drawing.Size(200, 100);
            this.map_container.TabIndex = 14;
            // 
            // exit_btn
            // 
            this.exit_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exit_btn.AutoSize = true;
            this.exit_btn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.exit_btn.BackColor = System.Drawing.Color.White;
            this.exit_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exit_btn.FlatAppearance.BorderSize = 0;
            this.exit_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exit_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.exit_btn.ForeColor = System.Drawing.Color.Red;
            this.exit_btn.Location = new System.Drawing.Point(167, 3);
            this.exit_btn.Name = "exit_btn";
            this.exit_btn.Size = new System.Drawing.Size(30, 30);
            this.exit_btn.TabIndex = 2;
            this.exit_btn.Text = "X";
            this.exit_btn.UseVisualStyleBackColor = false;
            // 
            // info_label
            // 
            this.info_label.AutoSize = true;
            this.info_label.BackColor = System.Drawing.Color.White;
            this.info_label.ForeColor = System.Drawing.Color.Black;
            this.info_label.Location = new System.Drawing.Point(80, 63);
            this.info_label.Name = "info_label";
            this.info_label.Padding = new System.Windows.Forms.Padding(2);
            this.info_label.Size = new System.Drawing.Size(39, 17);
            this.info_label.TabIndex = 0;
            this.info_label.Text = "label1";
            this.info_label.Visible = false;
            // 
            // bookings_label
            // 
            this.bookings_label.AutoSize = true;
            this.bookings_label.BackColor = System.Drawing.Color.Transparent;
            this.bookings_label.Location = new System.Drawing.Point(360, 138);
            this.bookings_label.Name = "bookings_label";
            this.bookings_label.Size = new System.Drawing.Size(94, 13);
            this.bookings_label.TabIndex = 13;
            this.bookings_label.Text = "My Booked Flights";
            // 
            // tickets_container
            // 
            this.tickets_container.AutoScroll = true;
            this.tickets_container.BackColor = System.Drawing.Color.Transparent;
            this.tickets_container.Location = new System.Drawing.Point(247, 201);
            this.tickets_container.Name = "tickets_container";
            this.tickets_container.Size = new System.Drawing.Size(254, 190);
            this.tickets_container.TabIndex = 12;
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
            this.navbar_panel.Location = new System.Drawing.Point(4, 3);
            this.navbar_panel.Name = "navbar_panel";
            this.navbar_panel.Size = new System.Drawing.Size(796, 92);
            this.navbar_panel.TabIndex = 11;
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
            // dummy_btn
            // 
            this.dummy_btn.Location = new System.Drawing.Point(33, 191);
            this.dummy_btn.Name = "dummy_btn";
            this.dummy_btn.Size = new System.Drawing.Size(14, 23);
            this.dummy_btn.TabIndex = 0;
            this.dummy_btn.Text = "button1";
            this.dummy_btn.UseVisualStyleBackColor = true;
            this.dummy_btn.Visible = false;
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
            this.logout_btn.Location = new System.Drawing.Point(707, 95);
            this.logout_btn.Name = "logout_btn";
            this.logout_btn.Size = new System.Drawing.Size(75, 23);
            this.logout_btn.TabIndex = 20;
            this.logout_btn.Text = "Log Out";
            this.logout_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.logout_btn.UseVisualStyleBackColor = false;
            this.logout_btn.Visible = false;
            this.logout_btn.Click += new System.EventHandler(this.logout_btn_Click);
            // 
            // MyBookings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dummy_btn);
            this.Controls.Add(this.logout_btn);
            this.Controls.Add(this.my_bookings_background);
            this.Name = "MyBookings";
            this.Text = "MyBookings";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MyBookings_FormClosed);
            this.Load += new System.EventHandler(this.MyBookings_Load);
            this.Shown += new System.EventHandler(this.MyBookings_Shown);
            this.Resize += new System.EventHandler(this.MyBookings_Resize);
            this.my_bookings_background.ResumeLayout(false);
            this.my_bookings_background.PerformLayout();
            this.options_panel.ResumeLayout(false);
            this.map_container.ResumeLayout(false);
            this.map_container.PerformLayout();
            this.navbar_panel.ResumeLayout(false);
            this.navbar_panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel my_bookings_background;
        private System.Windows.Forms.Button dummy_btn;
        private System.Windows.Forms.Panel navbar_panel;
        private System.Windows.Forms.Label name_label;
        private FontAwesome.Sharp.IconButton profile_picture;
        private System.Windows.Forms.Button log_in_btn_nav;
        private System.Windows.Forms.Panel airline_logo;
        private System.Windows.Forms.Button home_btn_nav;
        private System.Windows.Forms.Button about_btn_nav;
        private System.Windows.Forms.Button flights_btn_nav;
        private System.Windows.Forms.Button my_bookings_btn_nav;
        private System.Windows.Forms.Button contact_btn_nav;
        private FontAwesome.Sharp.IconButton logout_btn;
        private System.Windows.Forms.Panel tickets_container;
        private System.Windows.Forms.Label bookings_label;
        private System.Windows.Forms.Panel map_container;
        private System.Windows.Forms.Label info_label;
        private System.Windows.Forms.Button exit_btn;
        private System.Windows.Forms.Panel options_panel;
        private FontAwesome.Sharp.IconButton save_ticket_btn;
        private FontAwesome.Sharp.IconButton view_map_btn;
        private FontAwesome.Sharp.IconButton cancel_ticket_btn;
    }
}