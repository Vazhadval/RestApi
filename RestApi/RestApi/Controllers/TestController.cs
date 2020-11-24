using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Controllers
{
    public class TestController : Controller
    {
        [HttpGet("api/user")]
        public IActionResult GetAll()
        {
            return Ok(new { name = "Vazha" });
        }
    }
}
