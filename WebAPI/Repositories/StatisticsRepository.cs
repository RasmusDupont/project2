using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using WebAPI.Entities;
using WebAPI.Interfaces;

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
    }
}
