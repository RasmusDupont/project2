using System;
namespace WebAPI.DataTransferObjects
{
    public class CommentDTO
    {
            public int Id { get; set; }
            public int Score { get; set; }
            public string Text { get; set; }
            public DateTime CreatedDate { get; set; }
            public string User { get; set; }
    }
}
