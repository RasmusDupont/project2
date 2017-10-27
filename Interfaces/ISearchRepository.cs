using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DataTransferObjects;
using WebAPI.Entities;

namespace WebAPI.Interfaces
{
    interface ISearchRepository
    {
        List<Post> GetPostsBySearchString(string searchString);
        void SaveSearch(SearchDTO search);
        List<Search> GetSearchHistory();

    }
}
