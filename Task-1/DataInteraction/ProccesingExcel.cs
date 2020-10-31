using System;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data;

namespace DataInteraction
{
    /// <summary>
    /// Класс для работы с Excel файлами
    /// </summary>
    public class ProccesingExcel : FileInteraction
    {
        public override void ImportFromDataBase(DateTime date, string Name, string LastName,
            string SurName, string City, string Country)
        {
            string path = @"C:\Users\User\source\repos\IBA_Tasks\Task-1\DataInteraction\ExcelFile.xlsx";

            Excel.Application excelapp = new Excel.Application();
            Excel.Workbook workbook = excelapp.Workbooks.Add();
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.ActiveSheet;

            int CurrentRow = 0;

            using (ConnectionDataBase db = new ConnectionDataBase())
            {
                var Humen = db.HumenDataSearch(date, Name, LastName, SurName, City, Country);

                foreach (Human human in Humen)
                {
                    CurrentRow++;

                    worksheet.Rows[CurrentRow, 1] = human.Date;
                    worksheet.Rows[CurrentRow, 2] = human.FirstName;
                    worksheet.Rows[CurrentRow, 3] = human.LastName;
                    worksheet.Rows[CurrentRow, 4] = human.SurName;
                    worksheet.Rows[CurrentRow, 5] = human.City;
                    worksheet.Rows[CurrentRow, 6] = human.Country;
                }
            }

            excelapp.AlertBeforeOverwriting = false;
            workbook.SaveAs(path);
            excelapp.Quit();
        }

        public override void ExportToDataBase() { }
    }
}
