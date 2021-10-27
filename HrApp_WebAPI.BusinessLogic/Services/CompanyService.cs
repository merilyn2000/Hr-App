using HrApp_WebAPI.Entities;
using HrApp_WebAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HrApp_WebAPI.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly CompanyContext _companyContext;

        public CompanyService(CompanyContext context)
        {
            _companyContext = context;
        }

        public ActionResult<IEnumerable<Company>> GetCompanies([FromQuery] CompanyParameters companyParameters)
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

            //Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return (companiesPagination);
        }

        public async Task<Company> GetCompanyById(int id)
        {
            return await _companyContext.Companies.Include(x => x.Employees).FirstOrDefaultAsync(x => x.Id == id);

            //var company = await _context.Companies.Include(c => c.Employees).FirstOrDefaultAsync(x => x.Id == id);
            //if (company == null)
            //{
            //    throw new Exception("There is no company with this id");
            //}

            //return new ObjectResult(company);
        }

        public async Task<IActionResult> CreateCompany(Company company)
        {
            _companyContext.Companies.Add(company);

            await _companyContext.SaveChangesAsync();

            return new ObjectResult(company);
        }

        public async Task<ActionResult> EditCompany(int id, Company company)
        {
            var foundCompany = await _companyContext.Companies.FirstOrDefaultAsync(x => x.Id == id);
            if (foundCompany == null)
            {
                throw new Exception("There is no company with this id !");
            }


            foundCompany.CompanyName = company.CompanyName;
            foundCompany.CompanyAddress = company.CompanyAddress;
            foundCompany.CompanyInformation = company.CompanyInformation;

            await _companyContext.SaveChangesAsync();

            return new OkObjectResult(foundCompany);
        }

        public async Task<IActionResult> DeleteCompany(int id)
        {
            var company = await _companyContext.Companies.FindAsync(id);
            if (company == null)
            {
                throw new Exception("There is no company with this id !");
            }

            _companyContext.Companies.Remove(company);
            await _companyContext.SaveChangesAsync();

            return new NoContentResult();
        }

        //------------------------------------------------------------------------------------------

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _companyContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id);
            //var employee = await _companyContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id);
            //if (employee == null)
            //{
            //    throw new Exception("There is no company with this id");
            //}

            //return new ObjectResult(employee);
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesFromCompany(int companyId)
        {
            return await _companyContext.Companies.Where(company => company.Id == companyId)
                                                    .Include(company => company.Employees)
                                                    .Select(company => company.Employees)
                                                    .FirstOrDefaultAsync();
        }

        public async Task<ActionResult> AddEmployeeToCompany(int companyId, Employee employee)
        {
            var company = await _companyContext.Companies
                            .Include(x => x.Employees)
                            .FirstOrDefaultAsync(x => x.Id == companyId);

            company.Employees.Add(employee);
            await _companyContext.SaveChangesAsync();

            return new ObjectResult(employee);
        }

        public async Task<ActionResult> EditEmployee(int id, Employee employee)
        {
            var foundEmployee = await _companyContext.Employees.FirstOrDefaultAsync(x => x.EmployeeId == id);
           
            foundEmployee.FirstName = employee.FirstName;
            foundEmployee.LastName = employee.LastName;

            await _companyContext.SaveChangesAsync();

            return new OkObjectResult(foundEmployee);
        }

        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _companyContext.Employees.FindAsync(id);
           
            _companyContext.Employees.Remove(employee);
            await _companyContext.SaveChangesAsync();

            return new NoContentResult();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _companyContext.SaveChangesAsync() > 0;
        }
    }
}
