using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebAPI.Entities
{
    public class Search
    {
        public int Id { get; set; }
        [Column("search_string")]
        public string SearchString { get; set; }
        [Column("search_date")]
        public DateTime SearchDate { get; set; }
    }
}
