using System;

namespace HrApp_WebAPI.Data.Entities.Companies.Employees

{
    public class EmployeePersonalDatas
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalIdentificationNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }
    }
}