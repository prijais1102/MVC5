using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MVC5.Models
{
    public class Employee
    {
        [Required]
        [Remote("UniqueIDValue", "Employee", HttpMethod = "Post", ErrorMessage = "Employee Id already exists.")]
        public int Id { get; set; }
        [Required]
        [MinLength(15, ErrorMessage = "Min 15 alphabets needed")]
        [RegularExpression("[a-zA-Z ]+", ErrorMessage = "Only alphabets allowed")]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [BirthYearValidator]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [JoiningYearValidator]
        public DateTime DateOfJoining { get; set; }
        [SalaryValidator]
        public int? Salary { get; set; }
        [Required]
        [DepartmentValidator]
        public string Department { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password do not match")]
        public string RetypePassword { get; set; }
    }
}
