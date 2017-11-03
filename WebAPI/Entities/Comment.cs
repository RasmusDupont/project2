using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebAPI.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public string Text { get; set; }
        public DateTime CreateDate { get; set; }
        [Column("fk_post_id")]
        public int PostId { get; set; }
        [Column("fk_user_id")]
        public int UserId { get; set; }
    }
}
