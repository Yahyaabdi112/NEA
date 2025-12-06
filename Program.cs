using System.Collections.Generic;
using System.Drawing;
using System.Reflection.Metadata;

GameState game = new GameState();
game.addPieces();
game.createBoard();
Console.WriteLine("The game board and pieces are loaded into memory!");
game.MakeMove(game.Pieces[7, 2], (4, 4));
public enum PieceTypes //The different possible types of pieces. With this we can set the different piece types later on and determine what type a piece is.
{
    pawn,
    knight,
    bishop,
    rook,
    queen,
    king
}

public enum Color //The different possible piece colours. With this we can set pieces and tiles colours later on and determine what color a piece is.
{
    black, white
}

public interface IPiece //The basis for each piece in the project. Its used as a contract so each direct piece class knows it must require these things. Used so that we dont directly create objects of pieces in classes later on when we want to add functionality.
{

    (int row, int column) Position { get; set; } //The position of each piece on the board. Uses a tuple with row and column.
    Color Color { get; set; } //The Colour of each piece. Uses the Enum Color from earlier as its type
    PieceTypes PieceType { get; } //The type of each piece. Uses the Enum PieceTypes from earlier as its type
    IEnumerable<(int row, int column)> Moves(); //A method with type of an IEnumerable tuple. This is so we can set and determine the possible moves a piece makes. Its IEnumerable so we can iterate through these possible moves meaning they can be passed between different data structures such as arrays and lists. Its a tuple with row and column so that we can get the exact coordinates of each possible move returned in a nice easy to work with format
}





public interface ITile //Used as the basis for all tiles on the gameboard.
{
    bool IsOccupied { get; set; } //A flag to tell us whether a tile is currently occupied by a piece. This can be used in the piece movement system so that no two pieces can occupy the same tile.
    (int row, int column) Position { get; set; } //Used so we can determine where a tile is.
    Color tileColor { get; set; } //Used to determine the colour of a tile, important when creating the board.
}

public class Tile : ITile
{
    public bool IsOccupied { get; set; }
    public (int row, int column) Position { get; set; }
    public Color tileColor { get; set; }

}

public interface IPieceFactory //This is an interface designed to be inherited by direct piece factory classes. It follows the abstract factory design pattern.Its role is to make sure that each piece factory contains all the correct properties, fields and methods.
{
    public IPiece? knight { get; } //makes sure the piece factories contain a knight. It’s a nullable type, important for later when properties in piece factory objects may be null.
    public IPiece? bishop { get; } //makes sure the piece factories contain a bishop. It’s a nullable type, important for later when properties in piece factory objects may be null.
    public IPiece? pawn { get; } //makes sure the piece factories contain a pawn. It’s a nullable type, important for later when properties in piece factory objects may be null.
    public IPiece? rook { get; } //makes sure the piece factories contain a rook. It’s a nullable type, important for later when properties in piece factory objects may be null.
    public IPiece? queen { get; } //makes sure the piece factories contain a queen. It’s a nullable type, important for later when properties in piece factory objects may be null.
    public IPiece? king { get; } //makes sure the piece factories contain a king. It’s a nullable type, important for later when properties in piece factory objects may be null.
    IPiece CreatePawn((int row, int column) Position); //method which each piece factory should have to create pawns, takes in a position parameter.
    IPiece CreateBishop((int row, int column) Position);
    IPiece CreateRook((int row, int column) Position);
    IPiece CreateKnight((int row, int column) Position);
    IPiece CreateQueen((int row, int column) Position);
    IPiece CreateKing((int row, int column) Position);
}
public class BlackPieceFactory : IPieceFactory //This class is a concrete piece factory class which handles creating all black game pieces and storing them in objects. 
{
    public IPiece? knight { get; set; } //property for knight
    public IPiece? bishop { get; set; } //property for bishop
    public IPiece? pawn { get; set; } //property for pawn
    public IPiece? rook { get; set; } //property for rook
    public IPiece? queen { get; set; } //property for queen
    public IPiece? king { get; set; } //property for king




