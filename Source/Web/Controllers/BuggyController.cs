using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSBRackets;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Models;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuggyController : ControllerBase
    {
        private readonly Logic _logic;
        public BuggyController(Logic logic)
        {
            _logic = logic;
        }

        //[Authorize]
        // look at this
        [HttpGet("auth")]
        public ActionResult<string> GetAuth()
        {
            return Unauthorized("Unauthorized.");
        }

        [HttpGet("not-found")]
        public ActionResult<AppUser> GetNotFound()
        {
            AppUser user = _logic.GetUserByIdNonAsync(-1);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet("server-error")]
        public ActionResult<string> GetServerError()
        {

                AppUser user = _logic.GetUserByIdNonAsync(-1);
                var exc = user.ToString();
                return exc;
        }

        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest("Bad Request.");
        }
    }
}
