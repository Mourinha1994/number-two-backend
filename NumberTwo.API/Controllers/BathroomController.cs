using Microsoft.AspNetCore.Mvc;
using NumberTwo.Core.Entities;
using NumberTwo.Core.Services;

namespace NumberTwo.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BathroomController : ControllerBase
{
    private readonly BathroomService _bathroomService;

    public BathroomController(BathroomService bathroomService)
        => _bathroomService = bathroomService;

    [HttpGet]
    public async Task<IActionResult> GetBathrooms()
    {
        var bathrooms = await _bathroomService.GetBathroomsAsync();
        return Ok(bathrooms);
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetBathroom(int id)
    {
        var bathroom = await _bathroomService.GetBathroomByIdAsync(id);

        if (bathroom == null)
            return NotFound();

        return Ok(bathroom);
    }

    [HttpPost]
    public async Task<IActionResult> AddBathroom(Bathroom bathroom)
    {
        await _bathroomService.AddBathroomAsync(bathroom);

        return CreatedAtAction(nameof(GetBathroom), new {id =  bathroom.Id}, bathroom);
    }

    [HttpPut("id")]
    public async Task<IActionResult> UpdateBathroom(int id, Bathroom bathroom)
    {
        if (id != bathroom.Id)
            return BadRequest();

        await _bathroomService.UpdateBathroomAsync(bathroom);

        return NoContent();
    }

    [HttpDelete("id")]
    public async Task<IActionResult> DeleteBathroom(int id)
    {
        await _bathroomService.DeleteBathroomAsync(id);
        return NoContent();
    }
}
