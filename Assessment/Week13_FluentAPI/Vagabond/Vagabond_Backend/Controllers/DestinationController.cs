using Microsoft.AspNetCore.Mvc;
using Vagabond_Backend.DTOs;
using Vagabond_Backend.HandleException;
using Vagabond_Backend.Models;
using Vagabond_Backend.Repository;

[ApiController]
[Route("api/destination")]
public class DestinationController : ControllerBase
{
    private readonly IDestinationRepository _repo;

    public DestinationController(IDestinationRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var resp = await _repo.GetAllAsync();
        return Ok(resp);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var resp = await _repo.GetByIdAsync(id);
            return Ok(resp);
        }
        catch (DestinationNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create(DestinationDto destination)
    {
        var resp = await _repo.AddAsync(destination);
        return Ok(resp);
    }

    [HttpPut]
    public async Task<IActionResult> Update(int id , DestinationDto destination)
    {
        try
        {
            var resp = await _repo.UpdateAsync(id,destination);
            return Ok(resp);
        }
        catch (DestinationNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var resp = await _repo.DeleteAsync(id);
            return Ok(resp);
        }
        catch (DestinationNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }
}