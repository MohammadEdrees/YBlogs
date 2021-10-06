using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogs.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryTitle { get; set; }
        public virtual IList<Article> Articles { get; set; }
    }
}
