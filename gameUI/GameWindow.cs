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

namespace gameUI
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


       public class Imageresources
       {
           // public static System.Drawing.Image WhitePawnImage => Properties.Resources.w_pawn_svg_withShadow;
       }
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


           /* Tiles[,] tiles = new Tiles[9, 9];
            CreateBoard<Tiles> board = new CreateBoard<Tiles>(tiles);

            board.create();
            Dictionary<(int row, int column), Piece> pieces = new Dictionary<(int row, int column), Piece>(); //the dictionary which is passed into the addPieces object - dont call this dictionary when trying to access the dictionary, this dictionary is just a meant to be passed in to the addPieces object to change the value of the dictionary of the addPieces object from generic to Piece
            AddPieces<Piece, Tiles> addPieces = new AddPieces<Piece, Tiles>(pieces, tiles); //How the pieces are added
            addPieces.add("pawn");
            
            


            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    // PointF point = new PointF(Convert.ToInt16(tiles[i, j].column), Convert.ToInt16(tiles[i, j].row));


                    PictureBox tilePicture = new PictureBox();
                    PictureBox piecepicture = new PictureBox();
                    


                    if (WindowResize == true)
                    {
                        tilePicture.Size = new Size(55 * (Newx / x), 55 * (Newy / y));
                        tilePicture.Location = new Point((tiles[i, j].column + i * 55) * (Newx / x), (tiles[i, j].row + j * 55) * (Newy / y));
                        tilePicture.Name = "Tile: " + Convert.ToString(tiles[i, j].column) + ", " + Convert.ToString(tiles[i, j].row);
                        tilePicture.Image = tiles[i, j].Tileimage;
                        

                        if (j == 1 || j == 6)
                        {
                            Bitmap pieceImageBitmap = new Bitmap(addPieces._Pieces[(i, j)].PieceImage);
                            Graphics g = Graphics.FromImage(pieceImageBitmap);
                            
                                
                            g.DrawImage(pieceImageBitmap, tiles[i, j].column + i * 55, tiles[i, j].row + j * 55);
                        }
                    }
                    else
                    {
                        tilePicture.Name = "Tile: " + Convert.ToString(tiles[i, j].column) + ", " + Convert.ToString(tiles[i, j].row);
                        tilePicture.Size = new Size(55, 55);
                        tilePicture.Location = new Point(tiles[i, j].column + i * 55, tiles[i, j].row + j * 55);
                        tilePicture.Image = tiles[i, j].Tileimage;
                        //tilePicture.SendToBack();

                        if (j == 1 || j == 6)
                        {
                            Bitmap pieceImageBitmap = new Bitmap(addPieces._Pieces[(i, j)].PieceImage);
                            //using PaintEventArgs y;
                            Graphics g = Graphics.FromImage(pieceImageBitmap);
                            

                            g.DrawImage(pieceImageBitmap, new Rectangle(tiles[i, j].column + i * 55, tiles[i, j].row + j * 55, 50, 50));


                            /*piecepicture.Size = new Size(20, 20);
                            piecepicture.Location = new Point(tiles[i, j].column + i * 55, tiles[i, j].row + j * 55);
                            
                            piecepicture.Image = addPieces._Pieces[(i, j)].PieceImage;
                            
                            piecepicture.SizeMode = PictureBoxSizeMode.Zoom;

                            //piecepicture.BackColor = Color.Transparent;

                            //piecepicture.Name = addPieces._Pieces[(i + 1, j + 1)].type;
                        }
                    }

                    
                    this.Controls.Add(tilePicture);
                    
                        this.Controls.Add(piecepicture);
                        piecepicture.BringToFront();
                    
                    if (i == 8)
                    {
                        for (int k = 0; k < 9; k++)
                        {
                            this.Controls.RemoveByKey($"Tile: 8, {k}");

                        }
                    }*/

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
            

         
          
        
