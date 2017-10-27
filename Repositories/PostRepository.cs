using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Entities;
using WebAPI.Interfaces;

namespace WebAPI.Repositories
{
    public class PostRepository : IPostRepository
    {
        private SovaContext db;

        public PostRepository(SovaContext db)
        {
            this.db = db;
        }

        public Post GetPostRelationsByPostId(int id)
        {
            Post post = db.Post.FirstOrDefault();
            return post;
        }

        public void MarkPost(int id)
        {
            throw new NotImplementedException();
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

