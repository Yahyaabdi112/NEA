using gameUI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace gameUI
{
    public partial class GameWindow : Form
    {
        static int gameTime = 20;
        static string plr1name;
        static string plr2name;
        static bool isMessageBoxShown = false; //flag which says if the message box

        System.Windows.Forms.Timer refreshScreen = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer lightUpTileDebounce = new System.Windows.Forms.Timer(); //timer which for handlelling the green dot indicators


        public GameWindow(string plr1, string plr2, int val)
        {

            InitializeComponent();
            gameTime = val;
            plr1name = plr1;
            plr2name = plr2;
            label1.Text = plr1;
            label2.Text = plr2;

            refreshScreen.Tick += RefreshScreen_Tick;
            refreshScreen.Interval = 1;

            lightUpTileDebounce.Tick += lightUpTileDebounce_Tick;
            lightUpTileDebounce.Interval = 2000; //set each green dot to last for 2 seconds
        }

        private void RefreshScreen_Tick(object? sender, EventArgs e)
        {
            if (game.isGameEnd && isMessageBoxShown == false) //check if the game is over and the message box saying the game is over is not shown
            {
                isMessageBoxShown = true; //set the flag which says if the message box is shown to true
                string winner = "";
                string endReason = game.endCondition.ToString();
                if (game.Winner.color == itemColor.white)
                {
                    winner = "White";
                }
                else
                {
                    winner = "Black";
                }

                MessageBox.Show($"Game over \n The Winner is: {winner} by {endReason}", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            if (game.hasPieceBeenCaptured)
            {
                int xPiecePicturePositionBlack = 0;
                int yPiecePicturePositionBlack = 0;
                int xPiecePicturePositionWhite = 0;
                int yPiecePicturePositionWhite = 0;
                bool isFirstIterationForBlack = true; //this is used to check if its the first iteration of the loop so we dont move the x position on the first piece
                bool isFirstIterationForWhite = true; //this is used to check if its the first iteration of the loop so we dont move the x position on the first piece

                foreach (var piece in game.player1.takenPieces)
                {
                    if (!isFirstIterationForBlack)
                    {
                        xPiecePicturePositionBlack += 35;
                    }

                    PictureBox pieceImage = new PictureBox();
                    pieceImage.SizeMode = PictureBoxSizeMode.Zoom;

                    if (plr1CapturedPiecesBox.Size.Width < xPiecePicturePositionBlack + 35)
                    {
                        yPiecePicturePositionBlack += 35;
                        xPiecePicturePositionBlack = 0;
                    }

                    pieceImage.Size = new Size(35, 35);
                    if (piece.PieceType == PieceTypes.pawn)
                    {
                        if (piece.Color == itemColor.black)
                        {
                            pieceImage.Image = blackPawn;
                            pieceImage.Location = new Point(xPiecePicturePositionBlack, yPiecePicturePositionBlack);
                            plr1CapturedPiecesBox.Controls.Add(pieceImage);
                        }
                    }
                    if (piece.PieceType == PieceTypes.rook)
                    {
                        if (piece.Color == itemColor.black)
                        {
                            pieceImage.Image = blackRook;
                            pieceImage.Location = new Point(xPiecePicturePositionBlack, yPiecePicturePositionBlack);
                            plr1CapturedPiecesBox.Controls.Add(pieceImage);
                        }
                    }
                    if (piece.PieceType == PieceTypes.bishop)
                    {
                        if (piece.Color == itemColor.black)
                        {
                            pieceImage.Image = blackBishop;
                            pieceImage.Location = new Point(xPiecePicturePositionBlack, yPiecePicturePositionBlack);
                            plr1CapturedPiecesBox.Controls.Add(pieceImage);
                        }
                    }
                    if (piece.PieceType == PieceTypes.knight)
                    {
                        if (piece.Color == itemColor.black)
                        {
                            pieceImage.Image = blackKnight;
                            pieceImage.Location = new Point(xPiecePicturePositionBlack, yPiecePicturePositionBlack);
                            plr1CapturedPiecesBox.Controls.Add(pieceImage);
                        }
                    }
                    if (piece.PieceType == PieceTypes.queen)
                    {
                        if (piece.Color == itemColor.black)
                        {
                            pieceImage.Image = blackQueen;
                            pieceImage.Location = new Point(xPiecePicturePositionBlack, yPiecePicturePositionBlack);
                            plr1CapturedPiecesBox.Controls.Add(pieceImage);
                        }
                    }
                    if (piece.PieceType == PieceTypes.king)
                    {
                        if (piece.Color == itemColor.black)
                        {
                            pieceImage.Image = blackKing;
                            pieceImage.Location = new Point(xPiecePicturePositionBlack, yPiecePicturePositionBlack);
                            plr1CapturedPiecesBox.Controls.Add(pieceImage);
                        }        
                    }


                    isFirstIterationForBlack = false;

                }

                foreach (var piece in game.player2.takenPieces)
                {
                    if (!isFirstIterationForWhite)
                    {
                        xPiecePicturePositionWhite += 35;
                    }

                    PictureBox pieceImage = new PictureBox();
                    pieceImage.SizeMode = PictureBoxSizeMode.Zoom;

                    if (plr2CapturedPiecesBox.Size.Width < xPiecePicturePositionWhite + 35)
                    {
                        yPiecePicturePositionWhite += 35;
                        xPiecePicturePositionWhite = 0;
                    }

                    pieceImage.Size = new Size(35, 35);
                    if (piece.PieceType == PieceTypes.pawn)
                    {
                        
                        if (piece.Color == itemColor.white)
                        {
                            pieceImage.Image = whitePawn;
                            pieceImage.Location = new Point(xPiecePicturePositionWhite, yPiecePicturePositionWhite);
                            plr2CapturedPiecesBox.Controls.Add(pieceImage);
                        }

                    }
                    if (piece.PieceType == PieceTypes.rook)
                    {
                        if (piece.Color == itemColor.white)
                        {
                            pieceImage.Image = whiteRook;
                            pieceImage.Location = new Point(xPiecePicturePositionWhite, yPiecePicturePositionWhite);
                            plr2CapturedPiecesBox.Controls.Add(pieceImage);
                        }
                    }
                    if (piece.PieceType == PieceTypes.bishop)
                    {
                        if (piece.Color == itemColor.white)
                        {
                            pieceImage.Image = whiteBishop;
                            pieceImage.Location = new Point(xPiecePicturePositionWhite, yPiecePicturePositionWhite);
                            plr2CapturedPiecesBox.Controls.Add(pieceImage);
                        }
                    }
                    if (piece.PieceType == PieceTypes.knight)
                    {
                        if (piece.Color == itemColor.white)
                        {
                            pieceImage.Image = whiteKnight;
                            pieceImage.Location = new Point(xPiecePicturePositionWhite, yPiecePicturePositionWhite);
                            plr2CapturedPiecesBox.Controls.Add(pieceImage);
                        }
                    }
                    if (piece.PieceType == PieceTypes.queen)
                    {
                        if (piece.Color == itemColor.white)
                        {
                            pieceImage.Image = whiteQueen;
                            pieceImage.Location = new Point(xPiecePicturePositionWhite, yPiecePicturePositionWhite);
                            plr2CapturedPiecesBox.Controls.Add(pieceImage);
                        }
                    }
                    if (piece.PieceType == PieceTypes.king)
                    {
                        if (piece.Color == itemColor.white)
                        {
                            pieceImage.Image = whiteKing;
                            pieceImage.Location = new Point(xPiecePicturePositionWhite, yPiecePicturePositionWhite);
                            plr2CapturedPiecesBox.Controls.Add(pieceImage);
                        }
                    }


                    isFirstIterationForWhite = false;

                }

            }

            plr2time.Text = game.player2.timeRemaining.ToString();
            plr1time.Text = game.player1.timeRemaining.ToString();


            if (game.player1.Checked) //check if white or black has been checked - if they are checked their checked field would be true - if so change the label to show their in check - if not just leave the label empty
            {

                lblGameInfo.Text = "White is in Check";
                // game.isPlayerinCheck = false;

            }
            else if (game.player2.Checked)
            {

                lblGameInfo.Text = "Black is in Check";
                //game.isPlayerinCheck = false;

            }
            else
            {
                lblGameInfo.Text = "";
            }

            if (game.player1.CheckMate)
            {
                lblGameInfo.Text = "White is in Checkmate";
            }
            else if (game.player2.CheckMate)
            {
                lblGameInfo.Text = "Black is in Checkmate";
            }
            


            Refresh();
        }

        private void lightUpTileDebounce_Tick(object? sender, EventArgs e)//runs every time the debounce timers interval ends
        {
            for (int row = 0; row < game.gameBoard.GetLength(0); row++)
            {
                for (int column = 0; column < game.gameBoard.GetLength(1); column++)
                {
                    game.gameBoard[row, column].isLightUp = false; //set every tile to not light up
                }
            }
        }



        static TimeSpan t = new TimeSpan(0, gameTime, 0); //pass the given game time into a time span objet so we can have it in the timer format
        GameState game = new GameState(t, plr1name, plr2name); //create a new gamestate object
        Matrix gameCoordinates = new Matrix(); //create a new alternative coordinate space for our chessboard so we can have our own custom x and y units and our own custom origin which is not the ame as the defualt origin


        (int row, int column) selectedPos; //the position the player selects

        bool click = false; //flag to see if a player has clicked on the board
        IPiece selectedPiece; //holds the piece the player has selected


        static float mouseX; //variable used for checking the X location of the mouse, changes everytime the mouse moves
        static float mouseY; //variable used for chacking the Y location of the mouse, changes everytime the mouse moves

        Rectangle tileSizeRect = new Rectangle(new Point(0, 0), new Size(1, 1)); //the rectangle used for defining the size and position of each tile - allows for consistent sizing and positions
        Rectangle pieceSizeRect = new Rectangle(new Point(0, 0), new Size(1, 1)); //the rectangle used for defining the size adn position of each piece - allows for consistent sizing and positions
        Rectangle completeBoard = new Rectangle(new Point(0, 0), new Size(8, 8)); //the rectangle used for referencing the size and position of the entire board

        Bitmap darkTile = Properties.Resources.DarkTile; //all image resources ...
        Bitmap lightTile = Properties.Resources.LightTile;
        Bitmap blackPawn = Properties.Resources.BlackPawn;
        Bitmap blackKing = Properties.Resources.BlackKing;
        Bitmap blackQueen = Properties.Resources.BlackQueen;
        Bitmap blackKnight = Properties.Resources.BlackKnight;
        Bitmap blackBishop = Properties.Resources.BlackBishop;
        Bitmap blackRook = Properties.Resources.BlackRook;
        Bitmap whitePawn = Properties.Resources.WhitePawn;
        Bitmap whiteKing = Properties.Resources.WhiteKing;
        Bitmap whiteQueen = Properties.Resources.WhiteQueen;
        Bitmap whiteKnight = Properties.Resources.WhiteKnight;
        Bitmap whiteBishop = Properties.Resources.WhiteBishop;
        Bitmap whiteRook = Properties.Resources.WhiteRook;
        Bitmap LightTileGreenDot = Properties.Resources.LightTileGreenDot;
        Bitmap DarkTileGreenDot = Properties.Resources.DarkTileGreenDot;




        private void btnquit_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void GameWindow_Load(object sender, EventArgs e)
        {
            game.createBoard(); //create the board
            game.addPieces(); //add the pieces
            gameCoordinates.Translate(100, 75); //move our matrix 100 x and 75 y away from the origin
            gameCoordinates.Scale(70, 70); //turn one unit in our matrix equal to 70 native units (1 unit = 70 pixels) this is done so one unit of measurement equals one tile
            this.DoubleBuffered = true;

            this.MouseDown += GameWindow_MouseDown;
            this.MouseMove += GameWindow_MouseMove;
            this.MouseUp += GameWindow_MouseUp;

            // plr1time.Text = 0.17826.ToString();
            //plr2time.Text = 0.17826.ToString();

            refreshScreen.Start(); //start the timer which refreshes the screen
            lightUpTileDebounce.Start(); //start the timer which removes the green dots when needed



        }


        protected override void OnPaint(PaintEventArgs e)//this event is used to repaint the form everytime a repaint is needed all drawing should be put in here
        {

            Graphics g = e.Graphics; //Graphics object
            g.Transform = gameCoordinates; //transform our graphics object to use our defined coordinate space


            for (int row = 0; row < game.gameBoard.GetLength(0); row++) //loop through the rows of gameBoard array
            {
                for (int column = 0; column < game.gameBoard.GetLength(1); column++) //loop through the columns of gameboard array
                {



                    if (game.gameBoard[row, column].tileColor == itemColor.black) //if the tile color at this index is black
                    {

                        if (game.gameBoard[row, column].isLightUp)
                        {
                            tileSizeRect.X = column;
                            tileSizeRect.Y = row;
                            g.DrawImage(DarkTileGreenDot, tileSizeRect);
                        }
                        else
                        {
                            tileSizeRect.X = column; //set the x position of the tile size rectangle to this current column
                            tileSizeRect.Y = row; //set the y position of the tile size rectangle to this current row
                            g.DrawImage(darkTile, tileSizeRect); //draw the dark tile image using the defined rectangle - in the rectangle the size is 70 as defined above and remains constant as all tiles have the same size. The position changes to the current row and column - we have definied our own coordinate space so the x (column) and y (row) positions needed by the tiles perfectly match 1 to 1 with our coordinate space
                        }
                    }
                    else//if the tile color at this index is white
                    {

                        if (game.gameBoard[row, column].isLightUp)
                        {
                            tileSizeRect.X = column; //set the x position of the tile size rectangle to this current column
                            tileSizeRect.Y = row; //set the y position of the tile size rectangle to this current row 
                            g.DrawImage(LightTileGreenDot, tileSizeRect);
                        }
                        else
                        {
                            tileSizeRect.X = column; //set the x position of the tile size rectangle to this current column
                            tileSizeRect.Y = row; //set the y position of the tile size rectangle to this current row
                            g.DrawImage(lightTile, tileSizeRect);  //draw the light tile image using the defined rectangle - in the rectangle the size is 70 as defined above and remains constant as all tiles have the same size. The position changes to the current row and column - we have definied our own coordinate space so the x (column) and y (row) positions needed by the tiles perfectly match 1 to 1 with our coordinate space
                        }
                    }
                }
            }

            for (int row = 0; row < game.Pieces.Count; row++) //row loop to loop through the rows in the 2d pieces list
            {
                for (int column = 0; column < game.Pieces.Count; column++) //column loop to loop through the columns in the 2d pieces list
                {



                    if (game.Pieces[row][column] != null) //first check that the current index dosnt hold a null value because all spaces in the list which dont hold a piece are null and trying to check the properties of those locations like how is done before would lead to an unhandled exception
                    {

                        if (game.Pieces[row][column].PieceType == PieceTypes.pawn && game.Pieces[row][column].Color == itemColor.black) //drawing black pawn
                        {

                            pieceSizeRect.X = column;
                            pieceSizeRect.Y = row;

                            g.DrawImage(blackPawn, pieceSizeRect); //draw the piece image using the defined rectangle - in the rectangle the size is 70 as defined above and remains constant as all pieces have the same size. The position changes to the current row and column - we have definied our own coordinate space so the x (column) and y (row) positions needed by the piece perfectly match 1 to 1 with our coordinate space so we can use the index of our for loop and set positions like that
                        }

                        if (game.Pieces[row][column].PieceType == PieceTypes.pawn && game.Pieces[row][column].Color == itemColor.white) //drawing white pawn
                        {

                            pieceSizeRect.X = column;
                            pieceSizeRect.Y = row;

                            g.DrawImage(whitePawn, pieceSizeRect); //draw the piece image using the defined rectangle - in the rectangle the size is 70 as defined above and remains constant as all pieces have the same size. The position changes to the current row and column - we have definied our own coordinate space so the x (column) and y (row) positions needed by the piece perfectly match 1 to 1 with our coordinate space so we can use the index of our for loop and set positions like that
                        }

                        if (game.Pieces[row][column].PieceType == PieceTypes.king && game.Pieces[row][column].Color == itemColor.black) //drawing black king
                        {

                            pieceSizeRect.X = column;
                            pieceSizeRect.Y = row;

                            g.DrawImage(blackKing, pieceSizeRect); //draw the piece image using the defined rectangle - in the rectangle the size is 70 as defined above and remains constant as all pieces have the same size. The position changes to the current row and column - we have definied our own coordinate space so the x (column) and y (row) positions needed by the piece perfectly match 1 to 1 with our coordinate space so we can use the index of our for loop and set positions like that
                        }

                        if (game.Pieces[row][column].PieceType == PieceTypes.queen && game.Pieces[row][column].Color == itemColor.black) //drawing black queen
                        {

                            pieceSizeRect.X = column;
                            pieceSizeRect.Y = row;

                            g.DrawImage(blackQueen, pieceSizeRect); //draw the piece image using the defined rectangle - in the rectangle the size is 70 as defined above and remains constant as all pieces have the same size. The position changes to the current row and column - we have definied our own coordinate space so the x (column) and y (row) positions needed by the piece perfectly match 1 to 1 with our coordinate space so we can use the index of our for loop and set positions like that
                        }

                        if (game.Pieces[row][column].PieceType == PieceTypes.bishop && game.Pieces[row][column].Color == itemColor.black) //drawing black bishop
                        {

                            pieceSizeRect.X = column;
                            pieceSizeRect.Y = row;

                            g.DrawImage(blackBishop, pieceSizeRect); //draw the piece image using the defined rectangle - in the rectangle the size is 70 as defined above and remains constant as all pieces have the same size. The position changes to the current row and column - we have definied our own coordinate space so the x (column) and y (row) positions needed by the piece perfectly match 1 to 1 with our coordinate space so we can use the index of our for loop and set positions like that
                        }

                        if (game.Pieces[row][column].PieceType == PieceTypes.knight && game.Pieces[row][column].Color == itemColor.black) //drawing black knight
                        {

                            pieceSizeRect.X = column;
                            pieceSizeRect.Y = row;

                            g.DrawImage(blackKnight, pieceSizeRect); //draw the piece image using the defined rectangle - in the rectangle the size is 70 as defined above and remains constant as all pieces have the same size. The position changes to the current row and column - we have definied our own coordinate space so the x (column) and y (row) positions needed by the piece perfectly match 1 to 1 with our coordinate space so we can use the index of our for loop and set positions like that
                        }

                        if (game.Pieces[row][column].PieceType == PieceTypes.rook && game.Pieces[row][column].Color == itemColor.white)//white rook
                        {
                            pieceSizeRect.X = column;
                            pieceSizeRect.Y = row;

                            g.DrawImage(whiteRook, pieceSizeRect); //draw the piece image using the defined rectangle - in the rectangle the size is 70 as defined above and remains constant as all pieces have the same size. The position changes to the current row and column - we have definied our own coordinate space so the x (column) and y (row) positions needed by the piece perfectly match 1 to 1 with our coordinate space so we can use the index of our for loop and set positions like that
                        }


                        if (game.Pieces[row][column].PieceType == PieceTypes.rook && game.Pieces[row][column].Color == itemColor.black) // black rook
                        {
                            pieceSizeRect.X = column;
                            pieceSizeRect.Y = row;

                            g.DrawImage(blackRook, pieceSizeRect); //draw the piece image using the defined rectangle - in the rectangle the size is 70 as defined above and remains constant as all pieces have the same size. The position changes to the current row and column - we have definied our own coordinate space so the x (column) and y (row) positions needed by the piece perfectly match 1 to 1 with our coordinate space so we can use the index of our for loop and set positions like that
                        }

                        if (game.Pieces[row][column].PieceType == PieceTypes.bishop && game.Pieces[row][column].Color == itemColor.white) //drawing white bishop
                        {
                            pieceSizeRect.X = column;
                            pieceSizeRect.Y = row;//set the y position of the piece size rectangle to this current row



                            g.DrawImage(whiteBishop, pieceSizeRect); //draw the piece image using the defined rectangle - in the rectangle the size is 70 as defined above and remains constant as all pieces have the same size. The position changes to the current row and column - we have definied our own coordinate space so the x (column) and y (row) positions needed by the piece perfectly match 1 to 1 with our coordinate space so we can use the index of our for loop and set positions like that
                        }

                        if (game.Pieces[row][column].PieceType == PieceTypes.knight && game.Pieces[row][column].Color == itemColor.white) //drawing white knight
                        {
                            pieceSizeRect.X = column;
                            pieceSizeRect.Y = row;//set the y position of the piece size rectangle to this current row  


                            g.DrawImage(whiteKnight, pieceSizeRect); //draw the piece image using the defined rectangle - in the rectangle the size is 70 as defined above and remains constant as all pieces have the same size. The position changes to the current row and column - we have definied our own coordinate space so the x (column) and y (row) positions needed by the piece perfectly match 1 to 1 with our coordinate space so we can use the index of our for loop and set positions like that
                        }

                        if (game.Pieces[row][column].PieceType == PieceTypes.queen && game.Pieces[row][column].Color == itemColor.white) //drawing white queen
                        {
                            pieceSizeRect.X = column;
                            pieceSizeRect.Y = row;//set the y position of the piece size rectangle to this current row 


                            g.DrawImage(whiteQueen, pieceSizeRect); //draw the piece image using the defined rectangle - in the rectangle the size is 70 as defined above and remains constant as all pieces have the same size. The position changes to the current row and column - we have definied our own coordinate space so the x (column) and y (row) positions needed by the piece perfectly match 1 to 1 with our coordinate space so we can use the index of our for loop and set positions like that
                        }

                        if (game.Pieces[row][column].PieceType == PieceTypes.king && game.Pieces[row][column].Color == itemColor.white) //white king
                        {
                            pieceSizeRect.X = column;
                            pieceSizeRect.Y = row;//set the y position of the piece size rectangle to this current row


                            g.DrawImage(whiteKing, pieceSizeRect); //draw the piece image using the defined rectangle - in the rectangle the size is 70 as defined above and remains constant as all pieces have the same size. The position changes to the current row and column - we have definied our own coordinate space so the x (column) and y (row) positions needed by the piece perfectly match 1 to 1 with our coordinate space so we can use the index of our for loop and set positions like that
                        }


                        if (game.Pieces[row][column].PieceType == PieceTypes.king && game.Pieces[row][column].Color == itemColor.white) //white king
                        {
                            pieceSizeRect.X = column;
                            pieceSizeRect.Y = row;//set the y position of the piece size rectangle to this current row


                            g.DrawImage(whiteKing, pieceSizeRect); //draw the piece image using the defined rectangle - in the rectangle the size is 70 as defined above and remains constant as all pieces have the same size. The position changes to the current row and column - we have definied our own coordinate space so the x (column) and y (row) positions needed by the piece perfectly match 1 to 1 with our coordinate space so we can use the index of our for loop and set positions like that
                        }

                    }
                }
            }




            base.OnPaint(e);
        }

        private void GameWindow_MouseDown(object sender, MouseEventArgs e)
        {
            Matrix inverse = gameCoordinates.Clone(); //create an copy of our coordinate space matrix
            inverse.Invert(); //invert this copy

            PointF[] pts = { new PointF(e.X, e.Y) };
            inverse.TransformPoints(pts); //transform our mouse position at click time to be in terms of our chessboard coordinates




            if (completeBoard.Contains((int)Math.Floor(pts[0].X), (int)Math.Floor(pts[0].Y))) //check if the user clicked the chessboard
            {
                for (int row = 0; row < game.gameBoard.GetLength(0); row++)
                {
                    for (int column = 0; column < game.gameBoard.GetLength(1); column++)
                    {
                        game.gameBoard[row, column].isLightUp = false;
                    }
                }

                mouseX = (int)Math.Floor(pts[0].X); //set the mouseX variable to hold the position of the mouse rounded down
                mouseY = (int)Math.Floor(pts[0].Y); ///set the mouseY variable to hold the position of the mouse rounded down

                selectedPos.row = (int)Math.Floor(mouseY); //copy this rounded down value of the mouses y to another vairable to represent the position of the selected piece - we dont use the mouseY because that changes as the mouse moves
                selectedPos.column = (int)Math.Floor(mouseX); //copy this rounded down value of the mouses x to another vairable to represent the position of the selected piece - we dont use the mouseX because that changes as the mouse moves

                if (game.Pieces[selectedPos.row][selectedPos.column] != null) //make sure the selected position in the 2d list reflecting where the user clicked actually holds a piece
                {
                    click = true; //if so set click to true
                    selectedPiece = game.Pieces[selectedPos.row][selectedPos.column];
                    game.lightUpTiles(selectedPiece); //show the green indicators for the piece which was clicked
                    lightUpTileDebounce.Interval = 500; //set the time before the green indicators are removed to be half a second

                }


            }






        }


        private void GameWindow_MouseMove(object sender, MouseEventArgs e)
        {
            Matrix inverse = gameCoordinates.Clone(); //create a copy of our chessboard coordinate space matrix
            inverse.Invert(); //invert this copy

            PointF[] pts = { new PointF(e.X, e.Y) };
            inverse.TransformPoints(pts);  //transform our mouse position at move time to be in terms of our chessboard coordinates


            if (click) //if the user previously clicked
            {
                mouseX = (int)Math.Floor(pts[0].X); //set the mouseX and mouseY to be the position of the mouse rounded down everytime the user moves the mouse
                mouseY = (int)Math.Floor(pts[0].Y);


            }




        }

        private void GameWindow_MouseUp(object sender, MouseEventArgs e)
        {
            Matrix inverse = gameCoordinates.Clone(); //create a copy of our chessboard coordinate space matrix
            inverse.Invert(); //invert this copy

            PointF[] pts = { new PointF(e.X, e.Y) };
            inverse.TransformPoints(pts); //transform our mouse position at move time to be in terms of our chessboard coordinates

            mouseX = (int)Math.Floor(pts[0].X); //set the mouseX and mouseY to hold the position of the mouse when the user lets go of the mouse
            mouseY = (int)Math.Floor(pts[0].Y);

            if (click) //if the user clicked initially
            {
                if (selectedPiece.Position.row != mouseY || selectedPiece.Position.column != mouseX)
                {
                    game.MakeMove(game.Pieces[selectedPos.row][selectedPos.column], ((int)mouseY, (int)mouseX)); //move the piece using the make move method - we dont have to worry about rectangles or drawing anything because make move moves the piece form its current index to its destination index
                }


                lightUpTileDebounce.Interval = 10; //set the time before the green indicators are removed to something really small so if the player lifts there mouse the green indicators go almost instantly
                for (int row = 0; row < game.gameBoard.GetLength(0); row++) //loop through the entire board and remove any green indicators
                {
                    for (int column = 0; column < game.gameBoard.GetLength(1); column++)
                    {
                        game.gameBoard[row, column].isLightUp = false;
                    }
                }


            }
            click = false; //set click to false as the user is no longer holding down there left mouse button and we can restart the cycle




        }

       
    }
}
            

         
          
        
