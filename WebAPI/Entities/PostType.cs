using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebAPI.Entities
{
    [Table("posttype")]
    public class PostType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
