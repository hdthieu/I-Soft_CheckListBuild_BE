using CheckListBuild_BE.Database;
using CheckListBuild_BE.Entities;
using MongoDB.Driver;

namespace CheckListBuild_BE.service.impl
{
    public class CheckListItemServiceImpl : ICheckListItem
    {
        private readonly IMongoCollection<CheckListItem> _cListItem;

        public CheckListItemServiceImpl(ApplicationDbContext dbContext)
        {
            _cListItem = dbContext.GetCollection<CheckListItem>("CheckListItems");
        }

        public async Task<List<CheckListItem>> GetAll()
        {
            return await _cListItem.Find(_ => true).ToListAsync();
        }
        public async Task Create(CheckListItem checkListItem)
        {
            if (checkListItem == null)
            {
                return;
            }
            await _cListItem.InsertOneAsync(checkListItem);
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<CheckListItem> Get(string id)
        {
            throw new NotImplementedException();
        }

      

        public Task<CheckListItem> Update(string id, CheckListItem checkListItem)
        {
            throw new NotImplementedException();
        }
    }
}
