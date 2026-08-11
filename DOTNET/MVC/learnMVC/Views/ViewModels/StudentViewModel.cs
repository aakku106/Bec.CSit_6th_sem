using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace MCProgramStartup.Views.ViewModels
{
    public class StudentViewModelPost
    {
        [Required] public string FirstName { get; set; } = string.Empty;
        [Required] public string LastName { get; set; } = string.Empty;
        [Required][EmailAddress] public string Email { get; set; } = string.Empty;
        [Required][DataType(DataType.Password)] public string Password { get; set; } = string.Empty;
        [Required][DataType(DataType.Password)][Compare("Password")] public string ConfirmPassword { get; set; } = string.Empty;
        [Required][DataType(DataType.Date)] public DateTime DOB { get; set; }

        [SimpleClassName] public string wotEver { get; set; } = string.Empty;

    }
}