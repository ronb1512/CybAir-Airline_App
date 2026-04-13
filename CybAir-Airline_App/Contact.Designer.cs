namespace CybAir_Airline_App
{
    partial class Contact
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Contact));
            this.contact_background = new System.Windows.Forms.Panel();
            this.dummy_btn = new System.Windows.Forms.Button();
            this.container = new System.Windows.Forms.Panel();
            this.messages_container = new System.Windows.Forms.Panel();
            this.textbox_container = new System.Windows.Forms.Panel();
            this.textbox = new Krypton.Toolkit.KryptonRichTextBox();
            this.send_btn = new FontAwesome.Sharp.IconButton();
            this.extention = new System.Windows.Forms.Panel();
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
            this.logout_btn = new FontAwesome.Sharp.IconButton();
            this.contact_background.SuspendLayout();
            this.container.SuspendLayout();
            this.textbox_container.SuspendLayout();
            this.navbar_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // contact_background
            // 
            this.contact_background.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(216)))), ((int)(((byte)(212)))));
            this.contact_background.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.contact_background.Controls.Add(this.dummy_btn);
            this.contact_background.Controls.Add(this.container);
            this.contact_background.Controls.Add(this.extention);
            this.contact_background.Controls.Add(this.navbar_panel);
            this.contact_background.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contact_background.Location = new System.Drawing.Point(0, 0);
            this.contact_background.Name = "contact_background";
            this.contact_background.Size = new System.Drawing.Size(800, 450);
            this.contact_background.TabIndex = 1;
            // 
            // dummy_btn
            // 
            this.dummy_btn.Location = new System.Drawing.Point(33, 220);
            this.dummy_btn.Name = "dummy_btn";
            this.dummy_btn.Size = new System.Drawing.Size(14, 23);
            this.dummy_btn.TabIndex = 14;
            this.dummy_btn.Text = "button1";
            this.dummy_btn.UseVisualStyleBackColor = true;
            this.dummy_btn.Visible = false;
            // 
            // container
            // 
            this.container.AutoScroll = true;
            this.container.BackColor = System.Drawing.Color.White;
            this.container.Controls.Add(this.messages_container);
            this.container.Controls.Add(this.textbox_container);
            this.container.Location = new System.Drawing.Point(132, 125);
            this.container.Name = "container";
            this.container.Size = new System.Drawing.Size(557, 272);
            this.container.TabIndex = 13;
            // 
            // messages_container
            // 
            this.messages_container.AutoScroll = true;
            this.messages_container.Location = new System.Drawing.Point(0, 0);
            this.messages_container.Name = "messages_container";
            this.messages_container.Size = new System.Drawing.Size(554, 219);
            this.messages_container.TabIndex = 3;
            // 
            // textbox_container
            // 
            this.textbox_container.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textbox_container.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.textbox_container.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.textbox_container.Controls.Add(this.textbox);
            this.textbox_container.Controls.Add(this.send_btn);
            this.textbox_container.Location = new System.Drawing.Point(0, 221);
            this.textbox_container.Name = "textbox_container";
            this.textbox_container.Size = new System.Drawing.Size(557, 51);
            this.textbox_container.TabIndex = 2;
            // 
            // textbox
            // 
            this.textbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textbox.CueHint.Color1 = System.Drawing.Color.Gray;
            this.textbox.CueHint.CueHintText = "Enter Message";
            this.textbox.CueHint.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.textbox.Location = new System.Drawing.Point(31, 4);
            this.textbox.Name = "textbox";
            this.textbox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.textbox.Size = new System.Drawing.Size(470, 38);
            this.textbox.StateCommon.Border.Rounding = 7F;
            this.textbox.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.textbox.StateCommon.Content.Padding = new System.Windows.Forms.Padding(5);
            this.textbox.TabIndex = 1;
            this.textbox.Text = "";
            this.textbox.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            // 
            // send_btn
            // 
            this.send_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.send_btn.AutoSize = true;
            this.send_btn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.send_btn.BackColor = System.Drawing.Color.Transparent;
            this.send_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.send_btn.FlatAppearance.BorderSize = 0;
            this.send_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.send_btn.IconChar = FontAwesome.Sharp.IconChar.PaperPlane;
            this.send_btn.IconColor = System.Drawing.Color.DimGray;
            this.send_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.send_btn.IconSize = 30;
            this.send_btn.Location = new System.Drawing.Point(507, 4);
            this.send_btn.Name = "send_btn";
            this.send_btn.Size = new System.Drawing.Size(36, 36);
            this.send_btn.TabIndex = 1;
            this.send_btn.UseVisualStyleBackColor = false;
            this.send_btn.Click += new System.EventHandler(this.send_btn_Click);
            // 
            // extention
            // 
            this.extention.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.extention.Location = new System.Drawing.Point(4, 95);
            this.extention.Name = "extention";
            this.extention.Size = new System.Drawing.Size(793, 88);
            this.extention.TabIndex = 12;
            // 
            // navbar_panel
            // 
            this.navbar_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
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
            this.name_label.BackColor = System.Drawing.Color.Transparent;
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
            this.logout_btn.Location = new System.Drawing.Point(704, 101);
            this.logout_btn.Name = "logout_btn";
            this.logout_btn.Size = new System.Drawing.Size(75, 23);
            this.logout_btn.TabIndex = 21;
            this.logout_btn.Text = "Log Out";
            this.logout_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.logout_btn.UseVisualStyleBackColor = false;
            this.logout_btn.Visible = false;
            this.logout_btn.Click += new System.EventHandler(this.logout_btn_Click);
            // 
            // Contact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.logout_btn);
            this.Controls.Add(this.contact_background);
            this.Name = "Contact";
            this.Text = "Contact";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Contact_FormClosed);
            this.Load += new System.EventHandler(this.Contact_Load);
            this.Shown += new System.EventHandler(this.Contact_Shown);
            this.Resize += new System.EventHandler(this.Contact_Resize);
            this.contact_background.ResumeLayout(false);
            this.container.ResumeLayout(false);
            this.textbox_container.ResumeLayout(false);
            this.textbox_container.PerformLayout();
            this.navbar_panel.ResumeLayout(false);
            this.navbar_panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel contact_background;
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
        private System.Windows.Forms.Panel container;
        private System.Windows.Forms.Panel extention;
        private System.Windows.Forms.Panel textbox_container;
        private Krypton.Toolkit.KryptonRichTextBox textbox;
        private FontAwesome.Sharp.IconButton send_btn;
        private System.Windows.Forms.Button dummy_btn;
        private System.Windows.Forms.Panel messages_container;
    }
}