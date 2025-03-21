using CheckListBuild_BE.Entities;
using CheckListBuild_BE.service;
using CheckListBuild_BE.service.impl;
using Microsoft.AspNetCore.Mvc;

namespace CheckListBuild_BE.Controllers
{
    [Route("api/checklist/")]
    [ApiController]

    public class CheckListController : ControllerBase
    {
        private readonly ICheckListService _checkList;
        public CheckListController(ICheckListService checkList)
        {
            _checkList = checkList;
        }
        [HttpPost("add")]
        public async Task<IActionResult> Create([FromBody] CheckList checkList)
        {
            if(checkList == null)
            {
                return BadRequest("CheckList no empty");
            }
            await _checkList.Create(checkList);
            return Ok("Added Successfully");
        }

        [HttpGet("get")]
        public async Task<ActionResult<List<CheckList>>> Get()
        {
            return await _checkList.GetAll();
        }
        //[HttpGet("{id:length(24)}", Name = "GetCheckListItem")]
        //public async Task<ActionResult<CheckListItem>> Get(string id)
        //{
        //    var checkListItem = await _checkList.Get(id);
        //    if (checkListItem == null)
        //    {
        //        return NotFound();
        //    }
        //    return checkListItem;
        //}
       
        //[HttpPut("{id:length(24)}")]
        //public async Task<IActionResult> Update(string id, CheckListItem checkListItemIn)
        //{
        //    var checkListItem = await _checkList.Get(id);
        //    if (checkListItem == null)
        //    {
        //        return NotFound();
        //    }
        //    await _checkList.Update(id, checkListItemIn);
        //    return NoContent();
        //}
        //[HttpDelete("{id:length(24)}")]
        //public async Task<IActionResult> Delete(string id)
        //{
        //    var checkListItem = await _checkList.Get(id);
        //    if (checkListItem == null)
        //    {
        //        return NotFound();
        //    }
        //    _checkListItem.Delete(checkListItem.Id);
        //    return NoContent();
        //}
    }
}
