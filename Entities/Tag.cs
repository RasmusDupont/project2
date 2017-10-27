using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebAPI.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Column("search_count")]
        public int SearchCount { get; set; }
    }
}
