using System;
using System.Collections;
using System.Collections.Generic;

namespace HashMap
{
    public class HashMap<TKey, TValue> : IDictionary<TKey, TValue>
    {

        private LinkedList<KeyValuePair<TKey, TValue>>[] buckets;
        private int pairs = 0;
        private bool readOnly = false;

        public HashMap(int initialSize)
        {
            buckets = new LinkedList<KeyValuePair<TKey, TValue>>[initialSize];
        }

        public HashMap()
        {
            buckets = new LinkedList<KeyValuePair<TKey, TValue>>[65535];
        }

        #region Public Methods

        public TValue this[TKey i]
        {
            get 
            {
                int index = hashCode(i) % buckets.Length;

                if (buckets[index] == null) throw new Exception($"Key {i} doesn't exist in Hash Map.");

                LinkedListNode<KeyValuePair<TKey, TValue>> current = buckets[index].First;

                do
                {
                    if (current.Value.Key.Equals(i)) return current.Value.Value;

                    current = current.Next;
                }
                while (current.Next != null);

                throw new Exception($"Key {i} doesn't exist in Hash Map.");
            }

            set
            {
                if (readOnly) return;

                int index = hashCode(i) % buckets.Length;

                if (buckets[index] == null)
                {
                    buckets[index] = new LinkedList<KeyValuePair<TKey, TValue>>();
                    buckets[index].AddFirst(new KeyValuePair<TKey, TValue>(i, value));
                }
                else
                {
                    LinkedListNode<KeyValuePair<TKey, TValue>> current = buckets[index].First;

                    do
                    {
                        if (current.Value.Key.Equals(i))
                        {
                            current.Value = new KeyValuePair<TKey, TValue>(i, value);
                            return;
                        }

                        current = current.Next;
                    }
                    while (current != null);

                    buckets[index].AddLast(new KeyValuePair<TKey, TValue>(i, value));
                }
            }
        }

        /// <summary>
        /// Gets or sets if the Hash Map is readonly
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                return readOnly;
            }

