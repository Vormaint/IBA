using System;
using System.Xml;

namespace DataInteraction
{
    /// <summary>
    /// Класс для работы с XML файлами
    /// </summary>
    public class ProccesingXML : FileInteraction
    {
        public override void ImportFromDataBase(DateTime date, string Name, string LastName,
            string SurName, string City, string Country)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"C:\Users\User\source\repos\IBA\IBA_Tasks\IBA_Tasks\Task-1\DataInteraction\XML.xml");

            //Открытие соединения с БД
            using (ConnectionDataBase db = new ConnectionDataBase())
            {
                var Humen = db.HumenDataSearch(date, Name, LastName, SurName, City, Country);

                foreach (Human human in Humen)
                {
                    XmlElement xRoot = xDoc.DocumentElement;
                    // Создаем новую запись.
                    XmlElement RecordElem = xDoc.CreateElement("Record");
                    // Создаем атрибут ID.
                    XmlAttribute idAttr = xDoc.CreateAttribute("ID");
                    // Создаем элементы Date, FirstName, LastName, SurName, City, Country.
                    XmlElement DateElem = xDoc.CreateElement("Date");
                    XmlElement FirstNameElem = xDoc.CreateElement("FirstName");
                    XmlElement LastNameElem = xDoc.CreateElement("LastName");
                    XmlElement SurNameElem = xDoc.CreateElement("SurName");
                    XmlElement CityElem = xDoc.CreateElement("City");
                    XmlElement CountryElem = xDoc.CreateElement("Country");

                    // Создаем текстовые значения для элементов и атрибута.
                    XmlText idText = xDoc.CreateTextNode(human.HumanID.ToString());
                    XmlText DateText = xDoc.CreateTextNode(human.Date.ToString("d"));
                    XmlText FirstNameText = xDoc.CreateTextNode(human.FirstName);
                    XmlText LastNameText = xDoc.CreateTextNode(human.LastName);
                    XmlText SurNameText = xDoc.CreateTextNode(human.SurName);
                    XmlText CityText = xDoc.CreateTextNode(human.City);
                    XmlText CountryText = xDoc.CreateTextNode(human.Country);

                    // Добавляем узлы.
                    idAttr.AppendChild(idText);
                    DateElem.AppendChild(DateText);
                    FirstNameElem.AppendChild(FirstNameText);
                    LastNameElem.AppendChild(LastNameText);
                    SurNameElem.AppendChild(SurNameText);
                    CityElem.AppendChild(CityText);
                    CountryElem.AppendChild(CountryText);

                    RecordElem.Attributes.Append(idAttr);
                    RecordElem.AppendChild(DateElem);
                    RecordElem.AppendChild(FirstNameElem);
                    RecordElem.AppendChild(LastNameElem);
                    RecordElem.AppendChild(SurNameElem);
                    RecordElem.AppendChild(CityElem);
                    RecordElem.AppendChild(CountryElem);

                    xRoot.AppendChild(RecordElem);
                }
            }

            xDoc.Save(@"C:\Users\User\source\repos\IBA\IBA_Tasks\IBA_Tasks\Task-1\DataInteraction\XML.xml");
        }

        public override void ExportToDataBase() { }
    }
}
