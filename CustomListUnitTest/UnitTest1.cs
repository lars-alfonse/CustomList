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
            CustomList<string> list = new CustomList<string>;
            string expectedValue = "test";

            list.Add("test");
            string actualValue = list[0];

            Assert.AreEqual(actualValue, expectedValue);
        }
        [TestMethod]
        public void AddRetainsOldValues()
        {
            CustomList<string> list = new CustomList<string>;
            string expectedValue = "test";

            list.Add("test");
            list.Add("!test");
            string actualValue = list[0];

            Assert.AreEqual(actualValue, expectedValue);
        }
        [TestMethod]
        public void AddRetainsOrder()
        {
            CustomList<string> list = new CustomList<string>;
            string expectedValue = "test";

            list.Add("!test");
            list.Add("test");
            list.Add("!test");
            string actualValue = list[1];

            Assert.AreEqual(actualValue, expectedValue);
        }
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void StringListDoesntAllowAddInteger()
        {
            CustomList<string> list = new CustomList<string>;

            list.Add("!test");
            list.Add(1);;
        }
        [TestMethod]
        public void AddKeepsObjectMemberVariables()
        {
            CustomList<TestObject> list = new CustomList<TestObject>;
            TestObject testObject = new TestObject();
            testObject.name = "test name";
            string expectedValue = "test name";

            list.Add(testObject);
            string actualValue = list[0].name;

            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}
