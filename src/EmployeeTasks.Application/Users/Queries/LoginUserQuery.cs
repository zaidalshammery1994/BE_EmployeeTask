using MediatR;

namespace EmployeeTasks.Application.Users.Queries;

public record LoginUserQuery(string UserName, string Password) : IRequest<string?>;
