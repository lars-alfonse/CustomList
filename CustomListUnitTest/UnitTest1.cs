using System;
using CustomList;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace CustomListUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddAddsAString()
        {
            CustomList<string> list = new CustomList<string>();
            string expectedValue = "test";

            list.Add("test");
            string actualValue = list[0];

            Assert.AreEqual(actualValue, expectedValue);
        }
        [TestMethod]
        public void AddRetainsOldValues()
        {
            CustomList<string> list = new CustomList<string>();
            string expectedValue = "test";

            list.Add("test");
            list.Add("!test");
            string actualValue = list[0];

            Assert.AreEqual(actualValue, expectedValue);
        }
        [TestMethod]
        public void AddRetainsOrder()
        {
            CustomList<string> list = new CustomList<string>();
            string expectedValue = "test";

            list.Add("!test");
            list.Add("test");
            list.Add("!test");
            string actualValue = list[1];

            Assert.AreEqual(actualValue, expectedValue);
        }

        [TestMethod]
        public void AddKeepsObjectMemberVariables()
        {
            CustomList<TestObject> list = new CustomList<TestObject>();
            TestObject testObject = new TestObject();
            testObject.name = "test name";
            string expectedValue = "test name";

            list.Add(testObject);
            string actualValue = list[0].name;

            Assert.AreEqual(expectedValue, actualValue);
        }
        [TestMethod]
        public void CountValueisTrueWhenZero()
        {
            CustomList<string> list = new CustomList<string>();
            int expectedValue = 0;

            int actualValue = list.Count;

            Assert.AreEqual(expectedValue, actualValue);
        }
        [TestMethod]
        public void CountValueisTrueWhenGreaterThanZero()
        {
            CustomList<string> list = new CustomList<string>();
            int expectedValue = 2;

            list.Add("test");
            list.Add("test");
            int actualValue = list.Count;

            Assert.AreEqual(expectedValue, actualValue);
        }
        [TestMethod]
        public void CountValueisTrueWhenItemIsRemoved()
        {
            CustomList<string> list = new CustomList<string>();
            int expectedValue = 1;

            list.Add("test");
            list.Add("!test");
            list.Remove("test");
            int actualValue = list.Count;

            Assert.AreEqual(expectedValue, actualValue);
        }
        [TestMethod]
        public void RemoveRemovesItem()
        {
            CustomList<string> list = new CustomList<string>();
            int expectedValue = 0;

            list.Add("test");
            list.Remove("test");
            int actualValue = list.Count;

            Assert.AreEqual(expectedValue, actualValue);
        }
        [TestMethod]
        public void RemovingItemFromZeroIndexPlacesTheNextItemAtZero()
        {
            CustomList<string> list = new CustomList<string>();
            string expectedValue = "test";

            list.Add("!test");
            list.Add("test");
            list.Remove("!test");
            string actualValue = list[0];

            Assert.AreEqual(expectedValue, actualValue);
        }
        [TestMethod]
        public void RemovingStringThatDoesntExistDoesntAffectList()
        {
            CustomList<string> list = new CustomList<string>();
            int expectedValue = 2;

            list.Add("test");
            list.Add("!test");
            list.Remove("!!test");
            int actualValue = list.Count;

            Assert.AreEqual(expectedValue, actualValue);
        }
        [TestMethod]
        public void RemovingFromEmptyListDoesntResultInNegativeCount()
        {
            CustomList<string> list = new CustomList<string>();
            int expectedValue = 0;

            list.Remove("test");
            int actualValue = list.Count;

            Assert.AreEqual(expectedValue, actualValue);
        }
        [TestMethod]
        public void ForEachLoopIteratesTheCorrectNumberOfTimes()
        {
            CustomList<string> list = new CustomList<string>();
            int expectedValue = 4;
            int counter = 0;

            list.Add("test");
            list.Add("!test");
            list.Add("test");
            list.Add("!test");
            foreach (string item in list)
            {
                counter++;
            }
           
            Assert.AreEqual(expectedValue, counter);
        }
        [TestMethod]
        public void IntegersAddThroughIterationLoop()
        {
            CustomList<int> list = new CustomList<int>();
            int expectedValue = 6;
            int actualValue = 0;

            list.Add(2);
            list.Add(3);
            list.Add(1);

            foreach(int number in list)
            {
                actualValue += number;
            }

            Assert.AreEqual(expectedValue, actualValue);
        }
        [TestMethod]
        public void ToStringFunctionCombinesStrings()
        {
            CustomList<string> list = new CustomList<string>();
            string expectedValue = "test";
            string result;

            list.Add("te");
            list.Add("st");

            result = list.ToString();

            Assert.AreEqual(expectedValue, result);
        }
        [TestMethod]
        public void ToStringFunctionCombinesStringsWithParameter()
        {
            CustomList<string> list = new CustomList<string>();
            string expectedValue = "te,st";
            string result = "";

            list.Add("te");
            list.Add("st");
            result = list.ToString(",");

            Assert.AreEqual(expectedValue, result);
        }
        [TestMethod]
        public void AddOperatorPlacesFirstListFirst()
        {
            CustomList<string> firstList = new CustomList<string>();
            CustomList<string> secondList = new CustomList<string>();
            string expectedValue = "test";

            firstList.Add("test");
            secondList.Add("!test");
            CustomList<string> testList = firstList + secondList;
            string actualValue = testList[0];

            Assert.AreEqual(expectedValue, actualValue);
        }
        [TestMethod]
        public void AddingListsUpdatesCount()
        {
            CustomList<string> firstList = new CustomList<string>();
            CustomList<string> secondList = new CustomList<string>();
            int expectedValue = 2;

            firstList.Add("test");
            secondList.Add("!test");
            CustomList<string> testList = firstList + secondList;
            int actualValue = testList.Count;

            Assert.AreEqual(expectedValue, actualValue);
        }
        [TestMethod]
        public void AddingListsKeepsOrderOfParentLists()
        {
            CustomList<string> firstList = new CustomList<string>();
            CustomList<string> secondList = new CustomList<string>();
            string expectedValue = "!!!test";

            firstList.Add("test");
            firstList.Add("!test");
            secondList.Add("!!test");
            secondList.Add("!!!test");
            secondList.Add("!!!!test");
            CustomList<string> testList = firstList + secondList;
            string actualValue = testList[3];

            Assert.AreEqual(expectedValue, actualValue);
        }
        [TestMethod]
        public void AddingSeveralListsCombinesThemAll()
        {
            CustomList<string> firstList = new CustomList<string>();
            CustomList<string> secondList = new CustomList<string>();
            CustomList<string> thirdList = new CustomList<string>();
            CustomList<string> fourthList = new CustomList<string>();
            CustomList<string> testList;
            int expectedValue = 4;

            firstList.Add("test");
            secondList.Add("test");
            thirdList.Add("test");
            fourthList.Add("test");
            testList = firstList + secondList + thirdList + fourthList;
            int actualValue = testList.Count;

            Assert.AreEqual(expectedValue, actualValue);

        }
        [TestMethod]
        public void AddingSeveralListsRetainsOrder()
        {
            CustomList<string> firstList = new CustomList<string>();
            CustomList<string> secondList = new CustomList<string>();
            CustomList<string> thirdList = new CustomList<string>();
            CustomList<string> fourthList = new CustomList<string>();
            CustomList<string> testList;
            string expectedValue = "test!test!!test!!!test";

            firstList.Add("test");
            secondList.Add("!test");
            thirdList.Add("!!test");
            fourthList.Add("!!!test");
            testList = firstList + secondList + thirdList + fourthList;
            string actualValue = testList.ToString();

            Assert.AreEqual(expectedValue, actualValue);

        }
        [TestMethod]
        public void SubtractOperatorRemovesItemsFromList()
        {
            CustomList<string> firstList = new CustomList<string>();
            CustomList<string> secondList = new CustomList<string>();
            CustomList<string> testList;

           int expectedValue = 0;

            firstList.Add("test");
            secondList.Add("test");
            testList = firstList - secondList;
            int actualValue = testList.Count;

            Assert.AreEqual(expectedValue, actualValue);
        }
        [TestMethod]
        public void SubtractOperaterRetainsOrderOfList()
        {
            CustomList<string> firstList = new CustomList<string>();
            CustomList<string> secondList = new CustomList<string>();
            string expectedValue = "!!!!test";

            firstList.Add("test");
            firstList.Add("!!!test");
            secondList.Add("!!test");
            secondList.Add("!!!test");
            secondList.Add("!!!!test");
            secondList.Add("!!!!!test");
            CustomList<string> testList = secondList - firstList;
            string actualValue = testList[1];

            Assert.AreEqual(expectedValue, actualValue);
        }
        [TestMethod]
        public void SubtractingListFromSelfResultsInEmptyList()
        {
            CustomList<string> firstList = new CustomList<string>();
            CustomList<string> testList;
            int expectedValue = 0;

            firstList.Add("test");
            firstList.Add("test");
            firstList.Add("test");
            testList = firstList - firstList;
            int actualValue = testList.Count;

            Assert.AreEqual(expectedValue, actualValue);
        }
        [TestMethod]
        public void ZipFunctionUpdatesCount()
        {
            CustomList<string> list = new CustomList<string>();
            CustomList<string> testList = new CustomList<string>();
            CustomList<string> resultList;
            int expectedValue = 4;

            list.Add("This");
            list.Add("a");
            testList.Add("is");
            testList.Add("test");
            resultList = list.Zip(testList);
            int actualResult = resultList.Count;

            Assert.AreEqual(expectedValue, actualResult);
        }
        [TestMethod]
        public void ZipFunctionPlacesZeroIndexOfSecondListToFirstIndexOfResultList()
        {
            CustomList<string> list = new CustomList<string>();
            CustomList<string> testList = new CustomList<string>();
            CustomList<string> resultList;
            string expectedValue = "is";

            list.Add("This");
            list.Add("a");
            testList.Add("is");
            testList.Add("test");
            resultList = list.Zip(testList);
            string actualResult = resultList[1];

            Assert.AreEqual(expectedValue, actualResult);
        }
        [TestMethod]
        public void ZipFunctionPlacesFirstIndexOfFirstListToSecondIndexOfResultList()
        {
            CustomList<string> list = new CustomList<string>();
            CustomList<string> testList = new CustomList<string>();
            CustomList<string> resultList;
            string expectedValue = "a";

            list.Add("This");
            list.Add("a");
            testList.Add("is");
            testList.Add("test");
            resultList = list.Zip(testList);
            string actualResult = resultList[2];

            Assert.AreEqual(expectedValue, actualResult);
        }
        [TestMethod]
        public void ZipFunctionAddsLeftOverListItemsToEnd()
        {
            CustomList<string> list = new CustomList<string>();
            CustomList<string> testList = new CustomList<string>();
            CustomList<string> resultList;
            string expectedValue = "Thisisatest!testtest!test";

            list.Add("This");
            list.Add("a");
            testList.Add("is");
            testList.Add("test");
            testList.Add("!test");
            testList.Add("test");
            testList.Add("!test");

            resultList = list.Zip(testList);
            string actualResult = resultList.ToString();

            Assert.AreEqual(expectedValue, actualResult);
        }
        [TestMethod]
        public void SortMovesZeroToFrontOfList()
        {
            CustomList<int> list = new CustomList<int>();
            int expectedValue = 0;

            list.Add(3);
            list.Add(5);
            list.Add(1);
            list.Add(0);
            list.Sort();
            int actualValue = list[0];

            Assert.AreEqual(expectedValue, actualValue);
        }
        [TestMethod]
        public void SortMovesHighestNumberToEndOfList()
        {
            CustomList<int> list = new CustomList<int>();
            int expectedValue = 5;

            list.Add(3);
            list.Add(5);
            list.Add(1);
            list.Add(0);
            list.Sort();
            int actualValue = list[3];

            Assert.AreEqual(expectedValue, actualValue);
        }
        [TestMethod]
        public void SortRetainsListCount()
        {
            CustomList<int> list = new CustomList<int>();
            int expectedValue = 4;

            list.Add(3);
            list.Add(5);
            list.Add(1);
            list.Add(0);
            list.Sort();
            int actualValue = list.Count;

            Assert.AreEqual(expectedValue, actualValue);
        }
        [TestMethod]
        public void SortPlacesAInZeroIndex()
        {
            CustomList<string> list = new CustomList<string>();
            string expectedValue = "a";

            list.Add("v");
            list.Add("c");
            list.Add("a");
            list.Add("b");
            list.Sort();
            string actualValue = list[0];

            Assert.AreEqual(expectedValue, actualValue);
        }
        [TestMethod]
        public void SortPlacesVInLastIndex()
        {
            CustomList<string> list = new CustomList<string>();
            string expectedValue = "v";

            list.Add("v");
            list.Add("c");
            list.Add("a");
            list.Add("b");
            list.Sort();
            string actualValue = list[3];

            Assert.AreEqual(expectedValue, actualValue);
        }
        [TestMethod]
        public void SortPrioritizesSpecialCharactersOverLetters()
        {
            CustomList<string> list = new CustomList<string>();
            string expectedValue = "!";

            list.Add("v");
            list.Add("!");
            list.Add("a");
            list.Add("b");
            list.Sort();
            string actualValue = list[0];

            Assert.AreEqual(expectedValue, actualValue);
        }
        [TestMethod]
        public void SortCanSortStringsNumericaly()
        {
            CustomList<string> list = new CustomList<string>();
            string expectedValue = "1";

            list.Add("2");
            list.Add("6");
            list.Add("1");
            list.Add("8");
            list.Sort();
            string actualValue = list[0];

            Assert.AreEqual(expectedValue, actualValue);
        }
        [TestMethod]
        public void PassingCustomListThroughCopiesCount()
        {
            CustomList<int> testList = new CustomList<int>();
            int expectedValue = 3;

            testList.Add(1);
            testList.Add(2);
            testList.Add(3);
            CustomList<int> secondList = new CustomList<int>(testList);
            int actualValue = secondList.Count;

            Assert.AreEqual(expectedValue, actualValue);
        }
        [TestMethod]
        public void PassingCustomListThroughRetainsOrder()
        {
            CustomList<int> testList = new CustomList<int>();
            int expectedValue = 3;

            testList.Add(1);
            testList.Add(2);
            testList.Add(3);
            CustomList<int> secondList = new CustomList<int>(testList);
            int actualValue = secondList[2];

            Assert.AreEqual(expectedValue, actualValue);
        }
        [TestMethod]
        public void PassingArrayThroughConstructorAdjustsCount()
        {
            int[] testArray = new int[3] { 1, 2, 3 };
            int expectedValue = 3;

            CustomList<int> testList = new CustomList<int>(testArray);
            int actualValue = testList.Count;

            Assert.AreEqual(expectedValue, actualValue);
        }
        [TestMethod]
        public void PassingArrayThroughConstructorRetainsOrder()
        {
            int[] testArray = new int[3] { 1, 2, 3 };
            int expectedValue = 3;

            CustomList<int> testList = new CustomList<int>(testArray);
            int actualValue = testList[2];

            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}
