namespace API.Models;

public class Person
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public int EducationLevelId { get; set; }

    public int DegreeId { get; set; }

    public int SpecializationId { get; set; }

    public EducationLevel? EducationLevel { get; set; }

    public Degree? Degree { get; set; }

    public Specialization? Specialization { get; set; }
}