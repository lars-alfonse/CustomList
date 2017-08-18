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
            CustomList<int> list = new CustomList<int>();

            list.Add(1);
            list.Add(2);
            list.Add(3);

            string test = list.ToString(",");

            Console.WriteLine(test);
            Console.ReadLine();
        }
    }
}