    public IPiece CreateKnight((int row, int column) Position) //used to create a black knight
    {
        knight = new Knight(Color.black, Position); //create a knight set its colour to black, set its position to the given position and store this knight in the object knight property
        return knight; //return the knight into a variable where the knight was called
    }

    public IPiece CreateBishop((int row, int column) Position) //used to create a black bishop 
    {
        bishop = new Bishop(Color.black, Position); //create a bishop set its colour to black, set its position to the given position and store this bishop in the object bishop property
        return bishop; //return the bishop into a variable where the bishop was called
    }

    public IPiece CreatePawn((int row, int column) Position) //used to create a black pawn 
    {
        pawn = new Pawn(Color.black, Position); //create a pawn set its colour to black, set its position to the given position and store this pawn in the object pawn property
        return pawn; //return the pawn into a variable where the pawn was called
    }

    public IPiece CreateRook((int row, int column) Position) //used to create a black rook
    {
        rook = new Rook(Color.black, Position); //create a rook set its colour to black, set its position to the given position and store this rook in the object rook property
        return rook; //return the rook into a variable where the rook was called
    }

    public IPiece CreateQueen((int row, int column) Position) //used to create a black queen
    {
        queen = new Queen(Color.black, Position); //create a queen set its colour to black, set its position to the given position and store this queen in the object queen property
        return queen; //return the queen into a variable where the queen was called
    }

    public IPiece CreateKing((int row, int column) Position) //used to create a black king
    {
        king = new King(Color.black, Position); //create a king set its colour to black, set its position to the given position and store this king in the object king property
        return king; //return the king into a variable where the king was called
    }
}
public class WhitePieceFactory : IPieceFactory //This class is a concrete piece factory class which handles creating all white game pieces and storing them in objects.
{
    public IPiece? knight { get; set; } //property for knight
    public IPiece? bishop { get; set; } //property for bishop
    public IPiece? pawn { get; set; } //property for pawn
    public IPiece? rook { get; set; } //property for rook
    public IPiece? queen { get; set; } //property for queen
    public IPiece? king { get; set; } //property for king



    public IPiece CreateKnight((int row, int column) Position) //used to create a white knight
    {
        knight = new Knight(Color.white, Position);//create a knight set its colour to white, set its position to the given position and store this knight in the object knight property
        return knight; //return the knight into a variable where the knight was called
    }

    public IPiece CreateBishop((int row, int column) Position) //used to create a white bishop
    {
        bishop = new Bishop(Color.white, Position); //create a bishop set its colour to white, set its position to the given position and store this bishop in the object bishop property
        return bishop; //return the bishop into a variable where the bishop was called
    }

    public IPiece CreatePawn((int row, int column) Position) //used to create a white pawn
    {
        pawn = new Pawn(Color.white, Position); //create a pawn set its colour to white, set its position to the given position and store this pawn in the object pawn property
        return pawn; //return the pawn into a variable where the pawn was called
    }

    public IPiece CreateRook((int row, int column) Position) //used to create a white rook
    {
        rook = new Rook(Color.white, Position); //create a rook set its colour to white, set its position to the given position and store this rook in the object rook property
        return rook; //return the rook into a variable where the rook was called
    }

    public IPiece CreateQueen((int row, int column) Position) //used to create a white queen
    {
        queen = new Queen(Color.white, Position); //create a queen set its colour to white, set its position to the given position and store this queen in the object queen property
        return queen; //return the queen into a variable where the queen was called
    }

    public IPiece CreateKing((int row, int column) Position) //used to create a white king
    {
        king = new King(Color.white, Position); //create a king set its colour to white, set its position to the given position and store this king in the object king property
        return king; //return the king into a variable where the king was called
    }


}



