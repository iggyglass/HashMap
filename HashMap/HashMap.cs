using System;
using System.Collections.Generic;
using System.Text;

namespace HashMap
{

    // todo:
    //  -Fix errors
    //  -Finish writing remove
    //  -Unit tests
    //  -Create gethashcode()

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
            buckets = new LinkedList<KeyValue<TKey, TValue>>[int.MaxValue];
        }

        #region Public Methods

        public void Insert(TKey key, TValue value)
        {
            int index = key.GetHashCode() % buckets.Length;

            if (buckets[index] == null)
            {
                buckets[index] = new LinkedList<KeyValue<TKey, TValue>>();
                buckets[index].AddFirst(new KeyValue<TKey, TValue>(key, value));
            }
            else
            {
                //if (buckets[index].Contains(value)) 
                LinkedListNode<KeyValue<TKey, TValue>> current = buckets[index].First;

                do
                {
                    if (current.Value.Key == key) throw new Exception($"Key {key} already exists in Hash Map.");
                }
                while (current.Next != null);


                //buckets[index].AddLast(value);
            }

            pairs++;
            rehash();
        }

        public void Remove(TKey key)
        {
            int index = key.GetHashCode() % buckets.Length;

            if (buckets[index] == null) throw new Exception($"Key {key} doesn't exist in Hash Map.");

            // todo: remove
        }

        #endregion
        #region Private Methods

        private void rehash()
        {
            if (pairs < buckets.Length && buckets.Length < int.MaxValue / 2) return;

            LinkedList<KeyValue<TKey, TValue>>[] temp = new LinkedList<KeyValue<TKey, TValue>>[buckets.Length * 2];

            for (int i = 0; i < buckets.Length; i++)
            {
                int index = buckets[i].First.Value.GetHashCode() % temp.Length;

                temp[index] = new LinkedList<KeyValue<TKey, TValue>>();
                temp[index].AddFirst(buckets[i].First.Value);
            }

            buckets = temp;
        }

        #endregion
    }
}
