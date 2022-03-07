using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace HashLib
{
    public class GameReader
    {
        SquareToIndexMap _squareToIndex = new SquareToIndexMap();

        public enum GameResult
        {
            WhiteWins, BlackWins, Draw, InProgress,
            NoResult
        };

        public GameReader(string filename)
        {
            IsWhitesMove = true;
            IsCastling = false;
            reader = new StreamReader(filename);
        }

        string GetNextMove(out bool endOfFile)
        {
            string move = null;
            endOfFile = false;
            if (!IsCastling)
            {
                if (moveQueue.Count > 0)
                {
                    move = moveQueue.Dequeue();
                }
                else
                {
                    while (moveQueue.Count == 0 && !reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string sDelimiters = " \t";
                        char[] delimiters = sDelimiters.ToCharArray();
                        string[] moves =
                            line.Split(delimiters,
                            StringSplitOptions.RemoveEmptyEntries);
                        foreach (string singleMove in moves)
                        {
                            moveQueue.Enqueue(singleMove);
                        }
                    }

                    if (moveQueue.Count != 0)
                    {
                        move = moveQueue.Dequeue();
                    }

                    endOfFile = (moveQueue.Count == 0);
                }
            }
            else
            {
                move = secondCastlingMove;
                IsCastling = false;
            }

            return move;
        }

        bool parseMove(string theString, out int source, out int destination)
        {
            throw new NotImplementedException();
            //const int MIN_MOVE_LENGTH = 5;
            //source = 0;
            //destination = 0;

            //// If it is a move with a dash
            //bool parses = (theString.Length >= MIN_MOVE_LENGTH &&
            //    theString[0] >= 'a' && theString[0] <= 'h' &&
            //    theString[1] >= '1' && theString[1] <= '8' &&
            //    theString[2] == '-' &&
            //    theString[3] >= 'a' && theString[3] <= 'h' &&
            //    theString[4] >= '1' && theString[4] <= '8');

            //if (parses)
            //{
            //    source = _squareToIndex[theString.Substring(0, 2)];
            //    destination = _squareToIndex[theString.Substring(3, 2)];
            //}
            //else
            //{
            //    // If it is a move without a dash
            //    parses = theString[0] >= 'a' && theString[0] <= 'h' &&
            //        theString[1] >= '1' && theString[1] <= '8' &&
            //        theString[2] >= 'a' && theString[2] <= 'h' &&
            //        theString[3] >= '1' && theString[3] <= '8';

            //    if (parses)
            //    {
            //        source = _squareToIndex[theString.Substring(0, 2)];
            //        destination = _squareToIndex[theString.Substring(2, 2)];
            //    }
            //}
            //return parses;
        }

        bool parseResult(string theString, out GameResult result)
        {
            result = GameResult.Draw;
            const int MIN_RESULT_LENGTH = 3;
            bool parses = true;
            if (theString.Length >= MIN_RESULT_LENGTH)
            {
                if (theString[0] == '0')
                {
                    result = GameResult.BlackWins;
                }
                else
                {
                    if (theString[0] == '1')
                    {
                        if (theString[1] == '-')
                            result = GameResult.WhiteWins;
                        else
                            result = GameResult.Draw;
                    }
                    else
                    {
                        parses = false;
                    }
                }
                WhiteCanCastle = true;
                BlackCanCastle = true;
            }
            return parses;
        }

        void assert(bool condition)
        {
            if (!condition)
            {
                throw new ApplicationException("Assertion failed.");
            }
        }



        void checkBlackCastle(ref int sourceSquare, ref int destinationSquare)
        {
            throw new NotImplementedException();
            //if (BlackCanCastle)
            //{
            //    int blackKingSquare = _squareToIndex["e8"];
            //    if (sourceSquare == blackKingSquare)
            //    {
            //        // Black is moving the king - can no longer castle.
            //        BlackCanCastle = false;

            //        int kingSideDestination = _squareToIndex["g8"];
            //        if (destinationSquare == kingSideDestination)
            //        {
            //            // Start castling king-side
            //            IsCastling = true;
            //            castlingSourceSquare = _squareToIndex["h8"];
            //            castlingDestinationSquare =
            //                _squareToIndex["f8"];
            //            secondCastlingMove = "e8-g8";
            //            IsWhitesMove = !IsWhitesMove;
            //        }

            //        int queenSideDestination = _squareToIndex["c8"];
            //        if (destinationSquare == queenSideDestination)
            //        {
            //            // Start castling queen-side
            //            IsCastling = true;
            //            castlingSourceSquare = _squareToIndex["a8"];
            //            castlingDestinationSquare = _squareToIndex["d8"];
            //            secondCastlingMove = "e8-c8";
            //            IsWhitesMove = !IsWhitesMove;
            //        }
            //    }
            //}
        }

        void checkWhiteCastle(ref int sourceSquare, ref int destinationSquare)
        {
            throw new NotImplementedException();
            //if (WhiteCanCastle)
            //{
            //    int whiteKingSquare = _squareToIndex["e1"];
            //    if (sourceSquare == whiteKingSquare)
            //    {
            //        // White is moving the king - can no longer castle.
            //        WhiteCanCastle = false;

            //        int kingSideDestination = _squareToIndex["g1"];
            //        if (destinationSquare == kingSideDestination)
            //        {
            //            // Start castling king-side
            //            IsCastling = true;
            //            castlingSourceSquare = _squareToIndex["h1"];
            //            castlingDestinationSquare = _squareToIndex["f1"];
            //            IsWhitesMove = !IsWhitesMove;
            //        }

            //        int queenSideDestination = _squareToIndex["c1"];
            //        if (destinationSquare == queenSideDestination)
            //        {
            //            // Start castling queen-side
            //            IsCastling = true;
            //            castlingSourceSquare = _squareToIndex["a1"];
            //            castlingDestinationSquare = _squareToIndex["d1"];
            //            IsWhitesMove = !IsWhitesMove;
            //        }
            //    }
            //}
        }

        public bool read(out int sourceSquare, out int destinationSquare,
                    out GameResult gameProgress)
        {
            throw new NotImplementedException();
            //bool parses = true;
            //sourceSquare = 0;
            //destinationSquare = 0;
            //gameProgress = GameResult.InProgress;

            //if (IsCastling)
            //{
            //    sourceSquare = castlingSourceSquare;
            //    destinationSquare = castlingDestinationSquare;
            //    IsCastling = false;
            //}
            //else
            //{
            //    try
            //    {
            //        if (moveQueue.Count > 0 || !reader.EndOfStream)
            //        {
            //            gameProgress = GameResult.InProgress;
            //            bool endOfFile;
            //            string move = GetNextMove(out endOfFile);
            //            if (!parseMove(move, out sourceSquare, out destinationSquare))
            //            {
            //                if (!parseResult(move, out gameProgress))
            //                {
            //                    parses = false;
            //                }
            //            }
            //            else
            //            {
            //                // parsed a move 
            //                assert(sourceSquare >= 0 && sourceSquare < 64);
            //                assert(destinationSquare >= 0 && destinationSquare < 64);

            //                if (IsWhitesMove)
            //                {
            //                    checkWhiteCastle(ref sourceSquare, ref destinationSquare);
            //                }
            //                else
            //                {
            //                    checkBlackCastle(ref sourceSquare, ref destinationSquare);
            //                }
            //            }
            //        }
            //        else
            //        {
            //            gameProgress = GameResult.NoResult;
            //            parses = false;
            //        }
            //    }
            //    catch (System.ApplicationException)
            //    {
            //        gameProgress = GameResult.NoResult;
            //        parses = false;
            //    }
            //}
            //IsWhitesMove = !IsWhitesMove;
            //return parses;
        }

        private Queue<string> moveQueue = new Queue<string>();
        private StreamReader reader;
        public int castlingSourceSquare;
        public int castlingDestinationSquare;
        public string secondCastlingMove;
        public bool IsWhitesMove { get; private set; } = true;
        public bool IsCastling { get; private set; } = false;
        public bool BlackCanCastle { get; private set; } = true;
        public bool WhiteCanCastle { get; private set; } = true;
    }
}
