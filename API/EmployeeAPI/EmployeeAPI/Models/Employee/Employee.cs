﻿using System.ComponentModel;

namespace EmployeeAPI.Models.Employee
{
    public class Employee
    {
        public Guid Id { get; set; }

        public required string Fullname { get; set; }

        public required string Firstname { get; set; }

        public required string Lastname { get; set; }

        public required string Middlename { get; set; }

        public required string Gender { get; set; }

        [DisplayName("Dob")]
        public DateTime DateofBirth { get; set; }

        public string? Email { get; set; }

        [DisplayName("Phone")]
        public required string PhoneNumber { get; set; }

        [DisplayName("Address")]
        public string? HomeAddress { get; set; }

        [DisplayName("Status")]
        public bool isActive { get; set; }
    }
}
