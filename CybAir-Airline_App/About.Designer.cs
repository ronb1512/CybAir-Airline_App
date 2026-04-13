namespace CybAir_Airline_App
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.picture1 = new System.Windows.Forms.Panel();
            this.logout_btn = new FontAwesome.Sharp.IconButton();
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.about_background = new System.Windows.Forms.Panel();
            this.picture2 = new System.Windows.Forms.Panel();
            this.picture3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.navbar_panel.SuspendLayout();
            this.about_background.SuspendLayout();
            this.SuspendLayout();
            // 
            // picture1
            // 
            this.picture1.BackColor = System.Drawing.Color.Transparent;
            this.picture1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picture1.BackgroundImage")));
            this.picture1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picture1.Location = new System.Drawing.Point(587, 157);
            this.picture1.Name = "picture1";
            this.picture1.Size = new System.Drawing.Size(181, 155);
            this.picture1.TabIndex = 14;
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
            this.logout_btn.Location = new System.Drawing.Point(693, 103);
            this.logout_btn.Name = "logout_btn";
            this.logout_btn.Size = new System.Drawing.Size(75, 23);
            this.logout_btn.TabIndex = 12;
            this.logout_btn.Text = "Log Out";
            this.logout_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.logout_btn.UseVisualStyleBackColor = false;
            this.logout_btn.Visible = false;
            this.logout_btn.Click += new System.EventHandler(this.logout_btn_Click);
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
            this.navbar_panel.Location = new System.Drawing.Point(2, 1);
            this.navbar_panel.Name = "navbar_panel";
            this.navbar_panel.Size = new System.Drawing.Size(796, 96);
            this.navbar_panel.TabIndex = 11;
            // 
            // name_label
            // 
            this.name_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.name_label.AutoSize = true;
            this.name_label.BackColor = System.Drawing.Color.Transparent;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 121);
            this.label2.MaximumSize = new System.Drawing.Size(500, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(498, 65);
            this.label2.TabIndex = 15;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 332);
            this.label3.MaximumSize = new System.Drawing.Size(500, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(496, 52);
            this.label3.TabIndex = 16;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 394);
            this.label4.MaximumSize = new System.Drawing.Size(500, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(499, 65);
            this.label4.TabIndex = 17;
            this.label4.Text = resources.GetString("label4.Text");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 467);
            this.label5.MaximumSize = new System.Drawing.Size(500, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(494, 52);
            this.label5.TabIndex = 18;
            this.label5.Text = resources.GetString("label5.Text");
            // 
            // about_background
            // 
            this.about_background.AutoScroll = true;
            this.about_background.BackColor = System.Drawing.Color.Transparent;
            this.about_background.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.about_background.Controls.Add(this.picture2);
            this.about_background.Controls.Add(this.picture3);
            this.about_background.Controls.Add(this.label1);
            this.about_background.Controls.Add(this.label2);
            this.about_background.Controls.Add(this.label3);
            this.about_background.Controls.Add(this.label4);
            this.about_background.Controls.Add(this.label5);
            this.about_background.Controls.Add(this.picture1);
            this.about_background.Controls.Add(this.logout_btn);
            this.about_background.Controls.Add(this.navbar_panel);
            this.about_background.Dock = System.Windows.Forms.DockStyle.Fill;
            this.about_background.Location = new System.Drawing.Point(0, 0);
            this.about_background.Name = "about_background";
            this.about_background.Size = new System.Drawing.Size(800, 450);
            this.about_background.TabIndex = 0;
            // 
            // picture2
            // 
            this.picture2.BackColor = System.Drawing.Color.Transparent;
            this.picture2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picture2.BackgroundImage")));
            this.picture2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture2.Location = new System.Drawing.Point(587, 318);
            this.picture2.Name = "picture2";
            this.picture2.Size = new System.Drawing.Size(181, 155);
            this.picture2.TabIndex = 15;
            // 
            // picture3
            // 
            this.picture3.BackColor = System.Drawing.Color.Transparent;
            this.picture3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picture3.BackgroundImage")));
            this.picture3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture3.Location = new System.Drawing.Point(587, 481);
            this.picture3.Name = "picture3";
            this.picture3.Size = new System.Drawing.Size(181, 155);
            this.picture3.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 204);
            this.label1.MaximumSize = new System.Drawing.Size(500, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(490, 78);
            this.label1.TabIndex = 19;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.about_background);
            this.Name = "About";
            this.Text = "About";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.About_FormClosed);
            this.Load += new System.EventHandler(this.About_Load);
            this.Shown += new System.EventHandler(this.About_Shown);
            this.Resize += new System.EventHandler(this.About_Resize);
            this.navbar_panel.ResumeLayout(false);
            this.navbar_panel.PerformLayout();
            this.about_background.ResumeLayout(false);
            this.about_background.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private FontAwesome.Sharp.IconButton logout_btn;
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
        private System.Windows.Forms.Panel picture1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel about_background;
        private System.Windows.Forms.Panel picture2;
        private System.Windows.Forms.Panel picture3;
        private System.Windows.Forms.Label label1;
    }
}