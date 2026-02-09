using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Reflection.Metadata;

TimeSpan t = new TimeSpan(3);
GameState game = new GameState(t, "Yahya", "plr2");

game.createBoard();

game.addPieces();

Console.WriteLine("The game board and pieces are loaded into memory!");

/*game.MakeMove(game.Pieces[6][4], (4, 4));
game.MakeMove(game.Pieces[1][3], (3, 3));*/


/*Console.WriteLine("Player 1:");
Console.WriteLine(game.player1.timeRemaining);
Console.WriteLine("Player 2:");
Console.WriteLine(game.player2.timeRemaining);*/

/*game.MakeMove(game.Pieces[6][4], (4, 4), false);
game.MakeMove(game.Pieces[1][5], (3, 5), false);
game.MakeMove(game.Pieces[7][3], (3, 7), false);*/






public enum PieceTypes //The different possible types of pieces. With this we can set the different piece types later on and determine what type a piece is.  

{

    pawn,

    knight,

    bishop,

    rook,

    queen,

    king


}

public enum itemColor //The different possible piece colours. With this we can set pieces and tiles colours later on and determine what color a piece is.  

{

    black, white


}

public enum EndCondition //the different reasons why the game could end
{
    Checkmate,
    Stalemate,
    Timeout,
    Resignation
}
public interface IPiece //The basis for each piece in the project. Its used as a contract so each direct piece class knows it must require these things. Used so that we dont directly create objects of pieces in classes later on when we want to add functionality.  

{

    (int row, int column) Position { get; set; } //The position of each piece on the board. Uses a tuple with row and column.  

    itemColor Color { get; set; } //The Colour of each piece. Uses the Enum Color from earlier as its type  

    PieceTypes PieceType { get; set; } //The type of each piece. Uses the Enum PieceTypes from earlier as its type  

    IEnumerable<(int row, int column)>? Moves(); //A method with type of an IEnumerable tuple. This is so we can set and determine the possible moves a piece makes. Its IEnumerable so we can iterate through these possible moves meaning they can be passed between different data structures such as arrays and lists. Its a tuple with row and column so that we can get the exact coordinates of each possible move returned in a nice easy to work with format  

    bool hasMoved { get; set; }


}


public interface ITile //Used as the basis for all tiles on the gameboard.  

{

    bool IsOccupied { get; set; } //A flag to tell us whether a tile is currently occupied by a piece. This can be used in the piece movement system so that no two pieces can occupy the same tile.  

    (int row, int column) Position { get; set; } //Used so we can determine where a tile is.  

    itemColor tileColor { get; set; } //Used to determine the colour of a tile, important when creating the board.  

    bool isLightUp { get; set; }

    bool isLightUpCheck { get; set; }
}

public class Piece : IPiece
{
    public (int row, int column) Position { get; set; }
    public itemColor Color { get; set; }

    public PieceTypes PieceType { get; set; }

    public bool hasMoved { get; set; }

    public IEnumerable<(int row, int column)>? Moves()
    {
        throw new NotImplementedException();
    }
}

public class Tile : ITile

{

    public bool IsOccupied { get; set; }

    public (int row, int column) Position { get; set; }

    public itemColor tileColor { get; set; }

    public bool isLightUp { get; set; }

    public bool isLightUpCheck { get; set; }
}

public class Player
{
    public List<IPiece> takenPieces;
    public itemColor color;
    public string name;
    public TimeSpan timeRemaining;
    public bool isThisPlayerMove = false;
    public bool playerTimeout = false; //check if a player has ran out of time
    public bool Checked = false; //used to signal if the player is in check
    public IPiece playerKing; //used to keep track of the players king
    public List<IPiece> playerPieces; //this is a list which contains all of a players pieces
    public bool CheckMate = false;

    public Player(itemColor color, string name, TimeSpan initialTime)
    {
        this.color = color;
        this.name = name;
        this.timeRemaining = initialTime;
        takenPieces = new List<IPiece>();
        playerPieces = new List<IPiece>();
    }
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

        knight = new Knight(itemColor.black, Position); //create a knight set its colour to black, set its position to the given position and store this knight in the object knight property  

        return knight; //return the knight into a variable where the knight was called  

    }



    public IPiece CreateBishop((int row, int column) Position) //used to create a black bishop   

    {

        bishop = new Bishop(itemColor.black, Position); //create a bishop set its colour to black, set its position to the given position and store this bishop in the object bishop property  

        return bishop; //return the bishop into a variable where the bishop was called  

    }



    public IPiece CreatePawn((int row, int column) Position) //used to create a black pawn   

    {

        pawn = new Pawn(itemColor.black, Position); //create a pawn set its colour to black, set its position to the given position and store this pawn in the object pawn property  

        return pawn; //return the pawn into a variable where the pawn was called  

    }



    public IPiece CreateRook((int row, int column) Position) //used to create a black rook  

    {

        rook = new Rook(itemColor.black, Position); //create a rook set its colour to black, set its position to the given position and store this rook in the object rook property  

        return rook; //return the rook into a variable where the rook was called  

    }



    public IPiece CreateQueen((int row, int column) Position) //used to create a black queen  

    {

        queen = new Queen(itemColor.black, Position); //create a queen set its colour to black, set its position to the given position and store this queen in the object queen property  

        return queen; //return the queen into a variable where the queen was called  

    }



    public IPiece CreateKing((int row, int column) Position) //used to create a black king  

    {

        king = new King(itemColor.black, Position); //create a king set its colour to black, set its position to the given position and store this king in the object king property  

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

        knight = new Knight(itemColor.white, Position);//create a knight set its colour to white, set its position to the given position and store this knight in the object knight property  

        return knight; //return the knight into a variable where the knight was called  

    }



    public IPiece CreateBishop((int row, int column) Position) //used to create a white bishop  

    {

        bishop = new Bishop(itemColor.white, Position); //create a bishop set its colour to white, set its position to the given position and store this bishop in the object bishop property  

        return bishop; //return the bishop into a variable where the bishop was called  

    }



    public IPiece CreatePawn((int row, int column) Position) //used to create a white pawn  

    {

        pawn = new Pawn(itemColor.white, Position); //create a pawn set its colour to white, set its position to the given position and store this pawn in the object pawn property  

        return pawn; //return the pawn into a variable where the pawn was called  

    }



    public IPiece CreateRook((int row, int column) Position) //used to create a white rook  

    {

        rook = new Rook(itemColor.white, Position); //create a rook set its colour to white, set its position to the given position and store this rook in the object rook property  

        return rook; //return the rook into a variable where the rook was called  

    }



    public IPiece CreateQueen((int row, int column) Position) //used to create a white queen  

    {

        queen = new Queen(itemColor.white, Position); //create a queen set its colour to white, set its position to the given position and store this queen in the object queen property  

        return queen; //return the queen into a variable where the queen was called  

    }



    public IPiece CreateKing((int row, int column) Position) //used to create a white king  

    {

        king = new King(itemColor.white, Position); //create a king set its colour to white, set its position to the given position and store this king in the object king property  

        return king; //return the king into a variable where the king was called  

    }


}

public class Knight : IPiece //Concrete Knight class which defines everything about a Knight  

{

    public itemColor Color { get; set; } //The colour of the knight  

    public PieceTypes PieceType { get; set; } //The Piecetype of the knight (set to knight later in the constructor)  

    public (int row, int column) Position { get; set; } //The position of the knight in tuple format  

    public bool hasMoved { get; set; }



    public Knight(itemColor _Color, (int x, int y) _Position) // Constructor - takes in a color and position. It then assigns the given color and position to the instantiated object whilst also making the piecetype knight  

    {

        PieceType = PieceTypes.knight; //set the piecetype to knight  

        Color = _Color; //set the colour to the given colour  

        Position = _Position; // set position to given position  

        hasMoved = false;

    }



    public IEnumerable<(int row, int column)>? Moves() //Defines the possible moves the knight can make  

