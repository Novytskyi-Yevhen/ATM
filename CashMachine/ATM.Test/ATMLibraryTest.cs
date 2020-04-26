using NUnit.Framework;
using LibraryATM;


namespace ATMLibraryTest
{
    public class Tests
    {
        [Test]
        public void CheckMinusValue()
        {
            //arrange
            int InputDataMinus = -50;
            int InputDataPlus = 50;
            bool ExpectedMinus = false;
            bool ExpectedPlus = true;
            //act
            bool ActualMinus = AtmLibrary.CheckMinusValue(InputDataMinus);
            bool ActualPlus = AtmLibrary.CheckMinusValue(InputDataPlus);
            //assert
            Assert.AreEqual(ExpectedMinus, ActualMinus);
            Assert.AreEqual(ExpectedPlus, ActualPlus);
        }
        [Test]
        public void CheckMultiplicity()
        {
            //arrange
            int InputData_10 = 100;
            int InputDataNot_10 = 99;
            bool Expected_10 = true;
            bool Expected_Not_10 = false;
            //act
            bool Actual_10 = AtmLibrary.CheckMultiplicity(InputData_10);
            bool AcuakNot_10 = AtmLibrary.CheckMultiplicity(InputDataNot_10);
            //assert
            Assert.AreEqual(Expected_10, Actual_10);
            Assert.AreEqual(Expected_Not_10, AcuakNot_10);
        }
        [Test]
        public void CheckValueMax5000()
        {
            //arrange
            int InputData_5000 = 5000;
            int InputData_5999 = 5999;
            bool Expected_5000 = true;
            bool Expected_5999 = false;
            //act
            bool Actual_5000 = AtmLibrary.CheckValueMax5000(InputData_5000);
            bool Actual_5999 = AtmLibrary.CheckValueMax5000(InputData_5999);
            //assert
            Assert.AreEqual(Expected_5000, Actual_5000);
            Assert.AreEqual(Expected_5999, Actual_5999);
        }
    }
}