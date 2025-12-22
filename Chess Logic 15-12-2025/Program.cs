using System.Collections.Generic;

using System.Drawing;

using System.Reflection.Metadata;

GameState game = new GameState();

game.createBoard();

game.addPieces();

Console.WriteLine("The game board and pieces are loaded into memory!");

game.MakeMove(game.Pieces[7][1], (5, 0));



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

    bool hasMoved { get; set; }


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

    public bool hasMoved { get; set; }



    public Knight(Color _Color, (int x, int y) _Position) // Constructor - takes in a color and position. It then assigns the given color and position to the instantiated object whilst also making the piecetype knight  

    {

        PieceType = PieceTypes.knight; //set the piecetype to knight  

        Color = _Color; //set the colour to the given colour  

        Position = _Position; // set position to given position  

        hasMoved = false;

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

    public bool hasMoved { get; set; }



    public Bishop(Color _Color, (int row, int column) _Position) //constructor to set the properties to the given and required values  

    {

        PieceType = PieceTypes.bishop;

        Position = _Position;

        Color = _Color;

        hasMoved = false;

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

            /*for (int i = 1; i < 8; i++) //For each of the unit vectors multiply them by 7 as the bishop can take any position on the board at these unit vectors  

            {

                /*(int row, int column) possiblePositionsAlongDirection; //create a temp varaible to represent every move in the given direction  

                possiblePositionsAlongDirection = ((move.row * i), (move.column * i)); //multiply the unit vector by i to give each position on the board along the unit vector  

                yield return possiblePositionsAlongDirection; //return this temp variable  

                

            }*/
            yield return move;
        }

    }


}

public class Rook : IPiece //Concrete Rook class which defines everything about a Rook  

{

    public Color Color { get; set; }  //The colour of the Rook  

    public PieceTypes PieceType { get; set; } //The PieceType of the Rook  

    public (int row, int column) Position { get; set; }  //The position of the Rook in tuple format  

    public bool hasMoved { get; set; }



    public Rook(Color _Color, (int row, int column) _Position) //constructor to set the properties to the given and required values  

