using EmployeeTasks.Domain.Entities;
using MediatR;
using EmployeeTasks.Application.Common.Interfaces;

namespace EmployeeTasks.Application.Users.Commands;

public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, string>
{
    private readonly IUserRepository _repository;

    public RegisterUserHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<string> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            FullName = request.FullName,
            UserName = request.UserName,
            Password = request.Password,
            PhoneNumber = request.PhoneNumber,
            Address = request.Address
        };
        return await _repository.Users_Create(user);
    }
}
