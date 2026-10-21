using API.DTOs;
using API.Models;

namespace API.Services.Interfaces;

public interface IPersonService
{
    Task<List<PersonDto>> GetAllAsync();

    Task<PersonDto?> GetByIdAsync(int id);

    Task<PersonDto> AddAsync(CreatePersonDto dto);

    Task<bool> UpdateAsync(int id, UpdatePersonDto dto);

    Task<bool> DeleteAsync(int id);
}