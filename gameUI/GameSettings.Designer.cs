namespace gameUI
{
    partial class GameSettings
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
            label1 = new Label();
            lblPlayer1 = new Label();
            lblPlayer2 = new Label();
            txtplr1 = new TextBox();
            txtplr2 = new TextBox();
            gameTime = new TrackBar();
            label2 = new Label();
            btnStartGame = new Button();
            ((System.ComponentModel.ISupportInitialize)gameTime).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Font = new Font("Arial Rounded MT Bold", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(269, 52);
            label1.Name = "label1";
            label1.Size = new Size(203, 30);
            label1.TabIndex = 0;
            label1.Text = "Configure Game";
            // 
            // lblPlayer1
            // 
            lblPlayer1.AutoSize = true;
            lblPlayer1.Font = new Font("Arial Rounded MT Bold", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPlayer1.ForeColor = SystemColors.ButtonHighlight;
            lblPlayer1.Location = new Point(109, 112);
            lblPlayer1.Name = "lblPlayer1";
            lblPlayer1.Size = new Size(146, 33);
            lblPlayer1.TabIndex = 1;
            lblPlayer1.Text = "Player 1 -";
            // 
            // lblPlayer2
            // 
            lblPlayer2.AutoSize = true;
            lblPlayer2.Font = new Font("Arial Rounded MT Bold", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPlayer2.ForeColor = SystemColors.ButtonHighlight;
            lblPlayer2.Location = new Point(109, 189);
            lblPlayer2.Name = "lblPlayer2";
            lblPlayer2.Size = new Size(146, 33);
            lblPlayer2.TabIndex = 2;
            lblPlayer2.Text = "Player 2 -";
            // 
            // txtplr1
            // 
            txtplr1.Location = new Point(274, 122);
            txtplr1.Name = "txtplr1";
            txtplr1.Size = new Size(203, 23);
            txtplr1.TabIndex = 3;
            // 
            // txtplr2
            // 
            txtplr2.Location = new Point(274, 199);
            txtplr2.Name = "txtplr2";
            txtplr2.Size = new Size(203, 23);
            txtplr2.TabIndex = 4;
            // 
            // gameTime
            // 
            gameTime.Location = new Point(384, 272);
            gameTime.Name = "gameTime";
            gameTime.Size = new Size(197, 45);
            gameTime.TabIndex = 5;
            gameTime.Value = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Rounded MT Bold", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(109, 272);
            label2.Name = "label2";
            label2.Size = new Size(278, 33);
            label2.TabIndex = 6;
            label2.Text = "Select Game Time:";
            // 
            // btnStartGame
            // 
            btnStartGame.BackColor = Color.Gold;
            btnStartGame.Font = new Font("Arial Rounded MT Bold", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnStartGame.ForeColor = SystemColors.ActiveCaptionText;
            btnStartGame.Location = new Point(249, 340);
            btnStartGame.Name = "btnStartGame";
            btnStartGame.Size = new Size(199, 65);
            btnStartGame.TabIndex = 7;
            btnStartGame.Text = "Start Game";
            btnStartGame.UseVisualStyleBackColor = false;
            btnStartGame.Click += btnStartGame_Click;
            // 
            // GameSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SaddleBrown;
            ClientSize = new Size(800, 450);
            Controls.Add(btnStartGame);
            Controls.Add(label2);
            Controls.Add(gameTime);
            Controls.Add(txtplr2);
            Controls.Add(txtplr1);
            Controls.Add(lblPlayer2);
            Controls.Add(lblPlayer1);
            Controls.Add(label1);
            Name = "GameSettings";
            Text = "GameSettings";
            ((System.ComponentModel.ISupportInitialize)gameTime).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblPlayer1;
        private Label lblPlayer2;
        private TextBox txtplr1;
        private TextBox txtplr2;
        private TrackBar gameTime;
        private Label label2;
        private Button btnStartGame;
    }
}