using API.Models;

namespace API.Repositories.Interfaces;

public interface IEducationRepository
{
    Task<List<EducationLevel>> GetEducationLevelsAsync();

    Task<List<Degree>> GetDegreesByEducationLevelAsync(int educationLevelId);

    Task<List<Specialization>> GetSpecializationsByDegreeAsync(int degreeId);
}