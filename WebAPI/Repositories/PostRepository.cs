using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Entities;
using WebAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using WebAPI.DataTransferObjects;

namespace WebAPI.Repositories
{
    public class PostRepository : IPostRepository
    {
        private SovaContext db;

        public PostRepository(SovaContext db)
        {
            this.db = db;
        }

        public List<Post> GetQuestionWithAnswersByPostId(int id)
        {
            Post post = db.Post.FromSql("call getPost({0})", id).FirstOrDefault();
            if (post == null) return null;
            //if post is not a question
            if (post.ParentId != null)
            {
                post = db.Post.FromSql("call getPost({0})", post.ParentId).FirstOrDefault();
            }
            List<Post> posts = db.Post.FromSql("call getAnswers({0})", post.Id).ToList();
            posts.Insert(0,post);

            foreach (var p in posts)
            {
                p.Comments = db.Comment.FromSql("call getComments({0})", p.Id).ToList();
                foreach (var c in p.Comments)
                {
                    c.User = db.User.Where(x => x.Id == c.UserId).FirstOrDefault();
                }

                p.User = db.User.Where(x => x.Id == p.UserId).FirstOrDefault();

                p.Tags = this.getRelatedTags(p);
            }

            return posts;
        }

        public bool MarkPost(int id)
        {
            try {
                Post post = db.Post.Single(x => x.Id == id);
                if (post != null)
                {
                    post.MarkedPost = !post.MarkedPost;
                    return true;
                }
                return false;
            }
            catch (Exception e) { Console.WriteLine(e); return false; }
            
        }

        public string GetAnnotation(int id)
        {
            try
            {
                Post post = db.Post.Single(x => x.Id == id);
            if (post != null)
            {
                string annotation = post.Annotation;
                return annotation;
            }
                return "No annotation for this post.";

            }
            catch (Exception e) { Console.WriteLine(e); return "No annotation for this post."; }
}

        public bool UpdateAnnotation(int id, string annotation)
        {
            Post post = db.Post.Single(x => x.Id == id);
            if (post != null)
            {
                post.Annotation = annotation;
                return true;
            }
            return false;
        }

        public List<Post> GetPostsBySearchString(string searchString, int page, int pageSize)
        {


            try
            {
                searchString = searchString.Replace(" ", ",");
                List<Post> posts = db.Post.FromSql("call bestmatchWithPaging({0}, {1}, {2})", searchString, page, pageSize).ToList();

                //old search
                /*
                List<Post> posts = db.Post
                                     .Where(x => x.Title.Contains(searchString) || x.Body.Contains(searchString))
                                     .Include(u => u.User)
                                     .Skip(pageSize * page)
                                     .Take(pageSize)
                    .ToList();

                */


                foreach (var p in posts)
                {
                    p.Tags = this.getRelatedTags(p);
                    p.User = db.User.Where(x => x.Id == p.UserId).FirstOrDefault();
                }


                return posts;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        public List<RankedWordsByFrequencyDTO> GetWordsFrequencyInPostSearch(string searchString)
        {
            MySqlConnection conn = (MySqlConnection)db.Database.GetDbConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;

            cmd.Parameters.Add("@1", DbType.String);
            cmd.Parameters["@1"].Value = searchString;

            cmd.CommandText = "call rankWordsByFrequency(@1)";

            var reader = cmd.ExecuteReader();

            List<RankedWordsByFrequencyDTO> wordList = new List<RankedWordsByFrequencyDTO>();
            while (reader.Read())
            {
                wordList.Add(new RankedWordsByFrequencyDTO
                {
                    Word = reader.GetString(0),
                    Frequency = reader.GetInt32(1)
                });
            }
            conn.Close();
            return wordList;


        }

        public int GetPostCountBySearchString(string searchString)
        {
            int result = db.Post
                           .Where(x => x.Title.Contains(searchString) || x.Body.Contains(searchString))
                           .Count();
            return result;
        }

        private List<Tag> getRelatedTags (Post post)
        {
            post.Tags = db.Tag
                    .Join(db.PostTag,
                          t => t.Id,
                          pt => pt.TagId,
                          (t, pt) => new { Tag = t, PostTag = pt })
                    .Where(x => x.PostTag.PostId == post.Id)
                    .Select(s => new Tag { Id = s.Tag.Id, Name = s.Tag.Name, SearchCount = s.Tag.SearchCount })
                    .ToList();
            return post.Tags;
        }
    }
}