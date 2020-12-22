using System;
using System.Collections.Generic;
using System.Xml;

namespace LibraryATM
{
    public class AtmLibrary
    {
        public Dictionary<int, int> BanknoteDivision() // Метод возвращающий словарь с конечным результатом для пользователя
        {
            // new stage

            XmlDocument XML = new XmlDocument(); // создание элемента XML
            XML.Load("F://VSproject//ATM//CashMachine//APPCashMachine//XML.xml"); // запись в элемент xml
            XmlElement XMLValueCountBanknote = XML.DocumentElement; // разбор xml файла : Получаем корневой элемент

            static int CheckAmountEntered(XmlElement XMLValueCountBanknote)
            {

               
                List<int> ValueMoney = new List<int>() { 500, 200, 100, 50, 20, 10 }; // Купюры 10 20 50 100 200 500

                Dictionary<int, int> DictionaryCountBanknote = new Dictionary<int, int>() { };
                

                foreach (XmlNode ValueCountBanknoteKey in XMLValueCountBanknote)
                {
                    foreach (int ListBanknoteKey in ValueMoney)
                    {
                        if (ValueCountBanknoteKey.Name == "BanknoteCountValue_" + Convert.ToString(ListBanknoteKey))
                        {
                            DictionaryCountBanknote.Add(ListBanknoteKey, Convert.ToInt32(ValueCountBanknoteKey.InnerText));
                        }
                    }
                }
                Console.WriteLine("Количество купюр в АТМ:");
                foreach (KeyValuePair<int, int> keyValue in DictionaryCountBanknote) // цикл вывода полученных данных
                {
                    if (keyValue.Value > 0)
                    {
                        Console.WriteLine($" Номиналом { keyValue.Key} = {keyValue.Value} шт.");

                    }
                }
                // На выходе словарь со значениями из XML



                int AmountEntered = 0; // Введенная сумма
                int CheckOfAmount = 1;

                while (CheckOfAmount > 0) // check banknote cycle
                {
                    CheckOfAmount = AmountEntered % 10;
                    Console.Write("Введите сумму кратную 10, но не больше 5000:");
                    AmountEntered = Convert.ToInt32(Console.ReadLine());

                    if (CheckMinusValue(AmountEntered) == true & CheckMultiplicity(AmountEntered) == true & CheckValueMax5000(AmountEntered)==true)
                    {
                        Console.WriteLine("Успешная попытка. Продолжим");
                        CheckOfAmount = 0;
                    }
                    else if (CheckMinusValue(AmountEntered) == false)
                    {
                        Console.WriteLine("Вы ввели отрицательное число. Повторите пожалуйста попытку.");
                        CheckOfAmount = 1;
                    }
                    else
                    {
                        Console.WriteLine("Вы ввели сумму не кратную 10. Либо сумма больше 5000. Повторите пожалуйста попытку.");
                        CheckOfAmount = 1;
                    }
                }
                return AmountEntered;
            } // на выходе число проверенное на +\- и кратность 10 и меньше 500

            int AmountEntered = CheckAmountEntered(XMLValueCountBanknote);


            Console.WriteLine("Ваша сумма: " + AmountEntered);

            // old stage
            List<int> ValueMoney = new List<int>() { 500, 200, 100, 50, 20, 10 }; // Купюры 10 20 50 100 200 500

            Dictionary<int, int> ValueCountMoney = new Dictionary<int, int>() { }; // Словарь со значениями номинала и кол-в купюр

            foreach (int i in ValueMoney) // цикл инициализации словаря
            {
                ValueCountMoney.Add(i, AmountEntered / i); // i = key; AmountEntered/i = value
                AmountEntered = AmountEntered % i;
            }

            // На выходе словарь ValueCountMoney со значениями ключ значение

            foreach (XmlNode ValueCountBanknoteKey in XMLValueCountBanknote)
            {

                foreach (int ValueMoneyKey in ValueMoney)
                {
                    if (ValueCountBanknoteKey.Name == "BanknoteCountValue_" + Convert.ToString(ValueMoneyKey))
                    {
                        // Старт оперции вычитания
                        int MinusCount = ValueCountMoney[ValueMoneyKey];
                        int LastCount = Convert.ToInt32(ValueCountBanknoteKey.InnerText);
                        ValueCountBanknoteKey.InnerText = Convert.ToString(LastCount-MinusCount);

                        XmlText AlCount = XML.CreateTextNode(ValueCountBanknoteKey.InnerText);
                    }
                }
                XML.Save("F://VSproject//ATM//CashMachine//APPCashMachine//XML.xml");

            }

            return ValueCountMoney;
        }
        public static void AddBanknoteATM()// Метод добавления купюр в ATM
        {
            Dictionary<int, int> AddBanknoteDictionary = CheckBanknoteInAtm();
            Console.WriteLine("В банкомате сейчас находятся:");
            foreach (KeyValuePair<int, int> keyValue in AddBanknoteDictionary) // цикл вывода данных для инкасации перед добавлением валюты
            {
                Console.WriteLine($" Купюры номиналом { keyValue.Key} = {keyValue.Value} шт.");
            }


            int CountFaceValue = 0;
            int CheckFaceValue = 0;
            while (CheckFaceValue == 0)
            {
                Console.WriteLine("Максимум можно добавить 6 видов купюр. Номиналом 500,200,100,50,20,10");
                Console.Write("Введите сколько видов купюр вы хотите добавить: ");
                CountFaceValue = Convert.ToInt32(Console.ReadLine());
                if (CountFaceValue<7 & CountFaceValue>0)
                {
                    CheckFaceValue = 1;
                }
                else
                {
                    Console.WriteLine("Вы выбрали не коректное количество видов купюр. Повторите попытку.");
                    CheckFaceValue = 0;
                }
            }
            

            List<int> ListBanknote = new List<int> { };
            int checker = 1;
            while (checker != CountFaceValue + 1)
            {
                Console.Write("Введите значение {0} валюты: ", checker);
                int AddBanknote = Convert.ToInt32(Console.ReadLine());
                ListBanknote.Add(AddBanknote);
                checker++;
            }

            XmlDocument XML = new XmlDocument(); // создание элемента XML
            XML.Load("F://VSproject//ATM//CashMachine//APPCashMachine//XML.xml"); // запись в элемент xml
            XmlElement ValueCountBanknote = XML.DocumentElement; // разбор xml файла : Получаем корневой элемент

            // Цикл добавления значений в xml
            foreach (XmlNode ValueCountBanknoteKey in ValueCountBanknote)
            {
                foreach (int ListBanknoteKey in ListBanknote)
                {
                    if (ValueCountBanknoteKey.Name == "BanknoteCountValue_" + Convert.ToString(ListBanknoteKey))
                    {
                        Console.WriteLine("Количество купюр в автомате номиналом {0}: {1} шт. Добавьте купюры номиналом {0} в ATM.", ListBanknoteKey, ValueCountBanknoteKey.InnerText);
                        Console.Write("Введите количество добавленых вами купюр в ATM: ");
                        int AddCount = Convert.ToInt32(Console.ReadLine());
                        int LastCount = Convert.ToInt32(ValueCountBanknoteKey.InnerText);
                        ValueCountBanknoteKey.InnerText = Convert.ToString(AddCount + LastCount);


                        Console.WriteLine("Вы успешно загрузили купюры номиналом {0} в банкомат. Сейчас их в банкомате {1} шт. ", ListBanknoteKey, ValueCountBanknoteKey.InnerText);
                        XmlText AlCount = XML.CreateTextNode(ValueCountBanknoteKey.InnerText);
                    }
                }
                XML.Save("F://VSproject//ATM//CashMachine//APPCashMachine//XML.xml");
            }
        } 
        public static bool CheckMinusValue(int AmountEntered)// Возвращает True если число больше нуля и False если меньше
        {
            if (AmountEntered > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool CheckMultiplicity(int AmountEntered)// Возвращает True если число кратно 10 и False если нет
        {
            int CheckOfAmount = AmountEntered % 10;

            if (CheckOfAmount == 0)
            {
                return true;
            }
            else
            { 
                return false;
            }
        }
        public static bool CheckValueMax5000(int AmountEntered)// Возвращает True если число меньше 5001 и False если число больше
        {
            if (AmountEntered<5001)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static Dictionary<int,int> CheckBanknoteInAtm()// Возвращает словарь со значениями купюр в автомате
        {
            XmlDocument XML = new XmlDocument(); // создание элемента XML
            XML.Load("F://VSproject//ATM//CashMachine//APPCashMachine//XML.xml"); // запись в элемент xml
            XmlElement XMLValueCountBanknote = XML.DocumentElement; // разбор xml файла : Получаем корневой элемент

            List<int> ValueMoney = new List<int>() { 500, 200, 100, 50, 20, 10 }; // Купюры 10 20 50 100 200 500

            Dictionary<int, int> DictionaryCountBanknote = new Dictionary<int, int>() { };


            foreach (XmlNode ValueCountBanknoteKey in XMLValueCountBanknote)
            {
                foreach (int ListBanknoteKey in ValueMoney)
                {
                    if (ValueCountBanknoteKey.Name == "BanknoteCountValue_" + Convert.ToString(ListBanknoteKey))
                    {
                        DictionaryCountBanknote.Add(ListBanknoteKey, Convert.ToInt32(ValueCountBanknoteKey.InnerText));
                    }
                }
            }
            // На выходе словарь со значениями из XML
            return DictionaryCountBanknote;
        }
    }
}

