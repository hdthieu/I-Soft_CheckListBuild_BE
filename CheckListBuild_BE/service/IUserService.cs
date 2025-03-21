using CheckListBuild_BE.Entities;

namespace CheckListBuild_BE.service
{
    public interface IUserService
    {
        Task Create(User user);
        Task<List<User>> GetAll();
    }
}
