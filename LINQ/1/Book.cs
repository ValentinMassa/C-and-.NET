using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1
{
    public class Book
    {
        public string? Title { get; set; }
        public int PageCount { get; set; }
        public string? status{ get; set; }
        public DateTime publishedDate { get; set; } 
        public string[]? Authors { get; set; }
        public string[]? categories { get; set; }
        public string? Description { get; set; }
        public string? Website { get; set; }
    }
}
