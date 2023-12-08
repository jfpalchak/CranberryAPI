using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CranberryAPI.Models;

public class Entry
{
  public int EntryId { get; set; }

  public DateTime Date { get; set; }

  public int CravingIntensity { get; set; }

  public int CigsSmoked { get; set; }

  public string UserId { get; set; }

  [JsonIgnore]
  public ApplicationUser User { get; set; }
}