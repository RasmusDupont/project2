using System;
using WebAPI.Entities;
using System.Collections.Generic;
namespace WebAPI.DataTransferObjects
{
    public class PostDTO
    {
       
        public int? Id { get; set; }
        public int? AcceptedAnswerId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ClosedDate { get; set; }
        public int? Score { get; set; }
        public string Body { get; set; }
        public string Title { get; set; }
        public bool? MarkedPost { get; set; }
        public string Annotation { get; set; }
        public List<Comment> Comments { get; set; }
        public User User { get; set; }
        public List<Tag> Tags { get; set; }

    }
}