public class Knight : IPiece //Concrete Knight class which defines everything about a Knight
{
    public Color Color { get; set; } //The colour of the knight
    public PieceTypes PieceType { get; set; } //The Piecetype of the knight (set to knight later in the constructor)
    public (int row, int column) Position { get; set; } //The position of the knight in tuple format


    public Knight(Color _Color, (int x, int y) _Position) // Constructor - takes in a color and position. It then assigns the given color and position to the instantiated object whilst also making the piecetype knight
    {
        PieceType = PieceTypes.knight; //set the piecetype to knight
        Color = _Color; //set the colour to the given colour
        Position = _Position; // set position to given position
    }

    public IEnumerable<(int row, int column)> Moves() //Defines the possible moves the knight can make
    {
        var possiblemoves = new (int row, int column)[] {  //Creates an array of tuple type which contains coordinates for move offsets assuming the knight is at an origin 0,0
            (1, -2), (-1, -2),(2, -1),
            (2, 1), (1, 2), (-1, 2),
            (-2, 1), (-2, -1)
            
        };

        foreach (var move in possiblemoves) //loop through the array and return each item
        { 
            yield return move;
        }
    }
}

public class Bishop : IPiece //Concrete Bishop class which defines everything about a Bishop
{
    public (int row, int column) Position { get; set; } //The position of the knight in tuple format
    public Color Color { get; set; } //The colour of the Bishop
    public PieceTypes PieceType { get; set; } //piecetype

    public Bishop(Color _Color, (int row, int column) _Position) //constructor to set the properties to the given and required values
    {
        PieceType = PieceTypes.bishop;
        Position = _Position;
        Color = _Color;
    }

    public IEnumerable<(int row, int column)> Moves() //Defines the possible moves the Bishop can make
    {
        var possibleMoves = new (int row, int column)[] //Stores the unit vector of the offsets of each possible move the bishop and stores them in a coordinate tuple array (assuming the Bishop is at the origin 0,0)
        {
            (-1, -1), (1, -1),
            (1, 1), (-1, 1)
        };

        foreach (var move in possibleMoves) //Loop through the array and return each coordinate
        {
            for (int i = 1; i < 8; i++) //For each of the unit vectors multiply them by 7 as the bishop can take any position on the board at these unit vectors
            {
                (int row, int column) possiblePositionsAlongDirection; //create a temp varaible to represent every move in the given direction
                possiblePositionsAlongDirection = ((move.row * i), (move.column * i)); //multiply the unit vector by i to give each position on the board along the unit vector
                yield return possiblePositionsAlongDirection; //return this temp variable
            }
        }
    }
}

public class Rook : IPiece  //Concrete Rook class which defines everything about a Rook
{
    public Color Color { get; set; }  //The colour of the Rook
    public PieceTypes PieceType { get; set; } //The PieceType of the Rook
    public (int row, int column) Position { get; set; }  //The position of the Rook in tuple format

    public Rook(Color _Color, (int row, int column) _Position) //constructor to set the properties to the given and required values
    {
        PieceType = PieceTypes.rook;
        Position = _Position;
        Color = _Color;
    }

    public IEnumerable<(int row, int column)> Moves() //Defines the offsets of the particular moves the Rook can make
    {
        var possibleMoves = new (int row, int column)[]{ //The possible moves in row column tuple form stored in an ienumerable
            (0, -1), (1, 0),
            (0, 1), (-1, 0)
        };

        foreach (var move in possibleMoves) //foreach of these offsets multiply them by 7 and return each result to represent all the possible offsets
        {
            for (int i = 1; i < 8; i++)
            {
                var temp = (move.row * i, move.column * i);
                yield return temp;
            }
        }
    }
}

public class King : IPiece  //Concrete King class which defines everything about a king
{
    public (int row, int column) Position { get; set; } //The position of the King in tuple format
    public Color Color { get; set; } //The colour of the King
    public PieceTypes PieceType { get; set; } //PieceType, self explanatory used for checks later on

