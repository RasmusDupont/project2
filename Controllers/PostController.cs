using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
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

        [HttpPut("{id}")]
        public IActionResult Mark(int id)
        {
            return Ok("Ok");
        }

        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        [HttpDelete("{id}")]
        [ActionName("delete")]
        public void Delete(int id)
        {
        }
    }
}
