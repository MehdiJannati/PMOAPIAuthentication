using System;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace UI.WebApi.Estates.Helpers
{
    public class TokenManager
    {
        internal static string CreateToken(string username)
        {
            DateTime issuedAt = DateTime.UtcNow;

            DateTime expires = DateTime.UtcNow.AddDays(7);

            var tokenHandler = new JwtSecurityTokenHandler();

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name,username)
            });

            string sec = ConfigurationManager.AppSettings["jwt:key"];

            var now = DateTime.UtcNow;

            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(sec));

            var signingCredential = new Microsoft.IdentityModel.Tokens.SigningCredentials(securityKey, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256);

            var token = (JwtSecurityToken)tokenHandler.CreateJwtSecurityToken(
                issuer: ConfigurationManager.AppSettings["jwt:issuer"],
                audience: ConfigurationManager.AppSettings["jwt:audience"],
                subject: claimsIdentity, notBefore: issuedAt, expires: expires, signingCredentials: signingCredential);

            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}