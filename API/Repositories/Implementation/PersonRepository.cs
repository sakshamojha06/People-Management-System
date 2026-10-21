using API.Data;
using API.DTOs;
using API.Models;
using API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Implementations;

public class PersonRepository : IPersonRepository
{
    private readonly AppDbContext _context;

    public PersonRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<PersonDto>> GetAllAsync()
{
    return await _context.People
        .Include(p => p.EducationLevel)
        .Include(p => p.Degree)
        .Include(p => p.Specialization)
        .Select(p => new PersonDto
        {
            Id = p.Id,
            Name = p.Name,

            EducationLevelId = p.EducationLevelId,
            EducationLevel = p.EducationLevel!.Name,

            DegreeId = p.DegreeId,
            Degree = p.Degree!.Name,

            SpecializationId = p.SpecializationId,
            Specialization = p.Specialization!.Name
        })
        .ToListAsync();
}

    public async Task<PersonDto?> GetByIdAsync(int id)
{
    return await _context.People
        .Where(p => p.Id == id)
        .Select(p => new PersonDto
        {
            Id = p.Id,
            Name = p.Name,

            EducationLevelId = p.EducationLevelId,
            EducationLevel = p.EducationLevel!.Name,

            DegreeId = p.DegreeId,
            Degree = p.Degree!.Name,

            SpecializationId = p.SpecializationId,
            Specialization = p.Specialization!.Name
        })
        .FirstOrDefaultAsync();
}

    public async Task<PersonDto> AddAsync(CreatePersonDto dto)
{
    var person = new Person
    {
        Name = dto.Name,
        EducationLevelId = dto.EducationLevelId,
        DegreeId = dto.DegreeId,
        SpecializationId = dto.SpecializationId
    };

    _context.People.Add(person);
    await _context.SaveChangesAsync();

    return await GetByIdAsync(person.Id)
        ?? throw new Exception("Person could not be retrieved.");
}

    public async Task<bool> UpdateAsync(int id, UpdatePersonDto dto)
{
    var existingPerson = await _context.People.FindAsync(id);

    if (existingPerson == null)
        return false;

    existingPerson.Name = dto.Name;
    existingPerson.EducationLevelId = dto.EducationLevelId;
    existingPerson.DegreeId = dto.DegreeId;
    existingPerson.SpecializationId = dto.SpecializationId;

    await _context.SaveChangesAsync();

    return true;
}

    public async Task<bool> DeleteAsync(int id)
    {
        var person = await _context.People.FindAsync(id);

        if (person == null)
            return false;

        _context.People.Remove(person);

        await _context.SaveChangesAsync();

        return true;
    }
}