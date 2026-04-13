using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CybAir_Airline_App
{
    public partial class About : Form
    {
        /// <summary>
        /// the constructor sets the rendering options
        /// </summary>
        public About()
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
        private void About_Load(object sender, EventArgs e)
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
        /// calls the UI.set_profile_picture function to display the profile picture
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void About_Shown(object sender, EventArgs e)
        {
            Dictionary<string, Control> controls_dict = new Dictionary<string, Control>();
            UI.registerControls(this.Controls, controls_dict);
            await UI.set_profile_picture(controls_dict);
        }

       /// <summary>
       /// sets the style for all the different UI controls in the form relative to 
       /// the screen size
       /// </summary>
        private void set_components()
        {
            this.navbar_panel.Location = new Point(0, 0);
            this.navbar_panel.Width = this.ClientSize.Width - SystemInformation.VerticalScrollBarWidth;
            Font font = new Font(this.log_in_btn_nav.Font.FontFamily, UI.calculate_size(this.ClientSize.Width, 0.013));
            if (font.Size > 15f)
            {
                font = new Font(this.log_in_btn_nav.Font.FontFamily, 15f);
            }
            this.logout_btn.Top = this.navbar_panel.Bottom;
            this.logout_btn.Left = this.ClientSize.Width - this.logout_btn.Width - 30;
            this.logout_btn.IconSize = this.logout_btn.Font.Height;
            this.logout_btn.Font = font;
            this.logout_btn.BringToFront();
            UI.set_navbar(this.navbar_panel, this.ClientSize, font);
            int top_pos = navbar_panel.Bottom + UI.calculate_size(ClientSize.Height, 0.1);
            this.about_background.Controls.OfType<Label>().ToList().ForEach(label => {
                label.Font = font;
                label.MaximumSize = new Size(UI.calculate_size(this.ClientSize.Width, 0.5), 0);
                int index = about_background.Controls.OfType<Label>().ToList().IndexOf(label);
                label.Left = index < 2 ? UI.calculate_size(this.ClientSize.Width, 0.05) : ClientSize.Width - label.Width - UI.calculate_size(this.ClientSize.Width, 0.05);
                label.Top = top_pos;
                top_pos += label.Height + UI.calculate_size(ClientSize.Height, 0.05);
            });

            this.picture2.Width = UI.calculate_size(this.ClientSize.Width, 0.4);
            this.picture2.Height = UI.calculate_size(this.ClientSize.Width, 0.25);
            picture2.Location = new Point(ClientSize.Width - SystemInformation.VerticalScrollBarWidth - picture2.Width, label1.Top);
            this.picture1.Width = UI.calculate_size(this.ClientSize.Width, 0.25);
            this.picture1.Height = UI.calculate_size(this.ClientSize.Width, 0.3);
            picture1.Location = new Point(UI.calculate_size(ClientSize.Width, 0.1), label3.Top);
            this.picture3.Width = UI.calculate_size(this.ClientSize.Width, 0.4);
            this.picture3.Height = UI.calculate_size(this.ClientSize.Width, 0.25);
            picture3.Location = new Point(0, picture1.Bottom);
        }

        /// <summary>
        /// if the form is not in the minimized state it displays all the controls again with set_components
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void About_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized) return;
            this.about_background.AutoScrollPosition = new Point(0, 0);
            this.about_background.Size = new Size(this.ClientSize.Width, this.ClientSize.Height);
            this.about_background.AutoScrollPosition = new Point(0, 0);
            this.DoubleBuffered = true;
            set_components();
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

        /// <summary>
        /// closes and exists the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void About_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}