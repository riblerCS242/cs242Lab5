using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashLib
{
    public class HashTableEntry<KeyType, PayloadType> :
        IEquatable<HashTableEntry<KeyType, PayloadType>>
    {
        public HashTableEntry(KeyType key, PayloadType payload)
        {
            Key = key;
            Payload = payload;
        }

        public KeyType Key { get; private set; }
        public PayloadType Payload { get; private set; }

        public bool Equals(HashTableEntry<KeyType, PayloadType> other)
        {
            return Key.Equals(other.Key);
        }

        public override int GetHashCode()
        {
            return Key.GetHashCode();
        }
    }
}
