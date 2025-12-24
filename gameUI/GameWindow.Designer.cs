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
            SuspendLayout();
            // 
            // btnquit
            // 
            btnquit.Anchor = AnchorStyles.Right;
            btnquit.AutoSize = true;
            btnquit.BackColor = Color.Gold;
            btnquit.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnquit.Location = new Point(748, 148);
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
            // GameWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SaddleBrown;
            ClientSize = new Size(903, 528);
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
    }
}