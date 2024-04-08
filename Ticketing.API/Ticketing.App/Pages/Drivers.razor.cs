using Microsoft.AspNetCore.Components;
using Ticketing.Entities.Dtos.Responses;
using Ticketing.App.Services.Interfaces;

namespace Ticketing.App.Pages;

public partial class Drivers
{
    [Inject]
    private IDriverService _driverService {  get; set; }

    public IEnumerable<GetDriverResponse> _drivers { get; set; } = new List<GetDriverResponse>();

    protected async override Task OnInitializedAsync()
    {
        var drivers = await _driverService.GetDrivers();
        if (drivers?.Count != 0)
        {
            _drivers = drivers;
        }
    }
}