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

        public PostRepository PostRepository
        {
            get
            {
                return this.postRepository ?? new PostRepository(context);
            }
        }
    }
}
