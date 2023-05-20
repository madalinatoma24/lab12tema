using System;
using System.Collections.Generic;
using System.Text;

namespace lab12tema
{

    public interface IQueue<T>
    {
        IQueue<T> Enqueue(T entry);
        T Dequeue();
        string ToString();
        int Length { get; }
    }


    public class Queue<T> : IQueue<T>
    {
        private T[] _data;
        private int _count = 0;
        private readonly int _resizeStep;
        public int Length => _data.Length;

        public Queue(int sizeAndStep = 10) : this(sizeAndStep, sizeAndStep) { }
        public Queue(int size = 10, int resizeStep = 10)
        {
            _data = new T[size];
            _resizeStep = resizeStep;
        }

        public IQueue<T> Enqueue(T entry) {
            var index = _count;
            _count++;

            if (_count <= _data.Length) {
                // O(1)
                _data[index] = entry;
                return this;
            }

            // O(n)
            var newArr = new T[_data.Length + _resizeStep];
            for (var i = 0; i<_data.Length; i++) 
            {
                newArr[i] = _data[i];
            }
            _data = newArr;

            _data[index] = entry;

            return this;
        }

        public T Dequeue()
        {
            var firstElem = _data[0];
            _count--;
            var newArr = new T[_count];
            for(var i =1; i<=_count; i++)
            {
                newArr[i-1] = _data[i];
            }
            _data = newArr;

            return firstElem;
        }

        public int Count() => _count;

        public override string ToString() 
        {
            var stringBuilder = new StringBuilder();
            for (var i = 0; i < _count; i++) 
            {
                stringBuilder.Append(_data[i].ToString());
                if( i != _count -1)
                    stringBuilder.Append(",");
            }
            return stringBuilder.ToString();
        }
    }
}
