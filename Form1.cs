using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Windows.Forms;
using System.Timers;
using System.Threading;

namespace Saving_The_Stars
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer TimerFofBack;
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
            var model = new Model();
            //SpawnPlayer(model);
            Character = new Player(100, 0, 0, 0, new Point(60, 430), Image.FromFile(@"..\..\..\Pictures\Player.png"));
            PictureBox pictureBoxPlayer = new PictureBox();
            pictureBoxPlayer.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBoxPlayer.Image = Character.Picture.Image;
            pictureBoxPlayer.BackColor = Color.Transparent;
            Controls.Add(pictureBoxPlayer);
            pictureBoxPlayer.Location = Character.Position;
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var graphics = e.Graphics;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            graphics.DrawLine(new Pen(Color.Green, 5), new Point(0, 550), new Point(1200, 550));
        }
        //public void SpawnPlayer(Model player)
        //{
        //    var timer = new System.Windows.Forms.Timer();
        //    timer.Interval = 60000;
        //    timer.Tick += (sender, args) => { player.SpawnPlayerInGame(player); };
        //    timer.Start();
        //    //Controls.Add(player.PlayerInGame.Picture);
        //}

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

        //private void MoveLeft_Tick(object sender, EventArgs e)
        //{

        //}
        //private void MoveLeft_Tick(object sender, EventArgs e)
        //{

        //}
        //private void MoveLeft_Tick(object sender, EventArgs e)
        //{

        //}
        //private void Form1_KeyUp(object sender, KeyEventArgs e)
        //{
        //    mainPlayer.Image = Properties.Resources.cowboy_idble

        //    if (e.KeyCode == Keys.Left)
        //    {
        //        LeftMoveTimer.Stop();
        //    }

        //    if (e.KeyCode == Keys.Right)
        //    {
        //        RightMoveTimer.Stop();
        //    }

        //    if (e.KeyCode == Keys.Up)
        //    {
        //        UpMoveTimer.Stop();
        //    }

        //    if (e.KeyCode == Keys.Down)
        //    {
        //        DownMoveTimer.Stop();
        //    }
        //}
    }
}