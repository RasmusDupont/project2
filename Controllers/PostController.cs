using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI;

namespace Project2.Controllers
{
    [Route("api/[controller]")]
    public class PostController : Controller
    {
        private DataService dataService;

        public PostController(DataService dataService)
        {
            this.dataService = dataService;
        }

        [HttpGet("{id}")]
        public IActionResult GetQuestionWithAnswersByPostId(int id)
        {
            return Ok(dataService.PostRepository.GetQuestionWithAnswersByPostId(id));
        }

        [HttpPost("/mark/{id}")]
        public IActionResult Mark(int id)
        {
            return Ok("Ok");
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }


        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
