using System;
using System.Collections.Generic;
using System.Text;

namespace lab12tema
{
    public class SimpleQueue<T> : IQueue<T>
    {
        private T[] _data;
        private int _count = 0;
        public int Length => _data.Length;

        public SimpleQueue(int size = 10) 
        {
            _data = new T[size];
        }

        public IQueue<T> Enqueue(T entry)
        {
            if (_count >= _data.Length) 
                throw new ArgumentOutOfRangeException($"Can not add a new element because the queue size is set to [{_data.Length}]. \n\t Create a new queue with size [{_data.Length + 1}]");

            _data[_count] = entry;
            _count++;
            return this;
        }

        public T Dequeue()
        {
            var firstElem = _data[0];
            _count--;

            for (var i = 1; i <= _count; i++)
                _data[i - 1] = _data[i];

            return firstElem;
        }

        public int Count() => _count;

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            for (var i = 0; i < _count; i++)
            {
                stringBuilder.Append(_data[i].ToString());
                if (i != _count - 1)
                    stringBuilder.Append(",");
            }
            return stringBuilder.ToString();
        }
    }
}
