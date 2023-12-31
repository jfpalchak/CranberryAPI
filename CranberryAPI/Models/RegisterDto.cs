using System.ComponentModel.DataAnnotations;

namespace CranberryAPI.Models;

public class RegisterDto
{
  [Required]
  [EmailAddress]
  public string Email { get; set; }
  [Required]
  public string UserName { get; set; }
  [Required]
  public string Password { get; set; }

  public string QuitDate { get; set; }
  public int AvgSmokedDaily { get; set; }
  public float PricePerPack { get; set; }
  public int CigsPerPack { get; set; }

}