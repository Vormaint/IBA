using System;

namespace DataInteraction
{
    /// <summary>
    /// Абстрактный класс описывающий класс для Экспорта-Импорта данных
    /// </summary>
    public abstract class FileInteraction
    {
        /// <summary>
        /// Метод экспортирующий данные в БД
        /// </summary>
        public abstract void ExportToDataBase();

        /// <summary>
        /// Метод импортирующий данные в БД
        /// </summary>
        /// <param name="date">Дата</param>
        /// <param name="Name">Имя</param>
        /// <param name="LastName">Фамилия</param>
        /// <param name="SurName">Отчество</param>
        /// <param name="City">Город</param>
        /// <param name="Country">Страна</param>
        public abstract void ImportFromDataBase(DateTime date, string Name, string LastName,
            string SurName, string City, string Country);
    }
}
