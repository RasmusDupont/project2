using System;
using System.Collections.Generic;
namespace WebAPI.DataTransferObjects
{
    public class PagedListDTO
    {
        public int TotalEntities { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public string PrevLink { get; set; }
        public string NextLink { get; set; }
        public List<SearchedPostDTO> Content { get; set; }

    }
}
