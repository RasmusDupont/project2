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
        void GetAnnotation(int id);
        void UpdateAnnotation(string annotation);
    }
}
