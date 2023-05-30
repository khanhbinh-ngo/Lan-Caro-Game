using System.Windows.Forms.VisualStyles;
namespace CaroGameVer2
{
    public partial class Form1 : Form
    {
        #region Properties
        ChessBoardManager ChessBoard;

        #endregion

        #region Initiialize
        #endregion
        public Form1()
        {
            InitializeComponent();
            ChessBoard = new ChessBoardManager(pnlGameBoard, txbPlayerName, ptbxMark);
            ChessBoard.EndedGame += ChessBoard_EndedGame;
            ChessBoard.PlayerMarked += ChessBoard_PlayerMarked;

            prcbCoolDown.Step = Const.COOL_DOWN_STEP;
            prcbCoolDown.Maximum = Const.COOL_DOWN_TIME;
            prcbCoolDown.Value = 0;
            tmCoolDown.Interval = Const.COOL_DOWN_INTERVAL;
            tmCoolDown.Start();
            ChessBoard.DrawGameBoard();
        }

        void EndGame()
        {
            MessageBox.Show("end game");
            pnlGameBoard.Enabled = false;

        }

        private void ChessBoard_PlayerMarked(object? sender, EventArgs e)
        {
            tmCoolDown.Start();
            prcbCoolDown.Value = 0;
        }

        private void ChessBoard_EndedGame(object? sender, EventArgs e)
        {
            EndGame();

        }

        private void tmCoolDown_Tick(object sender, EventArgs e)
        {
            if(prcbCoolDown.Value >= prcbCoolDown.Maximum) 
            {
                EndGame(); 
            }
            prcbCoolDown.PerformStep();
            tmCoolDown.Stop();

        }

        private void prcbCoolDown_Click(object sender, EventArgs e)
        {

        }
    }
}