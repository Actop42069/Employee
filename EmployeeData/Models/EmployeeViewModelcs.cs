using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeData.Models
{
    public class EmployeeViewModelcs
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        [DisplayName("First Name")]
        public string LastName { get; set; }
        [DisplayName("Last Name")]
        public DateTime DateOfBirth { get; set; }
        [DisplayName("Date Of Birth")]
        public string Email { get; set; }
        public double Salary { get; set; }

        [DisplayName("Name")]
        public string FullName {
            get { return FirstName + " " + LastName; }
        }
        
    }
}
