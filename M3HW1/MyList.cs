using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M3HW1
{
    public class MyList<T>
        where T : IComparable<T>
    {
        private T[] _data = new T[10];
        private int _tail = 0;
        public MyList(T[] data)
        {
            if (data.Length > _data.Length)
            {
                T[] temp = new T[_data.Length * 2];
                _data = temp;
            }

            Array.Copy(data, _data, data.Length);
            _tail = data.Length;
        }

        public T this[int index]
        {
            get
            {
                if (index >= _data.Length || index < 0)
                {
                    throw new ArgumentOutOfRangeException("index out of range");
                }

                return _data[index];
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new MyEnumerator<T>(_data, _tail);
        }

        public void Add(T item)
        {
            _tail++;
            if (_tail >= _data.Length)
            {
                T[] tempArr = new T[_data.Length * 2];
                Array.Copy(_data, tempArr, _data.Length);
                _data = tempArr;
            }

            _data[_tail - 1] = item;
        }

        public void AddRange(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection is null");
            }

            foreach (T item in collection)
            {
                Add(item);
            }
        }

        public void Remove(T item)
        {
            int count = 0;
            if (_tail - 1 < 0)
            {
                return;
            }

            if (!_data.Contains(item))
            {
                return;
            }

            T[] tempArr = new T[_tail - 1];
            for (int i = 0, j = 0; i < _tail; i++)
            {
                if (count == 0)
                {
                    if (_data[i].Equals(item))
                    {
                        count++;
                        continue;
                    }
                }

                tempArr[j] = _data[i];
                j++;
            }

            _tail--;
            Array.Copy(tempArr, _data, tempArr.Length);
            _data[_tail] = default(T);
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _tail)
            {
                return;
            }

            T[] tempArr = new T[_tail - 1];
            for (int i = 0, j = 0; i < _tail; i++)
            {
                if (i == index)
                {
                    continue;
                }

                tempArr[j] = _data[i];
                j++;
            }

            _tail--;
            Array.Copy(tempArr, _data, tempArr.Length);
            _data[_tail] = default(T);
        }

        public void Sort(bool isDescending = false)
        {
            for (int i = 1; i < _tail; i++)
            {
                for (int j = 0; j < _tail - i; j++)
                {
                    if (!isDescending)
                    {
                        if (_data[j].CompareTo(_data[j + 1]) > 0)
                        {
                            SwapItems(ref _data[j], ref _data[j + 1]);
                        }
                    }
                    else
                    {
                        if (_data[j].CompareTo(_data[j + 1]) < 0)
                        {
                            SwapItems(ref _data[j], ref _data[j + 1]);
                        }
                    }
                }
            }
        }

        private void SwapItems(ref T first, ref T second)
        {
            (first, second) = (second, first);
        }
    }
}
