using System;

namespace HrApp_WebAPI.Data.Entities.Companies.Employees
{
    public class Passport
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Nationality { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime InvalidFrom { get; set; }
    }
}
