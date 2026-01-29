using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gameUI
{
    public partial class GameSettings : Form
    {
        public GameSettings()
        {
            InitializeComponent();
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            GameWindow gameWindow = new GameWindow(txtplr1.Text, txtplr2.Text, gameTime.Value);
            this.Hide();
            gameWindow.Show();
        }

        private void GameSettings_Load(object sender, EventArgs e)
        {

        }
    }
}
