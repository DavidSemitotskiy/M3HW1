using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M3HW1
{
    public class MyEnumerator<T> : IEnumerator<T>
    {
        private int _position = -1;
        private T[] _data;
        public MyEnumerator(T[] data, int tail)
        {
            _data = new T[tail];
            Array.Copy(data, _data, tail);
        }

        public T Current
        {
            get
            {
                if (_position == -1 || _position >= _data.Length)
                {
                    throw new ArgumentOutOfRangeException("index out of range");
                }

                return _data[_position];
            }
        }

        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose() => Console.WriteLine();

        public bool MoveNext()
        {
            if (_position < _data.Length - 1)
            {
                _position++;
                return true;
            }

            return false;
        }

        public void Reset()
        {
            _position = -1;
        }
    }
}
