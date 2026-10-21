using API.Models;
using API.Repositories.Interfaces;
using API.Services.Interfaces;

namespace API.Services.Implementations;

public class EducationService : IEducationService
{
    private readonly IEducationRepository _repository;

    public EducationService(IEducationRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<EducationLevel>> GetEducationLevelsAsync()
    {
        return await _repository.GetEducationLevelsAsync();
    }

    public async Task<List<Degree>> GetDegreesByEducationLevelAsync(int educationLevelId)
    {
        return await _repository.GetDegreesByEducationLevelAsync(educationLevelId);
    }

    public async Task<List<Specialization>> GetSpecializationsByDegreeAsync(int degreeId)
    {
        return await _repository.GetSpecializationsByDegreeAsync(degreeId);
    }
}