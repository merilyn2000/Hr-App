using HrApp_WebAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;

namespace HrApp_WebAPI.Interfaces
{
    public interface ICompanyService
    {
        ActionResult<IEnumerable<Company>> GetCompanies(CompanyParameters companyParameters);
        Task<Company> GetCompanyById(int id);
        Task<IActionResult> CreateCompany(Company company);
        Task<ActionResult> EditCompany(int id, Company company);
        Task<IActionResult> DeleteCompany(int id);
        Task<Employee> GetEmployeeById(int id);
        Task<IEnumerable<ExpandoObject>> GetAllEmployeesFromCompany(int companyId, CompanyParameters companyParameters);
        Task<ActionResult> AddEmployeeToCompany(int companyId, Employee employee);
        Task<ActionResult> EditEmployee(int id, Employee employee);
        Task<IActionResult> DeleteEmployee(int id);
        Task<bool> SaveChangesAsync();
    }
}
