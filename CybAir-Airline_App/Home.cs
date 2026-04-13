using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Guna.UI2.WinForms;
using System.Windows.Documents;
using System.Runtime.ConstrainedExecution;
using System.Diagnostics;
using System.Data.SqlTypes;
using System.Reflection;
using System.Drawing.Drawing2D;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.IO;
using FontAwesome.Sharp;
namespace CybAir_Airline_App
{
    public partial class Home : Form
    {
        /// <summary>
        /// the constructor sets the rendering options
        /// </summary>
        public Home()
        {
            
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint |
                          ControlStyles.ResizeRedraw, true);
            this.UpdateStyles();
            


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
        /// sets the screen size and call the set_components function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Home_Load(object sender, EventArgs e)
        {
            
            this.Size = new Size(
                UI.calculate_size(Screen.PrimaryScreen.WorkingArea.Width,0.7),
                UI.calculate_size(Screen.PrimaryScreen.WorkingArea.Height,0.75));
            
            set_controls(this.Home_panel);
            

        }
        /// <summary>
        /// calls the UI.set_profile_picture function to display the profile picture
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Home_Shown(object sender, EventArgs e)
        {
            Dictionary<string, Control> controls_dict = new Dictionary<string, Control>();
            UI.registerControls(this.Controls, controls_dict);
            await UI.set_profile_picture(controls_dict);
            create_places_cards();

        }
        private class PlaceCard
        {
            public String place_name;
            public Image image;
            public PlaceCard(String place_name, Image image)
            {
                this.place_name = place_name;
                this.image = image;
            }
            
        }
        /// <summary>
        /// creates instances of the PlaceCard class
        /// displays these instances as panels with picture and label
        /// </summary>
        private void create_places_cards()
        {
            PlaceCard[] all_place_cards = {
                new PlaceCard("London",Properties.Resources.London),
                new PlaceCard("New York",Properties.Resources.New_York),
                new PlaceCard("Barcelona",Properties.Resources.Barcelona_city),
                new PlaceCard("Tokyo",Properties.Resources.Tokyo),
                new PlaceCard("Paris",Properties.Resources.Paris_city),
                new PlaceCard("Bangkok",Properties.Resources.Bangkok),
                new PlaceCard("Rome",Properties.Resources.Rome_city)
            };
            for(int i=0; i<all_place_cards.Length; i++)
            {
                PlaceCard card = all_place_cards[i];
                Panel container_setup()
                {
                    Panel container = new Panel();
                    container.Name = card.place_name + "_card_container";
                    container.Parent = this.place_cards_container;
                    container.Size = new Size(UI.calculate_size(this.ClientSize.Width, 0.15), this.place_cards_container.Height);
                    container.Location = new Point(i * (container.Width + UI.calculate_size(bottom_panel.Width, 0.02)), 0);
                    UI.RoundCorners(container, 25, Color.White, 0);
                    container.BackColor = Color.White;
                    this.place_cards_container.Controls.Add(container);
                    container.BringToFront();
                    return container;
                }
                void image_setup(Panel container)
                {
                    Panel image = new Panel();
                    image.Name = card.place_name + "_image";
                    image.Size = new Size(container.Width, UI.calculate_size(container.Height, 0.8));
                    image.Parent = container;
                    image.Location = new Point(0, 0);
                    image.BackgroundImage = card.image;
                    image.BackgroundImageLayout = ImageLayout.Stretch;
                    container.Controls.Add(image);
                }              
                void label_setup(Panel container)
                {
                    Label label = new Label();
                    label.Name = card.place_name + "_label";
                    label.Text = card.place_name.Trim();
                    label.Font = new Font("Seuge UI", UI.calculate_size(bottom_panel.Width, 0.013));
                    label.ForeColor = Color.FromArgb(126, 126, 126);
                    label.BackColor = Color.White;
                    label.AutoSize = true;
                    label.Parent = container;
                    label.Left = UI.calculate_size(container.Width - label.Width, 0.5);
                    label.Top = UI.calculate_size(container.Height, 0.83);
                    container.Controls.Add(label);
                }
                Panel p = container_setup();
                image_setup(p);
                label_setup(p);
            }

        }
        /// <summary>
        /// changes the location of all the place cards according to the given offset
        /// </summary>
        /// <param name="offset"></param>
        private void update_place_cards(int offset)
        {
            
            int count = 0;
            Control[]containers = this.place_cards_container.Controls.Cast<Control>().ToArray();
            Array.Reverse(containers);
            foreach (Control container in containers)
            {
                   
                container.Size = new Size(UI.calculate_size(this.ClientSize.Width, 0.15), this.place_cards_container.Height);
                UI.RoundCorners(container, 25, Color.White,0);
                container.Location = new Point(count * (container.Width + UI.calculate_size(bottom_panel.Width, 0.02))+offset, 0);
                Control image = container.Controls[0];
                image.Size = new Size(container.Width, UI.calculate_size(container.Height, 0.8));
                image.Location = new Point(0, 0);
                Control label = container.Controls[1];
                label.Font = new Font("Seuge UI", UI.calculate_size(bottom_panel.Width, 0.013));
                label.Left = UI.calculate_size(container.Width - label.Width, 0.5);
                label.Top = UI.calculate_size(container.Height, 0.83);
                count++;
            }
        }
        /// <summary>
        /// sets the style for all the different UI controls in the form relative to 
        /// the screen size
        /// </summary>
        private void set_controls(Control parent)
        {
            this.DoubleBuffered= true;
            this.home_background.Size = new System.Drawing.Size(this.ClientSize.Width - SystemInformation.VerticalScrollBarWidth, this.ClientSize.Height);
            
            this.navbar_panel.Location=new Point(0,0);
            this.navbar_panel.Width = this.home_background.Width;

            


            int top_pos = UI.calculate_size(this.ClientSize.Height, 0.25);
            void set_header_labels()
            {
                var all_labels = parent.Controls.OfType<Label>().Reverse().Take(5).ToList();
                int count = 0;

                foreach (Label l in all_labels)
                {

                    if (count < 3)
                    {
                        l.Font = new Font(l.Font.FontFamily, UI.calculate_size(this.ClientSize.Width, 0.035), FontStyle.Bold);
                        l.Location = new Point(UI.calculate_size(this.ClientSize.Width, 0.02), top_pos);

                    }
                    else
                    {
                        l.Font = new Font(l.Font.FontFamily, UI.calculate_size(this.ClientSize.Width, 0.013));
                        if (count == 3)
                        {
                            top_pos += l.Height;
                        }
                        l.Location = new Point(UI.calculate_size(this.ClientSize.Width, 0.03), top_pos);
                    }

                    top_pos += UI.calculate_size(l.Height, 0.83);
                    l.Parent = this.home_background;
                    this.home_background.Controls.Add(l);
                    l.BringToFront();
                    count++;
                }
            }
            void set_buttons()
            {
                top_pos += UI.calculate_size(this.ClientSize.Height, 0.05);
                Font btn_font = new Font(this.sign_up_btn.Font.FontFamily, UI.calculate_size(this.ClientSize.Width, 0.013));
                if (btn_font.Size > 15f)
                {
                    btn_font = new Font(this.sign_up_btn.Font.FontFamily, 15);
                }
                Control[] home_background_controls = this.home_background.Controls.Cast<Control>().ToArray();
                Array.Reverse(home_background_controls);
                foreach (Control ctrl in home_background_controls)
                {
                    if (ctrl is Button)
                    {
                        ctrl.Font = btn_font;
                        
                    }

                }
                
                this.learn_more_btn.Location = new Point(UI.calculate_size(this.ClientSize.Width, 0.03), top_pos);
                this.sign_up_btn.Location = new Point(UI.calculate_size(this.ClientSize.Width, 0.04) + this.learn_more_btn.Width, top_pos);
                this.sign_up_btn.FlatAppearance.BorderSize = 0;
                UI.RoundCorners(this.sign_up_btn, 35, Color.FromArgb(0, 70, 127), 7);
                UI.RoundCorners(this.learn_more_btn, 35, Color.FromArgb(0, 172, 157), 7);
                this.logout_btn.Top = this.navbar_panel.Bottom;
                this.logout_btn.Left = this.ClientSize.Width - this.logout_btn.Width - 30;
                this.logout_btn.IconSize = this.logout_btn.Font.Height;
                this.logout_btn.BringToFront();
            }
            void set_bottom_panel()
            {
                this.bottom_panel.Parent = this.Home_panel;

                this.bottom_panel.Size = this.home_background.Size;
                this.bottom_panel.Location = new Point(0, this.home_background.Height);
                this.label6.Location = new Point(UI.calculate_size(this.bottom_panel.Width - this.label6.Width, 0.5), UI.calculate_size(this.bottom_panel.Height, 0.05));
                this.label6.Font = new Font(this.label6.Font.FontFamily, UI.calculate_size(this.ClientSize.Width, 0.03), FontStyle.Bold);
                this.place_cards_container.Parent = this.bottom_panel;
                this.place_cards_container.Size = new Size(UI.calculate_size(this.ClientSize.Width, 0.66), UI.calculate_size(this.ClientSize.Width, 0.21));
                this.place_cards_container.Location = new Point(UI.calculate_size(this.ClientSize.Width, 0.15), UI.calculate_size(this.ClientSize.Height, 0.2));
                this.move_left_btn.IconSize = UI.calculate_size(this.ClientSize.Width, 0.03);
                this.move_left_btn.Location = new Point(this.place_cards_container.Left - this.move_left_btn.Width,
                    this.place_cards_container.Top + UI.calculate_size(this.place_cards_container.Height - this.move_left_btn.Height, 0.5));
                this.move_right_btn.IconSize = UI.calculate_size(this.ClientSize.Width, 0.03);
                this.move_right_btn.Location = new Point(this.place_cards_container.Right, this.move_left_btn.Top);
            }
            
            set_header_labels();
            set_buttons();
            UI.set_navbar(this.navbar_panel, this.ClientSize, this.learn_more_btn.Font);
            set_bottom_panel();
            
            

        }

