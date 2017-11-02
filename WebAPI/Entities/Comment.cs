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
    }
}
