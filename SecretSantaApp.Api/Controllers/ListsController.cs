using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers.Internal;
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
                return Ok("Successful");
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
        [Route("owner/{id}")]
        public IActionResult GetByOwner(long id)
        {
            try
            {
                var lists = _listService.GetAllByOwner(id);
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
                return Ok("Successful");
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
                return Ok("Successful");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}