using API.DTOs;
using API.Models;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PeopleController : ControllerBase
{
    private readonly IPersonService _service;

    public PeopleController(IPersonService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var people = await _service.GetAllAsync();
        return Ok(people);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var person = await _service.GetByIdAsync(id);

        if (person == null)
            return NotFound();

        return Ok(person);
    }

    [HttpPost]
    public async Task<IActionResult> Add(CreatePersonDto dto)
    {
        var result = await _service.AddAsync(dto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = result.Id },
            result
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdatePersonDto dto)
    {
        var result = await _service.UpdateAsync(id, dto);

        if (!result)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _service.DeleteAsync(id);

        if (!result)
            return NotFound();

        return NoContent();
    }
}