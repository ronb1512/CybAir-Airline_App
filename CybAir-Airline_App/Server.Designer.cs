namespace CybAir_Airline_App
{
    partial class Server
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
            this.server_background = new System.Windows.Forms.Panel();
            this.users_container = new System.Windows.Forms.Panel();
            this.dummy_btn = new System.Windows.Forms.Button();
            this.container = new System.Windows.Forms.Panel();
            this.messages_container = new System.Windows.Forms.Panel();
            this.textbox_container = new System.Windows.Forms.Panel();
            this.textbox = new Krypton.Toolkit.KryptonRichTextBox();
            this.send_btn = new FontAwesome.Sharp.IconButton();
            this.extention = new System.Windows.Forms.Panel();
            this.server_background.SuspendLayout();
            this.container.SuspendLayout();
            this.textbox_container.SuspendLayout();
            this.SuspendLayout();
            // 
            // server_background
            // 
            this.server_background.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(216)))), ((int)(((byte)(212)))));
            this.server_background.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.server_background.Controls.Add(this.users_container);
            this.server_background.Controls.Add(this.dummy_btn);
            this.server_background.Controls.Add(this.container);
            this.server_background.Controls.Add(this.extention);
            this.server_background.Dock = System.Windows.Forms.DockStyle.Fill;
            this.server_background.Location = new System.Drawing.Point(0, 0);
            this.server_background.Name = "server_background";
            this.server_background.Size = new System.Drawing.Size(800, 450);
            this.server_background.TabIndex = 2;
            // 
            // users_container
            // 
            this.users_container.AutoScroll = true;
            this.users_container.BackColor = System.Drawing.SystemColors.ControlLight;
            this.users_container.Location = new System.Drawing.Point(29, 122);
            this.users_container.Name = "users_container";
            this.users_container.Size = new System.Drawing.Size(93, 272);
            this.users_container.TabIndex = 16;
            // 
            // dummy_btn
            // 
            this.dummy_btn.Location = new System.Drawing.Point(13, 221);
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
            this.extention.Location = new System.Drawing.Point(4, 3);
            this.extention.Name = "extention";
            this.extention.Size = new System.Drawing.Size(793, 180);
            this.extention.TabIndex = 12;
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.server_background);
            this.Name = "Server";
            this.Text = "Server";
            this.Load += new System.EventHandler(this.Server_Load);
            this.Shown += new System.EventHandler(this.Server_Shown);
            this.Resize += new System.EventHandler(this.Server_Resize);
            this.server_background.ResumeLayout(false);
            this.container.ResumeLayout(false);
            this.textbox_container.ResumeLayout(false);
            this.textbox_container.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel server_background;
        private System.Windows.Forms.Button dummy_btn;
        private System.Windows.Forms.Panel container;
        private System.Windows.Forms.Panel messages_container;
        private System.Windows.Forms.Panel textbox_container;
        private Krypton.Toolkit.KryptonRichTextBox textbox;
        private FontAwesome.Sharp.IconButton send_btn;
        private System.Windows.Forms.Panel extention;
        private System.Windows.Forms.Panel users_container;
    }
}