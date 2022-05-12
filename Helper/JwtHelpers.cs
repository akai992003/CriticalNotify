using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace CriticalNotify.Helper;

public class JwtHelpers
{
    public JwtHelpers() { }

    public string GenerateToken(string issuer, string signKey, string UserId, string UserName, int expirehour, string UserRole, string que, string UserType)
    {

        var claims = new[] {
            new Claim (ClaimTypes.Name, UserName),
                new Claim (ClaimTypes.Sid, UserId),
                new Claim (ClaimTypes.Role, UserRole),
                new Claim (ClaimTypes.PrimarySid, que),
                new Claim (ClaimTypes.GivenName, UserType),
        };

        ClaimsIdentity subject = new ClaimsIdentity(claims);

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signKey));
        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

        SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
        {
            Issuer = issuer,
            Subject = subject,
            Expires = DateTime.Now.AddHours(expirehour),
            SigningCredentials = signingCredentials
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.CreateToken(tokenDescriptor);
        var serializeToken = tokenHandler.WriteToken(securityToken);
        return serializeToken;
    }
}