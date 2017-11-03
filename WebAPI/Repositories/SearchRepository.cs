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

        public bool SaveSearch(string searchString)
        {
            try
            {
                db.Database.ExecuteSqlCommand("call saveSearch({0})", searchString);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Search> GetSearchHistory()
        {
            List<Search> searchHistory = db.Search.FromSql("call getSearchHistory").ToList();
            return searchHistory;
        }
    }
}
