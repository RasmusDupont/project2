﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace WebAPI.Entities
{
    [Table("post")]
    public class Post
    {
        public int Id { get; set; }
        [Column("parent_id")]
        public int? ParentId { get; set; }
        [Column("acceptedAnswer_id")]
        public int? AcceptedAnswerId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ClosedDate { get; set; }
        public int Score { get; set; }
        public string Body { get; set; }
        public string Title { get; set; }
        [Column("fk_user_id")]
        public int UserId { get; set; }
        [Column("fk_posttype_id")]
        public int PostTypeId { get; set; }
        [Column("marked_post")]
        public bool MarkedPost { get; set; }
        public string Annotation { get; set; }
        [Column("view_count")]
        public int ViewCount { get; set; }
        public List<Comment> Comments { get; set; }
        public User User { get; set; }
        [NotMapped]
        public List<Tag> Tags { get; set; }
    }
}
