using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Game_UI
{
    public partial class GameWindow : Form
    {
        public GameWindow()
        {
            InitializeComponent();
        }
        int x;
        int y;
        int Newx;
        int Newy;
        bool WindowResize;



        private void btnquit_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void GameWindow_Load(object sender, EventArgs e)
        {
            Rectangle screensize = new Rectangle(this.Location.X, this.Location.Y, this.Size.Width, this.Size.Height);
            x = this.Location.X;
            y = this.Location.Y;


            Tiles[,] tiles = new Tiles[9, 9];
            CreateBoard<Tiles> board = new CreateBoard<Tiles>(tiles);


            board.create();
            Console.WriteLine(tiles[0, 0].IsOccupied);

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    // PointF point = new PointF(Convert.ToInt16(tiles[i, j].column), Convert.ToInt16(tiles[i, j].row));


                    PictureBox picture = new PictureBox();



                    if (WindowResize == true)
                    {
                        picture.Size = new Size(55 * (Newx / x), 55 * (Newy / y));
                        picture.Location = new Point((tiles[i, j].column + i * 55) * (Newx / x), (tiles[i, j].row + j * 55) * (Newy / y));
                        picture.Name = "Tile: " + Convert.ToString(tiles[i, j].column) + ", " + Convert.ToString(tiles[i, j].row);
                        picture.Image = tiles[i, j].Tileimage;
                    }
                    else
                    {
                        picture.Name = "Tile: " + Convert.ToString(tiles[i, j].column) + ", " + Convert.ToString(tiles[i, j].row);
                        picture.Size = new Size(55, 55);
                        picture.Location = new Point(tiles[i, j].column + i * 55, tiles[i, j].row + j * 55);
                        picture.Image = tiles[i, j].Tileimage;
                    }

                    this.Controls.Add(picture);
                    if (i == 8)
                    {
                        for (int k = 0; k < 9; k++)
                        {
                            this.Controls.RemoveByKey($"Tile: 8, {k}");
                            
                        }
                    }

                }
            }

        }

        private void GameWindow_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void GameWindow_Resize(object sender, EventArgs e)
        {
            Newx = this.Location.X;
            Newy = this.Location.Y;
            WindowResize = true;
        }
    }
}
