using System;
using System.CodeDom;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.IO;
namespace CaroGameVer2
{
    public class ChessBoardManager
    {
        #region Properties

        private Panel chessBoard;
        public Panel ChessBoard
        {
            get { return chessBoard; }
            set { chessBoard = value; }
        }
        private List<Player> player;
        public List<Player> Player
        {
            get { return player; }
            set { player = value; }
        }
        private int currentPlayer; 
        public int CurrentPlayer
        {
            get { return currentPlayer; }
            set { currentPlayer = value; }
        }
        private TextBox playerName;
        public TextBox PlayerName
        {
            get { return playerName; }
            set { playerName = value; }
        }
        private PictureBox playerMark;
        public PictureBox PlayerMark
        {
            get { return  playerMark; }
            set { playerMark = value; }
        }

        private List<List<Button>> matrixOfButton;
        public List<List<Button>> MatrixOfButton
        {
            get { return  matrixOfButton; }
            set { matrixOfButton = value; }
        }

        private event EventHandler playerMarked;

        public event EventHandler PlayerMarked
        {
            add { playerMarked += value; }
            remove { playerMarked -= value; }
        }

        private event EventHandler endedGame;

        public event EventHandler EndedGame 
        {
            add { endedGame += value; }
            remove { endedGame -= value; }
        }
       
        #endregion

        #region Initialize

        public ChessBoardManager(Panel chessBoard, TextBox playerName, PictureBox ptbMark)
        {
            this.ChessBoard = chessBoard; 
            this.PlayerName = playerName;
            this.PlayerMark = ptbMark;

            this.player = new List<Player>()
            { 
                new Player("Player One", Image.FromFile(Application.StartupPath + "..\\..\\..\\Resources\\O_element.png")),
                new Player("Player Two", Image.FromFile(Application.StartupPath +  "..\\..\\..\\Resources\\X_element.png"))
            };
            currentPlayer = 0;
            ChangePlayer();
        }

        #endregion
        #region Methods

        public void DrawGameBoard() 
        {
            ChessBoard.Enabled = !false;
            Button oldbtn = new Button() { Width = 0, Height = 0 };
            MatrixOfButton = new List<List<Button>>();
            for (int i = 0; i < Const.CHESS_BOARD_WIDTH; i++)
            {
                MatrixOfButton.Add(new List<Button>());
                for (int j = 0; j < Const.CHESS_BOARD_HEIGHT; j++)
                {
                    Button btn = new Button()
                    {
                        Width = 32,
                        Height = 32,
                        Location = new Point(oldbtn.Location.X + oldbtn.Width, oldbtn.Location.Y),
                        BackgroundImageLayout = ImageLayout.Stretch,
                        Tag = i.ToString(),
                    };
                    btn.Click += btn_Click;
                    ChessBoard.Controls.Add(btn);
                    oldbtn = btn;
                    MatrixOfButton[i].Add(btn);
                }
                oldbtn.Location = new Point(0, oldbtn.Location.Y + Const.CHESS_HEIGHT);
                oldbtn.Width = 0;
                oldbtn.Height = 0;
            }
        }

        private bool isEndGame(Button btn)
        {
            return EndGameVertical(btn) || EndGameHorizontal(btn) || EndGamePrimaryDiagonal(btn) || EndGameSubticalDiagonal(btn);
        }

        private void ChangePlayer()
        {
            PlayerName.Text = Player[CurrentPlayer].Player_name;
            PlayerMark.Image = Player[CurrentPlayer].Mark;
        }

        private Point GetChessPoint(Button btn)
        {

            int Vertical = Convert.ToInt32(btn.Tag);
            int Horizontal = MatrixOfButton[Vertical].IndexOf(btn);
            
            Point point = new Point(Horizontal, Vertical);
            return point;
        }

        private void ChangeMark(Button btn)
        {
            btn.BackgroundImage = Player[CurrentPlayer].Mark;
            CurrentPlayer = CurrentPlayer == 1 ? 0 : 1;
        }

        public void EndGame()
        {
            if (endedGame != null)
                endedGame(this, new EventArgs());
        }

        private bool EndGameHorizontal(Button btn)
        {
            Point point = GetChessPoint(btn);
            int CountLeft = 0;
            for(int i = point.X; i >=  0 ; i--)
            {
                if (MatrixOfButton[point.Y][i].BackgroundImage == btn.BackgroundImage)
                    CountLeft++;
                else 
                    break;
            }

            int CountRight = 0;
            for(int i = point.X+1; i < Const.CHESS_BOARD_WIDTH; i++)
            {
                if (MatrixOfButton[point.Y][i].BackgroundImage == btn.BackgroundImage)
                    CountRight++;
                else 
                    break;
            }
            return CountLeft + CountRight == 5;
        }

        private bool EndGameVertical(Button btn)
        {
            Point point = GetChessPoint(btn);
            int CountTop = 0;
            for(int i  = point.Y; i >= 0; i--)
            {
                if (MatrixOfButton[i][point.X].BackgroundImage == btn.BackgroundImage)
                    CountTop++;
                else
                    break;
            }
            int CountBottom = 0;
            for(int i = point.Y+1; i < Const.CHESS_BOARD_HEIGHT; i++)
            {
                if (MatrixOfButton[i][point.X].BackgroundImage == btn.BackgroundImage)
                    CountBottom++;
                else
                    break;
            }
            return CountBottom + CountTop == 5;
        }

        private bool EndGamePrimaryDiagonal(Button btn)
        {
            Point point = GetChessPoint(btn);

            int CountTop = 0;
            for(int i = 0; i <= point.X; i++)
            {
                if (point.X - i < 0 || point.Y - i < 0)
                    break;
                if (MatrixOfButton[point.Y - i][point.X - i].BackgroundImage == btn.BackgroundImage)
                    CountTop++;
                else
                    break;
            }

            int CountBottom = 0;
            for(int i = 1; i < Const.CHESS_BOARD_WIDTH - point.X; i++)
            {
                if (point.Y + i > Const.CHESS_BOARD_HEIGHT || point.X + i > Const.CHESS_BOARD_WIDTH)
                    break;
                if (MatrixOfButton[point.Y + i][point.X + i].BackgroundImage == btn.BackgroundImage)
                    CountBottom++;
                else
                    break;
            }

            return CountBottom + CountTop == 5;

        }

        private bool EndGameSubticalDiagonal(Button btn)
        {
            Point point = GetChessPoint(btn);
            int CountTop = 0;
            for(int i = 0; i <= point.X; i++)
            {
                if(point.X + i> Const.CHESS_BOARD_WIDTH || point.Y - i  < 0 )
                    break;
                if(MatrixOfButton[point.Y - i][point.X + i].BackgroundImage == btn.BackgroundImage)
                    CountTop++;
                else 
                    break;
            }
            int CountBotton = 0;
            for(int i = 1; i <= Const.CHESS_BOARD_WIDTH - point.X;i++)
            {
                if(point.Y + i >= Const.CHESS_BOARD_HEIGHT || point.X - i < 0)
                    break;
                if (MatrixOfButton[point.Y + i][point.X - i].BackgroundImage == btn.BackgroundImage)
                    CountBotton++;
                else
                    break;
            }
            return CountBotton + CountTop == 5;
        }

        void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.BackgroundImage != null)
                return;
            ChangeMark(btn);
            ChangePlayer();

            if (playerMarked != null)
                playerMarked(this, new EventArgs());

            if (isEndGame(btn))
            {
                EndGame();
            }
        }

        #endregion
    }
}
