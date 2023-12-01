using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Name")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Only alphabets are allowed.")]
        public string EmployeeName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        [DisplayName("Email")]
        public string EmployeeEmail { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Password")]
        public string EmployeePassword { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Department")]
        public string EmployeeDepartment { get; set; }

        [Required]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Invalid mobile number")]
        [DisplayName("Mobile")]
        public string EmployeeMobile { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }

        // Navigation property
        public Role Role { get; set; }
    }
}