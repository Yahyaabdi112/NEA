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
            SuspendLayout();
            // 
            // btnquit
            // 
            btnquit.Anchor = AnchorStyles.Right;
            btnquit.AutoSize = true;
            btnquit.BackColor = Color.Gold;
            btnquit.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnquit.Location = new Point(645, 109);
            btnquit.Name = "btnquit";
            btnquit.Size = new Size(143, 54);
            btnquit.TabIndex = 2;
            btnquit.Text = "QUIT";
            btnquit.UseVisualStyleBackColor = false;
            btnquit.Click += btnquit_Click;
            // 
            // GameWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SaddleBrown;
            ClientSize = new Size(800, 450);
            Controls.Add(btnquit);
            Name = "GameWindow";
            Text = "GameWindow";
            Load += GameWindow_Load;
            Paint += GameWindow_Paint;
            Resize += GameWindow_Resize;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnquit;
    }
}