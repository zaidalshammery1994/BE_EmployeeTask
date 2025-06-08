using EmployeeTasks.Application.Common.Interfaces;
using MediatR;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace EmployeeTasks.Application.Users.Queries;

public class LoginUserHandler : IRequestHandler<LoginUserQuery, string?>
{
    private readonly IUserRepository _repository;
    private readonly JwtOptions _options;

    public LoginUserHandler(IUserRepository repository, IOptions<JwtOptions> options)
    {
        _repository = repository;
        _options = options.Value;
    }

    public async Task<string?> Handle(LoginUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _repository.Users_GetByUserName(request.UserName);
        if (user == null || user.Password != request.Password)
        {
            return null;
        }

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.UserID ?? string.Empty),
            new Claim(ClaimTypes.Name, user.UserName ?? string.Empty)
        };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Key));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            issuer: _options.Issuer,
            audience: _options.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(30),
            signingCredentials: creds);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
