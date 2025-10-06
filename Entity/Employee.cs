namespace Entity
{
    /// <summary>
    /// Сущность работника
    /// </summary>
    public class Employee
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string PayrollNumber { get; set; }    // Номер в системе оплаты труда
        public string Forenames { get; set; }        // Имя (может быть несколько)
        public string Surname { get; set; }          // Фамилия
        public DateTime? DateOfBirth { get; set; }

        public string Telephone { get; set; }
        public string Mobile { get; set; }

        public string Address { get; set; }
        public string Address_2 { get; set; }
        public string Postcode { get; set; }
        public string EmailHome { get; set; }

        public DateTime? Start_Date { get; set; }

        public string RawCsv { get; set; }           // для хранения оригинальной строки
    }
}
