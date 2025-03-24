using CheckListBuild_BE.Entities;
using CheckListBuild_BE.service;
using CheckListBuild_BE.service.impl;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<List<CheckList>>> GetByUser(string userId)
        {
            Debug.WriteLine(" Received userId: " + userId);
            var checkLists = await _checkList.GetByUserId(userId);
            Debug.WriteLine(" Fetched CheckLists: " + (checkLists?.Count ?? 0));

            if (checkLists == null || checkLists.Count == 0)
            {
                return NotFound("User chưa có CheckList nào.");
            }
            return Ok(checkLists);
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
