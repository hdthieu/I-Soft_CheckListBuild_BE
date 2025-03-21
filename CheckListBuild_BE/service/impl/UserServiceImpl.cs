using CheckListBuild_BE.Database;
using CheckListBuild_BE.Entities;
using MongoDB.Driver;

namespace CheckListBuild_BE.service.impl
{
    public class UserServiceImpl : IUserService
    {
        private readonly IMongoCollection<User> _userCollection;
        public UserServiceImpl(ApplicationDbContext dbContext)
        {
            _userCollection = dbContext.GetCollection<User>("UserListItems");
        }

        public async Task<List<User>> GetAll()
        {
            return await _userCollection.Find(_ => true).ToListAsync();
        }
        public async Task Create(User user)
        {
            if (user == null)
            {
                return;
            }
            await _userCollection.InsertOneAsync(user);
        }

    }
}



//{
//    "name": "John Doe",
//  "email": "john@example.com",
//  "password": "123456",
//  "role": "User",
//  "checkLists": []
//}
