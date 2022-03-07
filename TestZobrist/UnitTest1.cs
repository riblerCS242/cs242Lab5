using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
// Copy your HashWithLinearProbe.cs file from your previous project to this
// directory and add it to the HashLib project.
// You will need to update your implementation to comply with the new
// ISymbolTable used in this lab.  Specifically, keys in the new implementation
// must support IEquatable rather than IComparable.  This is because
// ISymbolTable for binary trees required that we be able to determine if
// one key is larger or smaller than another, but ISymbolTable for hash tables
// requires only that we can tell whether two keys are equal.

using HashLib;

// Files for some tests are provided in a zip file that
// will be made available in class.
// You should unzip this file and place all the resulting files
// in your home directory in a subdirectory called "cs242/lab5"

namespace UnitTest1
{
    [TestClass]
    public class ZobristTestClass
    {
        readonly string labDir = "/cs242/lab5";
        string userProfileDir = Environment.GetEnvironmentVariable("USERPROFILE");

        string GetFile(string filename)
        {
            return userProfileDir + labDir + "/" + filename;
        }

        // Write the class PieceToIdMap so that we can easily map 
        // piece names to unique id numbers.  This class must be implemented
        // using two instances of your HashWithLinearProbe class.
        // One instance will provide the id given the character name as a key.
        // The other instance will provide the character name given the id key.
        [TestMethod]
        public void T01_PieceIndexTest()
        {
            PieceToIdMap pieceToId = new();

            // Given a single character piece abbreviation and a boolean
            // variable (true if the request is for a white piece, false if
            // the request is for a black piece) return a number 0-13

            Assert.AreEqual(PieceToIdMap.WHITE_PAWN, pieceToId['P']);
            Assert.AreEqual(PieceToIdMap.WHITE_KNIGHT, pieceToId['N']);
            Assert.AreEqual(PieceToIdMap.WHITE_BISHOP, pieceToId['B']);
            Assert.AreEqual(PieceToIdMap.WHITE_ROOK, pieceToId['R']);
            Assert.AreEqual(PieceToIdMap.WHITE_QUEEN, pieceToId['Q']);
            Assert.AreEqual(PieceToIdMap.WHITE_KING, pieceToId['K']);

            Assert.AreEqual(PieceToIdMap.BLACK_PAWN, pieceToId['p']);
            Assert.AreEqual(PieceToIdMap.BLACK_KNIGHT, pieceToId['n']);
            Assert.AreEqual(PieceToIdMap.BLACK_BISHOP, pieceToId['b']);
            Assert.AreEqual(PieceToIdMap.BLACK_ROOK, pieceToId['r']);
            Assert.AreEqual(PieceToIdMap.BLACK_QUEEN, pieceToId['q']);
            Assert.AreEqual(PieceToIdMap.BLACK_KING, pieceToId['k']);

            Assert.AreEqual(PieceToIdMap.NO_PIECE, pieceToId[' ']);

            Assert.AreEqual('P', pieceToId[PieceToIdMap.WHITE_PAWN]);
            Assert.AreEqual('N', pieceToId[PieceToIdMap.WHITE_KNIGHT]);
            Assert.AreEqual('B', pieceToId[PieceToIdMap.WHITE_BISHOP]);
            Assert.AreEqual('R', pieceToId[PieceToIdMap.WHITE_ROOK]);
            Assert.AreEqual('Q', pieceToId[PieceToIdMap.WHITE_QUEEN]);
            Assert.AreEqual('K', pieceToId[PieceToIdMap.WHITE_KING]);

            Assert.AreEqual('p', pieceToId[PieceToIdMap.BLACK_PAWN]);
            Assert.AreEqual('n', pieceToId[PieceToIdMap.BLACK_KNIGHT]);
            Assert.AreEqual('b', pieceToId[PieceToIdMap.BLACK_BISHOP]);
            Assert.AreEqual('r', pieceToId[PieceToIdMap.BLACK_ROOK]);
            Assert.AreEqual('q', pieceToId[PieceToIdMap.BLACK_QUEEN]);
            Assert.AreEqual('k', pieceToId[PieceToIdMap.BLACK_KING]);

            Assert.AreEqual(' ', pieceToId[PieceToIdMap.NO_PIECE]);
        }

