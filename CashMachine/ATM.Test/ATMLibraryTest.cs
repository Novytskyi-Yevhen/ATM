using NUnit.Framework;
using LibraryATM;
using System.Collections.Generic;

namespace ATMLibraryTest
{
    public class Tests
    {
        AtmLibrary ATMLIBRARY = new AtmLibrary(); // создание экземпляра класса библиотеки
        [Test]
        public void CheckMinusValue()
        {
            //arrange
            int InputDataMinus = -50;
            int InputDataPlus = 50;
            bool ExpectedMinus = false;
            bool ExpectedPlus = true;
            //act
            bool ActualMinus = ATMLIBRARY.CheckMinusValue(InputDataMinus);
            bool ActualPlus = ATMLIBRARY.CheckMinusValue(InputDataPlus);
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
            bool Actual_10 = ATMLIBRARY.CheckMultiplicity(InputData_10);
            bool AcuakNot_10 = ATMLIBRARY.CheckMultiplicity(InputDataNot_10);
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
            bool Actual_5000 = ATMLIBRARY.CheckValueMax5000(InputData_5000);
            bool Actual_5999 = ATMLIBRARY.CheckValueMax5000(InputData_5999);
            //assert
            Assert.AreEqual(Expected_5000, Actual_5000);
            Assert.AreEqual(Expected_5999, Actual_5999);
        }
        [Test]
        public void BanknoteDivision()
        {
            //arrange
            int Input_AmountEntered_880 = 880;
            Dictionary<int, int> Expected_880 = new Dictionary<int, int>(){
                {500, 1},
                {200, 1},
                {100, 1},
                {50, 1},
                {20, 1},
                {10, 1}
            };
            //act
            Dictionary<int, int> Actual_880 = ATMLIBRARY.BanknoteDivision(Input_AmountEntered_880);
            //assert
            Assert.AreEqual(Expected_880, Actual_880);
        }
        [Test]
        public void CheckWorkATM_6_6()
        {
            //arrange
            int Actual_6 = 6;
            
            //act
            int Expected_6 = AtmLibrary.CheckWorkATM();
            //assert
            Assert.AreEqual(Expected_6, Actual_6);
        }
    }
}