using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Entities;
using WebAPI.DataTransferObjects;

namespace WebAPI.Interfaces
{
   public interface IPostRepository
    {
        List<Post> GetQuestionWithAnswersByPostId(int id);
        bool MarkPost(int id);
        string GetAnnotation(int id);
        bool UpdateAnnotation(int id, string annotation);
        List<Post> GetPostsBySearchString(string searchString, int page, int pageSize);
        int GetPostCountBySearchString(string searchString);
        List<Words> GetWordsFrequencyInPostSearch(string searchString);
    }
}
