﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using System.Text;

namespace WebAPI.Entities
{
    public class Post
    {
        public int Id { get; set; }
        [Column("parent_id")]
        public int ParentId { get; set; }
        [Column("acceptedAnswer_id")]
        public int AcceptedAnswerId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ClosedDate { get; set; }
        public int Score { get; set; }
        public string Body { get; set; }
        public string Title { get; set; }
        [Column("fk_user_id")]
        public User User { get; set; }
        [Column("fk_posttype_id")]
        public PostType Type { get; set; }
        [Column("marked_post")]
        public int MarkedPost { get; set; }
        public string Annotation { get; set; }
        [Column("view_count")]
        public int ViewCount { get; set; }
    }
}
