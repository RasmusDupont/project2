using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DataTransferObjects;
using WebAPI.Entities;

namespace WebAPI.Interfaces
{
    interface IStatisticsRepository
    {
        List<Post> GetMostViewedPosts(int num);
        List<Tag> GetMostUsedTags(int num);
        bool UpdateViewCount(int id);
        bool UpdateTagSearchCount(string tag);
    }
}
