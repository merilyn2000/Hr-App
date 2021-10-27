using HrApp_WebAPI.Controllers;
using HrApp_WebAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace HrApp_WebAPI.Tests
{
    public class CompanyTests
    {
        private readonly CompanyContext _context;

        public CompanyTests()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<CompanyContext>()
                .UseInMemoryDatabase("CompanyDB")
                .UseInternalServiceProvider(serviceProvider);

            _context = new CompanyContext(builder.Options);

            _context.Companies.Add(new Company
            {
                Id = 1,
                CompanyName = "companyTEST",
                Employees = new List<Employee> { new Employee { EmployeeId = 2, FirstName = "Raul" } }
            }); _context.Employees.Add(new Employee { EmployeeId = 1, FirstName = "TEST" });

            _context.SaveChanges();
        }

        [Fact]
        public async Task GetAllCompanies()
        {
            //arrange
            var controller = new CompaniesController(_context);

            //act
            var result = await controller.GetAllCompanies();

            //assert
            var model = Assert.IsAssignableFrom<IEnumerable<Company>>(result);
            Assert.Equal(1, model.Count());
        }

        [Fact]
        public async Task GetCompanyById_InvalidId()
        {
            var controller = new CompaniesController(_context);

            var result = await controller.GetCompanyById(99);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetCompanyById_ValidId()
        {
            var controller = new CompaniesController(_context);

            var result = await controller.GetCompanyById(1);

            var objectResult = Assert.IsType<ObjectResult>(result);
            var task = Assert.IsAssignableFrom<Company>(objectResult.Value);

            Assert.Equal("companyTEST", task.CompanyName);
        }

        [Fact]
        public async Task CreateCompany_ReturnsBadRequest_WhenModelStateIsInvalid()
        {
            var controller = new CompaniesController(_context);
            controller.ModelState.AddModelError("Name", "Required");

            var result = await controller.CreateCompany(new Company());

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task CreateCompany_ReturnsNewlyCreatedCompany()
        {
            var controller = new CompaniesController(_context);

            var result = await controller.CreateCompany(new Company { CompanyName = "company1" });

            Assert.IsType<ObjectResult>(result);
        }

        [Fact]
        public async Task EditCompany_ReturnsBadRequest_WhenModelStateIsInvalid()
        {
            var controller = new CompaniesController(_context);
            controller.ModelState.AddModelError("Name", "Required");

            var result = await controller.EditCompany(1, new Company { Id = 1, CompanyName = "company123" });

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task EditCompany_ReturnsBadRequest_WhenIdIsInvalid()
        {
            var controller = new CompaniesController(_context);

            var result = await controller.EditCompany(99, new Company { Id = 99, CompanyName = "company123" });

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task EditCompany_ReturnsNoContent_WhenCompanyIsUpdated()
        {
            var controller = new CompaniesController(_context);

            var result = await controller.EditCompany(1, new Company { Id = 1, CompanyName = "company123" });
            var result2 = await controller.GetCompanyById(1);

            var objectResult = Assert.IsType<ObjectResult>(result2);
            var task = Assert.IsAssignableFrom<Company>(objectResult.Value);

            Assert.Equal("company123", task.CompanyName);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task DeleteCompany_ReturnsNotFound_WhenIdIsInvalid()
        {
            var controller = new CompaniesController(_context);

            var result = await controller.DeleteCompany(99);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task DeleteCompany_ReturnsNoContent_WhenCompanyIsDeleted()
        {
            var controller = new CompaniesController(_context);

            var result = await controller.DeleteCompany(1);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task GetEmployeeById_InvalidId()
        {
            var controller = new CompaniesController(_context);

            var result = await controller.GetEmployeeById(99);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetEmployeeById_ValidId()
        {
            var controller = new CompaniesController(_context);

            var result = await controller.GetEmployeeById(1);

            var objectResult = Assert.IsType<ObjectResult>(result);
            var task = Assert.IsAssignableFrom<Employee>(objectResult.Value);

            Assert.Equal("TEST", task.FirstName);
        }

        [Fact]
        public async Task GetAllEmployeesFromACompany()
        {
            //arrange
            var controller = new CompaniesController(_context);

            //act
            var result = await controller.GetAllEmployeesFromCompany(1);

            //assert
            var model = Assert.IsAssignableFrom<IEnumerable<Employee>>(result);
            Assert.Equal(1, model.Count());
        }

        [Fact]
        public async Task AddEmployee_ReturnsBadRequest_WhenModelStateIsInvalid()
        {
            var controller = new CompaniesController(_context);
            controller.ModelState.AddModelError("Name", "Required");

            var result = await controller.AddEmployeeToCompany(1, new Employee());

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task AddEmployee_ReturnsNewlyCreatedEmployee()
        {
            var controller = new CompaniesController(_context);

            var result = await controller.AddEmployeeToCompany(1, new Employee { FirstName = "TEST" });

            Assert.IsType<ObjectResult>(result);
        }

        [Fact]
        public async Task EditEmployee_ReturnsBadRequest_WhenModelStateIsInvalid()
        {
            var controller = new CompaniesController(_context);
            controller.ModelState.AddModelError("Name", "Required");

            var result = await controller.EditEmployee(1, new Employee { EmployeeId = 1, FirstName = "employee123" });

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task EditEmployee_ReturnsBadRequest_WhenIdIsInvalid()
        {
            var controller = new CompaniesController(_context);

            var result = await controller.EditEmployee(99, new Employee { EmployeeId = 99, FirstName = "employee123" });

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task EditEmployee_ReturnsNoContent_WhenCompanyIsUpdated()
        {
            var controller = new CompaniesController(_context);

            var result = await controller.EditEmployee(1, new Employee { EmployeeId = 1, FirstName = "employee123" });

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task DeleteEmployee_ReturnsNotFound_WhenIdIsInvalid()
        {
            var controller = new CompaniesController(_context);

            var result = await controller.DeleteEmployee(99);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task DeleteEmployee_ReturnsNoContent_WhenEmployeeIsDeleted()
        {
            var controller = new CompaniesController(_context);

            var result = await controller.DeleteEmployee(1);

            Assert.IsType<NoContentResult>(result);
        }
    }
}
