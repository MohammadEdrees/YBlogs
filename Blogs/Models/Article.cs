using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Blogs.Models
{
    public class Article
    {
        [Key,Required]
        public int ArticleId { get; set; }
        [Required,MaxLength(128)]
        public string ArticleTitle { get; set; }
        [Required, MaxLength(1028)]
        public string ArticleBody { get; set; }
        public ApplicationUser Author { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
