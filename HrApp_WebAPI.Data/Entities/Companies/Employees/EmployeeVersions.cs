using System;

namespace HrApp_WebAPI.Data.Entities.Companies.Employees
{
    public class EmployeeVersions
    {
        public int Id { get; set; }
        public DateTime VersionStartDate { get; set; }
        public int Salary { get; set; }
        public string Pozition { get; set; }
        public string Department { get; set; }
        public string Hierarchy { get; set; }
        public int Number { get; set; }
    }
}