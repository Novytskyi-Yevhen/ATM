using System;
using System.Collections.Generic;
using System.Xml;
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

        public static void AddBanknoteATM()
        {
            Console.Write("Введите сколько видов купюр вы хотите добавить: ");
            int CountFaceValue = Convert.ToInt32(Console.ReadLine());
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
            XML.Load("C://Users//Kedr//source//repos//TestData//TestData//XML.xml"); // запись в элемент xml
            XmlElement ValueCountBanknote = XML.DocumentElement; // разбор xml файла : Получаем корневой элемент





            // Цикл добавления значений в xml
            foreach (XmlNode VCBKey in ValueCountBanknote)
            {

                foreach (int i in ListBanknote)
                {
                    if (VCBKey.Name == "BanknoteCountValue_" + Convert.ToString(i))
                    {
                        Console.WriteLine("Количество купюр в автомате номиналом {0}: {1} шт. Добавьте купюры номиналом {0} в ATM.", i, VCBKey.InnerText);
                        Console.Write("Введите количество добавленых вами купюр в ATM: ");
                        int AddCount = Convert.ToInt32(Console.ReadLine());
                        int LastCount = Convert.ToInt32(VCBKey.InnerText);
                        VCBKey.InnerText = Convert.ToString(AddCount + LastCount);


                        Console.WriteLine("Вы успешно загрузили купюры номиналом {0} в банкомат. Сейчас их в банкомате {1} шт. ", i, VCBKey.InnerText);
                        XmlText AlCount = XML.CreateTextNode(VCBKey.InnerText);
                    }
                }
                XML.Save("C://Users//Kedr//source//repos//TestData//TestData//XML.xml");

            }

        }
    }
}

