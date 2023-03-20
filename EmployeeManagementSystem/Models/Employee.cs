using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementSystem.Models
{
    public class Employee
    {

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(75)]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateofBirth { get; set; }
        [Required]
        [StringLength(75)]
        public string EmailAddress { get; set; }
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Error: Department is required to create an Employee. Please select a Department and try again.")]
        [ForeignKey("Department")]
        public int? DepartmentId { get;set; }

        public Department? Departments { get; set; }

        public Employee()
        {
            
        }
        public Employee(int id,string name,DateTime dateofbirth, string email,string phone,int departmentid)
        {
         Id = id;
         Name = name;
         DateofBirth = dateofbirth;
         EmailAddress = email;
         Phone = phone;
         DepartmentId = departmentid;
                
        }

    }
}
