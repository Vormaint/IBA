using System.Windows;
using DataInteraction;

namespace Task1_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ProccesingCsv proccesingCsv = new ProccesingCsv();
        ProccesingXML proccesingXML = new ProccesingXML();
        //ProccesingExcel proccesingExcel = new ProccesingExcel();

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Событие для экспорта данных в БД из CSV
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportDataFromCSV_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                proccesingCsv.ExportToDataBase();
                TextBlockInfo.Text = "Данные успешно экспортированы из CSV файла в базу данных!";
            }
            catch
            {
                TextBlockInfo.Text = "Произошла ошибка при экспортировании из CSV файла в базу данных!";
            }
        }

        /// <summary>
        /// Событие для импорта данных в XML
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImportDataToXML_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                proccesingXML.ImportFromDataBase(DataPickerDate.SelectedDate.Value, TextBoxName.Text, 
                    TextBoxLastName.Text,TextBoxSurName.Text, TextBoxCity.Text, TextBoxCountry.Text);
                TextBlockInfo.Text = "Данные успешно испортированны!";
            }
            catch
            {
                TextBlockInfo.Text = "Дата не выбрана!";
            }
        }

        /// <summary>
        /// Событие для импорта данных в Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImportDataToExcel_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch
            {
                TextBlockInfo.Text = "Произошла ошибка при импортировании данных в Excel!";
            }
        }
    }
}

