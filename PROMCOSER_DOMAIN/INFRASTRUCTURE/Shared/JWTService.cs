using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PROMCOSER_DOMAIN.CORE.Entities;
using PROMCOSER_DOMAIN.CORE.Interfaces;
using PROMCOSER_DOMAIN.CORE.Settings;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PROMCOSER_DOMAIN.INFRASTRUCTURE.Shared
{
    public class JWTService : IJWTService
    {
        public JWTSettings _settings { get; }

        public JWTService(IOptions<JWTSettings> settings)
        {
            _settings = settings.Value;
        }

        public string GenerateJWToken(Personal user)
        {
            var ssk = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.SecretKey));
            var sc = new SigningCredentials(ssk, SecurityAlgorithms.HmacSha256);

            var header = new JwtHeader(sc);

            var claims = new[] {
                new Claim(ClaimTypes.Name , user.Nombre),
                new Claim(ClaimTypes.Email , user.Correo),
                new Claim(ClaimTypes.DateOfBirth , user.FechNacimiento.ToString()),
                new Claim(ClaimTypes.Role , user.IdRol== 1 ? "Admin" : "Operador"),
                new Claim("PersonalId" , user.IdPersonal.ToString()),
            };

            var payload = new JwtPayload(
                            _settings.Issuer,
                            _settings.Audience,
                            claims,
                            DateTime.UtcNow,
                            DateTime.UtcNow.AddMinutes(_settings.DurationInMinutes));
            var token = new JwtSecurityToken(header, payload);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
