using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Entities;

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

        // TODO call procedure
        [HttpGet("{id}")]
        public IActionResult GetQuestionWithAnswersByPostId(int id)
        {
            return Ok(dataService.PostRepository.GetQuestionWithAnswersByPostId(id));
        }

        [HttpPut("mark/{id}")]
        public IActionResult MarkPost(int id)
        {
            bool result = dataService.PostRepository.MarkPost(id);
            dataService.Save();
            return Ok(result);
        }

        [HttpGet("annotation/{id}")]
        public IActionResult GetAnnotation(int id)
        {
            return Ok(dataService.PostRepository.GetAnnotation(id));
        }

        [HttpPut("annotation/{id}")]
        public IActionResult UpdateAnnotation(int id, [FromBody] string annotation)
        {
            bool result = dataService.PostRepository.UpdateAnnotation(id, annotation);
            dataService.Save();
            return Ok(result);
        }

        [HttpGet("search/{substring}")]
        public IActionResult GetPostsBySearchString(string substring)
        {
            //try
            //{
                List<Post> result = dataService.PostRepository.GetPostsBySearchString(substring);
                return Ok(result);
            //}
            //catch
            //{
            //    return BadRequest();
            //}
            
        }
    }
}