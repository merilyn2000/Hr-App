using HrApp_WebAPI.Data.Entities.Companies.Employees;

namespace HrApp_WebAPI.Data.Entities.Companies.Employees
{
    public class EmployeeIdentityDocuments
    {
        public int Id { get; set; }
        public IdentityCard CI { get; set; }
        public Passport Passport { get; set; }
        public DriverLicense DriverLicense { get; set; }
    }
}
