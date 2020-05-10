using System;
using LibraryATM;
using System.Collections.Generic;

namespace APPCashMachine
{
    class ATM
    {
        static void Main()
        {
            int CheckWork = AtmLibrary.CheckWorkATM();

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
                    //AtmLibrary.AddBanknoteATM();
                    SwitchCase(2);
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

                    SwitchCase(SelectionMode);
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
            static void SwitchCase(int SelectionMode)// Выбор операции Выдача наличных, Добавление наличных
            {
                AtmLibrary ATMLIBRARY = new AtmLibrary(); // создание экземпляра класса библиотеки
                Dictionary<int, int> DictionaryCountBanknote = AtmLibrary.CheckBanknoteInAtm();
                switch (SelectionMode)
                {
                    case 1:
                        Console.WriteLine("Вы выбрали режим работы - Выдача наличных.");


                        // На выходе словарь со значениями из XML
                        Console.WriteLine("Количество купюр в АТМ:");

                        foreach (KeyValuePair<int, int> keyValue in DictionaryCountBanknote) // цикл вывода полученных данных
                        {
                            if (keyValue.Value > 0)
                            {
                                Console.WriteLine($" Номиналом { keyValue.Key} = {keyValue.Value} шт.");

                            }
                        }

                        int CheckOfAmount = 0;
                        int AmountEntered = 0; // Введенная сумма
                        while (CheckOfAmount == 0)
                        {
                            Console.Write("Введите сумму кратную 10, но не больше 5000:");
                            AmountEntered = Convert.ToInt32(Console.ReadLine());
                            if (AtmLibrary.CheckOfAmount(AmountEntered) == 1)
                            {
                                CheckOfAmount = 1;
                            }
                            else if (AtmLibrary.CheckOfAmount(AmountEntered) == 2)
                            {
                                Console.WriteLine("Вы ввели отрицательное число. Повторите пожалуйста попытку.");
                                CheckOfAmount = 0;
                            }
                            else if (AtmLibrary.CheckOfAmount(AmountEntered) == 3)
                            {
                                Console.WriteLine("Вы ввели сумму не кратную 10. Либо сумма больше 5000. Повторите пожалуйста попытку.");
                                CheckOfAmount = 0;
                            }
                            else
                            {
                                Console.WriteLine("Вы ввели не правильную комбинацию символов. Повторите попытку");
                            }
                        }
                        // Проверенное число на выходе


                        Console.WriteLine("Ваша сумма: " + AmountEntered);

                        //AtmLibrary ATMLIBRARY = new AtmLibrary(); // создание экземпляра класса библиотеки

                        Dictionary<int, int> ValueCountMoney = ATMLIBRARY.BanknoteDivision(AmountEntered);



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
                            Console.WriteLine("Пароль принят успешно.");

                            Console.WriteLine("Количество купюр в АТМ:");

                            foreach (KeyValuePair<int, int> keyValue in DictionaryCountBanknote) // цикл вывода полученных данных
                            {
                                if (keyValue.Value > 0)
                                {
                                    Console.WriteLine($" Номиналом { keyValue.Key} = {keyValue.Value} шт.");

                                }
                            }

                            int CountFaceValue = 0;
                            int CheckFaceValue = 0;
                            while (CheckFaceValue == 0)
                            {
                                Console.WriteLine("Максимум можно добавить 6 видов купюр. Номиналом 500,200,100,50,20,10");
                                Console.Write("Введите сколько видов купюр вы хотите добавить: ");
                                CountFaceValue = Convert.ToInt32(Console.ReadLine());
                                if (CountFaceValue < 7 & CountFaceValue > 0)
                                {
                                    CheckFaceValue = 1;
                                }
                                else
                                {
                                    Console.WriteLine("Вы выбрали не коректное количество видов купюр. Повторите попытку.");
                                    CheckFaceValue = 0;
                                }
                            }
                            // На выходе число валют к добавлению; CountFaceValue

                            Dictionary<int, int> IntValueCountMoney = new Dictionary<int, int>() { }; // Словарь со значениями номинала и кол-в купюр

                            List<int> ListBanknoteCount = new List<int> { };
                            int checker = 1;
                            while (checker != CountFaceValue + 1)
                            {
                                Console.Write("Введите значение {0} валюты: ", checker);
                                int AddBanknote = Convert.ToInt32(Console.ReadLine());
                                ListBanknoteCount.Add(AddBanknote);
                                checker++;
                            }
                            // На выходе список с валютами; ListBanknoteCount
                            List<int> ListBanknoteValue = new List<int> { };
                            int check = 0;
                            while (check != CountFaceValue)
                            {
                                foreach (int ListBanknoteKey in ListBanknoteCount)
                                {
                                    Console.Write("Введите значение купюры номиналом {0} : ", ListBanknoteKey);
                                    int AddBanknote = Convert.ToInt32(Console.ReadLine());
                                    IntValueCountMoney.Add(ListBanknoteKey, AddBanknote);
                                    check++;
                                }
                            }
                            // На выходе список со значениями по каждой валюте; ListBanknoteValue

                            ATMLIBRARY.AddBanknoteATM(IntValueCountMoney, ListBanknoteCount);
                            Console.WriteLine("Процесс добавления валют успешно завершен.");
                            StartMenu();
                        }
                        else
                        {
                            Console.WriteLine("У вас нет права доступа в этот раздел. Повторите попытку.");
                            Main();
                        }


                        break;

                    default:
                        Console.WriteLine("Вы выбрали не правильный вариант. Повторите попытку.");
                        Main();
                        break;
                }
            }// Выбор операции Выдача наличных, Добавление наличных
        }   
    }
}
