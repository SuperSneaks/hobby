using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HuntingWeb.Controllers
{
    [Route("api/HuntingAPI")]
    [ApiController]
    public class HuntingAPIController : ControllerBase
    {
        //GET: api/Test
        [HttpGet]
        public string Test()
        {
            return "Test";
        }
    }
}