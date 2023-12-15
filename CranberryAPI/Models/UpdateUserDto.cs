
namespace CranberryAPI.Models;

public class UpdateUserDto
{
  public DateTime QuitDate { get; set; }
  public int AvgSmokedDaily { get; set; }
  public int PricePerPack { get; set; }
  public int CigsPerPack { get; set; }
}