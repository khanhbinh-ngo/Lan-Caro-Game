namespace CaroGameVer2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pnlGameBoard = new Panel();
            pnlAvatar = new Panel();
            ptrbAvatar = new PictureBox();
            pnlMARK = new Panel();
            ptbxMark = new PictureBox();
            pnlIP = new TextBox();
            prcbCoolDown = new ProgressBar();
            txbPlayerName = new TextBox();
            label1 = new Label();
            btnLAN = new Button();
            tmCoolDown = new System.Windows.Forms.Timer(components);
            pnlAvatar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ptrbAvatar).BeginInit();
            pnlMARK.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ptbxMark).BeginInit();
            SuspendLayout();
            // 
            // pnlGameBoard
            // 
            pnlGameBoard.Location = new Point(12, 12);
            pnlGameBoard.Name = "pnlGameBoard";
            pnlGameBoard.Size = new Size(700, 711);
            pnlGameBoard.TabIndex = 0;
            // 
            // pnlAvatar
            // 
            pnlAvatar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlAvatar.Controls.Add(ptrbAvatar);
            pnlAvatar.Location = new Point(718, 12);
            pnlAvatar.Name = "pnlAvatar";
            pnlAvatar.Size = new Size(400, 400);
            pnlAvatar.TabIndex = 1;
            // 
            // ptrbAvatar
            // 
            ptrbAvatar.BackgroundImage = Properties.Resources.image;
            ptrbAvatar.BackgroundImageLayout = ImageLayout.Stretch;
            ptrbAvatar.Location = new Point(3, 3);
            ptrbAvatar.Name = "ptrbAvatar";
            ptrbAvatar.Size = new Size(394, 394);
            ptrbAvatar.TabIndex = 0;
            ptrbAvatar.TabStop = false;
            // 
            // pnlMARK
            // 
            pnlMARK.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlMARK.Controls.Add(ptbxMark);
            pnlMARK.Controls.Add(pnlIP);
            pnlMARK.Controls.Add(prcbCoolDown);
            pnlMARK.Controls.Add(txbPlayerName);
            pnlMARK.Controls.Add(label1);
            pnlMARK.Controls.Add(btnLAN);
            pnlMARK.Location = new Point(718, 433);
            pnlMARK.Name = "pnlMARK";
            pnlMARK.Size = new Size(400, 290);
            pnlMARK.TabIndex = 2;
            // 
            // ptbxMark
            // 
            ptbxMark.BackgroundImage = Properties.Resources._100;
            ptbxMark.BackgroundImageLayout = ImageLayout.Stretch;
            ptbxMark.Location = new Point(227, 23);
            ptbxMark.Name = "ptbxMark";
            ptbxMark.Size = new Size(154, 130);
            ptbxMark.SizeMode = PictureBoxSizeMode.StretchImage;
            ptbxMark.TabIndex = 5;
            ptbxMark.TabStop = false;
            // 
            // pnlIP
            // 
            pnlIP.Location = new Point(18, 91);
            pnlIP.Name = "pnlIP";
            pnlIP.Size = new Size(181, 27);
            pnlIP.TabIndex = 4;
            // 
            // prcbCoolDown
            // 
            prcbCoolDown.Location = new Point(18, 56);
            prcbCoolDown.Name = "prcbCoolDown";
            prcbCoolDown.Size = new Size(181, 29);
            prcbCoolDown.TabIndex = 3;
            prcbCoolDown.Click += prcbCoolDown_Click;
            // 
            // txbPlayerName
            // 
            txbPlayerName.Location = new Point(18, 23);
            txbPlayerName.Name = "txbPlayerName";
            txbPlayerName.ReadOnly = true;
            txbPlayerName.Size = new Size(181, 27);
            txbPlayerName.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Showcard Gothic", 24F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(18, 194);
            label1.Name = "label1";
            label1.Size = new Size(363, 50);
            label1.TabIndex = 1;
            label1.Text = "5 in a line to win";
            // 
            // btnLAN
            // 
            btnLAN.Location = new Point(18, 124);
            btnLAN.Name = "btnLAN";
            btnLAN.Size = new Size(181, 29);
            btnLAN.TabIndex = 0;
            btnLAN.Text = "LAN";
            btnLAN.UseVisualStyleBackColor = true;
            // 
            // tmCoolDown
            // 
            tmCoolDown.Tick += tmCoolDown_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1131, 735);
            Controls.Add(pnlMARK);
            Controls.Add(pnlAvatar);
            Controls.Add(pnlGameBoard);
            Name = "Form1";
            Text = "Form1";
            pnlAvatar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ptrbAvatar).EndInit();
            pnlMARK.ResumeLayout(false);
            pnlMARK.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ptbxMark).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlGameBoard;
        private Panel pnlAvatar;
        private PictureBox ptrbAvatar;
        private Panel pnlMARK;
        private PictureBox ptbxMark;
        private TextBox pnlIP;
        private ProgressBar prcbCoolDown;
        private TextBox txbPlayerName;
        private Label label1;
        private Button btnLAN;
        private System.Windows.Forms.Timer tmCoolDown;
    }
}