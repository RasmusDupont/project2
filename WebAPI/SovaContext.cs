﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.Entities;

namespace WebAPI
{
    public class SovaContext : DbContext
    {
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<PostType> PostType { get; set; }
        public DbSet<Search> Search { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<PostTag> PostTag { get; set; }
        public DbSet<Words> words { get; set; }
        public DbSet<TermNetworkPart> TermNetworkPart { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseMySql("server=localhost;database=sovadb;uid=root;pwd=root");
            optionsBuilder.UseMySql("server=wt-220.ruc.dk;database=raw6;uid=raw6;pwd=raw6");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PostTag>().HasKey(pt => new { pt.PostId, pt.TagId });


        }
    }
}
