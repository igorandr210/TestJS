using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using TestAPI.Models;

namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomController : ControllerBase
    {
        private readonly IHostingEnvironment _env;

        public RandomController(IHostingEnvironment env)
        {
            _env = env;
        }
        // GET api/values
        [HttpGet]

        [Produces("text/html")]
        public ActionResult<IActionResult> Get()
        {
            return PhysicalFile(_env.WebRootPath+"\\Main.html", "text/html");
        }

        // GET api/values/5
        [HttpPost]
        public ActionResult<string> Post([FromBody] MinMaxModel Json)
        {
            try
            {
                var t = new Random().Next(Json.Min, Json.Max);
                return  "Random number is: "+t.ToString()+" !";
            }
            catch
            {
                return "Error!";
            }            
        }
        
    }
}
