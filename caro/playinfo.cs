using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caro
{
    public class playinfo
    {
        private Point point;

        public Point Point { get => point; set => point = value; }
        public int Currentplayer { get => currentplayer; set => currentplayer = value; }

        private int currentplayer;


        public playinfo(Point point,int currentplayer)
        {
            this.point = point;
            this.currentplayer = currentplayer;
        }    
    }
    
}
