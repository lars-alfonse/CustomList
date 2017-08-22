using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomList<string> testList;
            CustomList<string> list = new CustomList<string>();
            list.Add("A");
            list.Add("B");
            list.Add("C");
            list.Add("C");
            list.Add("D");
            list.Add("C");
            list.Add("E");
            list.Add("C");
            Console.WriteLine(list.ToString(", "));
            CustomList<string> listTwo = new CustomList<string>();
            listTwo.Add("C");
            listTwo.Add("C");
            listTwo.Add("E");
            listTwo.Add("A");
            listTwo.Add("R");

            Console.WriteLine(listTwo.ToString(", "));
            testList = list - listTwo;

            Console.WriteLine(testList.ToString(", "));
            Console.ReadLine();
        }
    }
}
