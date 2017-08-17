using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList
{
    class CustomList<T> : IEnumerable<T>
    {
        public T[] list;
        private int count;

        public T this[int i]
        {
            get { return list[i]; }
            set { list[i] = value; }
        }

        public int Count
        {
            get
            {
                return count;
            }
        }


        public void Add(T item)
        {
            count += 1;
            list = new T[count];
            list[count - 1] = item;
        }
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

    }
}
