using System;
using System.Collections.Generic;
using System.Xml;
using XMLLibrary;
using System.Linq;

namespace LibraryATM
{
    public class AtmLibrary
    {
        XmlDocument XML = LibraryXML.XmlLoad();

        public Dictionary<int, int> BanknoteDivision(int AmountEntered) // Метод возвращающий словарь с конечным результатом для пользователя
        {
            //Dictionary<int, int> DictionaryCountBanknote = LibraryXML.CheckBanknoteInAtm();
            // На выходе словарь со значениями из XML
   
             // на выходе число проверенное на +\- и кратность 10 и меньше 500

            
            // old stage
            List<int> ValueMoney = new List<int>() { 500, 200, 100, 50, 20, 10 }; // Купюры 10 20 50 100 200 500

            Dictionary<int, int> ValueCountMoney = new Dictionary<int, int>() { }; // Словарь со значениями номинала и кол-в купюр

            foreach (int i in ValueMoney) // цикл инициализации словаря
            {
                ValueCountMoney.Add(i, AmountEntered / i); // i = key; AmountEntered/i = value
                AmountEntered = AmountEntered % i;
            }

            // На выходе словарь ValueCountMoney со значениями ключ значение
            LibraryXML.XMLBanknoteMinus(ValueCountMoney); // вычитание из xml
            return ValueCountMoney;
            

            
        }
        public void AddBanknoteATM(Dictionary<int, int> IntValueCountMoney, List<int> ListBanknoteCount)// Метод добавления купюр в ATM
        {
            LibraryXML.XMLBanknoteAdd(IntValueCountMoney, ListBanknoteCount);
        } 
        
        //NEW STAGE
        public static int CheckOfAmount(int AmountEntered)// Метод проверки числа
        {
            AtmLibrary Check = new AtmLibrary(); // создание экземпляра класса
            if (Check.CheckMinusValue(AmountEntered) == true & Check.CheckMultiplicity(AmountEntered) == true & Check.CheckValueMax5000(AmountEntered) == true)
            {
                return 1;
            }
            else if (Check.CheckMinusValue(AmountEntered) == false)
            { 
                return 2;
            }
            else
            { 
                return 3;
            }
        }
        public bool CheckMinusValue(int AmountEntered)// Возвращает True если число больше нуля и False если меньше
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
        public bool CheckMultiplicity(int AmountEntered)// Возвращает True если число кратно 10 и False если нет
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
        public bool CheckValueMax5000(int AmountEntered)// Возвращает True если число меньше 5001 и False если число больше
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
        public static int CheckWorkATM()
        {
            Dictionary<int, int> DictionaryCountBanknote = LibraryXML.CheckBanknoteInAtm();
            int CheckWorkATM = 0;
            foreach (KeyValuePair<int, int> keyValue in DictionaryCountBanknote)
            {
                if (keyValue.Value > 10)
                {
                    CheckWorkATM++;
                }
            }
            return CheckWorkATM;
        }// Возвращает число 6 если кол каждой банкноты больше 10
        public static Dictionary<int, int> CheckBanknoteInAtm()
        {
            Dictionary<int, int> DictionaryCountBanknote = LibraryXML.CheckBanknoteInAtm();
            // На выходе словарь со значениями из XML
            return DictionaryCountBanknote;
}
    }
}
