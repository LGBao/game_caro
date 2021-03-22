using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace caro
{
    public partial class Form1 : Form
    {
        #region Properties

        Socketmanager socket;
        chess_Board_manager ChessBoard;
        #endregion
        public Form1()
        {
            InitializeComponent();

         
            ChessBoard = new chess_Board_manager(pal_chessboard,txt_namePlayer,pc_avtplayer);
            ChessBoard.Endegame += ChessBoard_Endegame;
            ChessBoard.Playermarked += ChessBoard_Playermarked;

            //thời gian đếm ngược
            probar_timeDown.Step = content.stepTimeDown;
            probar_timeDown.Maximum = content.coolDownTime;
            probar_timeDown.Value = 0;

            tr_timeDown.Interval = content.coolDownInterval;
            
            //vẽ bàn cờ
            ChessBoard.DrawChessBoard();

            socket = new Socketmanager();
            // tr_timeDown.Start();
            Newgame();
        }

        private void ChessBoard_Playermarked(object sender, EventArgs e)
        {
            tr_timeDown.Start();
            probar_timeDown.Value = 0;
            socket.Send(new SocketData((int)SocketCommand.SEND_POINT,"",new Point(0,0)));
        }

        private void ChessBoard_Endegame(object sender, EventArgs e)
        {
            EndGame();
        }
        void EndGame()
        {
            tr_timeDown.Stop();
            MessageBox.Show("end game");
            pal_chessboard.Enabled = false;
            undoToolStripMenuItem.Enabled = false;

        }
        void Newgame()
        {
            probar_timeDown.Value = 0;
            tr_timeDown.Stop();
            undoToolStripMenuItem.Enabled = true;
            ChessBoard.DrawChessBoard();
            
        }
        void Quit() 
        {
          //  if (MessageBox.Show("Bạn có chắc muốn thoát", "thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
             Application.Exit();
        }
        void Undo()
        {
            ChessBoard.Undo();
        }
        private void tr_timeDown_Tick(object sender, EventArgs e)
        {
            probar_timeDown.PerformStep();
            if (probar_timeDown.Value >= probar_timeDown.Maximum)
            {  EndGame(); }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Newgame();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Undo();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát", "thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                e.Cancel = true;
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            socket.IP = txt_IPserver.Text;

            if(!socket.ConnectServer())
            {
               /* socket.CreateServer();
                Thread listenThread = new Thread(() =>
                {
                    while(true)
                    {
                        Thread.Sleep(500);
                        try
                        {
                            Listen();
                            break;
                        }
                        catch { 
                        }
                        
                    }    
                   
                });
                listenThread.IsBackground = true;
                listenThread.Start();*/
              //  socket.Send("thông tin từ client");
            }    
            else
            {
                Listen();
             //   socket.Send(new SocketData((int)SocketCommand.NOTIFY,"Client đã kết nối"));
            }
            

        }
        void Listen()
        {
            
            
                Thread listenThread = new Thread(() =>
                {
                    try
                    {
                        SocketData data = (SocketData)socket.Receive();
                        ProcessData(data);
                    }
                    catch { }
                });
                listenThread.IsBackground = true;
                listenThread.Start();
          //  MessageBox.Show(data);
        }
        private void ProcessData(SocketData data)
        {
            switch(data.Command)
            {
                case (int)SocketCommand.NOTIFY:
                    MessageBox.Show(data.Message1);
                    break;
                case (int)SocketCommand.NEWGAME:
                    MessageBox.Show(data.Message1);
                    break;
                case (int)SocketCommand.QUUIT:
                    MessageBox.Show(data.Message1);
                    break;
                case (int)SocketCommand.SEND_POINT:
                    ChessBoard.otherPlayerMark(data.Point);


                    break;
                case (int)SocketCommand.UNDO:
                    MessageBox.Show(data.Message1);
                    break;
                default:
                    break;
            }
            Listen();
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            txt_IPserver.Text = socket.getLocalIPV4(System.Net.NetworkInformation.NetworkInterfaceType.Wireless80211);
            if(string.IsNullOrEmpty(txt_IPserver.Text))
            {
                txt_IPserver.Text = socket.getLocalIPV4(System.Net.NetworkInformation.NetworkInterfaceType.Wireless80211);
            }    
        }
    }


}
