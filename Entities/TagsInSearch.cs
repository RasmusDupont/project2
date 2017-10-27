using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Entities
{
    public class TagsInSearch
    {
        [Column("fk_search_id")]
        public int SearchId { get; set; }
        [Column("fk_tag_id")]
        public int TagId { get; set; }
    }
}