    public King(Color _Color, (int row, int column) _Position) //constructor to set the properties to the given and required values
    {
        PieceType = PieceTypes.king;
        Position = _Position;
        Color = _Color;
    }

    public IEnumerable<(int row, int column)> Moves() //Defines the unit vectors of the possible directions the king can move in
    {
        var possibleMoves = new (int row, int column)[]{ //The possible moves in row column tuple form stored in an ienumerable
            (0, -1), (1, 0),
            (0, 1), (-1, 0),
            (-1, -1), (1, -1),
            (1, 1), (-1, 1)

        };

        foreach (var move in possibleMoves) //foreach possible move return them
        {
            
                yield return move;
            
        }
    }
}

public class Pawn : IPiece //Concrete Pawn class which defines everything about a Pawn
{
    public (int row, int column) Position { get; set; } //The position of the Pawn in tuple format
    public Color Color { get; set; } //The colour of the Pawn

    public PieceTypes PieceType { get; set; } //PieceType, self explanatory used for checks later on
    public bool hasMoved = false; //Here because the pawn can move two spaces on its first move



    public Pawn(Color _Color, (int row, int column) _Position) //constructor to set the properties to the given and required values
    {
        PieceType = PieceTypes.pawn;
        Position = _Position;
        Color = _Color;
    }

    public IEnumerable<(int row, int column)> Moves() //Defines the offsets of the possible moves the pawn can make
    {
        var possibleMoves = new (int row, int column)[]{ //stroe each of these offsets in tuple form in an ienumerable
            (0, -2), (0, -1)

        };

        foreach (var move in possibleMoves) //foreach of these return
        {

            yield return move;

        }
    }
}

public class Queen : IPiece //Concrete Queen class which defines everything about a Queen
{
    public (int row, int column) Position { get; set; } //The position of the Queen in tuple format
    public Color Color { get; set; }//The colour of the Queen

    public PieceTypes PieceType { get; set; }//PieceType, self explanatory used for checks later on




    public Queen(Color color, (int row, int column) position) //constructor to set the properties to the given and required values
    {
        Position = position;
        Color = color;
        PieceType = PieceTypes.queen;
    }

    public IEnumerable<(int row, int column)> Moves() //defines the unit vectors of the posssible directions the queen can move in
    {
        var possibleMoves = new (int row, int column)[]{ //store each of these offsets in tuple form in an ienumerable
            (-1, 1), (-1, 0), (-1, -1),
            (0 ,-1), (1, -1), (1 ,0),
            (1 ,1), (0 ,1)

        };

        foreach (var move in possibleMoves) //foe each of these muliply them by 1 through 8 and return each of these values
        {
            for (int i = 1; i < 8; i++)
            {
                var temp = (move.row * i, move.column * i);
                yield return temp; //return
            }
            

        }
    }
}


public class GameState
{
    public ITile[,] gameBoard = new ITile[8, 8]; //Used to create the actual game board. Is Given Tile objects in createboard method
    public IPiece[,] Pieces = new IPiece[8, 8]; //Used to store the pieces, unique pieces handle specifics like location and type. Is given piece objects in addpieces class
    public string? currentPlayer; //Stores the current player


    public GameState() //Constructor
    {

    }

    public void MakeMove(IPiece piece, (int row, int column) position) //Move making class
    {
        bool moveSuccess = false;
        //this class needs to use the piece
        var possibleMoves = piece.Moves();
        for (int i = 1; i < 8; i++)
        {
            if (possibleMoves.Contains((position.row, position.column)))
            {
                if (gameBoard[position.row, position.column].IsOccupied == false)
                {
                    piece.Position = position;
                    moveSuccess = true;
                }
            }
            else {
                moveSuccess = false;
                }
        }
        if (moveSuccess == false)
        {
            Console.WriteLine("The move has failed");
        }
        else
        {
            Console.WriteLine("The move has succeded");
        }


    }

