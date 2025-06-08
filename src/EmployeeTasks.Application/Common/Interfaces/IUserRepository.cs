using EmployeeTasks.Domain.Entities;

namespace EmployeeTasks.Application.Common.Interfaces;

public interface IUserRepository
{
    Task<string> Users_Create(User user);
    Task<User?> Users_GetByUserName(string userName);
}
