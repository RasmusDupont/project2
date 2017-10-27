using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public DateTime CreateDate { get; set; }
        public string Location { get; set; }
        public int Age { get; set; }
    }
}
