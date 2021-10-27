using System;
using System.Collections.Generic;

namespace HrApp_WebAPI.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalIdentificationNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }
        //public EmployeePersonalDatas PersonalDatas { get; set; }
        public List<EmployeeAddresses> Addresses { get; set; }
        public List<EmployeeContacts> Contacts { get; set; }
        public List<EmployeeIdentityDocuments> IdentityDocuments { get; set; }
        public List<EmployeeBankData> BankData { get; set; }
        public EmployeeDependents Dependents { get; set; }
        public List<EmployeeContracts> Contracts { get; set; }
        //public Company Company { get; set; }
    }
}
