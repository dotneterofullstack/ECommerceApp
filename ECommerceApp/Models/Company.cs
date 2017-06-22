﻿using System;
namespace ECommerceApp.Models
{
    public class Company
    {
        public int CompanyId { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string Logo { get; set; }

        public int DepartmentId { get; set; }

        public int CityId { get; set; }
    }
}
