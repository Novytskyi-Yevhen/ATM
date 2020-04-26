using System;
using LibraryATM;
using System.Collections.Generic;

namespace APPCashMachine
{
    class ATM
    {
        static void Main()
        {
            Dictionary<int, int> DictionaryCountBanknote = AtmLibrary.CheckBanknoteInAtm(); // Возвращает словарь со значениями купюр в автомате
            // Проверка купюр в устройстве. Если в АТМ присутствуют все 6 видо купюр в кол больше 10шт то возвращается число 6
            int CheckWork = CheckWorkATM(DictionaryCountBanknote); 

            if (CheckWork == 6)
            {
                Console.WriteLine("Приветствуем вас в банкомате.");
                StartMenu();
            }
            else
            {
                Console.WriteLine("В автомате закончились банкноты. Ожидайте пополнения инкасаторами.");
                Console.Write("Введите пароль инкасации(1111): ");
                int Pass = Convert.ToInt32(Console.ReadLine());
                if (Pass == 1111)
                {
                    AtmLibrary.AddBanknoteATM();
                    StartMenu();
                }
                else
                {
                    Console.WriteLine("Вы ввели неправильный пароль. Повторите попытку.");
                    Main();
                }
            }
            //Главный метод. Выбор режима работы
            static void StartMenu()
            {
                int CheckerOut = 0;
                while (CheckerOut == 0) // Главный цикл == Меню
                {
                    Console.Write("Выберите режим работы банкомата. 1 - Выдача наличных. 2 - Пополнение наличных (Только для инкасаторов).");
                    int SelectionMode = Convert.ToInt32(Console.ReadLine());
                    switch (SelectionMode)
                    {
                        case 1:
                            Console.WriteLine("Вы выбрали режим работы - Выдача наличных.");
                            AtmLibrary Value = new AtmLibrary(); // создание экземпляра класса библиотеки

                            Dictionary<int, int> ValueCountMoney = Value.BanknoteDivision(); // Словарь со значениями Номинал:Количество
                            Console.WriteLine("Вам было выданно:");
                            foreach (KeyValuePair<int, int> keyValue in ValueCountMoney) // цикл вывода полученных данных
                            {
                                if (keyValue.Value > 0)
                                {
                                    Console.WriteLine($"Купюр номиналом { keyValue.Key} = {keyValue.Value} шт.");
                                }
                            }
                            break;

                        case 2:
                            Console.Write("Вы выбрали режим работы - Пополнение наличных (Только для инкасаторов). Введите код доступа (1111)");
                            int SecurityCode = Convert.ToInt32(Console.ReadLine());
                            if (SecurityCode == 1111)
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
                    
                    int CheckWorkATM = 0;
                    while (CheckWorkATM == 0)
                    {
                        Console.Write("Желаете продолжить работу с терминалом? 1-Да. 2-Нет.");
                        CheckWorkATM = Convert.ToInt32(Console.ReadLine());

                        if (CheckWorkATM == 1)
                        {
                            Console.WriteLine("Хорошо, сейчас перенаправлю вас на главный экран.");
                            CheckerOut = 0;
                            CheckWorkATM = 1;
                        }
                        else if (CheckWorkATM == 2)
                        {
                            Console.WriteLine("Операции завершенны успешно. Хорошего дня.");
                            CheckerOut = 1;
                            CheckWorkATM = 1;
                        }
                        else
                        {
                            Console.WriteLine("Вы выбрали не правильный ответ. Повторите ваш выбор.");
                            CheckWorkATM = 0;
                        }
                    }
                }
            }
            // Проверяет наличие купюр в АТМ каждой купюры должно быть больше 10 шт
            static int CheckWorkATM(Dictionary<int, int> DictionaryCountBanknote)
            {
                int CheckWorkATM = 0;
                foreach (KeyValuePair<int, int> keyValue in DictionaryCountBanknote)
                {
                    if (keyValue.Value>10)
                    {   
                        CheckWorkATM++;
                    }
                }
                return CheckWorkATM;
            }
        }   
    }
}
