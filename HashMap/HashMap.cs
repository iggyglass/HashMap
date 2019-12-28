using System;
using System.Collections.Generic;

namespace HashMap
{
    public class HashMap<TKey, TValue>
    {

        private LinkedList<KeyValue<TKey, TValue>>[] buckets;
        private int pairs = 0;

        public HashMap(int initialSize)
        {
            buckets = new LinkedList<KeyValue<TKey, TValue>>[initialSize];
        }

        public HashMap()
        {
            buckets = new LinkedList<KeyValue<TKey, TValue>>[65535];
        }

        #region Public Methods

        public TValue this[TKey i]
        {
            get 
            {
                int index = hashCode(i) % buckets.Length;

                if (buckets[index] == null) throw new Exception($"Key {i} doesn't exist in Hash Map.");

                LinkedListNode<KeyValue<TKey, TValue>> current = buckets[index].First;

                do
                {
                    if (current.Value.Key.Equals(i)) return current.Value.Value;
                }
                while (current.Next != null);

                throw new Exception($"Key {i} doesn't exist in Hash Map.");
            }

            set
            {
                int index = hashCode(i) % buckets.Length;

                if (buckets[index] == null)
                {
                    buckets[index] = new LinkedList<KeyValue<TKey, TValue>>();
                    buckets[index].AddFirst(new KeyValue<TKey, TValue>(i, value));
                }
                else
                {
                    LinkedListNode<KeyValue<TKey, TValue>> current = buckets[index].First;

                    do
                    {
                        if (current.Value.Key.Equals(i))
                        {
                            current.Value = new KeyValue<TKey, TValue>(i, value);
                            return;
                        }

                        current = current.Next;
                    }
                    while (current != null);

                    buckets[index].AddLast(new KeyValue<TKey, TValue>(i, value));
                }
            }
        }

        /// <summary>
        /// Does the value exist in the Hash Map?
        /// </summary>
        /// <param name="key">The key to search for</param>
        /// <returns>True if the key has a value</returns>
        public bool Exists(TKey key)
        {
            int index = hashCode(key) % buckets.Length;

            if (buckets[index] == null) return false;
            else
            {
                LinkedListNode<KeyValue<TKey, TValue>> current = buckets[index].First;

                do
                {
                    if (current.Value.Key.Equals(key)) return true;
                    current = current.Next;
                }
                while (current != null);

                return false;
            }
        }

        /// <summary>
        /// Inserts element with a value of value and a key of
        /// key into Hash Map
        /// </summary>
        /// <param name="key">The key in the Key Value Pair</param>
        /// <param name="value">The value in the Key Value Pair</param>
        public void Insert(TKey key, TValue value)
        {
            int index = hashCode(key) % buckets.Length;

            if (buckets[index] == null)
            {
                buckets[index] = new LinkedList<KeyValue<TKey, TValue>>();
                buckets[index].AddFirst(new KeyValue<TKey, TValue>(key, value));
            }
            else
            { 
                LinkedListNode<KeyValue<TKey, TValue>> current = buckets[index].First;

                do // Make sure key doesn't already exists
                {
                    if (current.Value.Key.Equals(key)) throw new Exception($"Key {key} already exists in Hash Map.");
                    current = current.Next;
                }
                while (current != null);


                buckets[index].AddLast(new KeyValue<TKey, TValue>());
            }

            pairs++;
            rehash();
        }

        /// <summary>
        /// Removes key and associated value from Hash Map
        /// </summary>
        /// <param name="key">The key denoting which value to remove</param>
        public void Remove(TKey key)
        {
            int index = hashCode(key) % buckets.Length;

            if (buckets[index] == null) throw new Exception($"Key {key} doesn't exist in Hash Map.");

            if (buckets[index].Count == 1)
            {
                buckets[index] = null;
            }
            else
            {
                LinkedListNode<KeyValue<TKey, TValue>> current = buckets[index].First;

                while (current.Next != null)
                {
                    if (current.Value.Key.Equals(key))
                    {
                        buckets[index].Remove(current);
                        return;
                    }

                    current = current.Next;
                }

                throw new Exception($"Key {key} doesn't exist in Hash Map.");
            }
        }

        #endregion
        #region Private Methods

        private void rehash()
        {
            if (pairs < buckets.Length && buckets.Length < int.MaxValue / 2) return;

            LinkedList<KeyValue<TKey, TValue>>[] temp = new LinkedList<KeyValue<TKey, TValue>>[buckets.Length * 2];

            for (int i = 0; i < buckets.Length; i++)
            {
                int index = hashCode(buckets[i].First.Value.Key) % temp.Length;

                temp[index] = new LinkedList<KeyValue<TKey, TValue>>();
                temp[index].AddFirst(buckets[i].First.Value);
            }

            buckets = temp;
        }

        private int hashCode(TKey key)
        {
            string str = key.ToString();
            int val = 0;

            for (int i = 0; i < str.Length; i++)
            {
                val += str[0] * (int)Math.Pow(31, str.Length - (i + 1));
            }

            return val;
        }

        #endregion
    }
}
