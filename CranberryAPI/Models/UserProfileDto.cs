
namespace CranberryAPI.Models;

public class UserProfileDto
{
  public string UserId { get; set; }
  public string UserName { get; set; }
  public string QuitDate { get; set; }
  public int AvgSmokedDaily { get; set; }
  public float PricePerPack { get; set; }
  public int CigsPerPack { get; set; }

  // public List<Journal> Journals { get; set; }
}