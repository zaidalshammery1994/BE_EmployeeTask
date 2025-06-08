using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using EmployeeTasks.Domain.Entities;
using EmployeeTasks.Application.Common.Interfaces;

namespace EmployeeTasks.Api.Endpoints;

public static class EmployeeTaskEndpoints
{
    public static void MapEmployeeTaskEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/tasks", async (EmployeeTask task, IEmployeeTaskRepository repo) =>
        {
            var id = await repo.EmployeesTasks_Create(task);
            return Results.Ok(new { id });
        }).RequireAuthorization();
    }
}
