using AutoMapper;
using HrApp_WebAPI.BusinessLogic.Interfaces;
using HrApp_WebAPI.Data.Entities.Companies;
using HrApp_WebAPI.Data.Entities.Companies.Employees;
using HrApp_WebAPI.Data.Entities.Pagination;
using HrApp_WebAPI.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
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
        public ActionResult<IEnumerable<Company>> GetCompanies([FromQuery] QueryCompanyParameters companyParameters)
        {
            

            var companies = _companyService.GetCompanies(companyParameters);
            return Ok(companies);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Company>> GetCompanyById(int id)
        {
            
            var company = await _companyService.GetCompanyById(id);
            return Ok(company);
        }

        [HttpPost]
        public async Task<ActionResult<Company>> CreateCompany(Company company)
        {
            await _companyService.CreateCompany(company);

            if(await _companyService.SaveChangesAsync())
            {
                return Ok(company);
            }

            return BadRequest("Failed to create a new company");
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
            await _companyService.DeleteCompany(id);

            if (await _companyService.SaveChangesAsync())
            {
                return Ok("The company was deleted");
            }
            return BadRequest("Unsuccessful delete");
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

        [HttpGet("employee/company/{id}")]
        [AllowAnonymous]
        public async Task<ActionResult> GetAllEmployeesFromCompany(int id,[FromQuery]QueryCompanyParameters companyParameters)
        {
            return Ok(await _companyService.GetAllEmployeesFromCompany(id, companyParameters));
        }

        [HttpPost("employee/{companyId}")]
        public async Task<ActionResult> AddEmployeeToCompany(int companyId, Employee employee)
        {
            await _companyService.AddEmployeeToCompany(companyId, employee);

            if (await _companyService.SaveChangesAsync())
            {
                return Ok(employee);
            }

            return BadRequest("Failed to add a new employee");
        }

        [HttpPut("employee/{employeeId}")]
        public async Task<ActionResult> EditEmployee(int employeeId, EmployeeDto employeeDto)
        {
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
            await _companyService.DeleteEmployee(id);

            if (await _companyService.SaveChangesAsync())
            {
                return Ok("The employee was deleted");
            }
            return BadRequest("Unsuccessful delete");
        }

        [HttpPost("upload"), DisableRequestSizeLimit]
        public IActionResult Upload()
        {
            try
            {
                var files = Request.Form.Files;
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (files.Any(f => f.Length == 0))
                {
                    return BadRequest();
                }

                foreach (var file in files)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }

                return Ok("All the files are successfully uploaded.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
