using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Ticketing.DataService.Repositories.Interfaces;
using Ticketing.Entities.DbSet;
using Ticketing.Entities.Dtos.Requests;
using Ticketing.Entities.Dtos.Responses;

namespace Ticketing.API.Controllers;

public class AchievementsController : BaseController
{
    public AchievementsController(
        IUnitOfWork unitOfWork, 
        IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    [HttpGet]
    [Route("{driverId:guid}")]
    public async Task<IActionResult> GetDriverAchievements(Guid driverId)
    {
        var driverAchievements = await _unitOfWork.Achievements.GetDriverAchievementsAsync(driverId);

        if(driverAchievements == null)
        {
            // check if driver exists
            return NotFound("Achievements not found");
        }

        var result = _mapper.Map<DriverAchievementResponse>(driverAchievements);

        return Ok(result);
    }

    [HttpPost("")]
    public async Task<IActionResult> AddAchievement([FromBody] CreateDriverAchievementRequest achievement)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest();
        }

        //map incoming DTO to object in DB
        var result = _mapper.Map<Achievement>(achievement);

        await _unitOfWork.Achievements.Add(result);
        await _unitOfWork.CompleteAsync();

        return CreatedAtAction(nameof(GetDriverAchievements), new {driverId = result.DriverId}, result);
    }

    [HttpPut("")]
    public async Task<IActionResult> UpdateAchievement([FromBody] UpdateDriverAchievementRequest achievement)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var result = _mapper.Map<Achievement>(achievement);

        await _unitOfWork.Achievements.Update(result);
        await _unitOfWork.CompleteAsync();

        return NoContent();
    }
}
