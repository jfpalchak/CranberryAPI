using System.ComponentModel.DataAnnotations;

namespace CranberryAPI.Models;

public class SendMailDto
{
  [Required]
  [EmailAddress]
  public string Receiver { get; set; }

  [Required]
  public string Header { get; set; }

  [Required]
  public string Body { get; set; }
}
