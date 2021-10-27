using System.Collections.Generic;

namespace HrApp_WebAPI.Entities
{
    public class EmployeeContracts
    {
        public int Id { get; set; }
        public int CodInregistrare { get; set; }
        public List<EmployeeVersions> Versiuni { get; set; }
    }
}
