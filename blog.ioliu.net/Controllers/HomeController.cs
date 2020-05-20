using blog.ioliu.net.Db;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blog.ioliu.net.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class HomeController:ControllerBase
    {
        
        [HttpGet]
        
        public string Index()
        {
            
            return "Hello World";
        }
    }
}
