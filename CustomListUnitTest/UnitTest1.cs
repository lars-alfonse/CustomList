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
        public void CheckIfAdds()
        {
            CustomListUnitTest<string> list = new CustomListUnitTest<string>;
            string expectedValue = "test";

            list.Add("test");
            string actualValue = list[0];

            Assert.AreEqual(actualValue, expectedValue);
        }
        [TestMethod]
        public void CheckIfAddRetainsOldValue()
        {
            CustomListUnitTest<string> list = new CustomListUnitTest<string>;
            string expectedValue = "test";

            list.Add("test");
            list.Add("!test");
            string actualValue = list[0];

            Assert.AreEqual(actualValue, expectedValue);
        }
    }
}
