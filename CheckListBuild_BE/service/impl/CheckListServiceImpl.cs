using CheckListBuild_BE.Database;
using CheckListBuild_BE.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CheckListBuild_BE.service.impl
{
    public class CheckListServiceImpl : ICheckListService
    {
        private readonly IMongoCollection<CheckList> _cListCollection;

        public CheckListServiceImpl(ApplicationDbContext dbContext)
        {
            _cListCollection = dbContext.GetCollection<CheckList>("CheckList");
        }
        public async Task<List<CheckList>> GetAll()
        {
            return await _cListCollection.Find(_ => true).ToListAsync();
        }
        public async Task Create(CheckList checkList)
        {
                if (checkList == null)
                {
                    return;
                }
                await _cListCollection.InsertOneAsync(checkList);
        }

        public void Delete(string id)
        {
            var filter = Builders<CheckList>.Filter.Eq(c => c.Id, id);
            _cListCollection.DeleteOne(filter);

        }
        public async Task<CheckList> Update(string id, CheckList checkList)
        {
            var filter = Builders<CheckList>.Filter.Eq(c => c.Id, id);
            var update = Builders<CheckList>.Update
            .Set(c => c.Title, checkList.Title)
            .Set(c => c.Items, checkList.Items);
            var options = new FindOneAndUpdateOptions<CheckList>
            {
                ReturnDocument = ReturnDocument.After
            };
            return await _cListCollection.FindOneAndUpdateAsync(filter, update, options);
        }

        public Task<CheckList> Get(string id)
        {
            throw new NotImplementedException();
        }

        
    }
}
