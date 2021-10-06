using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blogs.Models
{
    public class ApplicationUser:IdentityUser
    {
        
        [Required]
        public string Password { get; set; }
        public string Token { get; set; } 
    }
}
