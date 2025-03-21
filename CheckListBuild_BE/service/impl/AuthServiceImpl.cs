using CheckListBuild_BE.Configs;
using CheckListBuild_BE.Database;
using CheckListBuild_BE.DTOs;
using CheckListBuild_BE.Entities;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CheckListBuild_BE.service.impl
{
    public class AuthServiceImpl : IAuthService
    {
        private readonly ApplicationDbContext _dbContext;

        public AuthServiceImpl(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User Authenticate(string name, string password)
        {
            var user = _dbContext.GetCollection<User>("UserListItems")
                                 .Find(u => u.Username == name && u.Password == password)
                                 .FirstOrDefault();

            return user;

        }


        public string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(CommonConfig.AccessTokenConfig.SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                        new Claim(ClaimTypes.Name, user.Username),
                        new Claim("UserId", user.Id.ToString())
                    }),
                Expires = DateTime.UtcNow.AddSeconds(Convert.ToDouble(CommonConfig.AccessTokenConfig.ExpiredTime)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