        // Write the SquareToIndexMap class to map between square names
        // and unique indexes.  This class will be implemented very
        // much like the PieceToIdMap class.
        [TestMethod]
        public void T02_getSquareIndexTest()
        {
            SquareToIndexMap sqToIndex = new();

            //// Try to use the string to compute the integer, rather
            //// than just having a large switch.  Or use a SymbolTable!
            //Assert.AreEqual(0, sqToIndex["a1"]);
            //Assert.AreEqual(1, sqToIndex["b1"]);
            //Assert.AreEqual(2, sqToIndex["c1"]);
            //Assert.AreEqual(3, sqToIndex["d1"]);
            //Assert.AreEqual(4, sqToIndex["e1"]);
            //Assert.AreEqual(5, sqToIndex["f1"]);
            //Assert.AreEqual(6, sqToIndex["g1"]);
            //Assert.AreEqual(7, sqToIndex["h1"]);

            //Assert.AreEqual(56, sqToIndex["a8"]);
            //Assert.AreEqual(57, sqToIndex["b8"]);
            //Assert.AreEqual(58, sqToIndex["c8"]);
            //Assert.AreEqual(59, sqToIndex["d8"]);
            //Assert.AreEqual(60, sqToIndex["e8"]);
            //Assert.AreEqual(61, sqToIndex["f8"]);
            //Assert.AreEqual(62, sqToIndex["g8"]);
            //Assert.AreEqual(63, sqToIndex["h8"]);
        }

        // Start writing the ZobristChessHash class.  The constructor
        // takes a seed for a random number generator.
        // The ClearBoard function should be called in the constructor.
        // ClearBoard() should start with a 0 hash value and then place
        // a NO_PIECE on every square.
        [TestMethod]
        public void T03_clearBoard()
        {
            ZobristChessHash zobrist = new ZobristChessHash(24154231);

            ulong hash = zobrist.Hash;

            zobrist.ClearBoard();

            Assert.AreEqual(hash, zobrist.Hash);
        }

        // Write the PlacePiece() function that takes a piece name and
        // a square name, and places a piece on that square.
        // Don't forget to remove what is already there. (including NO_PIECE)
        [TestMethod]
        public void T04_placePieceTest()
        {
            ZobristChessHash zobrist = new ZobristChessHash(12345321);
            ulong oldHash = zobrist.Hash;
            ulong newHash = zobrist.PlacePiece('N', "f3");
            Assert.AreNotEqual(oldHash, newHash);

            ulong restoreHash = zobrist.PlacePiece(' ', "f3");
            Assert.AreEqual(restoreHash, oldHash);
        }


        [TestMethod]
        public void T05_setupBoard()
        {
            ZobristChessHash zobrist = new ZobristChessHash(25151231);

            // SetupPieces is already written for you using PlacePiece()
            // and ClearBoard().  You just need to uncomment it.
            ulong setupHash = zobrist.SetupPieces();
            ulong secondHash = zobrist.SetupPieces();
            Assert.IsTrue(setupHash == secondHash);
        }

        [TestMethod]
        public void T06_moveTest()
        {
            // To move a piece you must remove the piece from its current
            // square, remove whatever is currently on the destination square
            // (even if it is empty), place a NO_PIECE on the newly vacated
            // square, and place the moving piece on the destination square.
            ZobristChessHash zobrist = new ZobristChessHash(32423451);
            zobrist.SetupPieces();
            zobrist.MovePiece('P', "e2", "e4");
            zobrist.MovePiece('p', "e7", "e5");
            zobrist.MovePiece('N', "g1", "f3");
            zobrist.MovePiece('n', "b8", "c6");
            zobrist.MovePiece('B', "f1", "c4");

            ZobristChessHash moveOrder = new ZobristChessHash(32423451);
            moveOrder.SetupPieces();
            moveOrder.MovePiece('N', "g1", "f3");
            moveOrder.MovePiece('n', "b8", "c6");
            moveOrder.MovePiece('P', "e2", "e4");
            moveOrder.MovePiece('B', "f1", "c4");
            moveOrder.MovePiece('p', "e7", "e5");

            Assert.AreEqual(zobrist.Hash, moveOrder.Hash);
            string FEN = zobrist.GetPositionInFEN();
            Assert.AreEqual(zobrist.GetPositionInFEN(), moveOrder.GetPositionInFEN());
        }

