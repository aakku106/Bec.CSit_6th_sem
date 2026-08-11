using System.ComponentModel.DataAnnotations;
namespace learnMVC.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string password;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime DOB { get; set; }
    }
}