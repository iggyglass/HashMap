using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace HashMap
{
    public struct KeyValue<TKey, TValue> where TKey : IEqualityComparer
    {

        public TKey Key;
        public TValue Value;

        public KeyValue(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }
    }
}
