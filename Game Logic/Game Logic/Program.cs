
//This is for loading the chess pieces into a dictionary to be accessed later. I had a few issues with the file path(for the dictionary to acctually load on other computers i would need to shorten the file path)I did some troubleshooting and looking online at file path syntax so i could get it to work.

    Dictionary<string, Image> ChessPieces = new Dictionary<string, Image>(); //creating the dictionary which holds all the chess pieces
    Pieces(ChessPieces); //adding all the chess pieces to the dictionary


    
   

static void Pieces(Dictionary<string, Image> LoadPieces)
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


}

public interface ITiles
{
    public string row { get; set; }
    public string column { get; set; }
    public bool IsOccupied { get; set; }


}

public class Tiles : ITiles
{
    public string row { get; set; }
    public string column { get; set; }
    public bool IsOccupied { get; set; }
}

interface ICreateBoard
{
    void SetTiles(ITiles[,] tiles);
    void create();
}

public class CreateBoard : ICreateBoard
{
    public static ITiles[,] _tiles = new ITiles[,] { }; //creates the board array
    
    public void SetTiles(ITiles[,] tiles) //Allows the array type of _tiles to be changed to Tiles in the main
    {
        _tiles = tiles;
    }
    
    public void create() //creating the 8x8 board with alternating tiles in the pattern of a chessboard
    {
        for (int i = 0; i <= 7; i++) //initial loop for the columns
        {
            if (i % 2 == 0) // if the column number is even
            {
                for (int j = 0; j <= 7; j++) // The loop for the rows if the column number is even
                {
                    if (j % 2 == 0) //if the row number is even then a dark square
                    {
                        _tiles[i, j].IsOccupied = false;
                        _tiles[i, j].row = Convert.ToString(j);
                        _tiles[i, j].column = Convert.ToString(i);
                        _tiles[i, j] = (ITiles)Image.FromFile(@"..\..\..\..\JohnPablok Cburnett Chess-v2\JohnPablok Cburnett Chess set\board squares\square brown dark_svg.jpg");
                    }
                    else // if the row number is odd then a light square
                    {
                        _tiles[i, j].IsOccupied = false;
                        _tiles[i, j].row = Convert.ToString(j);
                        _tiles[i, j].column = Convert.ToString(i);
                        _tiles[i, j] = (ITiles)Image.FromFile(@"..\..\..\..\JohnPablok Cburnett Chess-v2\JohnPablok Cburnett Chess set\board squares\square brown light_svg.jpg");
                    }
                }
            }
            else // if the column number is odd
            {
                for (int j = 0; j <= 7; j++) //the loop for the rows if the column number is odd
                {
                    if (j % 2 == 0) // if the row number is even then a light square
                    {
                        _tiles[i, j].IsOccupied = false;
                        _tiles[i, j].row = Convert.ToString(j);
                        _tiles[i, j].column = Convert.ToString(i);
                        _tiles[i, j] = (ITiles)Image.FromFile(@"..\..\..\..\JohnPablok Cburnett Chess-v2\JohnPablok Cburnett Chess set\board squares\square brown light_svg.jpg");
                    }
                    else // if the row number is odd then a dark square
                    {
                        _tiles[i, j].IsOccupied = false;
                        _tiles[i, j].row = Convert.ToString(j);
                        _tiles[i, j].column = Convert.ToString(i);
                        _tiles[i, j] = (ITiles)Image.FromFile(@"..\..\..\..\JohnPablok Cburnett Chess-v2\JohnPablok Cburnett Chess set\board squares\square brown dark_svg.jpg");
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

interface IAddPieces
{
    
    void SetPieces( Dictionary<(string row, string column), IPiece> pieces);
}

public class AddPieces : IAddPieces
{
    Dictionary<(string row, string column), IPiece> _Pieces; //Its of type IPiece so each piece in the dictionary can use the fields from IPiece


    public void SetPieces(Dictionary<(string row, string column), IPiece> pieces) //Allows the user to change the value of the dictionary from IPiece to Piece in the main
    {
        _Pieces = pieces;
    }
}

