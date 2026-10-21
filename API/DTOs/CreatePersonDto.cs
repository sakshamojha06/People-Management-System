namespace API.DTOs;

public class CreatePersonDto
{
    public string Name { get; set; } = string.Empty;
    public int EducationLevelId { get; set; }
    public int DegreeId { get; set; }
    public int SpecializationId { get; set; }
}