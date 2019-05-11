using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SecretSantaApp.BusinessLogic.Services.Interfaces;
using SecretSantaApp.EfCore.Enitities;

namespace SecretSantaApp.Api.Controllers
{
    [Route("api/groups")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupsController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpPost]
        public IActionResult Create(Group group)
        {
            try
            {
                var newGroup = _groupService.Create(group);
                var json = JsonConvert.SerializeObject(newGroup, Formatting.None,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
                return Ok(json);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var groups = _groupService.GetAll();
                return Ok(groups);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetOneById(int id)
        {
            try
            {
                var group = _groupService.GetById(id);
                return Ok(group);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("foruser/{userId}")]
        public IActionResult GetAllByUserId(long userId)
        {
            try
            {
                var groups = _groupService.GetAllByUser(userId);
                var json = JsonConvert.SerializeObject(groups, Formatting.None,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
                return Ok(json);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(long id, [FromBody] Group group)
        {
            try
            {
                _groupService.Update(group);
                return Ok(group);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(long id)
        {
            try
            {
                _groupService.Delete(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}