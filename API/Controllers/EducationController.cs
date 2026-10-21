using API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EducationController : ControllerBase
{
    private readonly IEducationService _service;

    public EducationController(IEducationService service)
    {
        _service = service;
    }

    // GET: api/education/levels
    [HttpGet("levels")]
    public async Task<IActionResult> GetEducationLevels()
    {
        var result = await _service.GetEducationLevelsAsync();
        return Ok(result);
    }

    // GET: api/education/degrees/1
    [HttpGet("degrees/{educationLevelId}")]
    public async Task<IActionResult> GetDegrees(int educationLevelId)
    {
        var result = await _service
            .GetDegreesByEducationLevelAsync(educationLevelId);

        return Ok(result);
    }

    // GET: api/education/specializations/1
    [HttpGet("specializations/{degreeId}")]
    public async Task<IActionResult> GetSpecializations(int degreeId)
    {
        var result = await _service
            .GetSpecializationsByDegreeAsync(degreeId);

        return Ok(result);
    }
}