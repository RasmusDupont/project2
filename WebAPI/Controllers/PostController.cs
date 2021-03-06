﻿using System.Collections.Generic;
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
        private IDataService _dataService;

        public PostController(IDataService dataService)
        {
            this._dataService = dataService;
        }

        [HttpGet("{id}")]
        public IActionResult GetQuestionWithAnswersByPostId(int id)
        {
            try
            {
                List<PostDTO> result = _dataService.PostRepository.GetQuestionWithAnswersByPostId(id)
                                                  .Select(x => new PostDTO{
                                                      Id = x.Id,
                                                      AcceptedAnswerId = x.AcceptedAnswerId,
                                                      CreateDate = x.CreateDate,
                                                      ClosedDate = x.ClosedDate,
                                                      Score = x.Score,
                                                      Body = x.Body,
                                                      Title = x.Title,
                                                      MarkedPost = x.MarkedPost,
                                                      Annotation = x.Annotation,
                                                      Comments = x.Comments.Select(c => new CommentDTO{
                                                          Id = c.Id,
                                                          Score = c.Score,
                                                          Text = c.Text,
                                                          CreatedDate = c.CreateDate,
                                                          User = c.User.DisplayName
                                                      }).ToList(),
                                                      User = x.User.DisplayName,
                                                      Tags = x.Tags.Select(t => new TagDTO{
                                                          Id = t.Id,
                                                          Tag = t.Name
                                                      }).ToList()
                                                  }).ToList();
                return Ok(result);
            }
            catch (Exception e) { Console.WriteLine(e); return NotFound(); } 
            
        }

        [HttpPut("mark/{id}")]
        public IActionResult MarkPost(int id)
        {
            bool result = _dataService.PostRepository.MarkPost(id);
            _dataService.Save();

            if (result == true) return Ok(result);
            return NotFound();

        }

        [HttpGet("annotation/{id}")]
        public IActionResult GetAnnotation(int id)
        {
            string result = _dataService.PostRepository.GetAnnotation(id);
            if (result == "No annotation for this post.") { return NotFound(); }
            return Ok(result);
            
        }

        [HttpPut("annotation/{id}")]
        public IActionResult UpdateAnnotation(int id, [FromBody] string annotation)
        {
            bool result = _dataService.PostRepository.UpdateAnnotation(id, annotation);
            if (result == true) { _dataService.Save();  return Ok(result); }
            return NotFound();
            
        }

        [HttpGet("search/{substring}/{page}/{pageSize}")]
        public IActionResult GetPostsBySearchString(string substring, int page, int pageSize)
        {
            int totalPosts = _dataService.PostRepository.GetPostCountBySearchString(substring);
            int totalPages = (int)Math.Ceiling(totalPosts / (double)pageSize);
            try
            {
                List<SearchedPostDTO> posts = _dataService.PostRepository.GetPostsBySearchString(substring, page, pageSize)
                                                          .Select(x => new SearchedPostDTO{
                                                              Id = x.Id,
                                                              CreateDate = x.CreateDate,
                                                              Score = x.Score,
                                                              Body = x.Body,
                                                              Title = x.Title,
                                                              MarkedPost = x.MarkedPost,
                                                              Annotation = x.Annotation,
                                                              User = x.User.DisplayName,
                                                              Tags = x.Tags.Select(t => new TagDTO{
                                                                  Id = t.Id,
                                                                  Tag = t.Name
                                                              }).ToList()
                                                          }).ToList();
                

                if (posts == null) { return NotFound(); }
                PagedListDTO<SearchedPostDTO> result = new PagedListDTO<SearchedPostDTO>
                {
                    TotalEntities = totalPosts,
                    TotalPages = totalPages,
                    CurrentPage = page,
                    PrevLink = Link("/api/post/search/{0}/{1}/{2}", substring, page, pageSize, -1, () => page > 0),
                    NextLink = Link("/api/post/search/{0}/{1}/{2}", substring, page, pageSize, 1, () => page < totalPages - 1),
                    Content = posts
                };
                return Ok(result);
            }
            catch(Exception e) { Console.WriteLine(e); return NotFound(); }
        }

        [HttpGet("search/words/{substring}")]
        public IActionResult getSearchedWordsByFrequency(string substring)
        {
            List<Words> result = _dataService.PostRepository.GetWordsFrequencyInPostSearch(substring);
            return Ok(result);
        }

        [HttpGet("search/termnetwork/{substring}")]
        public IActionResult getTermNetwork(string substring)
        {
            List<TermNetworkPart> termNetwork = _dataService.PostRepository.GetTermNetwork(substring);
            string result = "";
            foreach (TermNetworkPart termNetworkPart in termNetwork)
            {
                result += termNetworkPart.part;
            }

            result = result.Replace(",]","]");
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