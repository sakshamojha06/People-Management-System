using API.Data;
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

    public async Task<List<Person>> GetAllAsync()
    {
        return await _context.People
            .Include(p => p.EducationLevel)
            .Include(p => p.Degree)
            .Include(p => p.Specialization)
            .ToListAsync();
    }

    public async Task<Person?> GetByIdAsync(int id)
    {
        return await _context.People
            .Include(p => p.EducationLevel)
            .Include(p => p.Degree)
            .Include(p => p.Specialization)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Person> AddAsync(Person person)
    {
        _context.People.Add(person);

        await _context.SaveChangesAsync();

        return person;
    }

    public async Task<bool> UpdateAsync(int id, Person person)
    {
        var existingPerson = await _context.People.FindAsync(id);

        if (existingPerson == null)
            return false;

        existingPerson.Name = person.Name;
        existingPerson.EducationLevelId = person.EducationLevelId;
        existingPerson.DegreeId = person.DegreeId;
        existingPerson.SpecializationId = person.SpecializationId;

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