    {

        PieceType = PieceTypes.rook;

        Position = _Position;

        Color = _Color;

        hasMoved = false;

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

public class King : IPiece //Concrete King class which defines everything about a king  

{

    public (int row, int column) Position { get; set; } //The position of the King in tuple format  

    public Color Color { get; set; } //The colour of the King  

    public PieceTypes PieceType { get; set; } //PieceType, self explanatory used for checks later on  

    public bool hasMoved { get; set; }



    public King(Color _Color, (int row, int column) _Position) //constructor to set the properties to the given and required values  

    {

        PieceType = PieceTypes.king;

        Position = _Position;

        Color = _Color;

        hasMoved = false;

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

    public bool hasMoved { get; set; } //Here because the pawn can move two spaces on its first move  







    public Pawn(Color _Color, (int row, int column) _Position) //constructor to set the properties to the given and required values  

    {

        PieceType = PieceTypes.pawn;

        Position = _Position;

        Color = _Color;

        hasMoved = false;

    }



    public IEnumerable<(int row, int column)> Moves() //Defines the offsets of the possible moves the pawn can make  

    {

        var possibleMoves = new (int row, int column)[]{ //stroe each of these offsets in tuple form in an ienumerable  
 
        (1, 0), (2, 0)



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

    public bool hasMoved { get; set; }



    public Queen(Color color, (int row, int column) position) //constructor to set the properties to the given and required values  

    {

        Position = position;

        Color = color;

        PieceType = PieceTypes.queen;

        hasMoved = false;

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

    public List<List<IPiece>> Pieces = new List<List<IPiece>>(); //Used to store the pieces, unique pieces handle specifics like location and type. Is given piece objects in addpieces class. It is a 2D list and works by being a list of type list; the inner list is of type IPiece 

    public string? currentPlayer; //Stores the current player  







    public GameState() //Constructor  

    {


        for (int r = 0; r < 8; r++) //Outer loop to dynamically create 8 rows for the pieces 
        {
            List<IPiece> row = new List<IPiece>(); //create a new list each of the 8 times

            for (int c = 0; c < 8; c++) //loop again 8 times to add 8 elements to the previously created list and set these lements to null
            {
                row.Add(null); //setting to null
            }

            Pieces.Add(row); //for each of these 8 outer iterations, add the list created as an element of the Pieces list
        }


    }



    public void MakeMove(IPiece piece, (int row, int column) destination) //Move making class  

    {

        bool moveSuccess = false;

        //this class needs to use the piece  

        var possibleMoves = piece.Moves();

        if (piece.PieceType == PieceTypes.pawn) //Check for if the piece is a pawn 

        {

            (int row, int column) signVector = ((destination.row - piece.Position.row), (destination.column - piece.Position.column)); //Calculate the difference between destination and current position and store it in a variable 

            if (piece.Color == Color.white) //check if the pawn is white 

            {

                if (signVector.row == -1 && signVector.column == 0) //check if the difference for row is -1 (the expected value for white pawns) and the column difference is zero meaning the pawn is moving one square in front of itself 

                {



                    if (gameBoard[destination.row, destination.column].IsOccupied == false) //check that tile the pawn is moving to is not occupied 

                    {

                        gameBoard[piece.Position.row, piece.Position.column].IsOccupied = false; //set the tile the piece is on before moving to not occupied 

                        piece.Position = destination; //set the piece position to the destination 

                        Pieces[piece.Position.row][piece.Position.column] = null; //Set the old index of the piece in the list to null

                        Pieces[destination.row][destination.column] = piece; //update the list to now hold the piece at the index of its new position

                        moveSuccess = true; //set move success flag to true 

                        piece.hasMoved = true; //set the piece has moved flag to true so the pawn can no longer do the two square move 

                        gameBoard[piece.Position.row, piece.Position.column].IsOccupied = true; //set the destination tile (tile the pawn is currently on) to occupied 

                    }

                    else //if there is a piece occupying the destiantion tile 

                    {

                        moveSuccess = false; //set move success to false - dont allow the move 

                    }





                }

                else if (signVector.row == -2 && signVector.column == 0) //check for if the white pawn is trying to move 2 squares ahead (no difference in column as pawns cant move horizontally) 

                {

                    if (gameBoard[destination.row, destination.column].IsOccupied == false && gameBoard[destination.row + 1, destination.column].IsOccupied == false) //check the tile in front of the pawn (behind the destination tile) and the destination tile are both unoccupied 

                    {

                        if (piece.hasMoved == false) //check that the pawn has not moved before because the pawn can only move 2 squares on its first move 

                        {

                            gameBoard[piece.Position.row, piece.Position.column].IsOccupied = false; //set the tile the piece is on before moving to not occupied 

                            moveSuccess = true; //set move success flag to true 

                            Pieces[piece.Position.row][piece.Position.column] = null; //Set the old index of the piece in the list to null

                            Pieces[destination.row][destination.column] = piece; //update the list to now hold the piece at the index of its new position

                            piece.Position = destination; //set the piece position to the destination 

                            piece.hasMoved = true; //set the piece has moved flag to true so the pawn can no longer do the two square move 

                            gameBoard[piece.Position.row, piece.Position.column].IsOccupied = true; //set the destination tile (tile the pawn is currently on) to occupied 

                        }

                    }

                    else //if the destination tile or the tile in front of the pawn is occupied dont allow the move 

                    {

                        moveSuccess = false;

                    }

                }

                else // if the pawn is trying to move in any other way dont allow the pawn to take that move 

                {

                    moveSuccess = false;

                }

            }

            else //if the pawn is black 

            {



                if (signVector.row == 1 && signVector.column == 0) //check if the difference for row is 1 (the expected value for black pawns) and the column difference is zero meaning the pawn is moving one square in front of itself 

                {

                    if (gameBoard[destination.row, destination.column].IsOccupied == false) //check that tile the pawn is moving to is not occupied 

                    {

                        gameBoard[piece.Position.row, piece.Position.column].IsOccupied = false; //set the tile the piece is on before moving to not occupied 

                        piece.Position = destination; //set the piece position to the destination 

                        Pieces[piece.Position.row][piece.Position.column] = null; //Set the old index of the piece in the list to null

                        Pieces[destination.row][destination.column] = piece; //update the list to now hold the piece at the index of its new position

                        moveSuccess = true; //set move success flag to true 

                        piece.hasMoved = true; //set the piece has moved flag to true so the pawn can no longer do the two square move 

                        gameBoard[piece.Position.row, piece.Position.column].IsOccupied = true; //set the destination tile (tile the pawn is currently on) to occupied 

                    }

                }

                else if (signVector.row == 2 && signVector.column == 0) //check for if the black pawn is trying to move 2 squares ahead (no difference in column as pawns cant move horizontally) 

                {

                    if (gameBoard[destination.row, destination.column].IsOccupied == false && gameBoard[destination.row - 1, destination.column].IsOccupied == false) //check the tile in front of the pawn (behind the destination tile) and the destination tile are both unoccupied 

                    {

                        if (piece.hasMoved == false) //check that the pawn has not moved before because the pawn can only move 2 squares on its first move 

                        {

                            gameBoard[piece.Position.row, piece.Position.column].IsOccupied = false; //set the tile the piece is on before moving to not occupied 

                            piece.Position = destination; //set the piece position to the destination 

                            Pieces[piece.Position.row][piece.Position.column] = null; //Set the old index of the piece in the list to null

                            Pieces[destination.row][destination.column] = piece; //update the list to now hold the piece at the index of its new position

                            moveSuccess = true; //set move success flag to true 

                            piece.hasMoved = true; //set the piece has moved flag to true so the pawn can no longer do the two square move 

                            gameBoard[piece.Position.row, piece.Position.column].IsOccupied = true; //set the destination tile (tile the pawn is currently on) to occupied 

                        }

                    }

                    else //if the destination tile or the tile in front of the pawn is occupied dont allow the move 

                    {

                        moveSuccess = false;

                    }

                }

                else // if the pawn is trying to move in any other way dont allow the pawn to take that move 

                {

                    moveSuccess = false;

                }

            }

        }
        else if (piece.PieceType == PieceTypes.bishop || piece.PieceType == PieceTypes.queen || piece.PieceType == PieceTypes.rook || piece.PieceType == PieceTypes.king)
        {
            bool isDestinationThisMove = false; //flag to check if the current offset in the iteration is the same offset the destination lies in
            foreach (var move in possibleMoves) //loop through every offset returned by the pieces moves function
            {
                int index = 0; //a placeholder variable to give the multiplier needed to be placed on the offset to get the destination position
                for (int i = 1; i < 9; i++) //loop 1 thorugh 8 and multiply the offset by the i variable
                {

                    if (((destination.row - piece.Position.row) == (move.row * i)) && (destination.column - piece.Position.column) == (move.column * i)) //check if the displacement vector of the position to destination matches the pieces offset multiplied by some constant
                    {
                        index = i; //if the displacement vector matches the current offset multiplied by some number update the index variable to store the number/multiplier
                        isDestinationThisMove = true; //update the flag to say this offset is the one which contains the destination position
                    }
                }

                if (isDestinationThisMove == true) //if the destination position is contained in this current offset
                {
                    //while (piece.Position.row <= destination.row && piece.Position.column <= destination.column)
                    {
                        for (int i = 1; i <= index; i++) //loop through from 1 to the multiplier (this is to check the tiles in between the destination tile and piece position tile)
                        {
                            if (gameBoard[piece.Position.row + (move.row * i), piece.Position.column + (move.column * i)].IsOccupied == false)// multiply the offset by i then add this to the pieces current position adn check if any tiles along this path are occupied
                            {
                                gameBoard[piece.Position.row, piece.Position.column].IsOccupied = false; //set the index of the original tile of the piece in the gameboard array to not occuppied as the piece is moving from this tile 
                                Pieces[piece.Position.row][piece.Position.column] = null; //set the index of the original position of the piece in the pieces list to null as the piece is being moved to a different index
                                piece.Position = destination; //set the pieces position to the destination position
                                Pieces[destination.row][destination.column] = piece;//set the index of the pieces array at the new position of the piece to hold the piece
                                gameBoard[destination.row, destination.column].IsOccupied = true; //set the tile at the index of the new position of the piece in the gameboard array to be occupied
                                piece.hasMoved = true; //set the has moved property of the piece to true
                                moveSuccess = true; //if none tiles are occuppied then allow the piece to move and set the move success flag to true
                                break;
                            }
                            else
                            {
                                moveSuccess = false; //if there are occuppied tiles then dont allow the piece to move
                            }
                        }
                    }
                }
            }
        }
        else //The final piece type is the knight which has a unique movement system
        {
            foreach (var move in possibleMoves)
            {
                bool isDestinationThisMove = false; //flag to check if the current offset in the iteration is the same offset the destination lies in
                if ((destination.row - piece.Position.row) == move.row && (destination.column - piece.Position.column) == move.column)
                { 
                    isDestinationThisMove = true; //if the displacement vector matches the current offset then set the flag to true
                }

                if (isDestinationThisMove)
                {
                    if (gameBoard[destination.row, destination.column].IsOccupied == false)
                    {
                        moveSuccess = true; //if the destination tile is not occupied allow the move
                        gameBoard[piece.Position.row, piece.Position.column].IsOccupied = false; //set the index of the original tile of the piece in the gameboard array to not occuppied as the piece is moving from this tile 
                        Pieces[piece.Position.row][piece.Position.column] = null; //set the index of the original position of the piece in the pieces list to null as the piece is being moved to a different index
                        piece.Position = destination; //set the pieces position to the destination position
                        Pieces[destination.row][destination.column] = piece;//set the index of the pieces array at the new position of the piece to hold the piece
                        gameBoard[destination.row, destination.column].IsOccupied = true; //set the tile at the index of the new position of the piece in the gameboard array to be occupied
                        piece.hasMoved = true; //set the has moved property of the piece to true
                    }
                    else
                    {
                        moveSuccess = false; //if the destination tile is occupied dont allow the move
                    }
                }
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

                    Pieces[row][column] = blackPieceFactory.CreatePawn((row, column)); //black pawn  

                    gameBoard[row, column].IsOccupied = true;

                }

                if (row == 6) //all of row 6 holds a pawn at the start of the game  

                {

                    Pieces[row][column] = whitePieceFactory.CreatePawn((row, column)); //white pawn  

                    gameBoard[row, column].IsOccupied = true;

                }

                if ((row == 0 && column == 0) || (row == 0 && column == 7))

                {

                    Pieces[row][column] = blackPieceFactory.CreateRook((row, column));//black rook  

                    gameBoard[row, column].IsOccupied = true;

                }

                if ((row == 7 && column == 0) || (row == 7 && column == 7))

                {

                    Pieces[row][column] = whitePieceFactory.CreateRook((row, column));// white rook  

                    gameBoard[row, column].IsOccupied = true;

                }

                if ((row == 0 && column == 1) || (row == 0 && column == 6))

                {

                    Pieces[row][column] = whitePieceFactory.CreateKnight((row, column));// white knight  

                    gameBoard[row, column].IsOccupied = true;

                }

                if ((row == 7 && column == 1) || (row == 7 && column == 6))

                {

                    Pieces[row][column] = whitePieceFactory.CreateKnight((row, column));// black knight  

                    gameBoard[row, column].IsOccupied = true;

                }

                if ((row == 0 && column == 2) || (row == 0 && column == 5))

                {

                    Pieces[row][column] = blackPieceFactory.CreateBishop((row, column)); // balck bishop  

                    gameBoard[row, column].IsOccupied = true;

                }

                if ((row == 7 && column == 2) || (row == 7 && column == 5))

                {

                    Pieces[row][column] = whitePieceFactory.CreateBishop((row, column)); // white bishop  

                    gameBoard[row, column].IsOccupied = true;

                }

                if (row == 0 && column == 3)

                {

                    Pieces[row][column] = blackPieceFactory.CreateQueen((row, column));// black queen  

                    gameBoard[row, column].IsOccupied = true;

                }

                if (row == 7 && column == 3)

                {

                    Pieces[row][column] = whitePieceFactory.CreateQueen((row, column)); // white queen  

                    gameBoard[row, column].IsOccupied = true;

                }

                if (row == 0 && column == 4)

                {

                    Pieces[row][column] = blackPieceFactory.CreateKing((row, column)); // Black King  

                    gameBoard[row, column].IsOccupied = true;

                }

                if (row == 7 && column == 4)

                {

                    Pieces[row][column] = whitePieceFactory.CreateKing((row, column)); // White King  

                    gameBoard[row, column].IsOccupied = true;

                }

            }

        }

    }



    public void createBoard()

    //creating the 8x8 board with alternating tiles in the pattern of a chessboard  

    {

        for (int row = 0; row < 8; row++) //initial loop for the rows  

        {

            if (row % 2 == 0) // if the row number is even  

            {

                for (int column = 0; column < 8; column++) // The loop for the columns if the row number is even  

                {

                    gameBoard[row, column] = new Tile();

                    if (column % 2 == 0) //if the column number is even then a white square  

                    {

                        gameBoard[row, column].tileColor = Color.white;

                        gameBoard[row, column].IsOccupied = false;

                        gameBoard[row, column].Position = (row, column);

                    }

                    else // if the column number is odd then a dark square  

                    {

                        gameBoard[row, column].tileColor = Color.black;

                        gameBoard[row, column].IsOccupied = false;

                        gameBoard[row, column].Position = (row, column);

                    }

                }

            }

            else // if the row number is odd  

            {

                for (int column = 0; column < 8; column++) //the loop for the columns if the row number is odd  

                {

                    gameBoard[row, column] = new Tile();

                    if (column % 2 == 0) // if the column number is even then a dark square  

                    {

                        gameBoard[row, column].tileColor = Color.black;

                        gameBoard[row, column].IsOccupied = false;

                        gameBoard[row, column].Position = (row, column);

                    }

                    else // if the column number is odd then a light square  

                    {

                        gameBoard[row, column].tileColor = Color.white;

                        gameBoard[row, column].IsOccupied = false;

                        gameBoard[row, column].Position = (row, column);

                    }

                }

            }

        }











    }


}


