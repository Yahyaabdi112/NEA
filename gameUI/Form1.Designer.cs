namespace gameUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btntutorial = new Button();
            btnquit = new Button();
            btnplay = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // btntutorial
            // 
            btntutorial.Anchor = AnchorStyles.Bottom;
            btntutorial.AutoSize = true;
            btntutorial.BackColor = Color.DarkOrange;
            btntutorial.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btntutorial.Location = new Point(273, 302);
            btntutorial.Name = "btntutorial";
            btntutorial.Size = new Size(143, 54);
            btntutorial.TabIndex = 0;
            btntutorial.Text = "TUTORIAL";
            btntutorial.UseVisualStyleBackColor = false;
            btntutorial.Click += btntutorial_Click;
            // 
            // btnquit
            // 
            btnquit.Anchor = AnchorStyles.Bottom;
            btnquit.AutoSize = true;
            btnquit.BackColor = Color.Red;
            btnquit.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnquit.Location = new Point(273, 362);
            btnquit.Name = "btnquit";
            btnquit.Size = new Size(143, 54);
            btnquit.TabIndex = 1;
            btnquit.Text = "QUIT";
            btnquit.UseVisualStyleBackColor = false;
            btnquit.Click += btnquit_Click;
            // 
            // btnplay
            // 
            btnplay.Anchor = AnchorStyles.Bottom;
            btnplay.AutoSize = true;
            btnplay.BackColor = Color.LimeGreen;
            btnplay.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnplay.Location = new Point(273, 242);
            btnplay.Name = "btnplay";
            btnplay.Size = new Size(143, 54);
            btnplay.TabIndex = 2;
            btnplay.Text = "PLAY";
            btnplay.UseVisualStyleBackColor = false;
            btnplay.Click += btnplay_Click_1;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ActiveBorder;
            label1.Font = new Font("Arial", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(220, 50);
            label1.Name = "label1";
            label1.Size = new Size(253, 75);
            label1.TabIndex = 3;
            label1.Text = "CHESS";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = SystemColors.ActiveCaptionText;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(671, 450);
            Controls.Add(btnquit);
            Controls.Add(btnplay);
            Controls.Add(btntutorial);
            Controls.Add(label1);
            DoubleBuffered = true;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            Resize += Form1_Resize;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btntutorial;
        private Button btnquit;
        private Button btnplay;
        private Label label1;
    }
}
