using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Repositories;
using WebAPI.Interfaces;

namespace WebAPI
{
    public interface IDataService
    {
       

        IPostRepository PostRepository { get; }

        ISearchRepository SearchRepository { get; }
        
        IStatisticsRepository StatisticsRepository { get; }
        
        void Save();        
    }
}
