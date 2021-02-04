using API.Models.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace API.Services
{
    public class Token
    {
        public static string CreateToken(IConfiguration config, User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["SecurityKey"]));

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var jwToken = new JwtSecurityToken
            (
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: credential
            );

            var token = new JwtSecurityTokenHandler().WriteToken(jwToken);

            return token;
        }

    }
}
