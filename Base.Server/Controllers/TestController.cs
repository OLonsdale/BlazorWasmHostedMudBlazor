using Base.Server.DataServices;
using Base.Shared.Statics;
using Microsoft.AspNetCore.Mvc;

namespace Base.Server.Controllers;

[ApiController]
public class TestController(TestService service) : ControllerBase
{
    [HttpGet(ApiRoutes.GetTestMessage)]
    public async Task<string> GetTestMessage()
    {
        return service.GetTestMessage();
    }
    
}