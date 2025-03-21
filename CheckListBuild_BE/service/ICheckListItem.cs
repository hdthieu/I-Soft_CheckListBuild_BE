using CheckListBuild_BE.Entities;

namespace CheckListBuild_BE.service
{
    public interface ICheckListItem
    {
        // crud operations
        Task Create(CheckListItem checkListItem);
        Task<CheckListItem> Get(string id);
        Task<List<CheckListItem>> GetAll();
        Task<CheckListItem> Update(string id, CheckListItem checkListItem);
        void Delete(string id);
    }
}
