namespace API.DTOs;

public class PersonDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public int EducationLevelId { get; set; }
    public string EducationLevel { get; set; } = string.Empty;

    public int DegreeId { get; set; }
    public string Degree { get; set; } = string.Empty;

    public int SpecializationId { get; set; }
    public string Specialization { get; set; } = string.Empty;
}