        // [TestMethod]
        //public void T07_moveTestWithSquareNumbers()
        //{
        //    SquareToIndexMap sqToIndex = new SquareToIndexMap();

        //    ZobristChessHash zobrist = new ZobristChessHash(24234131);
        //    zobrist.SetupPieces();

        //    ZobristChessHash justSquares = new ZobristChessHash(24234131);
        //    justSquares.SetupPieces();

        //    // get the square numbers for the move
        //    int sourceSquare = sqToIndex["e2"];
        //    int destinationSquare = sqToIndex["e4"];
        //    justSquares.MovePiece(sourceSquare, destinationSquare);
        //    zobrist.MovePiece('P', "e2", "e4");
        //    Assert.AreEqual(zobrist.Hash, justSquares.Hash);


        //    sourceSquare = sqToIndex["e7"];
        //    destinationSquare = sqToIndex["e5"];
        //    justSquares.MovePiece(sourceSquare, destinationSquare);
        //    zobrist.MovePiece('p', "e7", "e5");
        //    Assert.AreEqual(zobrist.Hash, justSquares.Hash);

        //    sourceSquare = sqToIndex["g1"];
        //    destinationSquare = sqToIndex["f3"];
        //    justSquares.MovePiece(sourceSquare, destinationSquare);
        //    zobrist.MovePiece('N', "g1", "f3");
        //    Assert.AreEqual(zobrist.Hash, justSquares.Hash);

        //    sourceSquare = sqToIndex["b8"];
        //    destinationSquare = sqToIndex["c6"];
        //    justSquares.MovePiece(sourceSquare, destinationSquare);
        //    zobrist.MovePiece('n', "b8", "c6");
        //    Assert.AreEqual(zobrist.Hash, justSquares.Hash);

        //    ZobristChessHash moveOrder = new ZobristChessHash(24234131);
        //    moveOrder.SetupPieces();
        //    moveOrder.MovePiece('N', "g1", "f3");
        //    moveOrder.MovePiece('n', "b8", "c6");
        //    moveOrder.MovePiece('P', "e2", "e4");
        //    moveOrder.MovePiece('p', "e7", "e5");

        //    Assert.AreEqual(zobrist.Hash, moveOrder.Hash);
        //    Assert.AreEqual(justSquares.Hash, moveOrder.Hash);
        //}


        // The GameReader class is already written for you, but you must
        // provide the ZobristChessHash function and the mapping classes
        // for it to work properly.  This tests that classes work together.
        [Ignore]
        [TestMethod]
        public void T08_gameReaderSimpleTest()
        {
            // I have implemented the GameReader class for you.
            GameReader gameReader = new GameReader(GetFile("cs242-oneGame.pgn"));
            int sourceSquare;
            int destinationSquare;
            GameReader.GameResult gameProgress;

            bool isWhitesMove = true;
            int plyNumber = 0;
            int castles = 0;

            do
            {
                Assert.AreEqual(isWhitesMove, gameReader.IsWhitesMove);

                gameReader.read(out sourceSquare, out destinationSquare,
                    out gameProgress);

                if (!gameReader.IsCastling)
                {
                    isWhitesMove = !isWhitesMove;
                    if (gameProgress == GameReader.GameResult.InProgress)
                        ++plyNumber;
                }
                else
                {
                    ++castles;
                }

            } while (gameProgress == GameReader.GameResult.InProgress);

            Assert.AreEqual((int)GameReader.GameResult.WhiteWins,
                (int)gameProgress);

            Assert.AreEqual(2, castles);
            Assert.AreEqual(41, plyNumber);
        }

        [Ignore]
        [TestMethod]
        public void T09_gameReaderNoMoves()
        {
            GameReader gameReader = new GameReader(GetFile("cs242-noMoves.pgn"));
            int sourceSquare;
            int destinationSquare;
            GameReader.GameResult gameProgress;

            bool isWhitesMove = true;
            int plyNumber = 0;
            int castles = 0;

            do
            {
                Assert.AreEqual(isWhitesMove, gameReader.IsWhitesMove);

                gameReader.read(out sourceSquare, out destinationSquare,
                    out gameProgress);

                if (!gameReader.IsCastling)
                {
                    isWhitesMove = !isWhitesMove;
                    if (gameProgress == GameReader.GameResult.InProgress)
                        ++plyNumber;
                }
                else
                {
                    ++castles;
                }

            } while (gameProgress == GameReader.GameResult.InProgress);

            Assert.AreEqual((int)GameReader.GameResult.BlackWins,
                (int)gameProgress);

            Assert.AreEqual(0, castles);
            Assert.AreEqual(0, plyNumber);
        }

