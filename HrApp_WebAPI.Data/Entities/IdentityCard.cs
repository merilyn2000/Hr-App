using System;

namespace HrApp_WebAPI.Entities
{
    public class IdentityCard
    {
        public int Id { get; set; }
        public string Series { get; set; }
        public int Number { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime InvalidFrom { get; set; }
    }
}