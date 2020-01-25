using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestWebApiWithTests.Models;

namespace RestWebApiWithTests.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public ActionResult<string> Index()
        {
            return Ok("Received");
        }

        [HttpGet("TodoItems")]
        [AllowAnonymous]
        public ActionResult<List<TodoItem>> TodoItems()
        {
            var list = new List<TodoItem>();
            return Ok(list);
        }

    }
}