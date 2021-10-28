using AutoMapper;
using HrApp_WebAPI.Data.Entities.Companies;
using HrApp_WebAPI.Data.Entities.Companies.Employees;
using HrApp_WebAPI.DTOs;

namespace HrApp_WebAPI.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Company, CompanyDto>().ReverseMap();
            CreateMap<Employee, EmployeeDto>().ReverseMap();
        }
    }
}
