using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Entities;
using WebAPI.DataTransferObjects;
using System;


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

            List<PostDTO> result = dataService.PostRepository.GetQuestionWithAnswersByPostId(id)
                                              .Select(x => new PostDTO
                                              {
                Id = x.Id,
                AcceptedAnswerId = x.AcceptedAnswerId,
                CreateDate = x.CreateDate,
                ClosedDate = x.ClosedDate,
                Score = x.Score,
                Body = x.Body,
                Title = x.Title,
                MarkedPost = x.MarkedPost,
                Annotation = x.Annotation,
                Comments = x.Comments,
                User = x.User,
                Tags = x.Tags
            }).ToList();

            return Ok(result);
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

        [HttpGet("search/{substring}/{page}/{pageSize}")]
        public IActionResult GetPostsBySearchString(string substring, int page, int pageSize)
        {
            int totalPosts = dataService.PostRepository.GetPostCountBySearchString(substring);
            int totalPages = (int)Math.Ceiling(totalPosts / (double)pageSize);

            List<SearchedPostDTO> posts = dataService.PostRepository.GetPostsBySearchString(substring, page, pageSize)
                                                      .Select(x => new SearchedPostDTO 
                                                      { 
                Id = x.Id, 
                CreateDate = x.CreateDate, 
                Score = x.Score, 
                Body = x.Body, 
                Title = x.Title, 
                MarkedPost = x.MarkedPost, 
                Annotation = x.Annotation, 
                User = x.User, 
                Tags = x.Tags 
            }).ToList();

            PagedListDTO result = new PagedListDTO
            {
                TotalEntities = totalPosts,
                TotalPages = totalPages,
                CurrentPage = page,
                PrevLink = Link("api/post/search/{0}/{1}/{2}", substring, page, pageSize, -1, () => page > 0),
                NextLink = Link("api/post/search/{0}/{1}/{2}", substring, page, pageSize, 1, () => page < totalPages - 1),
                Content = posts
            };

            return Ok(result);   
        }

        private string Link(string route, string substring, int page, int pageSize, int pageInc = 0, Func<bool> f = null)
        {
            if (f == null) return string.Format(route,substring, page, pageSize);

            return f()
                ? string.Format(route, substring, page = page + pageInc, pageSize)
                : null;
        }

    }
}