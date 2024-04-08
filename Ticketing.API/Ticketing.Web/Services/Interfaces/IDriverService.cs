using Ticketing.Entities.Dtos.Requests;
using Ticketing.Entities.Dtos.Responses;

namespace Ticketing.Web.Services.Interfaces;

public interface IDriverService
{
    Task<List<GetDriverResponse>?> GetDrivers();
    Task<GetDriverResponse?> GetDriverById(Guid id);
    Task<GetDriverResponse?> AddDriver(CreateDriverRequest driver);
    Task<bool> UpdateDriver(UpdateDriverRequest driver);
    Task<bool> DeleteDriver(Guid id);
}
