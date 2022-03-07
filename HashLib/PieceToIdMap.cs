using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashLib
{
    public class PieceToIdMap
    {
        private HashWithLinearProbe<char, int> _letterToId;
        private HashWithLinearProbe<int, char> _idToLetter;

        public const int NO_PIECE = 0;
        public const int WHITE_PAWN = 1;
        public const int WHITE_KNIGHT = 2;
        public const int WHITE_BISHOP = 3;
        public const int WHITE_ROOK = 4;
        public const int WHITE_QUEEN = 5;
        public const int WHITE_KING = 6;

        public const int BLACK_PAWN = 7;
        public const int BLACK_KNIGHT = 8;
        public const int BLACK_BISHOP = 9;
        public const int BLACK_ROOK = 10;
        public const int BLACK_QUEEN = 11;
        public const int BLACK_KING = 12;

        public PieceToIdMap()
        {
            mapPiecesToLetters();
        }

        // Given a char index, return the
        // piece id associated with that char.
        public int this[char index]
        {
            get { return _letterToId[index]; }
        }

        // Given an pieceId index, return
        // the associated char.
        public char this[int index]
        {
            get { return _idToLetter[index];  }
        }

        private void mapPiecesToLetters()
        {
            int tableSize = 103;
            _letterToId = new(tableSize);
            _idToLetter = new(tableSize);

            // Add code here that populates the 
            // _letterToId and _idToLetter hash tables
            // such that _letterToId['p'] returns BLACK_PAWN
            // and _idToLetter[BLACK_PAWN] return 'p'.
        }
    }
}
