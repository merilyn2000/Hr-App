﻿using System;
using System.Collections.Generic;

namespace HrApp_WebAPI.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public DateTime DateOfEstablishment { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyInformation { get; set; }
        public string CompanyLogo { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
