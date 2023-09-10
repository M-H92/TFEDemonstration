using Microsoft.IdentityModel.Tokens;
using Service.Contracts;
using Shared.DataTransfertObject.Token;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Service
{
    public sealed class JWTService : IJWTService
    {

        private string _key = "";
        private readonly string _meAsIssuer = "";
        private string _audience = "";

        public JWTService(string key, string meAsIssuer, string audience)
        {
            _key = key;
            _meAsIssuer = meAsIssuer;
            _audience = audience;
        }

        public string GenerateRoleToken(CreateRoleTokenDTO dto)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, dto.User));
            foreach (var role in dto.Roles)
                claims.Add(new Claim(ClaimTypes.Role, role));
            var token = new JwtSecurityToken(this._meAsIssuer,
                this._audience,
                claims,
                expires: DateTime.Now.AddMinutes(480),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
