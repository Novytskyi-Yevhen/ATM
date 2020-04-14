using System;
using System.Collections.Generic;
namespace LibraryATM
{
    public class AtmLibrary
    {
        public Dictionary<int, int> BanknoteDivision() // Метод деления суммы на купюры
        {
            // new stage

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
                else if (AmountEntered < 0)
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
            Console.WriteLine("Ваша сумма: " +AmountEntered);

            // old stage
            List<int> ValueMoney = new List<int>() { 500, 200, 100, 50, 20, 10 }; // Купюры 10 20 50 100 200 500

            Dictionary<int, int> ValueCountMoney = new Dictionary<int, int>() { }; // Словарь со значениями номинала и кол-в купюр

            foreach (int i in ValueMoney) // цикл инициализации словаря
            {
                ValueCountMoney.Add(i, AmountEntered / i); // i = key; AmountEntered/i = value
                AmountEntered = AmountEntered % i;
            }
            return ValueCountMoney;
        }
    }
}

