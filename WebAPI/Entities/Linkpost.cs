using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Entities
{
    [Table("linkpost")]
    public class Linkpost
    {
        [Column("fk_link_to_post")]
        public int ToPost { get; set; }
        [Column("fk_link_from_post")]
        public int FromPost { get; set; }
    }
}
