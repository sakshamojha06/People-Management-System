namespace API.Models;

public class Degree
{
    public int Id { get; set; }

    public int EducationLevelId { get; set; }

    public string Name { get; set; } = string.Empty;

    public EducationLevel? EducationLevel { get; set; }

    public ICollection<Specialization> Specializations { get; set; }
        = new List<Specialization>();
}