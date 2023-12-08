using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace CranberryAPI.Models;

public class ApplicationUser : IdentityUser
{
  [JsonIgnore]
  public List<Entry> Entries { get; set; }
}