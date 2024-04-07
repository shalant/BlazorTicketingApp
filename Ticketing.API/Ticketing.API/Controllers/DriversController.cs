using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Ticketing.DataService.Repositories.Interfaces;
using Ticketing.Entities.DbSet;
using Ticketing.Entities.Dtos.Requests;
using Ticketing.Entities.Dtos.Responses;

namespace Ticketing.API.Controllers;

public class DriversController : BaseController
{
    public DriversController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    [HttpGet]
    public async Task<IActionResult> GetAllDrivers()
    {
        var driver = await _unitOfWork.Drivers.GetAll();

        return Ok(_mapper.Map<IEnumerable<GetDriverResponse>>(driver));
    }
    
    [HttpGet]
    [Route("{driverId:Guid}")]
    public async Task<IActionResult> GetDriverById(Guid driverId)
    {
        var driver = await _unitOfWork.Drivers.GetById(driverId);

        if(driver == null)
        {
            return NotFound();
        }

        var result = _mapper.Map<GetDriverResponse>(driver);

        return Ok(result);
    }

    [HttpPost("")]
    public async Task<IActionResult> AddDriver([FromBody] CreateDriverRequest driver)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest();
        }

        var result = _mapper.Map<Driver>(driver);

        await _unitOfWork.Drivers.Add(result);
        await _unitOfWork.CompleteAsync();

        return CreatedAtAction(nameof(GetDriverById), new {driverId = result.Id}, result);
    }

    [HttpPut("")]
    public async Task<IActionResult> UpdateDriver([FromBody] UpdateDriverRequest driver)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var result = _mapper.Map<Driver>(driver);

        await _unitOfWork.Drivers.Update(result);
        await _unitOfWork.CompleteAsync();

        return NoContent();
    }

    [HttpDelete]
    [Route("{driverId:guid}")]
    public async Task<IActionResult> DeleteDriver(Guid driverId)
    {
        var driver = await _unitOfWork.Drivers.GetById(driverId);

        if (driver == null)
        {
            return NotFound();
        }

        await _unitOfWork.Drivers.Delete(driverId);
        await _unitOfWork.CompleteAsync();

        return NoContent();
    }

}
