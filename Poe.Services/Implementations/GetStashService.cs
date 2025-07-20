using System.Text.Json;
using Poe.Services.Interfaces;
using Poe.Services.Models;

namespace Poe.Services.Implementations;

public class GetStashService(HttpClient _client) : IGetStashService
{
    public async Task<StashResponse> GetStashTabAsync()
    {
        var response = await _client.GetAsync("/stash/Mercenaries");
        var jsonResponse = await response.Content.ReadAsStringAsync();
        
        var stashTab = JsonSerializer.Deserialize<StashResponse>(jsonResponse);

        return stashTab;
    }
}