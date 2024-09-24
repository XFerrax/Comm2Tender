using Comm2Tender.Logic;
using Comm2Tender.Logic.Constants;
using Comm2Tender.Logic.Models;
using Comm2Tender.Logic.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Comm2Tender.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly ILogicServiceCrud LogicService;

        public UserController(ILogicService logicService)
        {
            LogicService = (ILogicServiceCrud)logicService;
        }

        // POST User/Search
        [HttpPost("[action]")]
        public ActionResult<string> Search([FromBody] ListRequest listRequest)
        {
            return Ok(LogicService.SearchUser(listRequest));
        }

        [HttpGet("get_user/{id:int}")]
        public ActionResult<string> GetUser(int id) 
        {
            try
            {
                return Ok(LogicService.GetUser(id));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // POST User
        [HttpPost]
        public ActionResult<string> Post([FromBody] User model)
        {
            try
            {
                return Ok(LogicService.AddUser(model));
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
        }

        // PUT User/5
        //[HttpPut("{id:int:min(1)}")]
        [HttpPut]
        public ActionResult<string> Put([FromBody] User model)
        {
            //model.UserId = id;
            if (LogicService.UpdateUser(model))
            {
                return Ok();
            }
            return new NotFoundResult();
        }

        // DELETE User/5
        [HttpDelete("delete_user/{id:int:min(1)}")]
        public ActionResult<string> Delete(int id)
        {
            if (LogicService.DeleteUser(id))
            {
                return Ok();
            }
            return new NotFoundResult();
        }
    }
}
