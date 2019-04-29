using System;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using SecretSantaApp.BusinessLogic.Services.Interfaces;
using SecretSantaApp.EfCore.Enitities;

namespace SecretSantaApp.Api.Controllers
{
    [Route("api/invites")]
    [ApiController]
    public class InvitesController : ControllerBase
    {
        private readonly IInviteService _inviteService;

        public InvitesController(IInviteService inviteService)
        {
            _inviteService = inviteService;
        }

        [HttpPost]
        public IActionResult Create(Invite invite)
        {
            try
            {
                _inviteService.Create(invite);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("send")]
        public IActionResult Send(Invite invite)
        {
            try
            {
                _inviteService.Send(invite.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetByEmailAndHash(string email, string hash)
        {
            try
            {
                var invite = _inviteService.GetByEmailAndHash(email, hash);
                return Ok(invite);
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
                _inviteService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}