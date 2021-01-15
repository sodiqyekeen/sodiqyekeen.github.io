using System;

namespace SodiqYekeen.Site.Models
{
    public class Comment
    {
        public Guid CommentId { get; set; }
        public string Username { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
    }
}
