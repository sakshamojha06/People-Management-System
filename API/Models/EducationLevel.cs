namespace API.Models;

public class EducationLevel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Degree> Degrees { get; set; } = new List<Degree>();
}