using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caro
{
    public class player
    {
        private string namePlayer;

        public string NamePlayer { get => namePlayer; set => namePlayer = value; }//Ctrl+R+E
        public Image Mark1 { get => Mark; set => Mark = value; }

        private Image Mark;
        public player(string name , Image mark)
        {
            this.namePlayer = name;
            this.Mark = mark;
        }
    }
}
