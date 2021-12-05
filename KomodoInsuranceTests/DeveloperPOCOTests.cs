using KomodoInsurance.POCO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KomodoInsuranceTests
{
    [TestClass]
    public class DeveloperPOCOTests
    {
               
            [TestMethod]
            public void SetDeveloperFirstName_ShouldSetCorrectString()
            {
                Developer developer = new Developer();

                developer.FirstName = "SetAccessorFirstNameTest";

                string expected = "SetAccessorFirstNameTest";
                string actual = developer.FirstName;

                Assert.AreEqual(expected, actual);
            }
    }
}