    {

        var possiblemoves = new (int row, int column)[] {  //Creates an array of tuple type which contains coordinates for move offsets assuming the knight is at an origin 0,0  
 
        (1, -2), (1, 2), (2, 1),
        (2, -1), (-1, -2), (-1, 2),
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

    public itemColor Color { get; set; } //The colour of the Bishop  

    public PieceTypes PieceType { get; set; } //piecetype  

    public bool hasMoved { get; set; }



    public Bishop(itemColor _Color, (int row, int column) _Position) //constructor to set the properties to the given and required values  

    {

        PieceType = PieceTypes.bishop;

        Position = _Position;

        Color = _Color;

        hasMoved = false;

    }



    public IEnumerable<(int row, int column)>? Moves() //Defines the possible moves the Bishop can make  

    {

        var possibleMoves = new (int row, int column)[] //Stores the unit vector of the offsets of each possible move the bishop and stores them in a coordinate tuple array (assuming the Bishop is at the origin 0,0)  

        {

        (-1, -1), (1, -1),

        (1, 1), (-1, 1)

        };



        foreach (var move in possibleMoves) //foe each of these muliply them by 1 through 8 and return each of these values  

        {
            yield return move; //return  

        }

    }


}

public class Rook : IPiece //Concrete Rook class which defines everything about a Rook  

{

    public itemColor Color { get; set; }  //The colour of the Rook  

    public PieceTypes PieceType { get; set; } //The PieceType of the Rook  

    public (int row, int column) Position { get; set; }  //The position of the Rook in tuple format  

    public bool hasMoved { get; set; }



    public Rook(itemColor _Color, (int row, int column) _Position) //constructor to set the properties to the given and required values  

    {

        PieceType = PieceTypes.rook;

        Position = _Position;

        Color = _Color;

        hasMoved = false;

    }



    public IEnumerable<(int row, int column)>? Moves() //Defines the offsets of the particular moves the Rook can make  

    {

        var possibleMoves = new (int row, int column)[]{ //The possible moves in row column tuple form stored in an ienumerable  
 
        (0, -1), (1, 0),

        (0, 1), (-1, 0)

    };



        foreach (var move in possibleMoves) //foe each of these muliply them by 1 through 8 and return each of these values  

        {
            yield return move; //return  

        }

    }


}

public class King : IPiece //Concrete King class which defines everything about a king  

{

    public (int row, int column) Position { get; set; } //The position of the King in tuple format  

    public itemColor Color { get; set; } //The colour of the King  

    public PieceTypes PieceType { get; set; } //PieceType, self explanatory used for checks later on  

    public bool hasMoved { get; set; }



    public King(itemColor _Color, (int row, int column) _Position) //constructor to set the properties to the given and required values  

    {

        PieceType = PieceTypes.king;

        Position = _Position;

        Color = _Color;

        hasMoved = false;

    }



    public IEnumerable<(int row, int column)>? Moves() //Defines the unit vectors of the possible directions the king can move in  

    {

        var possibleMoves = new (int row, int column)[]{ //The possible moves in row column tuple form stored in an ienumerable  
 
        (-1, 0), (1, 0),

        (0, 1), (0, -1),

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

    public itemColor Color { get; set; } //The colour of the Pawn  

    public PieceTypes PieceType { get; set; } //PieceType, self explanatory used for checks later on  

    public bool hasMoved { get; set; } //Here because the pawn can move two spaces on its first move  







    public Pawn(itemColor _Color, (int row, int column) _Position) //constructor to set the properties to the given and required values  

    {

        PieceType = PieceTypes.pawn;

        Position = _Position;

        Color = _Color;

        hasMoved = false;

    }



    public IEnumerable<(int row, int column)>? Moves() //Defines the offsets of the possible moves the pawn can make  

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

    public itemColor Color { get; set; }//The colour of the Queen  

    public PieceTypes PieceType { get; set; }//PieceType, self explanatory used for checks later on  

    public bool hasMoved { get; set; }



    public Queen(itemColor color, (int row, int column) position) //constructor to set the properties to the given and required values  

    {

        Position = position;

        Color = color;

        PieceType = PieceTypes.queen;

        hasMoved = false;

    }



    public IEnumerable<(int row, int column)>? Moves() //defines the unit vectors of the posssible directions the queen can move in  

    {

        var possibleMoves = new (int row, int column)[]{ //store each of these offsets in tuple form in an ienumerable  
 
        (-1, -1), (-1, 0), (-1, 1),

        (0 ,-1), (1, -1), (1 ,0),

        (1 ,1), (0 ,1)



    };



        foreach (var move in possibleMoves) //foe each of these muliply them by 1 through 8 and return each of these values  

        {
            yield return move; //return  

        }







    }


}

public class GameState

{

    public ITile[,] gameBoard = new ITile[8, 8]; //Used to create the actual game board. Is Given Tile objects in createboard method  

    public List<List<IPiece>> Pieces = new List<List<IPiece>>(); //Used to store the pieces, unique pieces handle specifics like location and type. Is given piece objects in addpieces class. It is a 2D list and works by being a list of type list; the inner list is of type IPiece 

    public EndCondition endCondition; //used to track the reason for the game ending

    public bool isGameEnd = false; //used to track if the game has ended

    public Player Winner; //Used to identify the winner

    public Player currentPlayer; //Stores the current player  

    public itemColor playerTurn = itemColor.white; //variable which gives the color of the current player's turn

    public int playerTurnCounter = 0; //variable which is used to calculate the current player's turn

    public bool hasPieceBeenCaptured = false; //this is a flag used to check whether a piece has been captured following the most recent move

    public Player player1; //white
    public Player player2; //black

    public System.Timers.Timer timer;

    
    public bool isPlayerinCheck = false; //flag used to signal a player has been put into check
    public bool isMoveEscapedCheck = false; //flag used to signal if a move would let a player escape check
    public bool hasRecursiveCallHappened = false; //used to signal when a recursive call for the checking if a player can exit check has already happened - this stops infinite calls
    bool debounce = false; //used as a debounce for when CheckForCheck runs to check if a move will still result in a player being in check


    IPiece blacksKing; //these are used to store the white and black king - used for checking for check
    IPiece whitesKing;

    bool arePiecesLoaded = false; //used as a flag so that the check for check method doesn't run before pieces are loaded
    List<IPiece> player1CheckingPiecesList; //list of all the pieces checking player 1
    List<IPiece> player2CheckingPiecesList; //list of all the pieces checking player 2



    public GameState(TimeSpan gameTime, string player1Name, string player2Name) //Constructor  

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




        player1 = new Player(itemColor.white, player1Name, gameTime);
        player1.timeRemaining = gameTime;
        player2 = new Player(itemColor.black, player2Name, gameTime);
        player2.timeRemaining = gameTime;

        timer = new System.Timers.Timer();
        timer.Interval = 1000; //run the timer tick event once every second 
        timer.Elapsed += timer_Tick;

        timer.Start();
    }




  /*  public void MakeMove(IPiece piece, (int row, int column) destination, bool isThisMethodCheckingForCheck, bool isThisMethodCheckingForEscapingCheck) //Move making method 

    {
        bool moveSuccess = false; //used to determine if a move was successful
        bool isCapturingPiece = false; //this is so we know if we should run the logic which just moves a piece or if we should run the logic which moves and captures a piece
        bool willThisMoveEscapeCheck = false; //used if the method was called to check if moving a king would take a player out of check
        
       
        var possibleMoves = piece.Moves();

        if (playerTurnCounter % 2 == 0) //if the counter is even its whites turn - 0 is the first psoitive even number so white always goes first
        {
            playerTurn = itemColor.white;

        }
        else //if the counter is odd its blacks turn - odd numbers always come after an even number
        {
            playerTurn = itemColor.black;


        }

        if (playerTurn == itemColor.white) //check if its whites turn
        {
            if (player1.Checked) //check if white is checked
            {
                if (piece.PieceType == PieceTypes.king) //check if white is trying to move its king - a player should only be allowed to move their king if their in check no other pieces
                {
                    if (!hasRecursiveCallHappened) //When the check for check function below runs it calls make move - this prevents make move from calling check for check again and causing an infinite loop
                    {
                        hasRecursiveCallHappened = true; //set the flag to be true so the check for check function cant be called multiple times in one recursive call
                        //debounce = true;
                        if (checkForCheck((destination.row, destination.column), player1, true)) //this function would return true if a move would take a checked white king out of check
                        {
                            willThisMoveEscapeCheck = true; //if the move will allow the piece to escape check set this flag to true
                        }
                        else
                        {
                            
                            debounce = true; //if the move wont allow the white king to escape check set debounce to true 
                        }
                    }
                }
            }
        }
        else //if its not whites turn its blacks turn
        {
            if (player2.Checked) //check if black is checked
            {
                if (piece.PieceType == PieceTypes.king) //check if black is trying to move its king - a player should only be allowed to move their king if their in check no other pieces
                {if (!hasRecursiveCallHappened) //When the check for check function below runs it calls make move - this prevents make move from calling check for check again and causing an infinite loop
                    {
                        hasRecursiveCallHappened = true; //set the flag to be true so the check for check function cant be called multiple times in one recursive call
                        if (checkForCheck((destination.row, destination.column), player2, true)) //this function would return true if a move would take a checked black king out of check
                        {
                            willThisMoveEscapeCheck = true; //if the move will allow the piece to escape check set this flag to true
                        } 
                        else
                        {
                            debounce = true; //if the move wont allow the black king to escape check set debounce to true
                        }
                    }
                }
            }
        }


        if (piece.Color == playerTurn || isThisMethodCheckingForCheck == true) //check if the piece being moved belongs to the player whos turn it currently is but ignor this rule if we're only running this to check if a piece is in check
        {
            if (piece.Color == itemColor.white)
            {
                currentPlayer = player1;
            }
            else 
            {
                currentPlayer = player2;
            }
            

            if ((player1.playerTimeout != true) && (player2.playerTimeout != true)) //check a player hasn't timed out 
            {
                if ((isThisMethodCheckingForCheck && isThisMethodCheckingForEscapingCheck) || !debounce) // (1) If the method was called to check if a piece can escape check then allow the move logic to progress (the parameters 'isThisMethodCheckingForCheck' and 'isThisMethodCheckingForEscapingCheck' would be true in that case)  (2) If the method was called for movement then the debounce variable will determine whether the mvoe would be allowed (in all cases the debounce variable is set to false, unless a checked king is trying to mvoe into a position which would keeep them in check - in that case debounce is set to true) 
                {
                    
                    if (piece.PieceType == PieceTypes.pawn) //Check for if the piece is a pawn 

                    {

                        (int row, int column) signVector = ((destination.row - piece.Position.row), (destination.column - piece.Position.column)); //Calculate the difference between destination and current position and store it in a variable 

                        if (piece.Color == itemColor.white) //check if the pawn is white 

                        {

                            if (signVector.row == -1 && signVector.column == 0) //check if the difference for row is -1 (the expected value for white pawns) and the column difference is zero meaning the pawn is moving one square in front of itself 

                            {



                                if (gameBoard[destination.row, destination.column].IsOccupied == false) //check that tile the pawn is moving to is not occupied 

                                {


                                    moveSuccess = true; //set move success flag to true 

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


                                        moveSuccess = true; //set move success flag to true 



                                    }

                                }

                                else //if the destination tile or the tile in front of the pawn is occupied dont allow the move 

                                {

                                    moveSuccess = false;

                                }

                            }
                            else if (signVector.row == -1 && signVector.column == -1) //check if the white pawn is trying to move to the tile which is to its top left. This only works if there is a piece here as this move is for caputring pieces
                            {
                                if (gameBoard[destination.row, destination.column].IsOccupied == true)
                                {
                                    isCapturingPiece = true;
                                    moveSuccess = true;
                                }
                                else //if there is no piece on the tile the white pawn is trying to capture a piece from
                                {
                                    moveSuccess = false;
                                }
                            }
                            else if (signVector.row == -1 && signVector.column == 1) //check if the white pawn is trying to move to the tile which is to its top right. This only works if there is a piece here as this move is for caputring pieces 
                            {
                                if (gameBoard[destination.row, destination.column].IsOccupied == true)
                                {
                                    isCapturingPiece = true;
                                    moveSuccess = true;
                                }
                                else //if there is no piece on the tile the white pawn is trying to capture a piece from
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

                                    moveSuccess = true; //set move success flag to true 

                                }

                            }

                            else if (signVector.row == 2 && signVector.column == 0) //check for if the black pawn is trying to move 2 squares ahead (no difference in column as pawns cant move horizontally) 

                            {

                                if (gameBoard[destination.row, destination.column].IsOccupied == false && gameBoard[destination.row - 1, destination.column].IsOccupied == false) //check the tile in front of the pawn (behind the destination tile) and the destination tile are both unoccupied 

                                {

                                    if (piece.hasMoved == false) //check that the pawn has not moved before because the pawn can only move 2 squares on its first move 

                                    {


                                        moveSuccess = true; //set move success flag to true 

                                    }

                                }

                                else //if the destination tile or the tile in front of the pawn is occupied dont allow the move 

                                {

                                    moveSuccess = false;

                                }

                            }
                            else if (signVector.row == 1 && signVector.column == -1) //if the black pawn is trying to capture a piece to its bottom left. This only works if there is a piece here as this move is for capturing pieces
                            {
                                if (gameBoard[destination.row, destination.column].IsOccupied == true)
                                {
                                    isCapturingPiece = true;
                                    moveSuccess = true;
                                }
                                else //if there is no piece on the tile the black pawn is trying to capture a piece from
                                {
                                    moveSuccess = false;
                                }
                            }
                            else if (signVector.row == 1 && signVector.column == 1) //if the black pawn is trying to capture a piece to its bottom right. This only works if there is a piece here as this move is for caputring pieces
                            {
                                if (gameBoard[destination.row, destination.column].IsOccupied == true)
                                {
                                    isCapturingPiece = true;
                                    moveSuccess = true;
                                }
                                else //if there is no piece on the tile the black pawn is trying to capture a piece from
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
                        bool isDestinationThisMove = false; //flag to check if the current offset in the iteration is the same offset the destination lies in **
                        foreach (var move in possibleMoves) //loop through every offset returned by the pieces moves function
                        {
                            int index = 0; //a placeholder variable to give the multiplier needed to be placed on the offset to get the destination position
                            for (int i = 1; i < 9; i++) //loop 1 thorugh 8 and multiply the offset by the i variable
                            {

                                if (((destination.row - piece.Position.row) == (move.row * i)) && (destination.column - piece.Position.column) == (move.column * i)) //check if the displacement vector of the position to destination matches the pieces offset multiplied by some constant
                                {
                                    index = i; //if the displacement vector matches the current offset multiplied by some number update the index variable to store the number/multiplier
                                    isDestinationThisMove = true; //update the flag to say this offset is the one which contains the destination position
                                    break;


                                }
                            }

                            if (isDestinationThisMove == true) //if the destination position is contained in this current offset
                            {
                                bool tileBlocked = false; //flag to check that a tile on the path from a piece position to its destination is not blocked
                                                          //while (piece.Position.row <= destination.row && piece.Position.column <= destination.column)
                                {
                                    for (int i = 1; i <= index; i++) //loop through from 1 to the multiplier (this is to check the tiles in between the destination tile and piece position tile)
                                    {
                                        if (piece.PieceType == PieceTypes.king) //the king can only move one square in any direction, this avoids the king being allowed the same movement pattern as the queen
                                        {
                                            if (i > 1) break;
                                        }
                                        if (gameBoard[piece.Position.row + (move.row * i), piece.Position.column + (move.column * i)].IsOccupied == false)// multiply the offset by i then add this to the pieces current position adn check if any tiles along this path are occupied
                                        {
                                            if (!tileBlocked) //Only allow the tile blocked flag to be set to false if it hasnt previously been set to true. This prevents a tile being blocked, then a tile after that being free making this flag be set to false
                                            {
                                                tileBlocked = false; //set the flag to false as no tiles along the path are occuppied
                                            }
                                        }
                                        else //if a tile along the path is occuppied
                                        {
                                            
                                            tileBlocked = true; //set the flag to true to indicate that a tile along this path is blocked 
                                            moveSuccess = false; //if there are occuppied tiles then dont allow the piece to move
                                        }

                                        if (index == 1) //check if the piece is trying to move only one square - this is for capturing a piece
                                        {
                                            if (i == 1) //now check if its on its first iteration
                                            {
                                                if (gameBoard[destination.row, destination.column].IsOccupied == true) //check if we are taking a piece - this mean we would have checked every tile in between the start position and the end position and now we are manually checking the end position
                                                {
                                                    //**
                                                    moveSuccess = true;
                                                    isCapturingPiece = true;
                                                    break;
                                                }
                                            }
                                        }
                                        else //if the piece is trying to move more than one square - this is for capturing a piece
                                        {
                                            if (i == index - 1) //check if we have gone through every tile in between the pieces position and destination
                                            {
                                                if (gameBoard[piece.Position.row + (move.row * i), piece.Position.column + (move.column * i)].IsOccupied == false)
                                                {
                                                    if (!tileBlocked)
                                                    {
                                                        if (gameBoard[destination.row, destination.column].IsOccupied == true) //check if we are taking a piece - this measn we would have checked every tile in between the start position and the end position and now we are manually checking the end position
                                                        {
                                                            moveSuccess = true;
                                                            isCapturingPiece = true;
                                                            break;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        if (i == index) //check if this current iteration is the interation which would give us the pieces destination - this is not for capturing a piece so we go all the way to the destination as we are expecting this tile to not be occupied
                                        {

                                            if (tileBlocked == false) //check that no tiles along the path were blocked
                                            {
                                                moveSuccess = true; //if no tiles are occuppied then allow the piece to move and set the move success flag to true
                                                hasPieceBeenCaptured = false; //change the flag to be false as a piece hasnt been captured this move  
                                            } //we dont have an else as we dont allow a move under any circumstances if a tile was occuppied along the path

                                        }
                                    }
                                }
                            }
                            if (moveSuccess)
                            {

                                break;
                            }

                        }
                    }
                    else //The final piece type is the knight which has a unique movement system
                    {
                        foreach (var move in possibleMoves)
                        {
                            bool isDestinationThisMove = false; //flag to check if the current offset in the iteration is the same offset the destination lies in
                            if ((destination.row - piece.Position.row) == move.row && (destination.column - piece.Position.column) == move.column) //check if the move is valid by checking if the move is possible via the offstets for the knight
                            {
                                isDestinationThisMove = true; //if the displacement vector matches the current offset then set the flag to true
                            }

                            if (isDestinationThisMove)
                            {
                                if (gameBoard[destination.row, destination.column].IsOccupied == false)
                                {
                                    moveSuccess = true; //if the destination tile is not occupied allow the move
                                }
                                else
                                {
                                    isCapturingPiece = true;
                                    moveSuccess = true; //if the destination tile is occuppied and the knight can capture it allow the move
                                }
                            }
                        }
                    }
                    if (moveSuccess) //if a move was successfull
                    {

                        if (isThisMethodCheckingForCheck) //check if the method was called to check if a player is in check
                        {
                            

                            if (isThisMethodCheckingForEscapingCheck) //check if the method was called to check if a move would allow a player to escape check
                            {
                                //**black escape check check goes here
                                isPlayerinCheck = false; //reset the flag to show if a player is in check
                                isMoveEscapedCheck = false; //cheange the flag used to show if a player has escaped check to be true as the player has escaped check
                                debounce = false; //set debounce to false as the player has escaped check and movement should be allowed
                                hasRecursiveCallHappened = false; //reset the flag which allows the check for check method to run to make sure a piece is not moving into a position where it would be in check
                            }
                            else
                            { 
                                isPlayerinCheck = true; //set the flag to true as the move succeeded so the player is in check
                            }


                        }

                        if (!isThisMethodCheckingForCheck) //if the method was called to move or capture, not for checking for check
                        {
                            if (!isCapturingPiece) //if the piece is not trying to capture and the move is legal
                            {
                                gameBoard[piece.Position.row, piece.Position.column].IsOccupied = false; //set the tile the piece is on before moving to not occupied 
                                Pieces[piece.Position.row][piece.Position.column] = null; //Set the old index of the piece in the list to null
                                piece.Position = destination; //set the piece position to the destination 
                                Pieces[destination.row][destination.column] = piece; //update the list to now hold the piece at the index of its new position
                                piece.hasMoved = true; //set the piece has moved flag to true so the pawn can no longer do the two square move 
                                gameBoard[piece.Position.row, piece.Position.column].IsOccupied = true; //set the destination tile (tile the pawn is currently on) to occupied 
                                hasPieceBeenCaptured = false; //change the flag to be false as a piece hasnt been captured this move
                                isCapturingPiece = false; //reset the flag which allows the check for check method to run to make sure a piece is not moving into a position where it would be in check
                            }
                            else //if the piece is trying to capture and the move is legal
                            {
                                capturePiece(piece, Pieces[destination.row][destination.column]);
                                isCapturingPiece = false; //reset the flag which allows the check for check method to run to make sure a piece is not moving into a position where it would be in check
                            }
                            playerTurnCounter += 1;//move the playerTurnCounter up by one to show the calculation that its the next players turn

                            

                            player1.Checked = checkForCheck((0, 0), player1, false); //run the checks which check if a player is in check as we are not checking if the piece can escape check just put random values for the first parameter and set the last one to false so the function knows not to use these values in the first parameter and instead use the player's king field
                            player2.Checked = checkForCheck((0, 0), player2, false); //




                        }
                        







                        
                    }
                    else //if the move failed
                    {
                            if (isThisMethodCheckingForCheck) //check if the move failed and was checking for check
                            {
                                if (isThisMethodCheckingForEscapingCheck) //check if the mvoe that failed was a piece moving to a tile which a king wanting to move out of check was going to move to (simulation not actual movement) - this means that this tile is safe for the king to move to
                                {
                                    isMoveEscapedCheck = true; //The piece will no longer be in check if it takes this move
                                    hasRecursiveCallHappened = false; //reset the flag which allows the check for check method to run to make sure a piece is not moving into a position where it would be in check
                                }
                            }
                        if (!isThisMethodCheckingForCheck)
                        {
                            player1.Checked = checkForCheck((0, 0), player1, false); //run the checks which check if a player is in check as we are not checking if the piece can escape check just put random values for the first parameter and set the last one to false so the function knows not to use these values in the first parameter and instead use the player's king field
                            player2.Checked = checkForCheck((0, 0), player2, false);
                        }
                    }
                }
                debounce = false; //reset debounce as the cehcked king is no longer trying to move
                moveSuccess = false; //reset move success
            }
        }

        


        /* if (moveSuccess == false)

             {

                 Console.WriteLine("The move has failed");

             }

             else

                 {

                 Console.WriteLine("The move has succeded");

         }





    }*/

    public void MakeMove(IPiece piece, (int row, int column )destination) //move making method
    {
        Player currentPlayer; //the player whos turn it is
        bool allowMove = true; //whether the mvoe should be allowed

        if (piece.Color == itemColor.white)
        {
            currentPlayer = player1; //white = player1
        }
        else
        {
            currentPlayer = player2; //black = player2
        }

        if (currentPlayer.Checked) //if the current player is checked
        {
            allowMove = false;
            if (piece.PieceType == PieceTypes.king) //is the current is checked and trying to move their king
            {
                if (!checkIfKingInCheckAtPosition(currentPlayer, destination).isInCheck) //if the current player who is checked would still be in check after moving their king to a given location - if a player is checked the only piece that they can mvoe is their king and out of check 
                {
                    allowMove = true;
                }
            }
            
            else //if the player is checked and is not trying to move their king and moving any other pieces would not allow the player to escape check dont allow the move
            {
                //get the list of checking pieces
                List<IPiece> checkingPieces;

                if (currentPlayer.color == itemColor.black)
                {
                    checkingPieces = player2CheckingPiecesList;
                }
                else
                {
                    checkingPieces = player1CheckingPiecesList;
                }

                foreach (var checkingPiece in checkingPieces)
                {
                    if (destination.row == checkingPiece.Position.row && destination.column == checkingPiece.Position.column) //check if the piece being moved is trying to capture the checking peice
                    {
                        if (isMoveLegal(piece, destination).moveSuccess) //check if the move is legal
                        {
                            allowMove = true;
                            break;
                        }
                    }
                    if (checkingPiece.PieceType == PieceTypes.bishop || checkingPiece.PieceType == PieceTypes.rook || checkingPiece.PieceType == PieceTypes.queen)
                    {
                        List<(int row, int column)> tilesAlongPath = new List<(int row, int column)>();
                        int numberOfTiles = 0;

                        foreach (var move in checkingPiece.Moves())
                        {
                            bool isDestinationThisIndex = false;

                            for (int i = 0; i < 9; i++)
                            {
                                if ((currentPlayer.playerKing.Position.row - checkingPiece.Position.row == move.row * i) && (currentPlayer.playerKing.Position.column - checkingPiece.Position.column == move.column * i))
                                {
                                    numberOfTiles = i;
                                    isDestinationThisIndex = true;
                                    break;
                                }
                            }

                            if (isDestinationThisIndex)
                            {
                                for (int i = 1; i < numberOfTiles; i++)
                                {
                                    tilesAlongPath.Add(((checkingPiece.Position.row + move.row * i), (checkingPiece.Position.column + move.column * i)));
                                }
                                break;
                            }
                        }

                        foreach (var tile in tilesAlongPath)
                        {
                            if (destination.row == tile.row && destination.column == tile.column)
                            {
                                if (isMoveLegal(piece, destination).moveSuccess)
                                {
                                    allowMove = true;
                                    break;
                                }
                            }
                        }

                        if (allowMove)
                        {
                            break;
                        }
                    }

                }

               
                
            }
        }
        bool moveSuccess = isMoveLegal(piece, destination).moveSuccess;
        bool isCapturingPiece = isMoveLegal(piece, destination).isCapturingPiece;

        if (allowMove)
        {
            if (moveSuccess)
            {
                if (isCapturingPiece)
                {
                    capturePiece(piece, Pieces[destination.row][destination.column]);
                }
                else
                {
                    gameBoard[piece.Position.row, piece.Position.column].IsOccupied = false; //set the tile the piece is on before moving to not occupied 
                    Pieces[piece.Position.row][piece.Position.column] = null; //Set the old index of the piece in the list to null
                    piece.Position = destination; //set the piece position to the destination 
                    Pieces[destination.row][destination.column] = piece; //update the list to now hold the piece at the index of its new position
                    piece.hasMoved = true; //set the piece has moved flag to true so the pawn can no longer do the two square move 
                    gameBoard[piece.Position.row, piece.Position.column].IsOccupied = true; //set the destination tile (tile the pawn is currently on) to occupied 
                    hasPieceBeenCaptured = false; //change the flag to be false as a piece hasnt been captured this move
                }
                playerTurnCounter += 1;//move the playerTurnCounter up by one to show the calculation that its the next players turn

                player1.Checked = checkForCheck(player1).isInCheck; //as a move has occured check if white is now in check
                player1CheckingPiecesList = checkForCheck(player1).checkingPieces; //store the piece which may be putting player1 in check in the player1CheckingPiecesList field
                player2.Checked = checkForCheck(player2).isInCheck; //as a move has occured check if black is now in check
                player2CheckingPiecesList = checkForCheck(player2).checkingPieces; //store the pieces which may be putting player2 in check in the player2CheckingPiecesList field

                player1.CheckMate = isPlayerinCheckmate(player1);
                player2.CheckMate = isPlayerinCheckmate(player2);
            }
        }
    }

    public (bool moveSuccess, bool isCapturingPiece) isMoveLegal(IPiece piece, (int row, int column) destination)
    {
        bool moveSuccess = false; //used to determine if a move was successful
        bool isCapturingPiece = false; //this is so we know if we should run the logic which just moves a piece or if we should run the logic which moves and captures a piece
        


        var possibleMoves = piece.Moves();

        if (playerTurnCounter % 2 == 0) //if the counter is even its whites turn - 0 is the first psoitive even number so white always goes first
        {
            playerTurn = itemColor.white;

        }
        else //if the counter is odd its blacks turn - odd numbers always come after an even number
        {
            playerTurn = itemColor.black;


        }

        


        if (piece.Color == playerTurn) //check if the piece being moved belongs to the player whos turn it currently is
        {
            if (piece.Color == itemColor.white)
            {
                currentPlayer = player1;
            }
            else
            {
                currentPlayer = player2;
            }


            if ((player1.playerTimeout != true) && (player2.playerTimeout != true)) //check a player hasn't timed out 
            {
               

                if (piece.PieceType == PieceTypes.pawn) //Check for if the piece is a pawn 

                {

                    (int row, int column) signVector = ((destination.row - piece.Position.row), (destination.column - piece.Position.column)); //Calculate the difference between destination and current position and store it in a variable 

                    if (piece.Color == itemColor.white) //check if the pawn is white 

                    {

                        if (signVector.row == -1 && signVector.column == 0) //check if the difference for row is -1 (the expected value for white pawns) and the column difference is zero meaning the pawn is moving one square in front of itself 

                        {



                            if (gameBoard[destination.row, destination.column].IsOccupied == false) //check that tile the pawn is moving to is not occupied 

                            {


                                moveSuccess = true; //set move success flag to true 

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


                                    moveSuccess = true; //set move success flag to true 



                                }

                            }

                            else //if the destination tile or the tile in front of the pawn is occupied dont allow the move 

                            {

                                moveSuccess = false;

                            }

                        }
                        else if (signVector.row == -1 && signVector.column == -1) //check if the white pawn is trying to move to the tile which is to its top left. This only works if there is a piece here as this move is for caputring pieces
                        {
                            if (gameBoard[destination.row, destination.column].IsOccupied == true)
                            {
                                isCapturingPiece = true;
                                moveSuccess = true;
                            }
                            else //if there is no piece on the tile the white pawn is trying to capture a piece from
                            {
                                moveSuccess = false;
                            }
                        }
                        else if (signVector.row == -1 && signVector.column == 1) //check if the white pawn is trying to move to the tile which is to its top right. This only works if there is a piece here as this move is for caputring pieces 
                        {
                            if (gameBoard[destination.row, destination.column].IsOccupied == true)
                            {
                                isCapturingPiece = true;
                                moveSuccess = true;
                            }
                            else //if there is no piece on the tile the white pawn is trying to capture a piece from
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

                                moveSuccess = true; //set move success flag to true 

                            }

                        }

                        else if (signVector.row == 2 && signVector.column == 0) //check for if the black pawn is trying to move 2 squares ahead (no difference in column as pawns cant move horizontally) 

                        {

                            if (gameBoard[destination.row, destination.column].IsOccupied == false && gameBoard[destination.row - 1, destination.column].IsOccupied == false) //check the tile in front of the pawn (behind the destination tile) and the destination tile are both unoccupied 

                            {

                                if (piece.hasMoved == false) //check that the pawn has not moved before because the pawn can only move 2 squares on its first move 

                                {


                                    moveSuccess = true; //set move success flag to true 

                                }

                            }

                            else //if the destination tile or the tile in front of the pawn is occupied dont allow the move 

                            {

                                moveSuccess = false;

                            }

                        }
                        else if (signVector.row == 1 && signVector.column == -1) //if the black pawn is trying to capture a piece to its bottom left. This only works if there is a piece here as this move is for capturing pieces
                        {
                            if (gameBoard[destination.row, destination.column].IsOccupied == true)
                            {
                                isCapturingPiece = true;
                                moveSuccess = true;
                            }
                            else //if there is no piece on the tile the black pawn is trying to capture a piece from
                            {
                                moveSuccess = false;
                            }
                        }
                        else if (signVector.row == 1 && signVector.column == 1) //if the black pawn is trying to capture a piece to its bottom right. This only works if there is a piece here as this move is for caputring pieces
                        {
                            if (gameBoard[destination.row, destination.column].IsOccupied == true)
                            {
                                isCapturingPiece = true;
                                moveSuccess = true;
                            }
                            else //if there is no piece on the tile the black pawn is trying to capture a piece from
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
                    bool isDestinationThisMove = false; //flag to check if the current offset in the iteration is the same offset the destination lies in **
                    foreach (var move in possibleMoves) //loop through every offset returned by the pieces moves function
                    {
                        int index = 0; //a placeholder variable to give the multiplier needed to be placed on the offset to get the destination position
                        for (int i = 1; i < 9; i++) //loop 1 thorugh 8 and multiply the offset by the i variable
                        {

                            if (((destination.row - piece.Position.row) == (move.row * i)) && (destination.column - piece.Position.column) == (move.column * i)) //check if the displacement vector of the position to destination matches the pieces offset multiplied by some constant
                            {
                                index = i; //if the displacement vector matches the current offset multiplied by some number update the index variable to store the number/multiplier
                                isDestinationThisMove = true; //update the flag to say this offset is the one which contains the destination position
                                break;


                            }
                        }

                        if (isDestinationThisMove == true) //if the destination position is contained in this current offset
                        {
                            bool tileBlocked = false; //flag to check that a tile on the path from a piece position to its destination is not blocked
                                                      //while (piece.Position.row <= destination.row && piece.Position.column <= destination.column)
                            {
                                for (int i = 1; i <= index; i++) //loop through from 1 to the multiplier (this is to check the tiles in between the destination tile and piece position tile)
                                {
                                    if (piece.PieceType == PieceTypes.king) //the king can only move one square in any direction, this avoids the king being allowed the same movement pattern as the queen
                                    {
                                        if (index > 1) break;
                                    }
                                    if (gameBoard[piece.Position.row + (move.row * i), piece.Position.column + (move.column * i)].IsOccupied == false)// multiply the offset by i then add this to the pieces current position adn check if any tiles along this path are occupied
                                    {
                                        if (!tileBlocked) //Only allow the tile blocked flag to be set to false if it hasnt previously been set to true. This prevents a tile being blocked, then a tile after that being free making this flag be set to false
                                        {
                                            tileBlocked = false; //set the flag to false as no tiles along the path are occuppied
                                        }
                                    }
                                    else //if a tile along the path is occuppied
                                    {

                                        tileBlocked = true; //set the flag to true to indicate that a tile along this path is blocked 
                                        moveSuccess = false; //if there are occuppied tiles then dont allow the piece to move
                                    }

                                    if (index == 1) //check if the piece is trying to move only one square - this is for capturing a piece
                                    {
                                        if (i == 1) //now check if its on its first iteration
                                        {
                                            if (gameBoard[destination.row, destination.column].IsOccupied == true) //check if we are taking a piece - this mean we would have checked every tile in between the start position and the end position and now we are manually checking the end position
                                            {
                                                //**
                                                moveSuccess = true;
                                                isCapturingPiece = true;
                                                break;
                                            }
                                        }
                                    }
                                    else //if the piece is trying to move more than one square - this is for capturing a piece
                                    {
                                        if (i == index - 1) //check if we have gone through every tile in between the pieces position and destination
                                        {
                                            if (gameBoard[piece.Position.row + (move.row * i), piece.Position.column + (move.column * i)].IsOccupied == false)
                                            {
                                                if (!tileBlocked)
                                                {
                                                    if (gameBoard[destination.row, destination.column].IsOccupied == true) //check if we are taking a piece - this measn we would have checked every tile in between the start position and the end position and now we are manually checking the end position
                                                    {
                                                        moveSuccess = true;
                                                        isCapturingPiece = true;
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    if (i == index) //check if this current iteration is the interation which would give us the pieces destination - this is not for capturing a piece so we go all the way to the destination as we are expecting this tile to not be occupied
                                    {

                                        if (tileBlocked == false) //check that no tiles along the path were blocked
                                        {
                                            moveSuccess = true; //if no tiles are occuppied then allow the piece to move and set the move success flag to true
                                            hasPieceBeenCaptured = false; //change the flag to be false as a piece hasnt been captured this move  
                                        } //we dont have an else as we dont allow a move under any circumstances if a tile was occuppied along the path

                                    }
                                }
                            }
                        }
                        if (moveSuccess)
                        {

                            break;
                        }

                    }
                }
                else //The final piece type is the knight which has a unique movement system
                {
                    foreach (var move in possibleMoves)
                    {
                        bool isDestinationThisMove = false; //flag to check if the current offset in the iteration is the same offset the destination lies in
                        if ((destination.row - piece.Position.row) == move.row && (destination.column - piece.Position.column) == move.column) //check if the move is valid by checking if the move is possible via the offstets for the knight
                        {
                            isDestinationThisMove = true; //if the displacement vector matches the current offset then set the flag to true
                        }

                        if (isDestinationThisMove)
                        {
                            if (gameBoard[destination.row, destination.column].IsOccupied == false)
                            {
                                moveSuccess = true; //if the destination tile is not occupied allow the move
                            }
                            else
                            {
                                isCapturingPiece = true;
                                moveSuccess = true; //if the destination tile is occuppied and the knight can capture it allow the move
                            }
                        }
                    }

                }
            }
        }

        return (moveSuccess, isCapturingPiece);
    }

    public (List<IPiece> checkingPieces, bool isInCheck) checkForCheck(Player player)
    {
        bool isInCheck = false;   //whether the king is in check or not
        List<IPiece> checkingPieces = checkDetectionSystem(player).checkingPiecesList; //the pieces which are putting the king in check

        isInCheck= checkDetectionSystem(player).isInCheck;

        if (isInCheck)
        {
            foreach (var piece in checkDetectionSystem(player).checkingPiecesList)
            {
                gameBoard[piece.Position.row, piece.Position.column].isLightUpCheck = true;
            }
        }

        return (checkingPieces, isInCheck);
    }

    public (bool isTrue, List<IPiece> BlockingPieces) canPieceBlockCheck(Player player)
    {
        bool canBlockAllCheckingPieces = true; //assume initially that all pieces which check the king can be blocked - if a piece checking the king cannot be blocked this is set to false
        List<IPiece> checkingPieces = new List<IPiece>();
        List<IPiece> pieceWhichBlocksCheck = new List<IPiece>(); //this is used to track the piece which is able to block check

        if (player.color == itemColor.black) //if the current player is white the list of pieces which are putting the piece in check are white pieces
        {
            checkingPieces = player2CheckingPiecesList;
        }
        else //if the current player is white the list of pieces which are putting the piece in check are black pieces
        {
            checkingPieces = player1CheckingPiecesList;
        }

        if (checkingPieces.Count() != 1) //if the player is in check by more than two pieces then return false as the only way to escape check when checked by two pieces is to move the king, and also retun a blacnk list as no pieces can block
        {
            return (false, new List<IPiece>());
        }

        foreach (var checkingPiece in checkingPieces) //loop through all the pieces which currently have the king in check
        {
            
            //int numberOfTiles = 0; //create a variable to hold the number of tiles between the king and the sliding piece

            if (checkingPiece.PieceType == PieceTypes.pawn)//check if the piece which has the king in check is a pawn
            {
                foreach (var playerPiece in player.playerPieces) //loop through all of the players pieces
                {
                    if (isMoveLegal(playerPiece, checkingPiece.Position).moveSuccess) //if a players piece cant capture the pawn
                    {
                        pieceWhichBlocksCheck.Add(playerPiece); //if there is a pawn the player has which can capture the checkign piece add it to the list which contains the pieces which can take the king out of check
                        //canBlockAllCheckingPieces = false; //this would mean atleast one piece cant be captured by the player so the flag should be set to false
                    }
                    else
                    {
                        
                    }
                }
            }

            if (checkingPiece.PieceType == PieceTypes.knight) //check if the piece which has the king in check is a knight
            {
                foreach (var playerPiece in player.playerPieces) //loop through all of the players pieces
                {
                    if (isMoveLegal(playerPiece, checkingPiece.Position).moveSuccess) //if a players piece cant capture the knight
                    {
                         pieceWhichBlocksCheck.Add(playerPiece); //if there is a knight the player has which can capture the checking piece add it to the list which contains the pieces which can take the king out of check
                        //canBlockAllCheckingPieces = false; //this would mean that atleast one piece cant be captured by the player so the flag would be set to false
                    }
                    else
                    {
                       
                    }
                }
            }

            if(checkingPiece.PieceType == PieceTypes.king || checkingPiece.PieceType == PieceTypes.queen || checkingPiece.PieceType == PieceTypes.rook || checkingPiece.PieceType == PieceTypes.bishop) //check if the piece which currently has the king in check is a sliding piece
            {
                List<(int row, int column)> tilesAlongPath = new List<(int row, int column)>(); //create a new list to store tiles on the path from the sliding piece to the king
                int numberOfTiles = 0;
                
                    foreach (var move in checkingPiece.Moves()) //loop through all of the sliding pieces move offsets
                    {
                        bool isDestinationThisIndex = false;

                        for (int i = 0; i < 9; i++)
                        {
                            
                            if ((player.playerKing.Position.row - checkingPiece.Position.row) == move.row * i && (player.playerKing.Position.column - checkingPiece.Position.column) == move.column * i) //this if statement calculates the multiplier and if this current offset is the right one to move the sliding piece to the king
                            {
                                numberOfTiles = i;
                                isDestinationThisIndex = true;
                                break;
                            }
                        }

                        if (isDestinationThisIndex) //if the current offset is the offset which would allow the sliding piece to move to the king
                        {
                            //bool tileBlocked = false; //flag to check that a tile on the path from a piece position to its destination is not blocked
                            for (int i = 1; i < numberOfTiles; i++)
                            {
                                tilesAlongPath.Add(((checkingPiece.Position.row + move.row * i), (checkingPiece.Position.column + move.column * i))); //add all the tiles along this path to the list which stores the tiles between the sliding peice and the king                          
                            }
                            break;
                        }
                    }
                foreach (var playerPiece in player.playerPieces)
                { 
                    
                        if (playerPiece.PieceType != PieceTypes.king)
                        {
                            if (isMoveLegal(playerPiece, checkingPiece.Position).moveSuccess)
                            {
                                //canAPieceBeMovedToAtleastOneTile = true;
                                pieceWhichBlocksCheck.Add(playerPiece); //if there is piece which can move to one of these tiles add it to the list of peices which allow the king to escape check
                                continue;
                            }
                        }
                   

                    if (tilesAlongPath.Count > 0) //if the list is not empty
                    {
                        foreach (var tile in tilesAlongPath) //loop through every tile in the list
                        {
                        //bool canAPieceBeMovedToAtleastOneTile = false;
                            if (playerPiece.PieceType != PieceTypes.king)
                            {
                                if (isMoveLegal(playerPiece, tile).moveSuccess)
                                {
                                    //canAPieceBeMovedToAtleastOneTile = true;
                                    pieceWhichBlocksCheck.Add(playerPiece); //if there is piece which can move to one of these tiles add it to the list of peices which allow the king to escape check
                                    break;
                                }
                            }




                            /*if (!canAPieceBeMovedToAtleastOneTile)
                            {
                                canBlockAllCheckingPieces = false;
                            }*/
                        }
                    }
                }
                    
                
            }
        }
        if (pieceWhichBlocksCheck.Count > 0)
        {
            canBlockAllCheckingPieces = true;
        }

        return (canBlockAllCheckingPieces, pieceWhichBlocksCheck);
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

                    player2.playerPieces.Add(Pieces[row][column]); //as the piece is black add it to player 2's (black) player pieces list

                    gameBoard[row, column].IsOccupied = true;

                }

                if (row == 6) //all of row 6 holds a pawn at the start of the game  

                {

                    Pieces[row][column] = whitePieceFactory.CreatePawn((row, column)); //white pawn  

                    player1.playerPieces.Add(Pieces[row][column]); //as the piece is white add it to player 1's (white) player pieces list

                    gameBoard[row, column].IsOccupied = true;

                }

                if ((row == 0 && column == 0) || (row == 0 && column == 7))

                {

                    Pieces[row][column] = blackPieceFactory.CreateRook((row, column));//black rook  

                    player2.playerPieces.Add(Pieces[row][column]); //as the piece is black add it to player 2's (black) player pieces list

                    gameBoard[row, column].IsOccupied = true;

                }

                if ((row == 7 && column == 0) || (row == 7 && column == 7))

                {

                    Pieces[row][column] = whitePieceFactory.CreateRook((row, column));// white rook  

                    player1.playerPieces.Add(Pieces[row][column]); //as the piece is white add it to player 1's (white) player pieces list

                    gameBoard[row, column].IsOccupied = true;

                }

                if ((row == 7 && column == 1) || (row == 7 && column == 6))

                {

                    Pieces[row][column] = whitePieceFactory.CreateKnight((row, column));// white knight  

                    player1.playerPieces.Add(Pieces[row][column]); //as the piece is white add it to player 1's (white) player pieces list

                    gameBoard[row, column].IsOccupied = true;

                }

                if ((row == 0 && column == 1) || (row == 0 && column == 6))

                {

                    Pieces[row][column] = blackPieceFactory.CreateKnight((row, column));// black knight  

                    player2.playerPieces.Add(Pieces[row][column]); //as the piece is black add it to player 2's (black) player pieces list

                    gameBoard[row, column].IsOccupied = true;

                }

                if ((row == 0 && column == 2) || (row == 0 && column == 5))

                {

                    Pieces[row][column] = blackPieceFactory.CreateBishop((row, column)); // balck bishop  

                    player2.playerPieces.Add(Pieces[row][column]); //as the piece is black add it to player 2's (black) player pieces list

                    gameBoard[row, column].IsOccupied = true;

                }

                if ((row == 7 && column == 2) || (row == 7 && column == 5))

                {

                    Pieces[row][column] = whitePieceFactory.CreateBishop((row, column)); // white bishop  

                    player1.playerPieces.Add(Pieces[row][column]); //as the piece is white add it to player 1's (white) player pieces list

                    gameBoard[row, column].IsOccupied = true;

                }

                if (row == 0 && column == 3)

                {

                    Pieces[row][column] = blackPieceFactory.CreateQueen((row, column));// black queen  

                    player2.playerPieces.Add(Pieces[row][column]); //as the piece is black add it to player 2's (black) player pieces list

                    gameBoard[row, column].IsOccupied = true;

                }

                if (row == 7 && column == 3)

                {

                    Pieces[row][column] = whitePieceFactory.CreateQueen((row, column)); // white queen  

                    player1.playerPieces.Add(Pieces[row][column]); //as the piece is white add it to player 1's (white) player pieces list

                    gameBoard[row, column].IsOccupied = true;

                }

                if (row == 0 && column == 4)

                {

                    Pieces[row][column] = blackPieceFactory.CreateKing((row, column)); // Black King  

                    player2.playerPieces.Add(Pieces[row][column]); //as the piece is black add it to player 2's (black) player pieces list

                    gameBoard[row, column].IsOccupied = true;

                    player2.playerKing =  Pieces[row][column]; //store blacks king at the start of the game in player 2s (black) king field

                }

                if (row == 7 && column == 4)

                {

                    Pieces[row][column] = whitePieceFactory.CreateKing((row, column)); // White King  

                    player1.playerPieces.Add(Pieces[row][column]); //as the piece is white add it to player 1's (white) player pieces list

                    gameBoard[row, column].IsOccupied = true;

                    player1.playerKing = Pieces[row][column]; //store whites king at the start of the game in player 1s (white) king field
                    //whitesKing = Pieces[row][column]; //store whites king at the start of the game in a variable
                }

            }

        }
        arePiecesLoaded = true;

    }

    public (List<IPiece> checkingPieces, bool isInCheck) checkIfKingInCheckAtPosition(Player player, (int row, int column) position)
    {
        bool isInCheck = false;
        List<IPiece> checkingPieces = checkDetectionSystem(player, position).checkingPiecesList; //store the list of all the pieces putting the king in check if it were to move to that position

        isInCheck = checkDetectionSystem(player, position).isInCheck;

        if (isInCheck)
        {
            foreach (var piece in checkDetectionSystem(player).checkingPiecesList)
            {
                gameBoard[piece.Position.row, piece.Position.column].isLightUpCheck = true;
            }
            gameBoard[position.row, position.column].isLightUpCheck = true;
        }

        return (checkingPieces, isInCheck);
    }

    public bool isPlayerinCheckmate(Player player)
    {
        bool canKingEscapeCheckByMoving = false; //flag to indicate if the king can escape check by moving
        bool canPieceBlockCheckFlag = false; //flag to indicate if a piece can block check
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (!checkIfKingInCheckAtPosition(player, (i, j)).isInCheck)
                {
                    canKingEscapeCheckByMoving = true;
                    break;
                }
                
            }
            if (canKingEscapeCheckByMoving)
            {
                break;
            }
        }

        if (canPieceBlockCheck(player).isTrue)
        {
            canPieceBlockCheckFlag = true;
        }

        if (canKingEscapeCheckByMoving || canPieceBlockCheckFlag)
        {
            return false;
        }
        else
        {
            return true;
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

                        gameBoard[row, column].tileColor = itemColor.white;

                        gameBoard[row, column].IsOccupied = false;

                        gameBoard[row, column].Position = (row, column);

                        gameBoard[row, column].isLightUp = false;
                    }

                    else // if the column number is odd then a dark square  

                    {

                        gameBoard[row, column].tileColor = itemColor.black;

                        gameBoard[row, column].IsOccupied = false;

                        gameBoard[row, column].Position = (row, column);

                        gameBoard[row, column].isLightUp = false;
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

                        gameBoard[row, column].tileColor = itemColor.black;

                        gameBoard[row, column].IsOccupied = false;

                        gameBoard[row, column].Position = (row, column);

                        gameBoard[row, column].isLightUp = false;
                    }

                    else // if the column number is odd then a light square  

                    {

                        gameBoard[row, column].tileColor = itemColor.white;

                        gameBoard[row, column].IsOccupied = false;

                        gameBoard[row, column].Position = (row, column);

                        gameBoard[row, column].isLightUp = false;
                    }

                }

            }

        }











    }

