using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace blog.ioliu.net.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
       
        [HttpGet]
        public string Get()
        {
            return "Hello World";
        }

        [HttpGet]
        
        public string Two()
        {
            return "Two";
        }
    }
}
