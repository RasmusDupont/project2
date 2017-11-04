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
        private DataService dataService;

        public StatisticsController(DataService dataService)
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
    }
}