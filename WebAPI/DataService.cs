using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Entities;
using WebAPI.Repositories;

namespace WebAPI
{
    public class DataService
    {
        private SovaContext context = new SovaContext();
        private PostRepository postRepository;
        private SearchRepository searchRepository;
        private StatisticsRepository statisticsRepository;

        public PostRepository PostRepository
        {
            get { return this.postRepository ?? new PostRepository(context); }
        }

        public SearchRepository SearchRepository
        {
            get { return this.searchRepository ?? new SearchRepository(context); }
        }

        public StatisticsRepository StatisticsRepository
        {
            get { return this.statisticsRepository ?? new StatisticsRepository(context); }
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
