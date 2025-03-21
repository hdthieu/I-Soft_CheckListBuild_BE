using CheckListBuild_BE.DTOs;
using CheckListBuild_BE.Entities;

namespace CheckListBuild_BE.service
{
    public interface IAuthService
    {
        User Authenticate(string username, string password);
        string GenerateJwtToken(User user);
    }
}


