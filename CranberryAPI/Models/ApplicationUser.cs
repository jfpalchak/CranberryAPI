using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace CranberryAPI.Models;

public class ApplicationUser : IdentityUser
{

  // public string DisplayName { get; set; }
  public string QuitDate { get; set; }
  public int AvgSmokedDaily { get; set; }
  public float PricePerPack { get; set; }
  public int CigsPerPack { get; set; }

  [JsonIgnore]
  public List<Journal> Journals { get; set; }
}