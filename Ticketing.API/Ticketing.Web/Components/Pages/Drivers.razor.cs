using Microsoft.AspNetCore.Components;
using System.Runtime.CompilerServices;
using Ticketing.Entities.DbSet;
using Ticketing.Entities.Dtos.Responses;
using Ticketing.Web.Services.Interfaces;

namespace Ticketing.Web.Components.Pages;

public partial class Drivers
{
    [Inject]
    private IDriverService _driverService {  get; set; }

    public IEnumerable<GetDriverResponse> _drivers { get; set; } = new List<GetDriverResponse>();

    //protected async override Task OnInitializedAsync()
    //{
    //    var drivers = await _driverService.GetDrivers();
    //    if(drivers.Count != 0)
    //    {
    //        _drivers = drivers;
    //    }
    //}
}