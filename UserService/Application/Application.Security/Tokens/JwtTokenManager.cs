using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Application.Abstractions.Security;
using Application.Security.Configurations;
using Domain.Users;
using Microsoft.IdentityModel.Tokens;

namespace Application.Security.Tokens;

public class JwtTokenManager : ITokenManager
{
    public string CreateToken(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Login),
            new Claim(ClaimTypes.Sid, user.Id.ToString()),
        };

        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
            ApplicationConfiguration.JwtToken));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds);

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);
        return jwt;
    }
}