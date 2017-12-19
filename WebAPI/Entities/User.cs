using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebAPI.Entities
{
    [Table("user")]
    public class User
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public DateTime CreateDate { get; set; }
        public string Location { get; set; }
        public int? Age { get; set; }
    }
}
