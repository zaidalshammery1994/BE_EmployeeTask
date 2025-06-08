using EmployeeTasks.Domain.Entities;
using MediatR;

namespace EmployeeTasks.Application.Users.Commands;

public record RegisterUserCommand(string FullName, string UserName, string Password, string PhoneNumber, string Address) : IRequest<string>;