    public void lightUpTiles(IPiece piece)
    {
        var possibleMoves = piece.Moves();

        if (piece.PieceType == PieceTypes.pawn) //light up tile conditions for pawns
        {
            if (piece.Color == itemColor.white) //if the pawn is white
            {
                if (gameBoard[piece.Position.row - 1, piece.Position.column].IsOccupied == false) //check the tile one ahead of the pawn is not occuppied
                {
                    gameBoard[piece.Position.row - 1, piece.Position.column].isLightUp = true; //if so light up the tile
                }

                if (piece.hasMoved == false) //check the pawn hasnt moved as the pawn can only move two tiles ahead if its not moved before
                {
                    if (gameBoard[piece.Position.row - 1, piece.Position.column].IsOccupied == false) //check the tile one ahead of the pawn is not occuppied
                    {
                        if (gameBoard[piece.Position.row - 2, piece.Position.column].IsOccupied == false) //check the tile two ahead of the pawn is not occuppied
                        {
                            gameBoard[piece.Position.row - 2, piece.Position.column].isLightUp = true; //if so light it up
                        }
                    }
                }
            }
            else //black pawns
            {
                if (gameBoard[piece.Position.row + 1, piece.Position.column].IsOccupied == false) //check the tile one ahead of the pawn is not occuppied
                {
                    gameBoard[piece.Position.row + 1, piece.Position.column].isLightUp = true; //if so light it up
                }

                if (piece.hasMoved == false) //check the pawn hasnt moved as the pawn can only move two tiles ahead if its not moved before
                {
                    if (gameBoard[piece.Position.row + 1, piece.Position.column].IsOccupied == false) //check the tile one ahead of the pawn is not occuppied
                    {
                        if (gameBoard[piece.Position.row + 2, piece.Position.column].IsOccupied == false) //check the tile two ahead of the pawn is not occuppied
                        {
                            gameBoard[piece.Position.row + 2, piece.Position.column].isLightUp = true; //if so light it up
                        }
                    }
                }
            }
        }

        else if (piece.PieceType == PieceTypes.bishop || piece.PieceType == PieceTypes.rook || piece.PieceType == PieceTypes.queen || piece.PieceType == PieceTypes.king) //check if the piece is a sliding piece
        {
            foreach (var move in possibleMoves) //loop through every possible offset for the piece
            {
                bool isPathBlocked = false;

                for (int i = 1; i < 9; i++) //loop through 1 to 8 and check
                {
                    if (piece.PieceType == PieceTypes.king) //the king can only move one square in any direction, this avoids the king being shown the same movement pattern as the queen
                    {
                        if (i > 1) break;

                    }
                    if ((piece.Position.row + (move.row * i) <= 7 && piece.Position.column + (move.column * i) <= 7) && (0 <= piece.Position.row + (move.row * i) && 0 <= piece.Position.column + (move.column * i)))
                    {
                        if (gameBoard[piece.Position.row + (move.row * i), piece.Position.column + (move.column * i)].IsOccupied == false) //check that each tile at the pieces position plus the offset * i is not occuppied
                        {
                            gameBoard[piece.Position.row + (move.row * i), piece.Position.column + (move.column * i)].isLightUp = true; //if so light up the tiles which are not occuppied
                        }
                        else //if the tile is occuppied
                        {
                            isPathBlocked = true;
                            break; //dont allow the tile or any tiles after this oe along the straight line to light up
                        }
                    }
                }
            }
        }
        else //knights
        {
            foreach (var move in possibleMoves) //loop through each possible move a knight can make
            {
                if (((piece.Position.row + move.row) <= 7 && (piece.Position.column + move.column) <= 7) && (0 <= (piece.Position.row + move.row) && 0 <= (piece.Position.column + move.column)))
                {
                    if (gameBoard[piece.Position.row + move.row, piece.Position.column + move.column].IsOccupied == false) //check that the piece's current position + the offset is not occuppied
                    {
                        gameBoard[piece.Position.row + move.row, piece.Position.column + move.column].isLightUp = true; //if so let the tile light up
                    }
                }
            }
        }
    }

