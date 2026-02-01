namespace gameUI
{
    partial class GameWindow
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
            label1 = new Label();
            label2 = new Label();
            plr2time = new Label();
            plr1time = new Label();
            plr2CapturedPiecesBox = new GroupBox();
            plr1CapturedPiecesBox = new GroupBox();
            lblGameInfo = new Label();
            SuspendLayout();
            // 
            // btnquit
            // 
            btnquit.Anchor = AnchorStyles.Right;
            btnquit.AutoSize = true;
            btnquit.BackColor = Color.Gold;
            btnquit.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnquit.Location = new Point(748, 166);
            btnquit.Name = "btnquit";
            btnquit.Size = new Size(143, 54);
            btnquit.TabIndex = 2;
            btnquit.Text = "QUIT";
            btnquit.UseVisualStyleBackColor = false;
            btnquit.Click += btnquit_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ButtonFace;
            label1.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(80, 497);
            label1.Name = "label1";
            label1.Size = new Size(46, 22);
            label1.TabIndex = 3;
            label1.Text = "plr1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Snow;
            label2.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(438, 25);
            label2.Name = "label2";
            label2.Size = new Size(46, 22);
            label2.TabIndex = 4;
            label2.Text = "plr2";
            // 
            // plr2time
            // 
            plr2time.AutoSize = true;
            plr2time.BackColor = Color.Snow;
            plr2time.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            plr2time.Location = new Point(664, 25);
            plr2time.Name = "plr2time";
            plr2time.Size = new Size(86, 22);
            plr2time.TabIndex = 5;
            plr2time.Text = "plr2time";
            // 
            // plr1time
            // 
            plr1time.AutoSize = true;
            plr1time.BackColor = Color.Snow;
            plr1time.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            plr1time.Location = new Point(664, 497);
            plr1time.Name = "plr1time";
            plr1time.Size = new Size(86, 22);
            plr1time.TabIndex = 6;
            plr1time.Text = "plr1time";
            // 
            // plr2CapturedPiecesBox
            // 
            plr2CapturedPiecesBox.BackColor = Color.DarkOrange;
            plr2CapturedPiecesBox.ForeColor = SystemColors.ActiveCaptionText;
            plr2CapturedPiecesBox.Location = new Point(664, 59);
            plr2CapturedPiecesBox.Name = "plr2CapturedPiecesBox";
            plr2CapturedPiecesBox.Size = new Size(227, 89);
            plr2CapturedPiecesBox.TabIndex = 8;
            plr2CapturedPiecesBox.TabStop = false;
            plr2CapturedPiecesBox.Text = "Captured Pieces";
            // 
            // plr1CapturedPiecesBox
            // 
            plr1CapturedPiecesBox.BackColor = Color.DarkOrange;
            plr1CapturedPiecesBox.ForeColor = SystemColors.ActiveCaptionText;
            plr1CapturedPiecesBox.Location = new Point(664, 396);
            plr1CapturedPiecesBox.Name = "plr1CapturedPiecesBox";
            plr1CapturedPiecesBox.Size = new Size(227, 89);
            plr1CapturedPiecesBox.TabIndex = 9;
            plr1CapturedPiecesBox.TabStop = false;
            plr1CapturedPiecesBox.Text = "Captured Pieces";
            // 
            // lblGameInfo
            // 
            lblGameInfo.AutoSize = true;
            lblGameInfo.BackColor = Color.Snow;
            lblGameInfo.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblGameInfo.Location = new Point(664, 238);
            lblGameInfo.Name = "lblGameInfo";
            lblGameInfo.Size = new Size(103, 22);
            lblGameInfo.TabIndex = 10;
            lblGameInfo.Text = "Game Info";
            // 
            // GameWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SaddleBrown;
            ClientSize = new Size(903, 528);
            Controls.Add(lblGameInfo);
            Controls.Add(plr1CapturedPiecesBox);
            Controls.Add(plr2CapturedPiecesBox);
            Controls.Add(plr1time);
            Controls.Add(plr2time);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnquit);
            Name = "GameWindow";
            Text = "GameWindow";
            Load += GameWindow_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnquit;
        private Label label1;
        private Label label2;
        private Label plr2time;
        private Label plr1time;
        private GroupBox plr2CapturedPiecesBox;
        private GroupBox plr1CapturedPiecesBox;
        private Label lblGameInfo;
    }
}