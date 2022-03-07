using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashLib
{
    public interface ISymbolTable<KeyType, ValueType> where
        KeyType : IEquatable<KeyType>
    {
        void Insert(KeyType key, ValueType value);
        void Delete(KeyType key);
        bool Contains(KeyType key);
        ValueType Lookup(KeyType key);
    }
}
