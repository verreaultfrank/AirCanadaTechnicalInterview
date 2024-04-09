using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AirCanadaTechnicalInterview.Server.Data;
using Microsoft.Data.Sqlite;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;

// Create and open a connection. This creates the SQLite in-memory database, which will persist until the connection is closed
// at the end of the test (see Dispose below).
SqliteConnection _connection = new SqliteConnection("Filename=:memory:");
_connection.Open();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AirCanadaTechnicalInterviewServerContext>(options =>options.UseSqlite(_connection));

builder.Services.AddAuthorization();


builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<AirCanadaTechnicalInterviewServerContext>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapGet("pingauth", (ClaimsPrincipal user) =>
{
    string email = user.FindFirstValue(ClaimTypes.Email);
    return Results.Json(new { Email = email });
}).RequireAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapIdentityApi<IdentityUser>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
