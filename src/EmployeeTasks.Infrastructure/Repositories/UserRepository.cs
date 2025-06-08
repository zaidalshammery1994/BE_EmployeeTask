using System.Data;
using Dapper;
using EmployeeTasks.Domain.Entities;
using EmployeeTasks.Application.Common.Interfaces;

namespace EmployeeTasks.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IDbConnection _dbConnection;

    public UserRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<string> Users_Create(User user)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@FullName", user.FullName);
        parameters.Add("@UserName", user.UserName);
        parameters.Add("@Password", user.Password);
        parameters.Add("@PhoneNumber", user.PhoneNumber);
        parameters.Add("@Address", user.Address);
        return await _dbConnection.ExecuteScalarAsync<string>("Users_Create", parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task<User?> Users_GetByUserName(string userName)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@UserName", userName);
        return await _dbConnection.QueryFirstOrDefaultAsync<User>("Users_GetByUserName", parameters, commandType: CommandType.StoredProcedure);
    }
}
