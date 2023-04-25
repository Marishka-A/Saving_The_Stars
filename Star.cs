using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_The_Stars
{
    public class Star
    {
        public PictureBox Picture;
        public Point Position;
        public int Value;

        public Star(Image image, Point position) 
        {
            Picture = new PictureBox()
            {
                Left = position.X,
                Top = position.Y,
                Image = image,
                Bounds = new Rectangle(position, new Size(80, 80)),
                BackColor = Color.Transparent,
            };
            Position = position;
            Value = 20;
        }
    }
}
