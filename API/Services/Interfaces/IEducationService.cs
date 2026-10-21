using API.Models;

namespace API.Services.Interfaces;

public interface IEducationService
{
    Task<List<EducationLevel>> GetEducationLevelsAsync();

    Task<List<Degree>> GetDegreesByEducationLevelAsync(int educationLevelId);

    Task<List<Specialization>> GetSpecializationsByDegreeAsync(int degreeId);
}