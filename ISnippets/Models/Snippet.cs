using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISnippets.Models
{
    public class Snippet
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CodeSnippet { get; set; }
        public string Language { get; set; }
    }
}
