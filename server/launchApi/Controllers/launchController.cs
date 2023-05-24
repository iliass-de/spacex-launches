using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace launchApi.Controllers;

[ApiController]
[Route("[controller]")]
public class LaunchApiController : ControllerBase
{

    private readonly ILogger<LaunchApiController> _logger;
    private readonly HttpClient client = new HttpClient();

    public LaunchApiController(ILogger<LaunchApiController> logger)
    {
        _logger = logger;
    }

    [Route("Launches")]
    public async Task<Object> GetLaunches()
    {
        var response = await client.GetAsync("https://api.spacexdata.com/v4/launches");
        if(response.IsSuccessStatusCode ){
            var launches = await response.Content.ReadFromJsonAsync<Object>();
            return launches;
        }
        return StatusCode(404);
    }

    [Route("past")]
    public async Task<Object> GetPastLaunches()
    {
        var response = await client.GetAsync("https://api.spacexdata.com/v3/launches/past");
        if(response.IsSuccessStatusCode ){
            var launches = await response.Content.ReadFromJsonAsync<Object>();
            return launches;
        }
        return StatusCode(404);
    }

    [Route("launch/{id}")]
    public async Task<Object> GetLaunchById(int id)
    {
        var response = await client.GetAsync($"https://api.spacexdata.com/v3/launches/{id}");
        if(response.IsSuccessStatusCode ){
            var launch = await response.Content.ReadFromJsonAsync<Object>();
            return launch;
        }
        return StatusCode(404);
    }

        [Route("upcoming")]
    public async Task<Object> GetUpcomingLaunches()
    {
        var response = await client.GetAsync("https://api.spacexdata.com/v3/launches/upcoming");
        if(response.IsSuccessStatusCode ){
            var launches = await response.Content.ReadFromJsonAsync<Object>();
            return launches;
        }
        return StatusCode(404);
    }
}
