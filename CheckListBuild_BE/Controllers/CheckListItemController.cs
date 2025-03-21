using CheckListBuild_BE.Entities;
using CheckListBuild_BE.service;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CheckListBuild_BE.Controllers
{
    [Route("api/checklistitem/")]
    [ApiController]
    public class CheckListItemController : ControllerBase
    {
        private readonly ICheckListItem _cListItem;

        public CheckListItemController(ICheckListItem cListItem)
        {
            _cListItem = cListItem;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Create([FromBody] CheckListItem checkListItem)
        {
            if (checkListItem == null)
            {
                return BadRequest("CheckList no empty");
            }
            await _cListItem.Create(checkListItem);
            return Ok("Added Successfully");
        }

        [HttpGet("get")]
        public async Task<ActionResult<List<CheckListItem>>> Get()
        {
            return await _cListItem.GetAll();
        }
    }


}
