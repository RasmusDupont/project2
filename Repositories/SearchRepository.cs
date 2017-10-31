using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DataTransferObjects;
using WebAPI.Entities;
using WebAPI.Interfaces;

namespace WebAPI.Repositories
{
    public class SearchRepository : ISearchRepository
    {

        public List<Post> GetPostsBySearchString(string searchString)
        {
            throw new NotImplementedException();
        }

        //TODO er en procedure
        public void SaveSearch(SearchDTO search)
        {
            throw new NotImplementedException();
        }

        //TODO er en procedure
        public List<Search> GetSearchHistory()
        {
            throw new NotImplementedException();
        }
    }
}
