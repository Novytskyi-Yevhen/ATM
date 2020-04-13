using System;
using System.Collections.Generic;
namespace LibraryATM
{
    public class AtmLibrary
    {
        public static Dictionary<int, int> BanknoteDivision(int InputData) // Метод деления суммы на купюры
        {
            List<int> ValueMoney = new List<int>() { 500, 200, 100, 50, 20, 10 }; // Купюры 10 20 50 100 200 500

            Dictionary<int, int> ValueCountMoney = new Dictionary<int, int>() { }; // Словарь со значениями номинала и кол-в купюр

            foreach (int i in ValueMoney) // цикл инициализации словаря
            {
                ValueCountMoney.Add(i, InputData / i); // i = key; InputData    /i = value
                InputData = InputData % i;
            }
            return ValueCountMoney;
        }
    }
}
