using AutoMapper;
using HrApp_WebAPI.DTOs;
using HrApp_WebAPI.Entities;
using HrApp_WebAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HrApp_WebAPI.Controllers
{
    [Route("companies")]
    [Authorize(Roles ="Manager")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompaniesController(ICompanyService companyService, IMapper autoMapperProfile)
        {
            _companyService = companyService;
            _mapper = autoMapperProfile;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<Company>> GetCompanies([FromQuery] CompanyParameters companyParameters)
        {
            return _companyService.GetCompanies(companyParameters);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Company>> GetCompanyById(int id)
        {
            var company = await _companyService.GetCompanyById(id);
            return Ok(company);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany(Company company)
        {
            if (company == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _companyService.CreateCompany(company);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Company>> EditCompany(int id, CompanyDto companyDto)
        {
            var company = await _companyService.GetCompanyById(id);
            if(company == null)
            {
                return BadRequest("There is no company with this id");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(companyDto, company);

            if(await _companyService.SaveChangesAsync())
            {
                return Ok(company);
            }
            return BadRequest("Unsuccessful update");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            return await _companyService.DeleteCompany(id);
        }

        //------------------------------------------------------------------------------------------

        [HttpGet("employee/{id}")]
        [AllowAnonymous]
        public async Task<ActionResult> GetEmployeeById(int id)
        {
            var employee = await _companyService.GetEmployeeById(id);
            if (employee == null)
            {
                return BadRequest("There is no employee with this id!");
            }
            return Ok(employee);
        }

        [HttpGet("employee/company/{companyId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllEmployeesFromCompany(int companyId,[FromQuery]CompanyParameters companyParameters)
        {
            return Ok(await _companyService.GetAllEmployeesFromCompany(companyId, companyParameters));
        }

        [HttpPost("employee/{companyId}")]
        public async Task<ActionResult> AddEmployeeToCompany(int companyId, Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _companyService.AddEmployeeToCompany(companyId, employee);
        }

        [HttpPut("{companyId}/employee/{employeeId}")]
        public async Task<ActionResult> EditEmployee(int companyId, int employeeId, EmployeeDto employeeDto)
        {
            var company = await _companyService.GetCompanyById(companyId);
            if (company == null)
            {
                return BadRequest("There is no company with this id!");
            }

            var employee = await _companyService.GetEmployeeById(employeeId);
            if (employee == null)
            {
                return BadRequest("There is no employee with this id!");
            }

            _mapper.Map(employeeDto, employee);
            if (await _companyService.SaveChangesAsync())
            {
                return Ok(employee);
            }

            return BadRequest("Unsuccessful update employee!");
        }

        [HttpDelete("employee/{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            return await _companyService.DeleteCompany(id);
        }
    }
}
