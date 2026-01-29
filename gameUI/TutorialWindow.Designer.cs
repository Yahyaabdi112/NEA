namespace gameUI
{
    partial class TutorialWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnquit = new Button();
            linkLabel1 = new LinkLabel();
            listBox1 = new ListBox();
            SuspendLayout();
            // 
            // btnquit
            // 
            btnquit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnquit.AutoSize = true;
            btnquit.BackColor = Color.Gold;
            btnquit.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnquit.Location = new Point(464, 12);
            btnquit.Name = "btnquit";
            btnquit.Size = new Size(143, 54);
            btnquit.TabIndex = 3;
            btnquit.Text = "QUIT";
            btnquit.UseVisualStyleBackColor = false;
            btnquit.Click += btnquit_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(677, 140);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(60, 15);
            linkLabel1.TabIndex = 0;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "linkLabel1";
            // 
            // listBox1
            // 
            listBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBox1.FormattingEnabled = true;
            listBox1.Items.AddRange(new object[] { "\t\t                        The Fundamentals of Chess", "", "1. The Chessboard", "•\t8×8 grid of alternating light and dark squares.", "•\tEach player starts with 16 pieces:", "o\t1 King", "o\t1 Queen", "o\t2 Rooks", "o\t2 Bishops", "o\t2 Knights", "o\t8 Pawns", "•\tWhite pieces are placed on ranks 1–2, black on ranks 7–8.", "•\tBottom-right square is always light.", "________________________________________", "2. Objective", "•\tCheckmate the opponent’s king (put it under threat of capture and give no legal move to escape).", "•\tDraws are possible (see Section 7).", "________________________________________", "3. Piece Movement", "King", "•\tMoves 1 square in any direction (horizontally, vertically, diagonally).", "•\tCannot move into check.", "Queen", "•\tMoves any number of squares horizontally, vertically, or diagonally.", "Rook", "•\tMoves any number of squares horizontally or vertically.", "•\tParticipates in castling.", "Bishop", "•\tMoves any number of squares diagonally.", "•\tEach bishop stays on the same colour it started.", "Knight", "•\tMoves in an “L” shape: two squares in one direction, then one perpendicular.", "•\tCan jump over other pieces.", "Pawn", "•\tMoves forward 1 square (cannot move backward).", "•\tFirst move: may move forward 2 squares.", "•\tCaptures diagonally (1 square forward-left or forward-right).", "•\tSpecial rules: en passant, promotion.", "________________________________________", "4. Special Moves", "Castling", "•\tMove king two squares towards a rook, then move rook to the square next to the king on the opposite side.", "•\tConditions:", "o\tNeither king nor rook has moved.", "o\tNo pieces between them.", "o\tKing is not in check, does not move through check, and does not end in check.", "En Passant", "•\tIf a pawn moves two squares forward from its starting position and lands beside an opponent’s pawn, that opponent may capture it “as if” it had moved only one square forward.", "•\tMust be done immediately on the next move.", "Promotion", "•\tWhen a pawn reaches the opposite end of the board, it is promoted to queen, rook, bishop, or knight (player’s choice).", "•\tMost players choose a queen.", "________________________________________", "5. Check & Checkmate", "•\tCheck: King is under threat of capture. Must respond by:", "1.\tMoving the king out of check.", "2.\tBlocking the check.", "3.\tCapturing the attacking piece.", "•\tCheckmate: King is in check and no legal move can remove the threat — game over.", "________________________________________", "6. Draw Conditions", "•\tStalemate: Player to move has no legal move, but king is not in check.", "•\tThreefold repetition: Same position occurs three times with the same player to move.", "•\t50-move rule: 50 moves have passed with no pawn move or capture.", "•\tInsufficient material: Neither player has enough material to checkmate (e.g., king vs king, king vs king+bishop, etc.).", "•\tMutual agreement.", "________________________________________", "7. Additional Rules", "•\tYou must move if you have a legal move (no passing turns).", "•\tYou cannot place or leave your king in check.", "•\tTouch-move rule (in official play): If you touch a piece, you must move it if legal" });
            listBox1.Location = new Point(12, 12);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(429, 319);
            listBox1.TabIndex = 2;
            // 
            // TutorialWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SaddleBrown;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(619, 354);
            Controls.Add(listBox1);
            Controls.Add(linkLabel1);
            Controls.Add(btnquit);
            Name = "TutorialWindow";
            Text = "TutorialWindow";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnquit;
        private ListBox listBox1;
        private LinkLabel linkLabel1;
    }
}