using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Entities;

namespace WebAPI.Interfaces
{
    interface IPostRepository
    {
        Post GetQuestionWithAnswersByPostId(int id);
        bool MarkPost(int id);
        string GetAnnotation(int id);
        bool UpdateAnnotation(int id, string annotation);
    }
}
