using System;
using System.Collections.Generic;

namespace Employee_Management_API.Models
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime? Birthdate { get; set; }
        public double? Salary { get; set; }
        public string? Gender { get; set; }
    }
}
