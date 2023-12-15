
namespace CranberryAPI.Models;

public class UpdateUserDto
{
  public string QuitDate { get; set; }
  public int AvgSmokedDaily { get; set; }
  public float PricePerPack { get; set; }
  public int CigsPerPack { get; set; }
}