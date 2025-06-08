using EmployeeTasks.Domain.Entities;

namespace EmployeeTasks.Application.Common.Interfaces;

public interface IEmployeeTaskRepository
{
    Task<int> EmployeesTasks_Create(EmployeeTask task);
}
