using CustomList;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList
{
    public class CustomList<T> : IEnumerable
    {
        public T[] list = new T[0];
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
        public CustomList(T[] list)
        {
            count = 0;
            this.list = list;
            foreach(T item in list)
            {
                count++;
            }
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
            CustomList<T> returnList = FirstList;
            foreach(T item in SecondList)
            {
                returnList.Remove(item);
            }
            return returnList;
        }
        public void Add(T item)
        {
            T[] listPlaceHolder;
            listPlaceHolder = new T[count+1];
            for(int i = 0; i < count; i++)
            {
                listPlaceHolder[i] = list[i];
            }
            listPlaceHolder[count] = item;
            count++;
            list = listPlaceHolder;
        }
        public void Remove(T item)
        {
            T[] listPlaceHolder;
            for (int i = 0; i < Count; i++)
            {
                if (list[i].Equals(item))
                {
                    count --;
                    if (count == 0)
                    {
                        list = new T[0];
                    }
                    else
                    {
                        listPlaceHolder = new T[count];
                        for (int j = 0; j < i; j++)
                        {
                            listPlaceHolder[j] = list[j];
                        }
                        for (int j = i + 1; j <= count; j++)
                        {
                            listPlaceHolder[j - 1] = list[j];
                        }
                        list = listPlaceHolder;
                    }
                    return;
                }
            }
        }
        public void Sort()
        {

        }
        public string ToString(string inputParameter)
        {
            string result = "";
            for (int i = 0; i < count; i++)
            {
                if (i == count - 1)
                {
                    result += list[i].ToString();
                }
                else
                {
                    result += (list[i].ToString() + inputParameter);
                }
            }
            return result;
        }
        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < count; i++)
            {
                result += list[i].ToString();
            }
            return result;
        }

        public CustomList<T> Zip(CustomList<T> inputList)
        {
            int ResultListPosition = 0;
            T[] listPlaceHolder = new T[count + inputList.Count];
            if (count == inputList.count)
            {
                for (int i = 0; i < count; i++)
                {
                    listPlaceHolder[ResultListPosition] = list[i];
                    ResultListPosition++;
                    listPlaceHolder[ResultListPosition] = inputList[i];
                    ResultListPosition++;
                }
                return new CustomList<T>(listPlaceHolder);
            }
            return new CustomList<T>();
        }
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return list[i];
            }
        }
        
    }
}
