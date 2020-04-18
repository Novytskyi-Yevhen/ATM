using System;
using LibraryATM;
using System.Collections.Generic;

namespace APPCashMachine
{
    class ATM
    {
        static void Main(string[] args)
        {
            int CheckerOut = 0;
            while (CheckerOut==0)
            {
                Console.Write("Выберите режим работы банкомата. 1 - Выдача наличных. 2 - Пополнение наличных (Только для инкасаторов).");
                int SelectionMode = Convert.ToInt32(Console.ReadLine());
                switch (SelectionMode)
                {
                    case 1:
                        Console.WriteLine("Вы выбрали режим работы - Выдача наличных.");
                        AtmLibrary Value = new AtmLibrary(); // создание экземпляра класса библиотеки

                        Dictionary<int, int> ValueCountMoney = Value.BanknoteDivision(); // Словарь со значениями Номинал:Количество



                        foreach (KeyValuePair<int, int> keyValue in ValueCountMoney) // цикл вывода полученных данных
                        {
                            if (keyValue.Value > 0)
                            {
                                Console.WriteLine($"Количество купюр номиналом { keyValue.Key} = {keyValue.Value} шт.");
                            }
                        }

                        break;

                    case 2:
                        Console.Write("Вы выбрали режим работы - Пополнение наличных (Только для инкасаторов).Введите код доступа (1111)");
                        int SecurityCode = Convert.ToInt32(Console.ReadLine());
                        if (SecurityCode==1111)
                        {
                            AtmLibrary.AddBanknoteATM();
                        }
                        else
                        {
                            Console.WriteLine("У вас нет права доступа в этот раздел. Повторите попытку.");
                        }


                        break;

                    default:
                        Console.WriteLine("Вы выбрали не правильный вариант. Повторите попытку.");
                        break;
                }
                Console.Write("Желаете продолжить работу с терминалом? 1-Да. 2-Нет.");
                int CheckWorkATM = Convert.ToInt32(Console.ReadLine());
                if (CheckWorkATM == 1)
                {
                    CheckerOut = 0;
                }
                else if (CheckWorkATM == 2)
                {
                    CheckerOut = 1;
                }

            }
        }
    }
}
