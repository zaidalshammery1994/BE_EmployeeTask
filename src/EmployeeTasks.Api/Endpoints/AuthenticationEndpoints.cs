using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using EmployeeTasks.Application.Users.Commands;
using EmployeeTasks.Application.Users.Queries;
using MediatR;

namespace EmployeeTasks.Api.Endpoints;

public static class AuthenticationEndpoints
{
    public static void MapAuthenticationEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/register", async (RegisterUserCommand command, IMediator mediator) =>
        {
            var id = await mediator.Send(command);
            return Results.Ok(new { id });
        });

        app.MapPost("/login", async (LoginUserQuery query, IMediator mediator) =>
        {
            var token = await mediator.Send(query);
            if (token == null) return Results.Unauthorized();
            return Results.Ok(new { token });
        });
    }
}
