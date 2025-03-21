using CheckListBuild_BE.Configs;
using CheckListBuild_BE.Database;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Linq;

namespace CheckListBuild_BE.Controllers
{
    [Route("api")]
    [ApiController]
    public class DatabaseController : ControllerBase
    {
        private readonly ApplicationDbContext _appDBContext;
        private readonly CheckListConfiguration _checkListConfig;

        public DatabaseController(ApplicationDbContext appDBContext, IOptions<CheckListConfiguration> checkListConfig)
        {
            _appDBContext = appDBContext;
            _checkListConfig = checkListConfig.Value;
        }

        [HttpPost("/createDB")]
        public async Task<IActionResult> CreateDatabaseAsync()
        {
            try
            {
                var collections = _appDBContext.Database.ListCollectionNames().ToList();

                var collectionsToCreate = new Dictionary<string, string>
        {
            { "CheckList", _checkListConfig.CheckListCollection },
            { "CheckListItems", _checkListConfig.CheckListItemCollection },
            { "UserListItems", _checkListConfig.UsersCollection },
            { "Departments", _checkListConfig.DepartmentsCollection }, 
            { "JobTitles", _checkListConfig.JobTitlesCollection },
            { "Permissions", _checkListConfig.PermissionsCollection },
            { "PermissionDetails", _checkListConfig.PermissionDetailsCollection },
            { "Countries", _checkListConfig.CountriesCollection }
        };

                foreach (var collection in collectionsToCreate)
                {
                    if (string.IsNullOrEmpty(collection.Value))
                    {
                        return BadRequest($"Collection {collection.Key} không được để trống trong cấu hình!");
                    }

                    if (!collections.Contains(collection.Value))
                    {
                        _appDBContext.Database.CreateCollection(collection.Value);
                    }
                    else
                    {
                        return BadRequest($"Collection {collection.Value} đã tồn tại!");
                    }
                }

                return Ok("Database và tất cả Collection đã được tạo thành công!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



        // delete DB
        [HttpDelete("/deleteDB")]
        public async Task<IActionResult> DeleteDatabaseAsync()
        {
            try
            {
                var collections = _appDBContext.Database.ListCollectionNames().ToList();
                if (collections.Contains(_checkListConfig.CheckListCollection))
                {
                    _appDBContext.Database.DropCollection("CheckList");
                }
                else
                {
                    return BadRequest("Collection CheckList không tồn tại!");
                }
                if (collections.Contains(_checkListConfig.CheckListItemCollection))
                {
                    _appDBContext.Database.DropCollection("CheckListItems");
                }
                else
                {
                    return BadRequest("Collection CheckListItems không tồn tại!");
                }
                return Ok("Database và Collection đã được xóa thành công!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
