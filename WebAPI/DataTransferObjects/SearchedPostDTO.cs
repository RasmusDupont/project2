using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Entities;

namespace WebAPI.DataTransferObjects
{
    public class SearchedPostDTO
    {

        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public int Score { get; set; }
        public string Body { get; set; }
        public string Title { get; set; }
        public bool MarkedPost { get; set; }
        public string Annotation { get; set; }
        public string User { get; set; }
        public List<TagDTO> Tags { get; set; }

    }
}
