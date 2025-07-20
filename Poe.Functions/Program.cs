using System.Net.Http.Headers;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Poe.Services.Implementations;
using Poe.Services.Interfaces;

var builder = FunctionsApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("local.settings.json", optional: true, reloadOnChange: true);
builder.ConfigureFunctionsWebApplication();

var bearerToken = builder.Configuration["HttpClientSettings:Token"];

builder.Services.AddHttpClient<IGetStashService, GetStashService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["HttpClientSettings:PoeEndpoint"]);
    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", bearerToken);
    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
    client.DefaultRequestHeaders.Connection.Add("keep-alive");
    client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("PoE-Test", "1.0"));
});

builder.Services
    .AddApplicationInsightsTelemetryWorkerService()
    .ConfigureFunctionsApplicationInsights();

builder.Build().Run();
