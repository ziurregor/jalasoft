using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TestApi.Model;
using TestApi.Services;

namespace TestApi.Controllers
{

    [Route("api/pets")]
    [ApiController]
    public class PetsController : ControllerBase
    {

        // GET api/pets
        [HttpGet]
        public ActionResult<IEnumerable<Pets>> Get()
        {
            //return new string[] { "value1", "value2" };
            return Ok(this.service.GetAll());
        }


    }



   

    // GET api/todos
    [HttpGet]
    public ActionResult<IEnumerable<Todo>> Get()
    {
        return Ok(this.service.GetAll());
    }
}
