using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HuntingWeb.Controllers
{
    public class DefaultHuntingController : Controller
    {
        // 
        // GET: /DefaultHunting/

        public IActionResult Index()
        {
            return View("~/Views/HuntingWeb/Index.cshtml");
        }

        // 
        // GET: /DefaultHunting/Welcome/ 

        public string Welcome()
        {
            return "This is the Welcome action method...";
        }
    }
}