using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using System.Linq;

namespace DataInteraction
{
    /// <summary>
    /// Класс для взаимодействия с БД
    /// </summary>
    public class ConnectionDataBase : DbContext
    {
        /// <summary>
        /// Набор сущности Human в БД
        /// </summary>
        public DbSet<Human> Humen { get; set; }

        public ConnectionDataBase()
        {
            //Если БД отсутсвует, создаст её.
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Задание строки подключения
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-1T99363;Initial Catalog=HumanData;Integrated Security=True");
        }

        /// <summary>
        /// Метод, возвращающий список Human, удовлетворяющих условию
        /// </summary>
        /// <param name="date">Дата</param>
        /// <param name="Name">Имя</param>
        /// <param name="LastName">Фамилия</param>
        /// <param name="SurName">Отчество</param>
        /// <param name="City">Город</param>
        /// <param name="Country">Страна</param>
        /// <returns>Список Human</returns>
        public List<Human> HumenDataSearch(DateTime date, string Name, string LastName,
            string SurName, string City, string Country)
        {
            return Humen.Where(Human => date != null ? Human.Date == date : true)
                .Where(Human => (Name != null && Name != "") ? Human.FirstName == Name : true)
                .Where(Human => (LastName != null && LastName != "") ? Human.LastName == LastName : true)
                .Where(Human => (SurName != null && SurName != "") ? Human.SurName == SurName : true)
                .Where(Human => (City != null && City != "") ? Human.City == City : true)
                .Where(Human => (Country != null && Country != "") ? Human.Country == Country : true)
                .ToList();
        }
    }
}
