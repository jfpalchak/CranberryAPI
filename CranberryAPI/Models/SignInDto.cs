using System.ComponentModel.DataAnnotations;

namespace CranberryAPI.Models;

public class SignInDto
{
  [Required]
  [EmailAddress]
  public string Email { get; set; }
  [Required]
  public string Password { get; set; }
}