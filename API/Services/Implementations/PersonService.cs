using API.Models;
using API.Repositories.Interfaces;
using API.Services.Interfaces;

namespace API.Services.Implementations;

public class PersonService : IPersonService
{
    private readonly IPersonRepository _repository;

    public PersonService(IPersonRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Person>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Person?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<Person> AddAsync(Person person)
    {
        return await _repository.AddAsync(person);
    }

    public async Task<bool> UpdateAsync(int id, Person person)
    {
        return await _repository.UpdateAsync(id, person);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }
}