using Jinsei.Persistence.Database;
using Serilog;

var builder = WebApplication.CreateBuilder();

builder.Logging.ClearProviders();
builder.Host.UseSerilog();

builder.Services.AddControllers();
builder.Services.AddOptions();

builder.Services.AddJinseiDbContext();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.Run();
