using API.DTOs;
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

    public async Task<List<PersonDto>> GetAllAsync()
{
    return await _repository.GetAllAsync();
}

    public async Task<PersonDto?> GetByIdAsync(int id)
{
    return await _repository.GetByIdAsync(id);
}

    public async Task<PersonDto> AddAsync(CreatePersonDto dto)
{
    return await _repository.AddAsync(dto);
}

    public async Task<bool> UpdateAsync(int id, UpdatePersonDto dto)
{
    return await _repository.UpdateAsync(id, dto);
}

    public async Task<bool> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }
}