        [Ignore]
        [TestMethod]
        public void T10_gameReaderShortDraw()
        {
            GameReader gameReader = new GameReader(GetFile("cs242-shortDraw.pgn"));
            int sourceSquare;
            int destinationSquare;
            GameReader.GameResult gameProgress;

            bool isWhitesMove = true;
            int plyNumber = 0;
            int castles = 0;

            do
            {
                Assert.IsTrue(isWhitesMove == gameReader.IsWhitesMove);

                gameReader.read(out sourceSquare, out destinationSquare,
                    out gameProgress);

                if (!gameReader.IsCastling)
                {
                    isWhitesMove = !isWhitesMove;
                    if (gameProgress == GameReader.GameResult.InProgress)
                        ++plyNumber;
                }
                else
                {
                    ++castles;
                }

            } while (gameProgress == GameReader.GameResult.InProgress);

            Assert.AreEqual((int)GameReader.GameResult.Draw,
                (int)gameProgress);

            Assert.AreEqual(0, castles);
            Assert.AreEqual(2, plyNumber);
        }

        [TestMethod]
        public void T11_gameReaderReadTenGames()
        {
            GameReader gameReader = new GameReader(GetFile("cs242-10Games.pgn"));
            int sourceSquare;
            int destinationSquare;
            GameReader.GameResult gameProgress;

            bool isWhitesMove = true;
            int plyNumber = 0;
            int castles = 0;
            int nGames = 0;
            int blackWins = 0;
            int whiteWins = 0;

            bool goodRead = true;
            while (goodRead)
            {
                do
                {
                    Assert.IsTrue(isWhitesMove == gameReader.IsWhitesMove);

                    if (goodRead = gameReader.read(out sourceSquare,
                        out destinationSquare, out gameProgress))
                    {

                        if (!gameReader.IsCastling)
                        {
                            isWhitesMove = !isWhitesMove;
                            if (gameProgress == GameReader.GameResult.InProgress)
                                ++plyNumber;
                        }
                        else
                        {
                            ++castles;
                        }
                    }
                } while (goodRead && gameProgress == GameReader.GameResult.InProgress);
                if (gameProgress == GameReader.GameResult.BlackWins) ++blackWins;
                if (gameProgress == GameReader.GameResult.WhiteWins) ++whiteWins;
                if (gameProgress != GameReader.GameResult.NoResult) ++nGames;
            }

            Assert.AreEqual(13, castles);
            Assert.AreEqual(10, nGames);
            Assert.AreEqual(6, blackWins);
            Assert.AreEqual(4, whiteWins);
        }


        [TestMethod]
        // A description of FEN can be found at: 
        // https://en.wikipedia.org/wiki/Forsyth%E2%80%93Edwards_Notation
        public void T12_testFEN()
        {
            ZobristChessHash hash = new ZobristChessHash(23452341);
            hash.SetupPieces();
            bool isWhitesMove = true;
            bool whiteCanCastleKingSide = true;
            bool whiteCanCastleQueenSide = true;
            bool blackCanCastleKingSide = true;
            bool blackCanCastleQueenside = true;
            string enPassantSquare = null;
            int halfMoveClock = 0;
            int fullMoveNumber = 1;
            string initialPosition = hash.GetPositionInFEN(
                isWhitesMove,
                whiteCanCastleKingSide,
                whiteCanCastleQueenSide,
                blackCanCastleKingSide,
                blackCanCastleQueenside,
                enPassantSquare,
                halfMoveClock,
                fullMoveNumber);
            Assert.AreEqual(
                "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1",
                initialPosition);
        }


        private static void ResetGame(ref int nGames, ref int ply, ZobristChessHash theHash)
        {
            ++nGames;
            ply = 0;
            theHash.SetupPieces();
        }

