using Poe.Services.Models;

namespace Poe.Services.Interfaces;

public interface IGetStashService
{
    Task<StashResponse> GetStashTabAsync();
}