
//This is for loading the chess pieces into a dictionary to be accessed later. I had a few issues with the file path(for the dictionary to acctually load on other computers i would need to shorten the file path)I did some troubleshooting and looking online at file path syntax so i could get it to work.

    Dictionary<string, Image> ChessPieces = new Dictionary<string, Image>(); //creating the dictionary which holds all the chess pieces
                                                                             // Pieces(ChessPieces); //adding all the chess pieces to the dictionary
Tiles[,] tiles = new Tiles[8, 8];
CreateBoard<Tiles> board = new CreateBoard<Tiles>(tiles);

board.create();


for (int i = 0; i < 8; i++)
{
    for (int j = 0; j < 7; j++)
    {
        // PointF point = new PointF(Convert.ToInt16(tiles[i, j].column), Convert.ToInt16(tiles[i, j].row));


        //PictureBox picture = new PictureBox();
        string Name = "Tile: " + Convert.ToString(tiles[i, j].column) + ", " + Convert.ToString(tiles[i, j].row);
        Console.WriteLine(Name);


        //picture.Size = new Size(16, 16);
        //picture.Location = new Point(tiles[i, j].column + 10, tiles[i, j].row + 10);
        //picture.Image = tiles[i, j].Tileimage;

    }
}



/*static void Pieces(Dictionary<string, Image> LoadPieces)
{
    string filepath = @"..\..\..\..\JohnPablok Cburnett Chess-v2\JohnPablok Cburnett Chess set\SVG with shadow\"; 
    LoadPieces["Black Pawn"] = Image.FromFile(filepath + "b_pawn_svg_withShadow.jpg");
    LoadPieces["White Pawn"] = Image.FromFile(filepath + "w_pawn_svg_withShadow.jpg");
    LoadPieces["Black Rook"] = Image.FromFile(filepath + "b_rook_svg_withShadow.jpg");
    LoadPieces["White Rook"] = Image.FromFile(filepath + "w_rook_svg_withShadow.jpg");
    LoadPieces["White Knight"] = Image.FromFile(filepath + "w_knight_svg_withShadow.jpg");
    LoadPieces["Black Knight"] = Image.FromFile(filepath + "b_knight_svg_withShadow.jpg");
    LoadPieces["White Bishop"] = Image.FromFile(filepath + "w_bishop_svg_withShadow.jpg");
    LoadPieces["Black Bishop"] = Image.FromFile(filepath + "b_bishop_svg_withShadow.jpg");
    LoadPieces["Black Queen"] = Image.FromFile(filepath + "b_queen_svg_withShadow.jpg");
    LoadPieces["White Queen"] = Image.FromFile(filepath + "w_queen_svg_withShadow.jpg");
    LoadPieces["White King"] = Image.FromFile(filepath + "w_king_svg_withShadow.jpg");
    LoadPieces["Black King"] = Image.FromFile(filepath + "b_king_svg_withShadow.jpg");


}*/

public interface ITiles
{
    public  int row { get; set; }
    public  int column { get; set; }
    public  bool IsOccupied { get; set; }
    public  Image Tileimage { get; set; }


}

public class Tiles : ITiles
{
    public int row { get; set; }
    public int column { get; set; }
    public bool IsOccupied { get; set; }
    public  Image Tileimage { get; set; }

    public int getRow()
    {
        return row;
    }
}

public interface ICreateBoard
{
   // void SetTiles(ITiles[,] tiles);
    void create();
}

