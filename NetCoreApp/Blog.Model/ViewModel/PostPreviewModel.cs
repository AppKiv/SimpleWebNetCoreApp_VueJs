using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Model.ViewModel
{
    public class PostPreviewModel
    {
        public string Header { get; set; }
        public string Preview { get; set; }
        public int PostId { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
