using System;

namespace HrApp_WebAPI.Data.Entities.Companies.Employees
{
    public class DriverLicense
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime InvalidFrom { get; set; }
    }
}
