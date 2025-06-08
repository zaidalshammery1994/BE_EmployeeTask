using System.Data;
using Microsoft.Data.SqlClient;
using EmployeeTasks.Api.Endpoints;
using EmployeeTasks.Application;
using EmployeeTasks.Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using EmployeeTasks.Application.Common.Interfaces;
using EmployeeTasks.Application.Users.Commands;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("Jwt"));
var jwtOptions = builder.Configuration.GetSection("Jwt").Get<JwtOptions>() ?? new JwtOptions();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtOptions.Issuer,
            ValidAudience = jwtOptions.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Key))
        };
    });

builder.Services.AddAuthorization();
builder.Services.AddMediatR(typeof(EmployeeTasks.Application.Users.Commands.RegisterUserCommand).Assembly);

builder.Services.AddTransient<IDbConnection>(sp => new SqlConnection(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IEmployeeTaskRepository, EmployeeTaskRepository>();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapAuthenticationEndpoints();
app.MapEmployeeTaskEndpoints();

app.Run();