        [Ignore]
        [TestMethod]
        // This test will take several seconds (about 12 on my machine) to complete.
        // It reads 20,000 games from the "cs242-allGames.pgn" file and counts the
        // number of times each position occurs using the ZobristChessHash class.
        // Upon completion it checks to see if your results agree with mine for the
        // first 1, 5, and 10 ply.  Files showing the most commonly encountered
        // positions for the first 10 ply will be written to the
        // ./TestZobrist/bin/Debug/net5.0 directory as .fen files.  These file can
        // be viewed with programs such as WinBoard.
        public void T13_makeHashttable()
        {
            // Each game has an average of about 40 move >> (80 ply)
            const int MAX_GAMES = 20000;

            // 80 moves * MAX_GAMES = 1,600,000, but not all positions are unique.
            // Make the table size about twice that.
            const int TABLE_SIZE = 3200003;

            HashWithLinearProbe<Position, int> hashTable =
                new HashWithLinearProbe<Position, int>(TABLE_SIZE);

            GameReader reader = new GameReader(GetFile("cs242-allGames.pgn"));
            ZobristChessHash hash = new ZobristChessHash(2423411);
            int nGames = 0;
            int ply = 0;
            hash.SetupPieces();

            int sourceSquare;
            int destinationSquare;
            int BlackWins = 0;
            int WhiteWins = 0;
            int Draws = 0;

            const int plysToCheck = 11;
            int[] mostRepeatedPosition = new int[plysToCheck];
            string[] mostRepeatedFEN = new string[plysToCheck];
            GameReader.GameResult gameProgress;
            bool readSuccess = true;
            do
            {
                // Try to read a move
                readSuccess = reader.read(out sourceSquare,
                    out destinationSquare, out gameProgress);

                if (readSuccess)
                {
                    switch (gameProgress)
                    {
                        case GameReader.GameResult.BlackWins:
                            ++BlackWins;
                            ResetGame(ref nGames, ref ply, hash);
                            break;

                        case GameReader.GameResult.WhiteWins:
                            ++WhiteWins;
                            ResetGame(ref nGames, ref ply, hash);
                            break;

                        case GameReader.GameResult.Draw:
                            ++Draws;
                            ResetGame(ref nGames, ref ply, hash);
                            break;

                        case GameReader.GameResult.InProgress:
                            hash.MovePiece(sourceSquare, destinationSquare);
                            ++ply;
                            int currentCount = 0;

                            Position position = new Position(hash.Hash, ply,
                                hash.GetPositionInFEN());

                            if (hashTable.Contains(position))
                            {
                                currentCount = hashTable.Lookup(position);
                            }
                            hashTable.Insert(position, ++currentCount);
                            if (ply < plysToCheck &&
                                mostRepeatedPosition[ply] < currentCount)
                            {
                                mostRepeatedPosition[ply] = currentCount;
                                mostRepeatedFEN[ply] = hash.GetPositionInFEN(
                                    (ply % 2) == 0,
                                    false, false, false, false,
                                    null, 0, ply / 2 + 1);
                                if (ply == 3 && mostRepeatedFEN[ply] ==
                                    @"rnbqkbnr/pppp1ppp/8/4p3/4P3/8/PPPP1PPP/RNBQKBNR b - - 0 2"
                                    )
                                {
                                    ply = 2;
                                }
                            }
                            break;
                        case GameReader.GameResult.NoResult:
                            ResetGame(ref nGames, ref ply, hash);
                            break;

                    }
                }
            } while (readSuccess && nGames < MAX_GAMES);

            for (int i = 1; i < mostRepeatedFEN.Length; i++)
            {
                string filename = String.Format("top{0:00}.fen", i);
                StreamWriter fenWriter = new StreamWriter(filename);
                fenWriter.WriteLine(mostRepeatedFEN[i]);
                fenWriter.Close();
                Console.WriteLine($"position at ply {i} occurs {mostRepeatedPosition[i]} times.");
            }

            Assert.AreEqual(MAX_GAMES, nGames);
            Assert.AreEqual(
                "rnbqkbnr/pppppppp/8/8/4P3/8/PPPP1PPP/RNBQKBNR b - - 0 1",
                mostRepeatedFEN[1]);

            Assert.AreEqual(
                "r1bqkbnr/pppp1ppp/2n5/4p3/2B1P3/5N2/PPPP1PPP/RNBQK2R b - - 0 3",
                mostRepeatedFEN[5]);

            Assert.AreEqual(
                "rnbqkb1r/1p2pppp/p2p1n2/8/3NP3/2N5/PPP2PPP/R1BQKB1R w - - 0 6",
                mostRepeatedFEN[10]);
        }
    }
}
