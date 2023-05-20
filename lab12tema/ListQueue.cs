using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace lab12tema
{
    public class Element<T> 
    {
        public T Data => _data;
        internal Element<T> Left { get; set; }
        internal Element<T> Right { get; set; }
        private readonly T _data;

        public Element(T data, Element<T> left = null)
        {
            _data = data;
            Left = left;
            if(left != null)
                left.Right = this;
        }
    }

    public class ListQueue<E, T> : IEnumerator<T>, IQueue<T>
        where E: Element<T>
    {
        private E _start;
        private E _end;

        private E _current;
        private int _length;

        public int Length => _length;

        public T Current => _current != null ? _current.Data : default(T);

        object IEnumerator.Current => _current != null ? _current.Data : default(T);



        public T Dequeue()
        {
            var removedItem = _start;
            _start = _start.Right as E;
            if (_start != null) 
            {
                _start.Left.Right = null;
                _start.Left = null;
                _length--;
            }
            return removedItem.Data;
        }

        public IQueue<T> Enqueue(T entry)
        {
            _end = new Element<T>(entry, _end) as E;
            _start = _start is null ? _end : _start;
            _current = _current is null ? _start : _current;
            _length++;
            return this;
        }

        public void Dispose()
        {
            var item = _start;
            do
            {
                var tmp = item;
                item.Right = null;
                item.Left = null;
                item = tmp;
            } while (item.Left != null);
        }



        public bool MoveNext()
        {
            if (_current?.Right == null)
                return false;
            _current = _current.Right as E;
            return true;
        }

        public void Reset()
        {
            _current = _start;
        }

        public int Count() => _length;

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            Reset();
            do
            {
                stringBuilder.Append(Current?.ToString());
                if(_current?.Right != null)
                    stringBuilder.Append(",");
            } while (MoveNext());
            return stringBuilder.ToString();
        }
    }
}
