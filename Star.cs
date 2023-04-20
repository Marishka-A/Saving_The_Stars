using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_The_Stars
{
    public class Star
    {
        public Image ImageStar;
        public Point Location;

        public Star(Point location, Image image) 
        {
            ImageStar = image;
            Location = location;
        }
    }
}
