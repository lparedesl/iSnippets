using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ISnippets.Models
{
    public class Snippet
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        [StringLength(4010)]
        public string CodeSnippet { get; set; }

        [Required]
        public string Language { get; set; }
    }
}
