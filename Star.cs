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
        public Point Location;

        public Star(Image picture, Point location) 
        {
            Picture = new PictureBox()
            {
                Image = picture,
                BackColor = Color.Transparent,
            };
            Location = location;
        }
    }
}
