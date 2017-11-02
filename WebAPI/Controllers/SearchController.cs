using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class SearchController : Controller
    {
        private DataService dataService;

        public SearchController(DataService dataService)
        {
            this.dataService = dataService;
        }

        [HttpPost]
        public IActionResult SaveSearch([FromBody] string searchString)
        {
            bool result = dataService.SearchRepository.SaveSearch(searchString);
            return Ok(result);
        }
    }
    

}