using System;

namespace HrApp_WebAPI.Entities
{
    public class DriverLicense
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime InvalidFrom { get; set; }
    }
}
