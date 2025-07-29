// Step 1: Folder structure and Program.cs for driver-hos-state-api

// File: Program.cs
using driver_hos_state_api.Models;
using driver_hos_state_api.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

var builder = WebApplication.CreateBuilder(args);
// Add services
builder.Services.AddScoped<IDriverHosService, DriverHosService>();
//builder.Services.AddScoped<IDbConnection>(sp =>
//{
//    var configuration = sp.GetRequiredService<IConfiguration>();
//    var connectionString = configuration.GetConnectionString("MobileComm");
//    return new SqlConnection(connectionString);
//});

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/api/drivers/{driverCompany}/{driverNumber}",
    async Task<Results<Ok<DriverHosStateResponse>, NotFound<string>, BadRequest<string>>> (
        [FromRoute] string driverCompany,
        [FromRoute] string driverNumber,
        [FromQuery] DateTime startDate,
        [FromQuery] DateTime endDate,
        [FromQuery] string state,
        IDriverHosService hosService) =>
    {
        if (string.IsNullOrWhiteSpace(driverCompany) || string.IsNullOrWhiteSpace(driverNumber))
        {
            return TypedResults.BadRequest("Invalid driver company or number.");
        }

        var result = await hosService.GetDriverHosStateDataAsync(driverCompany, driverNumber, startDate, endDate,state);

        if (result is null || result.Records.Count == 0)
        {
            return TypedResults.NotFound("No HOS data found for the given driver.");
        }

        return TypedResults.Ok(result);
    });

app.Run();