        /// <summary>
        /// if the form is not in the minimized state it displays all the controls again with set_components
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Home_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized) return;
            this.Home_panel.AutoScrollPosition = new Point(0, 0);
            this.Home_panel.Size = new Size(this.ClientSize.Width,this.ClientSize.Height);  
            set_controls(this.home_background);
            update_place_cards(0);
            this.Home_panel.AutoScrollPosition = new Point(0, 0);
            this.bottom_panel.Location = new Point(0, this.home_background.Height);
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.UpdateStyles();
        }

        /// <summary>
        /// closes and exists the application and calls the UI.logout function
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
        /// creates an animation that moves all the card left
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void move_left_btn_Click(object sender, EventArgs e)
        {

            Control last_card = this.place_cards_container.Controls[this.place_cards_container.Controls.Count - 1];
            
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            int step_size = 20;
            int size = (this.place_cards_container.Controls[0].Width + UI.calculate_size(this.ClientSize.Width, 0.02)) / step_size;
            for (int i = 0; i <= size; i++)
            {
                this.update_place_cards(-step_size * i - 5);
                await Task.Delay(1);
            }
            this.place_cards_container.Controls.SetChildIndex(last_card, 0);
            this.FormBorderStyle = FormBorderStyle.Sizable;
        }
        /// <summary>
        /// creates an animation that moves all the cards right
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void move_right_btn_Click(object sender, EventArgs e)
        {
            Control last_card = this.place_cards_container.Controls[0];
            this.place_cards_container.Controls.SetChildIndex(last_card, this.place_cards_container.Controls.Count - 1);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            int step_size = 20;
            int size = (this.place_cards_container.Controls[0].Width + UI.calculate_size(this.ClientSize.Width, 0.02)) / step_size;
            for (int i = -size; i <= 0; i++)
            {
                this.update_place_cards(step_size * i);
                await Task.Delay(1);
            }
            this.FormBorderStyle = FormBorderStyle.Sizable;
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
        private void profile_picture_Click(object sender, EventArgs e)
        {

        }
    }
    
}
