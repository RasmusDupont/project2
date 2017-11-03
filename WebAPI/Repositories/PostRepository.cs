﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Entities;
using WebAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

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
            Post post = db.Post.FromSql("call getPost({0})", id).FirstOrDefault();

            if (post.ParentId != null)
            {
                post = db.Post.FromSql("call getPost({0})", post.ParentId).FirstOrDefault();
            }
            List<Post> posts = db.Post.FromSql("call getAnswers({0})", post.Id).ToList();
            posts.Prepend(post);

            foreach (var p in posts)
            {
                p.Comments = db.Comment.FromSql("call getComments({0})", p.Id).ToList();
            }

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

        public string GetAnnotation(int id)
        {
            Post post = db.Post.Single(x => x.Id == id);
            if (post != null)
            {
                string annotation = post.Annotation;
                return annotation;
            }
            return "No annotation for this post.";
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

        public List<Post> GetPostsBySearchString(string searchString)
        {
            List<Post> posts = db.Post
                .Where(x => x.Title.Contains(searchString) || x.Body.Contains(searchString))
                .ToList();
            return posts;
        }
    }
}