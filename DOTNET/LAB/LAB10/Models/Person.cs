using System.ComponentModel.DataAnnotations;

namespace Lab10.Models;

public class Person
{
    [Required, MaxLength(50)]
    public string Name { get; set; } = "";
    [Required, EmailAddress]
    public string Email { get; set; } = "";
    [Required, Range(18, 100)]
    public int Age { get; set; }
}
