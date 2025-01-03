using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CarDealershipAPI.Core.Services
{
    public class TokenGenerator
    {
        public string GenerateToken( string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = "US2BlUEkNFMy8yl0t6subj3cJKhAm7kQ7Asg7-mSwq0"u8.ToArray();

            var claims = new List<Claim>
            {
                //new(JwtRegisteredClaimNames.Sub, fullname.ToString()),
                 new(JwtRegisteredClaimNames.Email, email.ToString())
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(60),
                Issuer = "https://localhost:7129",
                Audience = "http://localhost:4200/",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
