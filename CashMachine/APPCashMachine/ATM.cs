using System;
using LibraryATM;
using System.Collections.Generic;

namespace APPCashMachine
{
    class ATM
    {
        static void Main(string[] args)
        {
            int AmountEntered = 0; // Введенная сумма

            Console.Write("Введите сумму кратную 10:");
            AmountEntered = Convert.ToInt32(Console.ReadLine());

            int VerifiedData = AtmLibrary.InputData_CheckValue(AmountEntered);
            Console.WriteLine(VerifiedData);
            Dictionary<int, int> ValueCountMoney = AtmLibrary.ATM(VerifiedData);
            foreach (KeyValuePair<int, int> keyValue in ValueCountMoney) // цикл вывода словаря
            {
                if (keyValue.Value > 0)
                {
                    Console.WriteLine($"Количество купюр номиналом { keyValue.Key} = {keyValue.Value} шт.");
                }
            
            }
        }
    }
}
