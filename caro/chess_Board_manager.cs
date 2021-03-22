using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace caro
{
    public class chess_Board_manager
    {

        #region Properties
        private Panel chessBoard;
        private List<player> player;
        private int currentplayer;
        private TextBox pleyerName;
        private PictureBox playerMark;
        private List<List<Button>> matrix;
        private event EventHandler playermarked;
        public event EventHandler Playermarked
        {
            add
            {
                playermarked += value;
            }
            remove
            {
                playermarked -= value;
            }
        }
        private event EventHandler endegame;
        public event EventHandler Endegame
        {
            add
            {
                endegame += value;
            }
            remove
            {
                endegame -= value;
            }
        }

        private Stack<playinfo> playTimeLine;
        public Panel ChessBoard { get => chessBoard; set => chessBoard = value; }
        public List<player> Player { get => player; set => player = value; }
        public int Currentplayer { get => currentplayer; set => currentplayer = value; }
        public TextBox PleyerName { get => pleyerName; set => pleyerName = value; }
        public PictureBox PlayerMark { get => playerMark; set => playerMark = value; }
        public List<List<Button>> Matrix { get => matrix; set => matrix = value; }

        #endregion

        #region Intialize
        public chess_Board_manager(Panel chessBoard,TextBox playername, PictureBox mark)
        {
            this.ChessBoard = chessBoard;
            this.pleyerName = playername;
            this.playerMark = mark;
            this.Player = new List<player>()
            { 
                new player("player1",Image.FromFile(Application.StartupPath+"\\Resources\\x.png")),
                 new player("player2",Image.FromFile(Application.StartupPath+"\\Resources\\o.png"))
            };
          

           
        }

      
        #endregion
        #region Method
        public void DrawChessBoard()
        {

          
            chessBoard.Enabled = true;
            chessBoard.Controls.Clear();
                
            playTimeLine = new Stack<playinfo>();
            currentplayer = 0;
            changePlayer();

            matrix = new List<List<Button>>();

            //vẽ bàn cờ
            Button oldbutton = new Button() { Width = 0, Location = new Point(0, 0) };
            for (int i = 0; i < content.chess_board_height; i++)
            {
                matrix.Add(new List<Button>());
                for (int j = 0; j < content.chess_board_width; j++)
                {
                    Button btn = new Button()
                    {
                        Width = content.chess_width,
                        Height = content.chess_height,
                        Location = new Point(oldbutton.Location.X + oldbutton.Width, oldbutton.Location.Y),
                        BackgroundImageLayout = ImageLayout.Stretch,
                        Tag=i.ToString()
                        
                    };
                    btn.Click += Btn_Click;
                    ChessBoard.Controls.Add(btn);
                    //lưu vào list
                    matrix[i].Add(btn);
                    oldbutton = btn;
                }
                oldbutton.Location = new Point(0, oldbutton.Location.Y + content.chess_height);
                oldbutton.Width = 0;
                oldbutton.Height = 0;
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
           Button btn= sender as Button;
            if (btn.BackgroundImage != null)
                return;
            //đổi hình
            mark(btn);
            playTimeLine.Push(new playinfo(GetChesspoint(btn),Currentplayer));
            currentplayer = currentplayer == 1 ? 0 : 1;
            changePlayer();

            if (playermarked != null)
                playermarked(this, new EventArgs());

            if(IsEndGame(btn))
            {
                EndGame();
            }    
           
        }
        public void otherPlayerMark(Point point)
        {
           
            Button btn = matrix[point.Y][point.X];
            if (btn.BackgroundImage != null)
                return;
            //đổi hình
            mark(btn);
            playTimeLine.Push(new playinfo(GetChesspoint(btn), Currentplayer));
            currentplayer = currentplayer == 1 ? 0 : 1;
            changePlayer();

            if (playermarked != null)
                playermarked(this, new EventArgs());

            if (IsEndGame(btn))
            {
                EndGame();
            }

        }
        private bool IsEndGame(Button btn)
        {
            return IsAnd_Horizontal(btn) || IsAnd_Vertical(btn) || IsAnd_Primary(btn) || IsAnd_Sub(btn);
        }
        private Point GetChesspoint( Button btn)
        {
            
            int vertical = Convert.ToInt32(btn.Tag);
            int horizontal = matrix[vertical].IndexOf(btn);
            Point point = new Point(horizontal, vertical);

            return point;
        }
        private bool IsAnd_Horizontal(Button btn)
        {
            Point point = GetChesspoint(btn);
            int countLeft = 0;
            for(int i=point.X;i>=0;i--)
            {
                if (matrix[point.Y][i].BackgroundImage == btn.BackgroundImage)
                {
                    countLeft++;
                }
                else
                    break;
            }    

            int countright = 0;
            for (int i = point.X+1; i < content.chess_board_width; i++)
            {
                if (matrix[point.Y][i].BackgroundImage == btn.BackgroundImage)
                {
                    countright++;
                }
                else
                    break;
            }

            return countLeft + countright==5;

        }
        private bool IsAnd_Vertical(Button btn)
        {
            Point point = GetChesspoint(btn);
            int countTop = 0;
            for (int i = point.Y; i >= 0; i--)
            {
                if (matrix[point.Y][i].BackgroundImage == btn.BackgroundImage)
                {
                    countTop++;
                }
                else
                    break;
            }

            int countBottom = 0;
            for (int i = point.X + 1; i < content.chess_board_height; i++)
            {
                if (matrix[i][point.X].BackgroundImage == btn.BackgroundImage)
                {
                    countBottom++;
                }
                else
                    break;
            }

            return countBottom + countTop == 5;
        }
        private bool IsAnd_Primary(Button btn)
        {
            //đường chéo chính xy tăng giảm cùng nhau
            Point point = GetChesspoint(btn);
            int countTop = 0;
            for (int i = 0; i <=point.X; i++)
            {
                if (point.X - i < 0 || point.Y - i < 0)
                    break;
                if (matrix[point.Y-i][point.X-i].BackgroundImage == btn.BackgroundImage)
                {
                    countTop++;
                }
                else
                    break;
            }

            int countBottom = 0;
            for (int i = 1; i <=content.chess_board_width - point.X; i++)
            {
                if (point.Y + i >= content.chess_board_width || point.X + i >= content.chess_board_height)
                    break;
                if (matrix[point.Y + i][point.X + i].BackgroundImage == btn.BackgroundImage)
                {
                    countBottom++;
                }
                else
                    break;
            }

            return countTop+countBottom == 5;
        }
        private bool IsAnd_Sub(Button btn)
        {
            Point point = GetChesspoint(btn);
            int countTop = 0;//đường chéo phụ hướng lên thĩ tăng y giảm
            for (int i = 0; i <= point.X; i++)
            {
                if (point.X + i > content.chess_board_width || point.Y - i < 0)
                    break;
                if (matrix[point.Y - i][point.X + i].BackgroundImage == btn.BackgroundImage)
                {
                    countTop++;
                }
                else
                    break;
            }

            int countBottom = 0;//đường chéo phụ hướng xuống thì y tắng x giảm
            for (int i = 1; i <= content.chess_board_width - point.X; i++)
            {
                if (point.Y + i >= content.chess_board_height || point.X - i < 0)
                    break;
                if (matrix[point.Y + i][point.X - i].BackgroundImage == btn.BackgroundImage)
                {
                    countBottom++;
                }
                else
                    break;
            }

            return countTop + countBottom == 5;
        }
        public void EndGame()
        {
            if (endegame != null)
                endegame(this, new EventArgs());

            MessageBox.Show("kết thúc game");
        }
        public bool Undo()
        {
            if (playTimeLine.Count <= 0)
                return false;
            playinfo oldpoint = playTimeLine.Pop();
            Button btn = matrix[oldpoint.Point.Y][oldpoint.Point.X];
            btn.BackgroundImage = null;

           

            if(playTimeLine.Count <= 0)
            {
                Currentplayer = 0;
            }
            else
            {
                oldpoint = playTimeLine.Peek();
                Currentplayer = playTimeLine.Peek().Currentplayer == 1 ? 0 : 1;
            }
            
           
            changePlayer();

            return true;
        }
        private void mark( Button btn)
        {
            btn.BackgroundImage = player[currentplayer].Mark1;
           
        }
        private void changePlayer()
        {
            pleyerName.Text = player[currentplayer].NamePlayer;
            playerMark.Image = player[currentplayer].Mark1;
        }
        
        #endregion


    }
}
