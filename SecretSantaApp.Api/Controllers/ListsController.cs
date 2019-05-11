using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers.Internal;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using Newtonsoft.Json;
using SecretSantaApp.Api.Models;
using SecretSantaApp.BusinessLogic.Services.Interfaces;
using SecretSantaApp.EfCore.Enitities;

namespace SecretSantaApp.Api.Controllers
{
    [Route("api/lists")]
    [ApiController]
    public class ListsController : ControllerBase
    {
        private readonly IListService _listService;

        public ListsController(IListService listService)
        {
            _listService = listService;
        }

        [HttpPost]
        public IActionResult Create(List list)
        {
            try
            {
                _listService.Create(list);
                return Ok(new { Message = "Successful" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetOne(long id)
        {
            try
            {
                var list = _listService.GetOne(id);
                var json = JsonConvert.SerializeObject(list, Formatting.None,
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
        [Route("group/{id}")]
        public IActionResult GetByGroup(long id)
        {
            try
            {
                var lists = _listService.GetAllByGroup(id);
                var json = JsonConvert.SerializeObject(lists, Formatting.None,
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
        [Route("owner/{ownerId}/group/{groupId}")]
        public IActionResult GetByOwner(long ownerId, long groupId)
        {
            try
            {
                var lists = _listService.GetAllByOwner(ownerId, groupId);
                var json = JsonConvert.SerializeObject(lists, Formatting.None,
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
        public IActionResult Update(List list)
        {
            try
            {
                _listService.Update(list);
                return Ok(new { Message = "Successful" });
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
                _listService.Delete(id);
                return Ok(new { Message = "Successful" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("group/{id}/assign")]
        public IActionResult AssignSantas(long id)
        {
            try
            {
                _listService.AssignListsToSantas(id);
                return Ok(new { Message = "Successful" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}