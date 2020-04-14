using System;
using LibraryATM;
using System.Collections.Generic;

namespace APPCashMachine
{
    class ATM
    {
        static void Main(string[] args)
        {
            AtmLibrary Value = new AtmLibrary();
            Dictionary<int, int> ValueCountMoney =Value.BanknoteDivision(); // Получение конечных данных
            foreach (KeyValuePair<int, int> keyValue in ValueCountMoney) // цикл вывода полученных данных
            {
                if (keyValue.Value > 0)
                {
                    Console.WriteLine($"Количество купюр номиналом { keyValue.Key} = {keyValue.Value} шт.");
                }
            }
           
        }
    }
}
