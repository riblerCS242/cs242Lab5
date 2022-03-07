using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashLib
{
    public class ZobristChessHash
    {
        SquareToIndexMap _sqToIndex = new();
        PieceToIdMap _pieceToIndex = new();

        const int nSquares = 64;
        const int nPieces = 13;

        // 64-bit Ids for every square-piece combination
        private ulong[,] PieceSquareId = new ulong[nSquares, 13];

        // Current value of the hash
        public ulong Hash { get; private set; }


        public ZobristChessHash(int RANDOM_SEED)
        {
            // Create a random number generator.
            // For every piece-square combination
            //   use GetRandomLong() to put a 64-bit random number
            //   in PieceSquareId.  You will have to write GetRandomLong()


            // make a 2D array that has all possible moves
            for (int i = 0; i < 64; i++)
            {
                for (int j = 0; j < 13; j++)
                    PieceSquareId[i, j] = GetRandomULong();
            }

            // Set the initial random hash to 0
            // Then generate the hash for a clear board by
            // placing an empty square on every square.
        }

        private Random random;

        private ulong GetRandomULong()
        {
            throw new NotImplementedException();
        }

        // board[square][piece]

        // Keep track of the id of every piece on the board.
        private int[] Board = new int[64];

        public ulong PlacePiece(char piece, string square)
        {
            // remove what is there
            // place the piece
            // Update Board[] with the index of the piece
            // Return the new Hash value
            throw new NotImplementedException();
            return Hash;
        }

        public ulong MovePiece(char piece, string location, string destination)
        {
            // lift the piece off the board
            // put a no piece where it was
            // remove the piece that is at the destination
            // place the piece at that location
            // update the board array
            // return the Hash
            throw new NotImplementedException();
            return Hash;
        }

        public ulong MovePiece(int location, int destination)
        {
            // lift the piece off the board
            // put a no piece where it was
            // remove the piece that is at the destination
            // place the piece at that location
            // update the board array

            throw new NotImplementedException();
            return Hash;
        }

        public void ClearBoard()
        {
            throw new NotImplementedException();

            // Reset the Hash to 0
            // Place an empty square in all 
            // 64 squares.
            
        }

        public ulong SetupPieces()
        {
            ClearBoard();

            // Place the white pawns
            PlacePiece('P', "a2");
            PlacePiece('P', "b2");
            PlacePiece('P', "c2");
            PlacePiece('P', "d2");
            PlacePiece('P', "e2");
            PlacePiece('P', "f2");
            PlacePiece('P', "g2");
            PlacePiece('P', "h2");

            // Place the black pawns
            PlacePiece('p', "a7");
            PlacePiece('p', "b7");
            PlacePiece('p', "c7");
            PlacePiece('p', "d7");
            PlacePiece('p', "e7");
            PlacePiece('p', "f7");
            PlacePiece('p', "g7");
            PlacePiece('p', "h7");

            // Place the Rooks
            PlacePiece('R', "a1");
            PlacePiece('R', "h1");
            PlacePiece('r', "a8");
            PlacePiece('r', "h8");

            // Place the Knights
            PlacePiece('N', "b1");
            PlacePiece('N', "g1");
            PlacePiece('n', "b8");
            PlacePiece('n', "g8");

            // Place the Bishops
            PlacePiece('B', "c1");
            PlacePiece('B', "f1");
            PlacePiece('b', "c8");
            PlacePiece('b', "f8");

            // Place the Queens
            PlacePiece('Q', "d1");
            PlacePiece('q', "d8");

            // Place the Kings
            PlacePiece('K', "e1");
            PlacePiece('k', "e8");

            return Hash;
        }

        private string GetFEN(int pieceIndex)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(_pieceToIndex[pieceIndex]);
            return builder.ToString(); ;
        }

        public string GetPositionInFEN()
        {
            return GetPositionInFEN(true, true, true,
                true, true, null, 1, 1);
        }

        public string GetPositionInFEN(bool isWhitesMove,
                bool whiteCanCastleKingSide,
                bool whiteCanCastleQueenSide,
                bool blackCanCastleKingSide,
                bool blackCanCastleQueenside,
                string enPassantSquare,
                int halfMoveClock,
                int fullMoveNumber)
        {
            string boardPosition = "";
            int emptyCounter = 0;
            // read the row
            for (int row = 7; row >= 0; row--)
            {
                // read the column
                for (int col = 0; col < 8; col++)
                {
                    if (Board[row * 8 + col] == 0)
                        ++emptyCounter;
                    else
                    {
                        if (emptyCounter > 0)
                        {
                            boardPosition += emptyCounter.ToString();
                            emptyCounter = 0;
                        }
                        boardPosition += GetFEN(Board[row * 8 + col]);
                    }
                }
                if (emptyCounter > 0)
                    boardPosition += emptyCounter.ToString();
                if (row != 0)
                    boardPosition += "/";
                emptyCounter = 0;
            }

            // game specifics
            boardPosition += " ";
            if (isWhitesMove)
                boardPosition += "w";
            else
                boardPosition += "b";
            boardPosition += " ";

            if (!whiteCanCastleKingSide && !whiteCanCastleQueenSide &&
                !blackCanCastleKingSide && !blackCanCastleQueenside)
                boardPosition += "-";
            else
            {
                if (whiteCanCastleKingSide)
                    boardPosition += "K";
                if (whiteCanCastleQueenSide)
                    boardPosition += "Q";
                if (blackCanCastleKingSide)
                    boardPosition += "k";
                if (blackCanCastleQueenside)
                    boardPosition += "q";
            }
            boardPosition += " ";
            if (enPassantSquare == null)
                boardPosition += "-";
            else
                boardPosition += enPassantSquare;
            boardPosition += " ";
            boardPosition += halfMoveClock.ToString();
            boardPosition += " ";
            boardPosition += fullMoveNumber.ToString();

            return boardPosition;
        }
    }
}
