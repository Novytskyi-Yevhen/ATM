using System;
using LibraryATM;
using System.Collections.Generic;

namespace APPCashMachine
{
    class ATM
    {
        static void Main(string[] args)
        {
            static int StartWorkATM()
            {
                int CheckOfAmount = 1; // Проверка суммы
                int AmountEntered = 0; // Введенная сумма
                while (CheckOfAmount > 0) // Цикл проверки суммы
                {
                    Console.Write("Введите сумму кратную 10:");
                    //Console.WriteLine(-10%2);
                    AmountEntered = Convert.ToInt32(Console.ReadLine());
                    //Логика обработки 

                    CheckOfAmount = AmountEntered % 10;

                    if (CheckOfAmount == 0 & AmountEntered > 0)
                    {
                        Console.WriteLine("Успешная попытка. Продолжим");
                        CheckOfAmount = 0;
                    }
                    else if (AmountEntered<0)
                    {
                        Console.WriteLine("Вы ввели отрицательное число. Повторите пожалуйста попытку.");
                        CheckOfAmount = 1;
                    }
                    else
                    {
                        Console.WriteLine("Вы ввели сумму не кратную 10. Повторите пожалуйста попытку.");
                        CheckOfAmount = 1;
                    }

                }
                return AmountEntered; // Возврат проверенной суммы
            }

            int InputData = StartWorkATM(); // Вызов метода начала работы банкомата
            Dictionary<int, int> ValueCountMoney = AtmLibrary.BanknoteDivision(InputData); // Получение конечных данных
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
