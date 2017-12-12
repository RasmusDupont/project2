using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DataTransferObjects;
using WebAPI.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class SearchController : Controller
    {
        private IDataService dataService;

        public SearchController(IDataService dataService)
        {
            this.dataService = dataService;
        }

        [HttpPost]
        public IActionResult SaveSearch([FromBody] string searchString)
        {
            bool result = dataService.SearchRepository.SaveSearch(searchString);
            return Ok(result);
        }

        [HttpGet("history/{page}/{pageSize}")]
        public IActionResult GetSearchHistory(int page, int pageSize)
        {
            int totalPosts = dataService.SearchRepository.GetSearchHistoryCount();
            int totalPages = (int)Math.Ceiling(totalPosts / (double)pageSize);

            List<Search> searchHistory = dataService.SearchRepository.GetSearchHistory().Skip(pageSize * page)
                                     .Take(pageSize).ToList();
            PagedListDTO<Search> result = new PagedListDTO<Search>
            {
                TotalEntities = totalPosts,
                TotalPages = totalPages,
                CurrentPage = page,
                PrevLink = Link("/api/search/history/{0}/{1}", page, pageSize, -1, () => page > 0),
                NextLink = Link("/api/search/history/{0}/{1}", page, pageSize, 1, () => page < totalPages - 1),
                Content = searchHistory
            };

            return Ok(result);
        }

        private string Link(string route, int page, int pageSize, int pageInc = 0, Func<bool> f = null)
        {
            if (f == null) return string.Format(route, page, pageSize);

            return f()
                ? string.Format(route, page = page + pageInc, pageSize)
                : null;
        }
    }
}