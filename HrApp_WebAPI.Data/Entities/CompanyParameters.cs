using System;

namespace HrApp_WebAPI.Entities
{
    public class CompanyParameters : QueryStringParameters
    {
        public CompanyParameters()
        {
            OrderBy = "name";
        }
        public uint DateOfEstablishment1 { get; set; }
        public uint DateOfEstablishment2 { get; set; } = (uint)DateTime.Now.Year;
        public bool Year => DateOfEstablishment2 > DateOfEstablishment1;

        public string Name { get; set; }
    }
}