    public void capturePiece(IPiece piece, IPiece capturedPiece)
    {
        if (capturedPiece.Color != piece.Color)
        {
            if (piece.Color == itemColor.white) //if its white who captured the puece
            {
                var type = piece.GetType();

                player1.takenPieces.Add(capturedPiece);
            }
            else //if its black who captured the piece
            {
                player2.takenPieces.Add(capturedPiece);

            }

            if (capturedPiece.Color == itemColor.black) //if the piece is black remove it from the list which stores black's pieces
            {
                player2.playerPieces.Remove(capturedPiece);
            }
            else //if the piece is white remove it from the list which stores white's pieces
            {
                player1.playerPieces.Remove(capturedPiece);
            }

            piece.hasMoved = true;
            gameBoard[piece.Position.row, piece.Position.column].IsOccupied = false; //set the tile which holds the pieces initial position to not occuppied
            Pieces[piece.Position.row][piece.Position.column] = null; //Set the old index of the piece in the list to null
            piece.Position = capturedPiece.Position; //set the piece position to the destination

            Pieces[piece.Position.row][piece.Position.column] = null; //remove the captured piece from the pieces list
            Pieces[piece.Position.row][piece.Position.column] = piece; //set where the index of the captured piece in the Pieces list to hold the piece whihc captured it

            gameBoard[piece.Position.row, piece.Position.column].IsOccupied = true; //set the tile which holds the piece to be captured to be occuppied

            hasPieceBeenCaptured = true; //indicate a piece has been captured
        }
    }

