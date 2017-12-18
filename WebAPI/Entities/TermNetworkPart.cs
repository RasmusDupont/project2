using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Entities
{
    public class TermNetworkPart
    {
        [Key]
        public string part
        {
            get;
            set;
        }
    }
}
