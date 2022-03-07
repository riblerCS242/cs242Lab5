using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashLib
{
    public class SquareToIndexMap
    {
        const int _tableSize = 241;


        public SquareToIndexMap()
        {
            // MakeMapping();
        }

        // You can just uncomment this function to make the mappings.

        //private void MakeMapping()
        //{
        //    _squareToIndex = new(_tableSize);
        //    _indexToSquare = new(_tableSize);

        //    StringBuilder builder = new();
        //    int index = 0;

        //    for (char row = '1'; row <= '8'; ++row)
        //    {
        //        for (char column = 'a'; column <= 'h'; ++column)
        //        {
        //            builder.Clear();
        //            builder.Append(column);
        //            builder.Append(row);
        //            string SquareName = builder.ToString();
        //            _indexToSquare[index] = SquareName;
        //            _squareToIndex[SquareName] = index++;
        //        }
        //    }
        //}
    }
}