    public (List<IPiece> checkingPiecesList, bool isInCheck) checkDetectionSystem(Player player, (int row, int column) position = default)
    {
        bool moveSuccess = false; //variable which determines if a piece is successfully able to move to a position - if an opposing piece can move to a location legally
        Player opposingPlayer; //the player who is attacking the king
        List<IPiece> checkingPieces = new List<IPiece>(); //the pieces which is putting the king/position in check
        bool isTrue = false; //used to track if the player is in check

        (int row, int column) destination;

        if (position == (0, 0)) //if the position parameter has this value this means that the function call has requested this function to use the player king field instead
        {
            destination = player.playerKing.Position;
        }
        else //if the position is an actual specified value this means the function call is requesting to use the psoition parameter instead
        {
            if (Pieces[position.row][position.column] != null) //if the position passed in contains a piece
            {
                if (player.playerKing.Color != Pieces[position.row][position.column].Color) //check that the players king and the position the players king is trying to move is not occuppied by a piece of the same colour
                {
                    destination = position;
                }
                else
                {
                    if (player.CheckMate) //if the king was previously checked then set the flag to true as the king cant legally make a move to escape check
                    {
                        isTrue = true;
                    }
                    isTrue = true; //set isTrue to true as the king cant move to this position so the king is still in check
                    return (checkingPieces, isTrue);
                }
            }
            else //if the position passed in doenst contain a piece
            {

                destination = position;
            }
        }

        if (player.color == itemColor.white)
        {
            opposingPlayer = player2; //player 2 = black
        }
        else
        {
            opposingPlayer = player1;// player1 = white
        }

        foreach (var piece in opposingPlayer.playerPieces)
        {
            var possibleMoves = piece.Moves();
                        

                if ((player1.playerTimeout != true) && (player2.playerTimeout != true)) //check a player hasn't timed out 
                {


                    if (piece.PieceType == PieceTypes.pawn) //Check for if the piece is a pawn 

                    {

                        (int row, int column) signVector = ((destination.row - piece.Position.row), (destination.column - piece.Position.column)); //Calculate the difference between destination and current position and store it in a variable 

                        if (piece.Color == itemColor.white) //check if the pawn is white 

                        {

                            if (signVector.row == -1 && signVector.column == 0) //check if the difference for row is -1 (the expected value for white pawns) and the column difference is zero meaning the pawn is moving one square in front of itself 

                            {



                                if (gameBoard[destination.row, destination.column].IsOccupied == false) //check that tile the pawn is moving to is not occupied 

                                {


                                    moveSuccess = true; //set move success flag to true 
                                   
                                }





                            }

                            else if (signVector.row == -2 && signVector.column == 0) //check for if the white pawn is trying to move 2 squares ahead (no difference in column as pawns cant move horizontally) 

                            {

                                if (gameBoard[destination.row, destination.column].IsOccupied == false && gameBoard[destination.row + 1, destination.column].IsOccupied == false) //check the tile in front of the pawn (behind the destination tile) and the destination tile are both unoccupied 

                                {

                                    if (piece.hasMoved == false) //check that the pawn has not moved before because the pawn can only move 2 squares on its first move 

                                    {


                                        moveSuccess = true; //set move success flag to true 
                                        


                                }

                                }

                            }
                            else if (signVector.row == -1 && signVector.column == -1) //check if the white pawn is trying to move to the tile which is to its top left. This only works if there is a piece here as this move is for caputring pieces
                            {
                                if (gameBoard[destination.row, destination.column].IsOccupied == true)
                                {
                                    moveSuccess = true;
                                }
                            }
                            else if (signVector.row == -1 && signVector.column == 1) //check if the white pawn is trying to move to the tile which is to its top right. This only works if there is a piece here as this move is for caputring pieces 
                            {
                                if (gameBoard[destination.row, destination.column].IsOccupied == true)
                                {
                                    moveSuccess = true;
                                }
                            }

                        }

                        else //if the pawn is black 

                        {



                            if (signVector.row == 1 && signVector.column == 0) //check if the difference for row is 1 (the expected value for black pawns) and the column difference is zero meaning the pawn is moving one square in front of itself 

                            {

                                if (gameBoard[destination.row, destination.column].IsOccupied == false) //check that tile the pawn is moving to is not occupied 

                                {

                                    moveSuccess = true; //set move success flag to true 
                                }

                            }

                            else if (signVector.row == 2 && signVector.column == 0) //check for if the black pawn is trying to move 2 squares ahead (no difference in column as pawns cant move horizontally) 

                            {

                                if (gameBoard[destination.row, destination.column].IsOccupied == false && gameBoard[destination.row - 1, destination.column].IsOccupied == false) //check the tile in front of the pawn (behind the destination tile) and the destination tile are both unoccupied 

                                {

                                    if (piece.hasMoved == false) //check that the pawn has not moved before because the pawn can only move 2 squares on its first move 

                                    {


                                        moveSuccess = true; //set move success flag to true 
                                    }

                                }

                            }
                            else if (signVector.row == 1 && signVector.column == -1) //if the black pawn is trying to capture a piece to its bottom left. This only works if there is a piece here as this move is for capturing pieces
                            {
                                if (gameBoard[destination.row, destination.column].IsOccupied == true)
                                {
                                    moveSuccess = true;
                                }
                            }
                            else if (signVector.row == 1 && signVector.column == 1) //if the black pawn is trying to capture a piece to its bottom right. This only works if there is a piece here as this move is for caputring pieces
                            {
                                if (gameBoard[destination.row, destination.column].IsOccupied == true)
                                {
                                    moveSuccess = true;
                                }
                            }

                        }

                    }
                    else if (piece.PieceType == PieceTypes.bishop || piece.PieceType == PieceTypes.queen || piece.PieceType == PieceTypes.rook || piece.PieceType == PieceTypes.king)
                    {
                        bool isDestinationThisMove = false; //flag to check if the current offset in the iteration is the same offset the destination lies in **
                        foreach (var move in possibleMoves) //loop through every offset returned by the pieces moves function
                        {
                            int index = 0; //a placeholder variable to give the multiplier needed to be placed on the offset to get the destination position
                            for (int i = 1; i < 9; i++) //loop 1 thorugh 8 and multiply the offset by the i variable
                            {

                                if (((destination.row - piece.Position.row) == (move.row * i)) && (destination.column - piece.Position.column) == (move.column * i)) //check if the displacement vector of the position to destination matches the pieces offset multiplied by some constant
                                {
                                    index = i; //if the displacement vector matches the current offset multiplied by some number update the index variable to store the number/multiplier
                                    isDestinationThisMove = true; //update the flag to say this offset is the one which contains the destination position
                                    break;


                                }
                            }

                            if (isDestinationThisMove == true) //if the destination position is contained in this current offset
                            {
                                bool tileBlocked = false; //flag to check that a tile on the path from a piece position to its destination is not blocked
                                                          //while (piece.Position.row <= destination.row && piece.Position.column <= destination.column)
                                {
                                    for (int i = 1; i <= index; i++) //loop through from 1 to the multiplier (this is to check the tiles in between the destination tile and piece position tile)
                                    {
                                        if (piece.PieceType == PieceTypes.king) //the king can only move one square in any direction, this avoids the king being allowed the same movement pattern as the queen
                                        {
                                            if (index > 1) break;
                                        }
                                        if (gameBoard[piece.Position.row + (move.row * i), piece.Position.column + (move.column * i)].IsOccupied == false)// multiply the offset by i then add this to the pieces current position adn check if any tiles along this path are occupied
                                        {
                                            if (!tileBlocked) //Only allow the tile blocked flag to be set to false if it hasnt previously been set to true. This prevents a tile being blocked, then a tile after that being free making this flag be set to false
                                            {
                                                tileBlocked = false; //set the flag to false as no tiles along the path are occuppied
                                            }
                                        }
                                        else //if a tile along the path is occuppied
                                        {

                                            tileBlocked = true; //set the flag to true to indicate that a tile along this path is blocked 
                                        }

                                        if (index == 1) //check if the piece is trying to move only one square - this is for capturing a piece
                                        {
                                            if (i == 1) //now check if its on its first iteration
                                            {
                                                if (gameBoard[destination.row, destination.column].IsOccupied == true) //check if we are taking a piece - this mean we would have checked every tile in between the start position and the end position and now we are manually checking the end position
                                                {
                                                    //**
                                                    moveSuccess = true;
                                                    break;
                                                }
                                            }
                                        }
                                        else //if the piece is trying to move more than one square - this is for capturing a piece
                                        {
                                            if (i == index - 1) //check if we have gone through every tile in between the pieces position and destination
                                            {
                                                if (gameBoard[piece.Position.row + (move.row * i), piece.Position.column + (move.column * i)].IsOccupied == false)
                                                {
                                                    if (!tileBlocked)
                                                    {
                                                        if (gameBoard[destination.row, destination.column].IsOccupied == true) //check if we are taking a piece - this measn we would have checked every tile in between the start position and the end position and now we are manually checking the end position
                                                        {
                                                            moveSuccess = true;
                                                            break;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        if (i == index) //check if this current iteration is the interation which would give us the pieces destination - this is not for capturing a piece so we go all the way to the destination as we are expecting this tile to not be occupied
                                        {

                                            if (tileBlocked == false) //check that no tiles along the path were blocked
                                            {
                                                moveSuccess = true; //if no tiles are occuppied then allow the piece to move and set the move success flag to true
                                            } //we dont have an else as we dont allow a move under any circumstances if a tile was occuppied along the path

                                        }
                                    }
                                }
                            }
                            if (moveSuccess)
                            {

                                break;
                            }

                        }
                    }
                    else //The final piece type is the knight which has a unique movement system
                    {
                        foreach (var move in possibleMoves)
                        {
                            bool isDestinationThisMove = false; //flag to check if the current offset in the iteration is the same offset the destination lies in
                            if ((destination.row - piece.Position.row) == move.row && (destination.column - piece.Position.column) == move.column) //check if the move is valid by checking if the move is possible via the offstets for the knight
                            {
                                isDestinationThisMove = true; //if the displacement vector matches the current offset then set the flag to true
                            }

                            if (isDestinationThisMove)
                            {
                                if (gameBoard[destination.row, destination.column].IsOccupied == false)
                                {
                                    moveSuccess = true; //if the destination tile is not occupied allow the move
                                }
                                else
                                {
                                    moveSuccess = true; //if the destination tile is occuppied and the knight can capture it allow the move
                                }
                            }
                        }

                    }
                }
            if (moveSuccess) //if any piece can legally move to the position then there is no need to check other pieces as this tells us that position is check 
            {
                checkingPieces.Add(piece); //if the move is successful then the piece whihc is doing the checking is this current piece
                isTrue = true;
                moveSuccess = false;
                break;
            }
        }
        if (destination != player.playerKing.Position) //check if the king is not moveing to teh same position it was already in
        {
            if (isMoveLegal(player.playerKing, destination).moveSuccess) //check if the king moving to this position is possible
            {
                return (checkingPieces, isTrue);
            }
            else //if the king cant move to this position then the king would have to stay in its old position  and state
            {
                isTrue = true;
                 //change position to destination
                return (checkingPieces, isTrue);
            }
        }
        
            return (checkingPieces, isTrue);
        
        
    }
    
    /*public bool checkForCheck((int row, int column) possiblePosition, Player player, bool isCheckingForEscapingCheck)
    {
        //isPlayerinCheck = false;
        itemColor playerColour = player.color; //get the colour of the player

        if (playerColour == itemColor.black) //if the player is black
        {
            if (!isCheckingForEscapingCheck) // if not checking for whether the player can escape check use the kings current position which would be stored in the player.playerKing field, instead of using the possiblePosition parameter value which would be used if we wanted to see if the psoition that a king may possibly move to would still lead to the king being in check
            {
                for (int row = 0; row < 8; row++) //outer loop for rows  
                {

                    for (int column = 0; column < 8; column++) //inner loop for columns  
                    {
                        if (Pieces[row][column] != null) //check that the value in the pieces list we are trying to compare is not null
                        {
                            if (Pieces[row][column].Color == itemColor.white) //only select pieces from the pieces list that are white - opposite colour to black - to check if these pieces can capture black
                            {

                                MakeMove(Pieces[row][column], player.playerKing.Position, true, false); //try make all possible white pieces capture the black king
                                if (isPlayerinCheck) //check if the flag which signals when a plaer is in check has been set off
                                {

                                    isPlayerinCheck = false; //reset the flag
                                    return true; //return true - this would be captured by a players check variable - would mean that the black player, player 2 is in check

                                }



                            }

                        }

                    }
                }
            }
            else // if checking for whether the player can escape check use the possiblePosition parameter value which would be used if we wanted to see if the psoition that a king may possibly move to would still lead to the king being in check - check that this position would elad to the king escaping check
            {
                for (int row = 0; row < 8; row++) //outer loop for rows  
                {
                    for (int column = 0; column < 8; column++) //inner loop for columns  
                    {
                        if (Pieces[row][column] != null) //check that the value in the pieces list we are trying to compare is not null
                        {
                            if (Pieces[row][column].Color == itemColor.white) //only select pieces from the pieces list that are white - opposite colour to black - to check if these pieces can capture black
                            {
                                MakeMove(Pieces[row][column], possiblePosition, true, true); //try make all possible white pieces capture the black king
                                if (isMoveEscapedCheck) //check if the flag which signals when a plaer is in check has been set off
                                {

                                isMoveEscapedCheck = false; //reset the flag
                                return true; //return true - this would be captured by a players check variable - would mean that the black player, player 2 is in check if moving to a certain position

                                }
                                else
                                {

                                return false; //return false - this would be captured by a players check variable - would mean that the black player, player 2 is not in check if moving to a certain position
                                }
                            }
                        }
                    }
                }
                
            }
        }
        else //if not black - white
        {
         

            if (!isCheckingForEscapingCheck) // if not checking for whether the player can escape check use the kings current position which would be stored in the player.playerKing field, instead of using the possiblePosition parameter value which would be used if we wanted to see if the psoition that a king may possibly move to would still lead to the king being in check
            { 
                for (int row = 0; row < 8; row++) //outer loop for rows  
                {

                    for (int column = 0; column < 8; column++) //inner loop for columns  
                    {
                        if (Pieces[row][column] != null) //check that the piece in the pieces list we are trying to access is not null
                        {
                            if (Pieces[row][column].Color == itemColor.black) //only select pieces from the pieces list that are black - opposite colour to white - to check if these pieces can capture white
                            {

                                MakeMove(Pieces[row][column], player.playerKing.Position, true, false); //try make all possible black pieces capture the white king
                                if (isPlayerinCheck) //check if the flag which signals when a plaer is in check has been set off
                                {

                                    isPlayerinCheck = false; //reset the flag
                                    return true; //return true - this would be captured by a players check variable - would mean that the black player, player 2 is in check

                                }
                            }


                        }

                    }

                }
                
            }
            else // if checking for whether the player can escape check use the possiblePosition parameter value which would be used if we wanted to see if the psoition that a king may possibly move to would still lead to the king being in check - check that this position would elad to the king escaping check
            {
                for (int row = 0; row < 8; row++) //outer loop for rows  
                {

                    for (int column = 0; column < 8; column++) //inner loop for columns  
                    {
                        if (Pieces[row][column] != null) //check that the piece in the pieces list we are trying to access is not null
                        {
                            if (Pieces[row][column].Color == itemColor.black) //only select pieces from the pieces list that are black - opposite colour to white - to check if these pieces can capture white
                            {
                                MakeMove(Pieces[row][column], possiblePosition, true, true); //try make all possible white pieces capture the black king
                                if (isMoveEscapedCheck) //check if the flag which signals when a plaer is in check has been set off
                                {

                                isMoveEscapedCheck = false; //reset the flag
                                return true; //return true - this would be captured by a players check variable - would mean that the white player, player 1 is in check if moving to a certain position

                                }
                                else
                                {

                                return false; //return false - this would be captured by a players check variable - would mean that the white player, player 1 is in check if moving to a certain position
                                }
                            }
                        }
                    }
                }
                
            }

        }
        return false; //if no pieces of the opposite colour can capture the given players king return false - this would mean the player is not in check
        
    }*/


    private void timer_Tick(object sender, EventArgs e)
    {
        
        

        if (playerTurnCounter % 2 == 0) //if the counter is even its whites turn - 0 is the first psoitive even number so white always goes first
        {
            playerTurn = itemColor.white;
        }
        else //if the counter is odd its blacks turn - odd numbers always come after an even number
        {
            playerTurn = itemColor.black;
        }

        TimeSpan oneSecond = new TimeSpan(0, 0, 1); //variable just used so we can subtract a second
        TimeSpan zeroSeconds = new TimeSpan(0, 0, 0); //variable used so we can convert 0 minutes and seconds into a time span

        if ((player1.timeRemaining > zeroSeconds) && (player2.timeRemaining > zeroSeconds)) //check if each player has above 0 seconds left if so continue as normal and subtract a second each
        {
            if (playerTurn == itemColor.white) //white is player 1
            {
                player1.timeRemaining = player1.timeRemaining.Subtract(oneSecond);
            }
            else //black is player 2
            {
                player2.timeRemaining = player2.timeRemaining.Subtract(oneSecond);
            }
        }
        else //if not whoever ran out of time set there timeout to true
        {
            if (player1.timeRemaining <= zeroSeconds)
            {
                player1.playerTimeout = true; //set this player to have timed out
                Winner = player2; //set the winner to the other player (black)
                endCondition = EndCondition.Timeout; //set the end condition to time out
                isGameEnd = true; //set the game to have ended
            }
            else if (player2.timeRemaining <= zeroSeconds)
            {
                player2.playerTimeout = true;
                Winner = player1; //set the winner to the other player (white)
                endCondition = EndCondition.Timeout; //set the end condition to time out
                isGameEnd = true; //set the game to have ended
            }
        }

        

    }


}








