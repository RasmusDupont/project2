using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Entities;
using WebAPI.Repositories;
using WebAPI.Interfaces;

namespace WebAPI
{
    public class DataService : IDataService
    {
        private SovaContext context = new SovaContext();
        private PostRepository postRepository;
        private SearchRepository searchRepository;
        private StatisticsRepository statisticsRepository;

        public IPostRepository PostRepository
        {
            get { return this.postRepository ?? new PostRepository(context); }
        }

        public ISearchRepository SearchRepository
        {
            get { return this.searchRepository ?? new SearchRepository(context); }
        }

        public IStatisticsRepository StatisticsRepository
        {
            get { return this.statisticsRepository ?? new StatisticsRepository(context); }
        }

        public void Save()
        {
            context.SaveChanges();
        }

    }
}
