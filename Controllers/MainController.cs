using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskManager.Controllers
{
    [Route("api/")]
    [ApiController]
    public class MainController : ControllerBase
    {
        [HttpGet("test")]
        public string testc()
        {
            return "Hello world";
        }
    }

}