            set
            {
                if (!readOnly) readOnly = value;
            }
        }

        /// <summary>
        /// Copies value pairs into the passed in array
        /// </summary>
        /// <param name="valuePairs">The array to copy into</param>
        /// <param name="start">the start index</param>
        public void CopyTo(KeyValuePair<TKey, TValue>[] valuePairs, int start)
        {
            int index = start;

            for (int i = 0; i < buckets.Length; i++)
            {
                if (buckets[i] == null) continue;

                LinkedListNode<KeyValuePair<TKey, TValue>> current = buckets[i].First;

                do
                {
                    valuePairs[index] = new KeyValuePair<TKey, TValue>(current.Value.Key, current.Value.Value);
                    index++;

                    current = current.Next;
                }
                while (current != null);
            }
        }

        /// <summary>
        /// Returns enumerator for hash map
        /// </summary>
        /// <returns>The enumerator</returns>
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            for (int i = 0; i < buckets.Length; i++)
            {
                if (buckets[i] == null) continue;

                LinkedListNode<KeyValuePair<TKey, TValue>> current = buckets[i].First;

                do
                {
                    yield return current.Value;
                    current = current.Next;
                }
                while (current != null);
            }
        }

        /// <summary>
        /// Gets the number of pairs in Hash Map
        /// </summary>
        public int Count
        {
            get { return pairs; }
        }

        /// <summary>
        /// Gets all of the current keys in Hash Map
        /// </summary>
        public ICollection<TKey> Keys
        {
            get
            {
                TKey[] ret = new TKey[pairs];
                int j = 0;

                for (int i = 0; i < buckets.Length; i++)
                {
                    if (buckets[i] == null) continue;

                    LinkedListNode<KeyValuePair<TKey, TValue>> current = buckets[i].First;

                    do
                    {
                        ret[j] = current.Value.Key;
                        j++;

                        current = current.Next;
                    }
                    while (current != null);
                }

                return ret;
            }
        }

        /// <summary>
        /// Gets all of the current values in Hash Map
        /// </summary>
        public ICollection<TValue> Values
        {
            get
            {
                TValue[] ret = new TValue[pairs];
                int j = 0;

                for (int i = 0; i < buckets.Length; i++)
                {
                    if (buckets[i] == null) continue;

                    LinkedListNode<KeyValuePair<TKey, TValue>> current = buckets[i].First;

                    do
                    {
                        ret[j] = current.Value.Value;
                        j++;

                        current = current.Next;
                    }
                    while (current != null);
                }

                return ret;
            }
        }

        /// <summary>
        /// Attempts to get value at index key, returns false on error
        /// and true on success.
        /// </summary>
        /// <param name="key">The key to search for</param>
        /// <param name="value">The output value</param>
        /// <returns>True if value exists</returns>
        public bool TryGetValue(TKey key, out TValue value)
        {
            try
            {
                value = this[key];
                return true;
            }
            catch (Exception)
            {
                value = default;
                return false;
            }
        }

        /// <summary>
        /// Does the value exist in the Hash Map?
        /// </summary>
        /// <param name="key">The key to search for</param>
        /// <returns>True if the key has a value</returns>
        public bool ContainsKey(TKey key)
        {
            int index = hashCode(key) % buckets.Length;

            if (buckets[index] == null) return false;
            else
            {
                LinkedListNode<KeyValuePair<TKey, TValue>> current = buckets[index].First;

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
        /// Checks if pair exists in Hash Map
        /// </summary>
        /// <param name="pair">The pair to check for</param>
        /// <returns>True if the key value pair exists</returns>
        public bool Contains(KeyValuePair<TKey, TValue> pair)
        {
            int index = hashCode(pair.Key) % buckets.Length;

            if (buckets[index] == null) return false;
            else
            {
                LinkedListNode<KeyValuePair<TKey, TValue>> current = buckets[index].First;

                do
                {
                    if (current.Value.Key.Equals(pair.Key)) return current.Value.Value.Equals(pair.Value);
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
        public void Add(TKey key, TValue value)
        {
            if (readOnly) return;

            int index = hashCode(key) % buckets.Length;

            if (buckets[index] == null)
            {
                buckets[index] = new LinkedList<KeyValuePair<TKey, TValue>>();
                buckets[index].AddFirst(new KeyValuePair<TKey, TValue>(key, value));
            }
            else
            { 
                LinkedListNode<KeyValuePair<TKey, TValue>> current = buckets[index].First;

                do // Make sure key doesn't already exist
                {
                    if (current.Value.Key.Equals(key)) throw new Exception($"Key {key} already exists in Hash Map.");
                    current = current.Next;
                }
                while (current != null);


                buckets[index].AddLast(new KeyValuePair<TKey, TValue>());
            }

            pairs++;
            rehash();
        }

        /// <summary>
        /// Adds a Key Value Pair to Hash Map
        /// </summary>
        /// <param name="pair">The pair to add</param>
        public void Add(KeyValuePair<TKey, TValue> pair)
        {
            Add(pair.Key, pair.Value);
        }

        /// <summary>
        /// Removes key and associated value from Hash Map
        /// </summary>
        /// <param name="key">The key denoting which value to remove</param>
        /// <returns>True if value is successfully removed</returns>
        public bool Remove(TKey key)
        {
            if (readOnly) return false;

            int index = hashCode(key) % buckets.Length;

            if (buckets[index] == null) return false;

            if (buckets[index].Count == 1)
            {
                buckets[index] = null;
                pairs--;

                return true;
            }
            else
            {
                LinkedListNode<KeyValuePair<TKey, TValue>> current = buckets[index].First;

                while (current.Next != null)
                {
                    if (current.Value.Key.Equals(key))
                    {
                        buckets[index].Remove(current);
                        pairs--;

                        return true;
                    }

                    current = current.Next;
                }

                return false;
            }
        }

        /// <summary>
        /// Removes specified key value pair from Hash Map
        /// </summary>
        /// <param name="pair">The pair to remove</param>
        /// <returns>True if pair was successfully removed</returns>
        public bool Remove(KeyValuePair<TKey, TValue> pair)
        {
            if (readOnly) return false;

            int index = hashCode(pair.Key) % buckets.Length;

            if (buckets[index] == null) return false;

            if (buckets[index].Count == 1 && buckets[index].First.Value.Value.Equals(pair.Value))
            {
                buckets[index] = null;
                pairs--;

                return true;
            }
            else if (buckets[index].Count > 1)
            {
                LinkedListNode<KeyValuePair<TKey, TValue>> current = buckets[index].First;

                while (current.Next != null)
                {
                    if (current.Value.Key.Equals(pair.Key))
                    {
                        if (!current.Value.Value.Equals(pair.Value)) return false;

                        buckets[index].Remove(current);
                        pairs--;

                        return true;
                    }

                    current = current.Next;
                }

                return false;
            }

            return false;
        }

        /// <summary>
        /// Clears the Hash Map
        /// </summary>
        public void Clear()
        {
            if (readOnly) return;

            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i] = null;
            }

            pairs = 0;
        }

        #endregion
        #region Private Methods

        private void rehash()
        {
            if (pairs < buckets.Length && buckets.Length < int.MaxValue / 2) return;

            LinkedList<KeyValuePair<TKey, TValue>>[] temp = new LinkedList<KeyValuePair<TKey, TValue>>[buckets.Length * 2];

            for (int i = 0; i < buckets.Length; i++)
            {
                int index = hashCode(buckets[i].First.Value.Key) % temp.Length;

                temp[index] = new LinkedList<KeyValuePair<TKey, TValue>>();
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

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}
