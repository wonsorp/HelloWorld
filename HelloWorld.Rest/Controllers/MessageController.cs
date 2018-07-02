using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HelloWorld.Rest.Model.Message;
using HelloWorld.Rest.Workflow.Message;
using Newtonsoft.Json;


namespace HelloWorld.Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        // GET: api/Message/#
        [HttpGet("{val}", Name = "Get")]
        public async Task<ActionResult> Get(int val)
        {
            var process = new ProcessHelloWorld(val);
            if (!process.ExecutionErrors.Any())
            {
                var retval = await process.Execute();
                if (retval)
                {
                    return Content(JsonConvert.SerializeObject(process.messages), "application/json");
                }
            }
            return BadRequest("error trying to retreive messages");
          }
    
    }
}
