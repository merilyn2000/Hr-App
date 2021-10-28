using HrApp_WebAPI.BusinessLogic.Interfaces;
using HrApp_WebAPI.Data.Entities.Companies;
using HrApp_WebAPI.Data.Entities.Companies.Employees;
using HrApp_WebAPI.Data.Entities.Pagination;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace HrApp_WebAPI.BusinessLogic.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly CompanyContext _companyContext;
        private readonly IDataShaper<Employee> _dataShaper;

        public CompanyService(CompanyContext context, IDataShaper<Employee> dataShaper)
        {
            _companyContext = context;
            _dataShaper = dataShaper;
        }

        public IEnumerable<Company> GetCompanies(QueryCompanyParameters companyParameters)
        {
            if (!companyParameters.Year)
            {
                throw new Exception($"The year of establishment can't be bigger than {DateTime.Now.Year} ");
            }

            var companies = _companyContext.Companies.Where(c => c.DateOfEstablishment.Year >= companyParameters.DateOfEstablishment1
                                                        && c.DateOfEstablishment.Year <= companyParameters.DateOfEstablishment2)
                                                .OrderBy(c => c.CompanyName)
                                                .Include(c => c.Employees)
                                                .Skip((companyParameters.PageNumber - 1) * companyParameters.PageSize)
                                                .Take(companyParameters.PageSize);
            var sort = new Sorting();
            sort.SearchByName(ref companies, companyParameters.Name);
            sort.ApplySort(ref companies, companyParameters.OrderBy);
            
            var companiesPagination = PagedList<Company>.ToPagedList(companies, companyParameters.PageNumber,
                                                                    companyParameters.PageSize);

            var metadata = new
            {
                companiesPagination.TotalCount,
                companiesPagination.PageSize,
                companiesPagination.CurrentPage,
                companiesPagination.TotalPages,
                companiesPagination.HasNext,
                companiesPagination.HasPrevious
            };

            return (companiesPagination);
        }

        public async Task<Company> GetCompanyById(int id)
        {
            return await _companyContext.Companies.Include(x => x.Employees).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task CreateCompany(Company company)
        {
            await _companyContext.Companies.AddAsync(company);
        }

        public async Task DeleteCompany(int id)
        {
            var company = await _companyContext.Companies.FindAsync(id);
            if (company == null)
            {
                throw new Exception("There is no company with this id !");
            }

            _companyContext.Companies.Remove(company);
        }

        //------------------------------------------------------------------------------------------

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _companyContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id);
        }

        public async Task<IEnumerable<ExpandoObject>> GetAllEmployeesFromCompany(int companyId,QueryCompanyParameters companyParameters)
        {
            var employees = await _companyContext.Companies
                    .Where(company => company.Id == companyId)
                   .Include(company => company.Employees)
                   .Select(company => company.Employees)
                   .FirstOrDefaultAsync();

            return _dataShaper.ShapeData(employees, companyParameters.Fields);
        }

        public async Task AddEmployeeToCompany(int companyId, Employee employee)
        {
            var company = await _companyContext.Companies
                            .Include(x => x.Employees)
                            .FirstOrDefaultAsync(x => x.Id == companyId);

            company.Employees.Add(employee);
        }

        public async Task<ActionResult> EditEmployee(int id, Employee employee)
        {
            var foundEmployee = await _companyContext.Employees.FirstOrDefaultAsync(x => x.EmployeeId == id);
           
            foundEmployee.FirstName = employee.FirstName;
            foundEmployee.LastName = employee.LastName;

            await _companyContext.SaveChangesAsync();

            return new OkObjectResult(foundEmployee);
        }

        public async Task DeleteEmployee(int id)
        {
            var employee = await _companyContext.Employees.FindAsync(id);
            if (employee == null)
            {
                throw new Exception("There is no employee with this id !");
            }

            _companyContext.Remove(employee);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _companyContext.SaveChangesAsync() > 0;
        }
    }
}