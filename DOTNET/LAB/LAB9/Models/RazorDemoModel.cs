using System.ComponentModel.DataAnnotations;

namespace Lab9.Models;

public class RazorDemoModel
{
    [Required]
    public string Name { get; set; } = "";
    [Required, EmailAddress]
    public string Email { get; set; } = "";
}
