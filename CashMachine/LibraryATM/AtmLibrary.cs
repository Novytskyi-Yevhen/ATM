using System;
using System.Collections.Generic;
namespace LibraryATM
{
    public class AtmLibrary
    {
        public static int InputData_CheckValue(int AmountEntered)
        {
            int CheckOfAmount = 1; // Проверка суммы
            
            while (CheckOfAmount > 0)
            {
                
                //Логика обработки 

                CheckOfAmount = AmountEntered % 10;

                if (CheckOfAmount == 0)
                {
                    Console.WriteLine("Успешная попытка. Продолжим");
                    CheckOfAmount=0;
                }
                else
                {
                    Console.WriteLine("Вы ввели не правильное число. Повторите пожалуйста попытку.");
                    Console.Write("Введите сумму кратную 10:");
                    AmountEntered = Convert.ToInt32(Console.ReadLine());      
                }
                
            }
            return AmountEntered; 
        }

        public static Dictionary<int, int> OutputData(int InputData)
        {
            //Купюры 10 20 50 100 200 500
            List<int> ValueMoney = new List<int>() { 500, 200, 100, 50, 20, 10 }; // номинал

            Dictionary<int, int> ValueCountMoney = new Dictionary<int, int>() { }; // Словарь со значениями номинала и кол-в купюр

            foreach (int i in ValueMoney) // цикл инициализации словаря
            {
                ValueCountMoney.Add(i, InputData / i); // i = key; number/i = value
                InputData = InputData % i;
            }

            
            return ValueCountMoney;
        }

        public static Dictionary<int, int> ATM(int AmountEntered)
        {
            int AmountEntered2 = AtmLibrary.InputData_CheckValue(AmountEntered);
            Dictionary<int, int> ValueCountMoney = AtmLibrary.OutputData(AmountEntered2);
            return ValueCountMoney;
        }
    }
}
