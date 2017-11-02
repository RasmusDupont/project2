using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.DataTransferObjects;
using WebAPI.Entities;
using WebAPI.Interfaces;

namespace WebAPI.Repositories
{
    public class SearchRepository : ISearchRepository
    {
        private SovaContext db;

        public SearchRepository(SovaContext db)
        {
            this.db = db;
        }

        public List<Post> GetPostsBySearchString(string searchString)
        {
            throw new NotImplementedException();
        }

        //TODO virker ikke
        public bool SaveSearch(string searchString)
        {
            try
            {
                //db.Search.FromSql("call saveSearch(" + searchString + ")");
                //db.SqlQuery<Search>("saveSearch",searchString);

                SqlParameter param1 = new SqlParameter("@search_string", searchString);
                db.Database.ExecuteSqlCommand("saveSearch @search_string", param1);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //TODO er en procedure
        public List<Search> GetSearchHistory()
        {
            throw new NotImplementedException();
        }
    }
}
