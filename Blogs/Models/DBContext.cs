using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogs.Models
{
    public class DBContext:IdentityDbContext<ApplicationUser>
    {
     
        public DBContext(DbContextOptions<DBContext> options)
           : base(options)
        {

        }
         public virtual DbSet<Article> Articles { get; set; }
         public virtual DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}
