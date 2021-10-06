using Blogs.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogs.Controllers
{
    public class UserController : Controller
    {
        private  IServices _services;
        public UserController(IServices services) {
            _services = services;
        }

        [HttpPost]
        public async Task <IActionResult> Register( ApplicationUser user ,  string role)
        {
            if (user == null)
            {
                return BadRequest(" user equals null ");
            }
            if (string.IsNullOrEmpty(role))
            {
                return BadRequest(" role Is Null Or Empty ");
            }
             
                bool v = await _services.RegisterUser(user, role);
            return Ok($"Saved Successfully If true ==> {v}");
            
            
        }

        
        [HttpPost]
        public async Task <IActionResult>Login(string mail,string password)
        {
            if (string.IsNullOrEmpty(mail) || string.IsNullOrEmpty(password))
                return BadRequest("check mail or password please");

            ApplicationUser LoggedInUser = await _services.Login(mail, password);
            return Ok(LoggedInUser);
        }

    }
}
