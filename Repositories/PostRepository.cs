using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Entities;
using WebAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Repositories
{
    public class PostRepository : IPostRepository
    {
        private SovaContext db;

        public PostRepository(SovaContext db)
        {
            this.db = db;
        }

        public Post GetQuestionWithAnswersByPostId(int id)
        {
            Post post = db.Post.Single(x => x.Id == id);
                //.Where(x => x.Id == id)
                //.Include(p => p.)
                //.FirstOrDefault();
            return post;
        }

        public bool MarkPost(int id)
        {
            Post post = db.Post.Single(x => x.Id == id);
            if (post != null)
            {
                post.MarkedPost = !post.MarkedPost;
                return true;
            }
            return false;
        }

        public void GetAnnotation(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateAnnotation(string annotation)
        {
            throw new NotImplementedException();
        }
    }
}

