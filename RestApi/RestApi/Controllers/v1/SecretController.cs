using Microsoft.AspNetCore.Mvc;
using RestApi.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Controllers.v1
{
    [ApiKeyAuth]
    public class SecretController : Controller
    {
        [HttpGet("secret")]
        public IActionResult GetSecret()
        {
            return Ok("super secret endpoint");
        }
    }
}
