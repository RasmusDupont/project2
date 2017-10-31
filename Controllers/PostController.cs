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

        // TODO test
        [HttpGet("{id}")]
        public IActionResult GetQuestionWithAnswersByPostId(int id)
        {
            return Ok(dataService.PostRepository.GetQuestionWithAnswersByPostId(id));
        }

        // TODO test
        [HttpPut("mark/{id}")]
        public IActionResult MarkPost(int id)
        {
            bool result = dataService.PostRepository.MarkPost(id);
            dataService.Save();
            return Ok(result);
        }

        // TODO implementer
        [HttpGet("annotation/{id}")]
        public IActionResult GetAnnotation(int id)
        {
            return Ok("Ok");
        }

        // TODO implementer
        [HttpPut("annotation/{id}")]
        public IActionResult UpdateAnnotation(int id)
        {
            return Ok("Ok");
        }
    }
}