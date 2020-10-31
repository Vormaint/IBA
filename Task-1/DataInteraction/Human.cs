using System;

namespace DataInteraction
{
    /// <summary>
    /// Класс описывающий человека
    /// </summary>
    public class Human
    {
        public int HumanID { get; set; }
        public DateTime Date { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SurName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
