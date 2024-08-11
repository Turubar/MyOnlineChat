using Microsoft.AspNetCore.Identity;
using RegistrationService.Application;
using RegistrationService.DataAccess;
using RegistrationService.DataAccess.Repositories;
using RegistrationService.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<UsersDbContext>();
builder.Services.AddScoped<IUserValidationService, UserValidationService>();
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

app.MapControllers();

app.Run();
