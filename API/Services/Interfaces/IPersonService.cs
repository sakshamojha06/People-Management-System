using API.Models;

namespace API.Services.Interfaces;

public interface IPersonService
{
    Task<List<Person>> GetAllAsync();

    Task<Person?> GetByIdAsync(int id);

    Task<Person> AddAsync(Person person);

    Task<bool> UpdateAsync(int id, Person person);

    Task<bool> DeleteAsync(int id);
}