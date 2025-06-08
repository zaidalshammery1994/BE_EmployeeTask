using System.Data;
using Dapper;
using EmployeeTasks.Domain.Entities;
using EmployeeTasks.Application.Common.Interfaces;

namespace EmployeeTasks.Infrastructure.Repositories;

public class EmployeeTaskRepository : IEmployeeTaskRepository
{
    private readonly IDbConnection _dbConnection;

    public EmployeeTaskRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<int> EmployeesTasks_Create(EmployeeTask task)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@EmployeeID", task.EmployeeID);
        parameters.Add("@Task", task.Task);
        return await _dbConnection.ExecuteScalarAsync<int>("EmployeesTasks_Create", parameters, commandType: CommandType.StoredProcedure);
    }
}
