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

    // GET: api/people
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var people = await _service.GetAllAsync();
        return Ok(people);
    }

    // GET: api/people/1
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var person = await _service.GetByIdAsync(id);

        if (person == null)
            return NotFound();

        return Ok(person);
    }

    // POST: api/people
    [HttpPost]
    public async Task<IActionResult> Add(Person person)
    {
        var result = await _service.AddAsync(person);

        return CreatedAtAction(
            nameof(GetById),
            new { id = result.Id },
            result
        );
    }

    // PUT: api/people/1
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Person person)
    {
        var result = await _service.UpdateAsync(id, person);

        if (!result)
            return NotFound();

        return NoContent();
    }

    // DELETE: api/people/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _service.DeleteAsync(id);

        if (!result)
            return NotFound();

        return NoContent();
    }
}