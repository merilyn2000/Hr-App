using AutoMapper;
using HrApp_WebAPI.DTOs;
using HrApp_WebAPI.Entities;

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
