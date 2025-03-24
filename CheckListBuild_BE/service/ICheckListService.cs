using CheckListBuild_BE.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CheckListBuild_BE.service
{
    public interface ICheckListService
    {
        // crud operations
        Task Create(CheckList checkList);
        Task<CheckList> Get(string id);
        Task<List<CheckList>> GetAll();
        Task<CheckList> Update(string id, CheckList checkList);
        void Delete(string id);
        Task<List<CheckList>> GetByUserId(string userId);


    }
}
