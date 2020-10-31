using Microsoft.VisualBasic.FileIO;
using System;

namespace DataInteraction
{
    /// <summary>
    /// Класс для работы с Csv файлами
    /// </summary>
    public class ProccesingCsv : FileInteraction
    {
        //путь к файлу
        public string PathCsvFile = @"C:\Users\User\source\repos\IBA_Tasks\Task-1\DataInteraction\bin\Debug\Humen.csv";

        public override void ExportToDataBase()
        {
            //Открытие соединения с БД
            using (ConnectionDataBase db = new ConnectionDataBase())
            {
                //Открытие потока для записи
                using (TextFieldParser tfp = new TextFieldParser(PathCsvFile))
                {
                    //Задание разделителя по условию ";"
                    tfp.TextFieldType = FieldType.Delimited;
                    tfp.SetDelimiters(";");

                    //Считывание будет продолжаться пока не дойдет до конца файла
                    while (!tfp.EndOfData)
                    {
                        //Список полей одной строки
                        string[] fields = tfp.ReadFields();

                        //Добавление новой записи в БД
                        db.Humen.Add(new Human()
                        {
                            Date = DateTime.Parse(fields[0]),
                            FirstName = fields[1],
                            LastName = fields[2],
                            SurName = fields[3],
                            City = fields[4],
                            Country = fields[5]
                        });
                    }
                    //Сохрание изменений
                    db.SaveChanges();
                }
            }
        }

        public override void ImportFromDataBase(DateTime date, string Name, string LastName,
            string SurName, string City, string Country) { }
    }
}