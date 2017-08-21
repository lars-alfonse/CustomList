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
            Random random = new Random();

            list.Add(1);
            list.Add(2);
            list.Add(3);

            string test = list.ToString(",");

            Console.WriteLine(test);
            Console.ReadLine();
            CustomList<TestObject> testList = new CustomList<TestObject>();
            for (int i = 0; i < 4; i++)
            {
                TestObject obj = new TestObject();
                testList.Add(obj);
            }

            CustomList<int> testListTwo = new CustomList<int>();
            for (int i = 0; i < 10; i++)
            {
                testListTwo.Add(random.Next(1, 100));
            }
            testListTwo.Sort();
            Console.WriteLine(testListTwo.ToString(", "));
            Console.ReadLine();

            CustomList<int> testListThree = new CustomList<int>();
            testListThree.Add(1);
            testListThree.Add(1);
            testListThree.Add(1);

            CustomList<int> testListFour;
            testListFour = testListTwo + testListThree;
       

            Console.WriteLine(testListFour.ToString(", "));
            Console.ReadLine();
            testListFour.Sort();
            Console.WriteLine(testListFour.ToString(", "));
            Console.ReadLine();
        }
    }
}