public class CreateBoard<T> where T : ITiles, new() // The '<T>' means the class will work with a type T wich will be daclared later in the main. The 'where T : ITiles' means This type T will implement ITiles. The 'new()' means T has a parameterless constructor which is required for this to work.
{
    public T[,] _tiles; //2D array of type T
    public CreateBoard(T[,] tiles) // Class constructor which changes the type of the array to the one in main.
    {
        _tiles = tiles;
    }
    public void create( )
     //creating the 8x8 board with alternating tiles in the pattern of a chessboard
    {
        for (int i = 0; i <9; i++) //initial loop for the columns
        {
            if (i % 2 == 0) // if the column number is even
            {
                for (int j = 0; j < 8; j++) // The loop for the rows if the column number is even
                {
                    if (j % 2 == 0) //if the row number is even then a dark square
                    {
                        _tiles[i, j] = new T();
                        _tiles[i, j].IsOccupied = false;
                        _tiles[i, j].row = j;
                        _tiles[i, j].column = i;
                        _tiles[i, j].Tileimage = Image.FromFile(@"..\..\..\..\..\JohnPablok Cburnett Chess-v2\JohnPablok Cburnett Chess set\board squares\square brown dark_svg.jpg");
                    }
                    else // if the row number is odd then a light square
                    {
                        _tiles[i, j] = new T();
                        _tiles[i, j].IsOccupied = false;
                        _tiles[i, j].row = j;
                        _tiles[i, j].column = i;
                        _tiles[i, j].Tileimage = Image.FromFile(@"..\..\..\..\..\JohnPablok Cburnett Chess-v2\JohnPablok Cburnett Chess set\board squares\square brown light_svg.jpg");
                    }
                }
            }
            else // if the column number is odd
            {
                for (int j = 0; j < 8; j++) //the loop for the rows if the column number is odd
                {
                    if (j % 2 == 0) // if the row number is even then a light square
                    {
                        _tiles[i, j] = new T();
                        _tiles[i, j].IsOccupied = false;
                        _tiles[i, j].row = j;
                        _tiles[i, j].column = i;
                        _tiles[i, j].Tileimage = Image.FromFile(@"..\..\..\..\..\JohnPablok Cburnett Chess-v2\JohnPablok Cburnett Chess set\board squares\square brown light_svg.jpg");
                    }
                    else // if the row number is odd then a dark square
                    {
                        _tiles[i, j] = new T();
                        _tiles[i, j].IsOccupied = false;
                        _tiles[i, j].row = j;
                        _tiles[i, j].column = i;
                        _tiles[i, j].Tileimage = Image.FromFile(@"..\..\..\..\..\JohnPablok Cburnett Chess-v2\JohnPablok Cburnett Chess set\board squares\square brown dark_svg.jpg");
                    }
                }
            }
        }
    }

   
}
 public interface IPiece
 { 
    public string type { set; get; }
    public string color { set; get; }
    public bool HasMoved { set; get; }
    public Image PieceImage { set; get; }

 }

public class Piece : IPiece
{
    public string type { get; set; }
    public string color { get; set; }
    public bool HasMoved { get; set; }
    public Image PieceImage { set; get; }

    public void moves()
    {
        
    }


}

public class Pawn : Piece
{ 

}

public interface IAddPieces
{
    
    void SetPieces( Dictionary<(int row, int column), IPiece> pieces);
}

public class AddPieces : IAddPieces
{
    Dictionary<(int row, int column), IPiece> _Pieces; //Its of type IPiece so each piece in the dictionary can use the fields from IPiece


    public void SetPieces(Dictionary<(int row, int column), IPiece> pieces) //Allows the user to change the value of the dictionary from IPiece to Piece in the main
    {
        _Pieces = pieces;
    }

    public void add(ICreateBoard board, IPiece piece)
    {
        board.create();

        switch (piece.type)
        {
            case "pawn":
                for (int i = 0; i < 8; i++)
                {
                    _Pieces.Add((i, 1), piece);
                    piece.PieceImage = Image.FromFile(@"..\..\..\..\..\JohnPablok Cburnett Chess - v2\JohnPablok Cburnett Chess set\PNGs\With Shadow\256px\b_pawn_png_shadow_256px.png");
                }
            break;

        }

    }
}

/*public class UpdateBoard<T> where T : ITiles, new() //this class updates the position of pieces
{
    ICreateBoard createboard;
     int row, row2, column, column2;// the original position of the piece and the new position of the piece
    public T[,] tiles;

    public UpdateBoard(int row, int column, int row2, int column2)
    {
        this.row = row;
        this.column = column;
        this.row2 = row2;
        this.column2 = column2;
    }

    public void update()
    {
        tiles[row, column].IsOccupied = false; //sets the tile of the moved piece to not occupied

    }
}

public class BoardManager
{
    private static bool IsWhiteturn, IsBlackturn;


    public string PlayerTurn() //check which players turn it is
    {
        int I = 0;
        IsWhiteturn = true;
        string Whiteturn =  "Whiteturn";
        string Blackturn =  "Blackturn";

        if (I % 2 == 0)
        {
            IsBlackturn = true;
            IsWhiteturn = false;
        }
        else
        {
            IsBlackturn = false;
            IsWhiteturn = true;
        }

        if (IsWhiteturn)
        {
            return Whiteturn;
        }
        else
        {
            return Blackturn;
        }
    }

    public void Piecemovement(ICreateBoard createboard, IPiece piece)
    { 
       
    }
}*/

