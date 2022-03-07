using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace HashLib
{
    public class HashWithLinearProbe<KeyType, PayloadType> :
      ISymbolTable<KeyType, PayloadType> where
      KeyType : IEquatable<KeyType>

    {
        public PayloadType this[KeyType key]
        {
            get
            {
                return Lookup(key);
            }
            set 
            {
                Insert(key, value);
            }
        }

        public int Size() { return NEntriesPresent;  }

        private int NEntriesPresent { get; set; }

        public HashWithLinearProbe(int tableSize)
        {
            hashTable = new HashTableEntry<KeyType, PayloadType>[tableSize];
            NEntriesPresent = 0;
        }

        public uint Hash(KeyType key)
        {
            return ((uint)key.GetHashCode()) % (uint)hashTable.Length;
        }

        private uint findKeyTableIndex(KeyType key)
        {
            uint hash = Hash(key);

            while (hashTable[hash] != null &&
                !key.Equals(hashTable[hash].Key))
            {
                hash = (uint)((hash + probeInc) % hashTable.Length);
            }
            return hash;
        }

        public void Insert(KeyType key, PayloadType value)
        {
            uint hash = findKeyTableIndex(key);
            hashTable[hash] = new HashTableEntry<KeyType, PayloadType>(key, value);
            ++NEntriesPresent;
        }

        public void Delete(KeyType key)
        {
            uint hash = findKeyTableIndex(key);
            hashTable[hash] = null;
            List<HashTableEntry<KeyType, PayloadType>> reinsertList =
                new List<HashTableEntry<KeyType, PayloadType>>();

            hash = (hash + 1) % (uint)hashTable.Length;

            while (hashTable[hash] != null)
            {
                reinsertList.Add(hashTable[hash]);
                hashTable[hash] = null;
                hash = (hash + 1) % (uint)hashTable.Length;
            }

            foreach (HashTableEntry<KeyType, PayloadType> record in reinsertList)
            {
                Insert(record.Key, record.Payload);
            }
            --NEntriesPresent;
        }

        public bool Contains(KeyType key)
        {
            uint hash = findKeyTableIndex(key);
            return hashTable[hash] != null;
        }

        public PayloadType Lookup(KeyType key)
        {
            uint hash = findKeyTableIndex(key);
            return hashTable[hash].Payload;
        }

        private HashTableEntry<KeyType, PayloadType>[] hashTable;
        private int probeInc = 1;
    }
}
