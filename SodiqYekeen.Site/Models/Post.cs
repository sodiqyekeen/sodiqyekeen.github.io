using System;
using System.Collections.Generic;

namespace SodiqYekeen.Site.Models
{
    public class Post
    {
        public Guid PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public string FeaturedImage { get; set; }
        public string Category { get; set; }
        public string Tags { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
