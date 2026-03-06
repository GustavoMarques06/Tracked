using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Tracked.Domain.Entities;
using Tracked.Domain.Interfaces;

namespace Tracked.Infrastructure.Security
{
    public class JWTService : IJWTService
    {
        private readonly IConfiguration _configuration;
        public JWTService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GerarToken(Usuario usuario)
        {
           var secretKey = _configuration["JWT:SecretKey"];
           var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

           var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

           var claims = new List<Claim>
           {
                new Claim(JwtRegisteredClaimNames.Sub, usuario.Id.ToString()), 
                new Claim(JwtRegisteredClaimNames.Email, usuario.Email),        
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), 
                new Claim("nome", usuario.Nome)
           };

           var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
           );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