    public void addPieces()
    {
        IPieceFactory blackPieceFactory = new BlackPieceFactory();
        IPieceFactory whitePieceFactory = new WhitePieceFactory();
        for (int row = 0; row < 8; row++) //outer loop for rows
        {
            for (int column = 0; column < 8; column++) //inner loop for columns
            {

                if (row == 1) //all of row 1 holds a pawn at the start of the game
                {
                    Pieces[row, column] = blackPieceFactory.CreatePawn((row, column)); //black pawn
                }
                if (row == 6) //all of row 6 holds a pawn at the start of the game
                {
                    Pieces[row, column] = whitePieceFactory.CreatePawn((row, column)); //white pawn
                }
                if ((row == 0 && column == 0) || (row == 0 && column == 7)) 
                {
                    Pieces[row, column] = blackPieceFactory.CreateRook((row, column));//black rook
                }
                if ((row == 7 && column == 0) || (row == 7 && column == 7)) 
                {
                    Pieces[row, column] = whitePieceFactory.CreateRook((row, column));// white rook
                }
                if ((row == 0 && column == 1) || (row == 0 && column == 6))
                {
                    Pieces[row, column] = whitePieceFactory.CreateKnight((row, column));// white knight
                }
                if ((row == 7 && column == 1) || (row == 7 && column == 6))
                {
                    Pieces[row, column] = whitePieceFactory.CreateKnight((row, column));// black knight
                }
                if ((row == 0 && column == 2) || (row == 0 && column == 5))
                {
                    Pieces[row, column] = blackPieceFactory.CreateBishop((row, column)); // balck bishop
                }
                if ((row == 7 && column == 2) || (row == 7 && column == 5))
                {
                    Pieces[row, column] = whitePieceFactory.CreateBishop((row, column)); // white bishop
                }
                if (row == 0 && column == 3)
                {
                    Pieces[row, column] = blackPieceFactory.CreateQueen((row, column)); // black queen
                }
                if (row == 7 && column == 3)
                {
                    Pieces[row, column] = whitePieceFactory.CreateQueen((row, column)); // white queen
                }
                if (row == 0 && column == 4)
                {
                    Pieces[row, column] = blackPieceFactory.CreateKing((row, column)); // Black King
                }
                if (row == 7 && column == 4)
                {
                    Pieces[row, column] = whitePieceFactory.CreateKing((row, column)); // White King
                }
            }
        }
    }

    public void createBoard()
    //creating the 8x8 board with alternating tiles in the pattern of a chessboard
    {
        for (int row = 0; row < 8; row++) //initial loop for the columns
        {
            if (row % 2 == 0) // if the column number is even
            {
                for (int column = 0; column < 8; column++) // The loop for the rows if the column number is even
                {
                    gameBoard[row, column] = new Tile();
                    if (column % 2 == 0) //if the row number is even then a dark square
                    {
                        gameBoard[row, column].tileColor = Color.black;
                        gameBoard[row, column].IsOccupied = false;
                        gameBoard[row, column].Position = (row, column);
                    }
                    else // if the row number is odd then a light square
                    {
                        gameBoard[row, column].tileColor = Color.white;
                        gameBoard[row, column].IsOccupied = false;
                        gameBoard[row, column].Position = (row, column);
                    }
                }
            }
            else // if the column number is odd
            {
                for (int column = 0; column < 8; column++) //the loop for the rows if the column number is odd
                {
                    gameBoard[row, column] = new Tile();
                    if (column % 2 == 0) // if the row number is even then a light square
                    {
                        gameBoard[row, column].tileColor = Color.white;
                        gameBoard[row, column].IsOccupied = false;
                        gameBoard[row, column].Position = (row, column);
                    }
                    else // if the row number is odd then a dark square
                    {
                        gameBoard[row, column].tileColor = Color.black;
                        gameBoard[row, column].IsOccupied = false;
                        gameBoard[row, column].Position = (row, column);
                    }
                }
            }
        }





    }
}
