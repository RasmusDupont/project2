using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Entities
{
    [Table("posttag")]
    public class PostTag
    {
        [Column("fk_tag_id")]
        public int TagId { get; set; }
        [Column("fk_post_id")]
        public int PostId { get; set; }
    }
}
