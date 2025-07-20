using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Poe.Services.Interfaces;

namespace Poe.Functions.Triggers.HttpTriggers;

public class SyncStashTabs(ILogger<SyncStashTabs> logger, IGetStashService getStashService)
{
    [Function("SyncStashTabs")]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
    {
        
        var x = await getStashService.GetStashTabAsync();
        logger.LogInformation("C# HTTP trigger function processed a request.");
        return new OkObjectResult("Welcome to Azure Functions!");
        
    }

}