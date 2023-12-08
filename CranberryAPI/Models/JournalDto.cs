namespace CranberryAPI.Models;

public class JournalDto
{
    public int JournalId { get; set; }
    public DateTime Date { get; set; }
    public int CravingIntensity { get; set; }
    public int CigsSmoked { get; set; }
    public string Notes { get; set; }
}