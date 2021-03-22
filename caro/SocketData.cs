 using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caro
{
    [Serializable]
   public class SocketData
    {

        private int command;

        public int Command { get => command; set => command = value; }
        public Point Point { get => point; set => point = value; }
        public string Message1 { get => Message; set => Message = value; }

        private Point point;
        private string Message;
        public SocketData(int command, string message, Point point)
        {
            this.Point = point;
            this.command = command;
            this.Message1 = message;
        }
    }
    public enum SocketCommand
    {     SEND_POINT,
            NOTIFY,
        NEWGAME,
        UNDO,
        QUUIT

     }
}
