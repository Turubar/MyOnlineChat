using RegistrationService.DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<UsersDbContext>();

var app = builder.Build();

app.MapControllers();

app.Run();
