namespace API.Models;

public class Specialization
{
    public int Id { get; set; }

    public int DegreeId { get; set; }

    public string Name { get; set; } = string.Empty;

    public Degree? Degree { get; set; }
}