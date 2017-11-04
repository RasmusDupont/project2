using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using WebAPI.Entities;
using WebAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Repositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private SovaContext db;

        public StatisticsRepository(SovaContext db)
        {
            this.db = db;
        }

        public List<Post> GetMostViewedPosts(int num)
        {
            List<Post> posts = db.Post.Take(num)
                .OrderByDescending(x => x.ViewCount)
                .ToList();
            return posts;
        }

        public List<Tag> GetMostUsedTags(int num)
        {
            List<Tag> tags = db.Tag.Take(num)
                .OrderByDescending(x => x.SearchCount)
                .ToList();
            return tags;
        }
        public bool UpdateViewCount(int id)
        {
            try
            {
                db.Database.ExecuteSqlCommand("call updateViewCount({0})", id);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool UpdateTagSearchCount(string tag)
        {
            try
            {
                db.Database.ExecuteSqlCommand("call updateCount({0})", tag);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
