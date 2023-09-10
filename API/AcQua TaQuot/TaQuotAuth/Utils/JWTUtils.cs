using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace TaQuotAuth.Utils
{
    public static class JWTUtils
    {
        private const string key = "ac5ac2fb-43d7-4cf4-92ec-64aa1534995e";
        private const string issuer = "https://localhost:7267/";
        private const string audience = "https://localhost:7262/";

        public static string GenerateToken(string user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTUtils.key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user),
            };
            var token = new JwtSecurityToken(JWTUtils.issuer,
                JWTUtils.audience,
                claims,
                expires: DateTime.Now.AddMinutes(480),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
