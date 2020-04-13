using LibraryATM;
using NUnit.Framework;
using System.Collections.Generic;

namespace ATMLibraryTest
{
    public class Tests
    {
        [Test]
        public void BanknoteDivision_880_returnerdDictAllOne()
        {
            // arrange
            int InputData = 880;
            Dictionary<int, int> Expected = new Dictionary<int, int>()
            {
            [500]=1,
            [200]=1,
            [100]=1,
            [50]=1,
            [20]=1,
            [10]=1,
            };
            //act
            Dictionary<int, int> Actual = AtmLibrary.BanknoteDivision(InputData);
            //assert
            Assert.AreEqual(Expected,Actual);
        }
    }
}