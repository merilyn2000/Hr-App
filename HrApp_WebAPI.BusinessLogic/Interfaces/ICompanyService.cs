using HrApp_WebAPI.Data.Entities.Companies;
using HrApp_WebAPI.Data.Entities.Companies.Employees;
using HrApp_WebAPI.Data.Entities.Pagination;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;

namespace HrApp_WebAPI.BusinessLogic.Interfaces
{
    public interface ICompanyService
    {
        IEnumerable<Company> GetCompanies(QueryCompanyParameters companyParameters);
        Task<Company> GetCompanyById(int id);
        Task CreateCompany(Company company);
        Task DeleteCompany(int id);

        Task<Employee> GetEmployeeById(int id);
        Task<IEnumerable<EmployeeContacts>> GetEmployeeContacts(int id);
        Task<IEnumerable<ExpandoObject>> GetAllEmployeesFromCompany(int companyId,QueryCompanyParameters companyParameters);
        Task AddEmployeeToCompany(int companyId, Employee employee);
        Task DeleteEmployee(int id);

        Task<bool> SaveChangesAsync();
    }
}
