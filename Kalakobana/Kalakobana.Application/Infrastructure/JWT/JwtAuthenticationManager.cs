using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Kalakobana.Application.Infrastructure.JWT
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
        private readonly string _key;
        public JwtAuthenticationManager(string key)
        {
            _key = key;
        }

        public string Authenticate(bool status, string email, List<string> roles)
        {
            if (status)
            {
                var claims = new List<Claim>();

                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }
                claims.Add(new Claim(ClaimTypes.Email, email));
                var tokeKey = Encoding.ASCII.GetBytes(_key);
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenDescription = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(claims),
                    //Token Life Time
                    Expires = DateTime.UtcNow.AddHours(5),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokeKey), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescription);
                return tokenHandler.WriteToken(token);
            }
            return string.Empty;
        }
    }
}
