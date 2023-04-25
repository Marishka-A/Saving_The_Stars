using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Windows.Forms;
using System.Timers;
using System.Threading;
using System.Numerics;

namespace Saving_The_Stars
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer TimerFofBack;
        private System.Windows.Forms.Timer TimerForStars;
        private int Index = 0;
        private Image[] ImagesForBack;
        public Player Character;
        public Form1()
        {
            InitializeComponent();
            Height = 600;
            Width = 1200;
            BackgroundImage = Image.FromFile(@"..\..\..\Pictures\background.png");
            DoubleBuffered = true;
            TimerFofBack = new System.Windows.Forms.Timer();
            TimerFofBack.Interval = 5000;
            ImagesForBack = new Image[] 
            { 
                Image.FromFile(@"..\..\..\Pictures\background.png"),
                Image.FromFile(@"..\..\..\Pictures\background2.png") 
            };
            TimerFofBack.Tick += (sender, args) =>
            {
                if (Index == ImagesForBack.Length) Index = 0;
                this.BackgroundImage = ImagesForBack[Index];
                Index++;
            };
            TimerFofBack.Start();
            TimerForStars = new System.Windows.Forms.Timer();
            TimerForStars.Tick += (sender, args) =>
            {
                CheckCollision();
                CreateStars();
            };
            TimerForStars.Start();
            var model = new Model();
            //SpawnPlayer(model);
            CreatePlayer();
            //Character = new Player(100, 0, new Point(60, 430), Image.FromFile(@"..\..\..\Pictures\Player.png"));
            //PictureBox pictureBoxPlayer = new PictureBox();
            //pictureBoxPlayer.SizeMode = PictureBoxSizeMode.AutoSize;
            //pictureBoxPlayer.Image = Character.Picture.Image;
            //pictureBoxPlayer.BackColor = Color.Transparent;
            //Controls.Add(pictureBoxPlayer);
            //pictureBoxPlayer.Location = Character.Position;
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
        }

        private void CreateStars()
        {
            Random random = new Random();
            int value = random.Next(1, 6);
            int x = random.Next(0, 1100);
            int y = random.Next(0, 550);
            Star star = new Star(Image.FromFile(@"..\..\..\Pictures\starMini.png"), new Point(x, y));
            Controls.Add(star.Picture);
        }

        private void CheckCollision()
        {
            foreach (Control control in Controls)
            {
                if (control is Star)
                {
                    Star star = (Star)control; // Как правильно присвоить?
                    if (Character.Picture.Bounds.IntersectsWith(star.Picture.Bounds))
                    {
                        Character.CollectStar(star);
                        //scoreLabel.Text = "Score: " + player.Score.ToString();
                    }
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var graphics = e.Graphics;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            graphics.DrawLine(new Pen(Color.Green, 5), new Point(0, 550), new Point(1200, 550));
        }
        private void CreatePlayer()
        {
            Character = new Player(100, 0, new Point(60, 430), Image.FromFile(@"..\..\..\Pictures\Player.png"));
            Controls.Add(Character.Picture);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    Character.MoveTo(Character, -10, 0);
                    //Character.Position = new Point(Character.Position.X - 10, Character.Position.Y);
                    break;
                case Keys.Right:
                    Character.MoveTo(Character, 10, 0);
                    //Character.Position = new Point(Character.Position.X + 10, Character.Position.Y);
                    break;
                case Keys.Up:
                    Character.MoveTo(Character, 0, -10);
                    //Character.Position = new Point(Character.Position.X, Character.Position.Y - 10);
                    break;
                case Keys.Down:
                    Character.MoveTo(Character, 0, 10);
                    //Character.Position = new Point(Character.Position.X, Character.Position.Y + 10);
                    break;
            }
            PictureBox pictureBoxPlayer = (PictureBox)Controls[0];
            pictureBoxPlayer.Location = Character.Position;
        }
    }
}