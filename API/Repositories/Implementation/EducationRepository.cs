using API.Data;
using API.Models;
using API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Implementations;

public class EducationRepository : IEducationRepository
{
    private readonly AppDbContext _context;

    public EducationRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<EducationLevel>> GetEducationLevelsAsync()
    {
        return await _context.EducationLevels.ToListAsync();
    }

    public async Task<List<Degree>> GetDegreesByEducationLevelAsync(int educationLevelId)
    {
        return await _context.Degrees
            .Where(d => d.EducationLevelId == educationLevelId)
            .ToListAsync();
    }

    public async Task<List<Specialization>> GetSpecializationsByDegreeAsync(int degreeId)
    {
        return await _context.Specializations
            .Where(s => s.DegreeId == degreeId)
            .ToListAsync();
    }
}