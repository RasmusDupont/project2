using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class StatisticsController : Controller
    {
        private IDataService dataService;

        public StatisticsController(IDataService dataService)
        {
            this.dataService = dataService;
        }

        [HttpGet("mostviewedposts/{num}")]
        public IActionResult MostViewedPosts(int num)
        {
            return Ok(dataService.StatisticsRepository.GetMostViewedPosts(num));
        }

        [HttpGet("mostusedtags/{num}")]
        public IActionResult MostUsedTags(int num)
        {
            return Ok(dataService.StatisticsRepository.GetMostUsedTags(num));
        }

        [HttpPatch("postviewcount/{id}")]
        public IActionResult PostViewCount(int id)
        {
            return Ok(dataService.StatisticsRepository.UpdateViewCount(id));
        }

        [HttpPatch("tagsearchcount/{tag}")]
        public IActionResult TagSearchCount(string tag)
        {
            return Ok(dataService.StatisticsRepository.UpdateTagSearchCount(tag));
        }
    }
}