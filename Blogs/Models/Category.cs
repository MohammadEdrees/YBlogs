using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogs.Models
{
    public class Category
    {
        public Category()
        {
            Articles = new HashSet<Article>();
        }
        public int CategoryId { get; set; }
        public string CategoryTitle { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}
