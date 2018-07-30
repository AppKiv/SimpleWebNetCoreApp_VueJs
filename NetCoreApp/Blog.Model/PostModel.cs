using System;

namespace Blog.Model
{
    public class PostModel
    {
        public string Body { get; set; }
        public string Header { get; set; }
        public string Preview { get; set; }
        public int PostId { get; set; }
        public DateTime PublishDate { get; set; }
        public string Tags { get; set; }
    }
}
