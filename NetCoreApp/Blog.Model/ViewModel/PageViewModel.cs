using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Model.ViewModel
{
    public class PageViewModel<T>
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public List<T> Records { get; set; }

        public PageViewModel()
        {
            Records = new List<T>();
        }

        public PageViewModel(IEnumerable<T> records)
        {
            Records = new List<T>(records);
        }
    }
    
}
