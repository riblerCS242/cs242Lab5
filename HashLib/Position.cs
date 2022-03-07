using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashLib
{
    public class Position : IEquatable<Position>
    {
        ulong ZobristHash;
        int Ply;
        string FEN;

        public Position(ulong zobristHash, int ply, string fen)
        {
            ZobristHash = zobristHash;
            Ply = ply;
            FEN = fen;
        }

        public override int GetHashCode()
        {
            return ZobristHash.GetHashCode() ^ Ply.GetHashCode();
        }

        public bool Equals(Position other)
        {
            return ZobristHash.Equals(other.ZobristHash) &&
                Ply.Equals(other.Ply) && FEN.Equals(other.FEN);
        }
    }
}
