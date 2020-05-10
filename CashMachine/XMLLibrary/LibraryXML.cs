using System;
using System.Collections.Generic;
using System.Xml;

namespace XMLLibrary
{
    public class LibraryXML
    {
        public static void XMLBanknoteAdd(Dictionary<int, int> ValueCountMoney, List<int> ListBanknoteCount)// метод добавления банкнот в DataXML//XML.xml
        {
            XmlDocument XML = XmlLoad();
            XmlElement XMLValueCountBanknote = XML.DocumentElement; // разбор xml файла : Получаем корневой элемент

            List<int> ValueMoney = new List<int>() { 500, 200, 100, 50, 20, 10 }; // Купюры 10 20 50 100 200 500
            foreach (XmlNode ValueCountBanknoteKey in XMLValueCountBanknote)
            {
                foreach (int ListBanknoteCountKey in ListBanknoteCount)
                {
                    if (ValueCountBanknoteKey.Name == "BanknoteCountValue_" + Convert.ToString(ListBanknoteCountKey))
                    {
                        // Старт оперции прибавления
                        int AddCount = ValueCountMoney[ListBanknoteCountKey];
                        int LastCount = Convert.ToInt32(ValueCountBanknoteKey.InnerText);
                        ValueCountBanknoteKey.InnerText = Convert.ToString(LastCount + AddCount);

                        XmlText AlCount = XML.CreateTextNode(ValueCountBanknoteKey.InnerText);
                    }
                }
                LibraryXML.XMLSave(XML);

            }
        } 
        public static void XMLBanknoteMinus(Dictionary<int,int> ValueCountMoney)// метод отнимания банкнот из DataXML//XML.xml
        {
            XmlDocument XML = XmlLoad();
            XmlElement XMLValueCountBanknote = XML.DocumentElement; // разбор xml файла : Получаем корневой элемент

            List<int> ValueMoney = new List<int>() { 500, 200, 100, 50, 20, 10 }; // Купюры 10 20 50 100 200 500
            foreach (XmlNode ValueCountBanknoteKey in XMLValueCountBanknote)
            {

                foreach (int ValueMoneyKey in ValueMoney)
                {
                    if (ValueCountBanknoteKey.Name == "BanknoteCountValue_" + Convert.ToString(ValueMoneyKey))
                    {
                        // Старт оперции вычитания
                        int MinusCount = ValueCountMoney[ValueMoneyKey];
                        int LastCount = Convert.ToInt32(ValueCountBanknoteKey.InnerText);
                        ValueCountBanknoteKey.InnerText = Convert.ToString(LastCount - MinusCount);

                        XmlText AlCount = XML.CreateTextNode(ValueCountBanknoteKey.InnerText);
                    }
                }
                LibraryXML.XMLSave(XML);

            }
        } 
        public static XmlDocument XmlLoad()// Возвращает XmlDocument "XML" с заграужеными данными из DataXML//XML.xml 
        {
            XmlDocument XML = new XmlDocument(); // создание элемента XML
            XML.Load("DataXML//XML.xml"); // запись в элемент xml
            return XML; 
        }
        public static void XMLSave(XmlDocument XML)// Сохраняет значения в XML
        {
            XML.Save("DataXML//XML.xml");
        }
        public static Dictionary<int, int> CheckBanknoteInAtmXML()// Возвращает словарь со значениями купюр в автомате
        {

            XmlDocument XML = XmlLoad(); // разбор xml файла : Получаем корневой элемент
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
