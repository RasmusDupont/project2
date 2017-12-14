using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
namespace WebAPI.Entities
{
    public class Words
    {
        [Key]
        [Column("lemma")]
        public string text { get; set; }
        [Column("count(lemma)")]
        public int weight { get; set; }
    }
}
