using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList
{
    public class CustomList<T> : IEnumerable<T>
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
        public CustomList()
        {

        }
        public CustomList(CustomList<T> firstList, CustomList<T> secondList)
        {
            int indexer = 0;
            count = firstList.Count + secondList.Count;
            list = new T[count];
            for(int i = 0; i < firstList.Count; i++)
            {
                list[indexer] = firstList[i];
                indexer++;
            }
            for (int i = 0; i < secondList.Count; i++)
            {
                list[indexer] = secondList[i];
                indexer++;
            }

        }
        public static CustomList<T> operator +(CustomList<T> FirstList, CustomList<T> SecondList)
        {
            CustomList<T> result;
            result = new CustomList<T>(FirstList, SecondList);
            return result;
        }
        public static CustomList<T> operator -(CustomList<T> FirstList, CustomList<T> SecondList)
        {
            CustomList<T> result;
            result = new CustomList<T>(FirstList, SecondList);
            return result;
        }
        public void Add(T item)
        {
            count += 1;
            list = new T[count];
            list[count - 1] = item;
        }
        public void Remove(T item)
        {
            bool wasRemoved = false;
            for (int i = 0; i < Count; i++)
            {

            }
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
