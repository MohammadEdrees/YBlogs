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
        public async Task <IActionResult> Register( [FromBody]ApplicationUser user ,  string role)
        {
            if (user == null)
            {
                return BadRequest(" Something Went Wrong Pleasse Try Again");
            }
            if (string.IsNullOrEmpty(role))
            {
                return BadRequest(" Something Went Wrong Pleasse Try Again ");
            }
             
                bool v = await _services.RegisterUser(user, role);
            if (v)
                return Ok(" User Created Successfully ");
            return BadRequest("Something Went Wrong Pleasse Try Again");
            
            
        }

        
        [HttpPost]
        public async Task <IActionResult>Login(string mail,string password)
        {
            if (string.IsNullOrEmpty(mail) || string.IsNullOrEmpty(password))
                return BadRequest("check mail or password please");

            ApplicationUser LoggedInUser = await _services.Login(mail, password);
            return Ok(LoggedInUser);
        }
        [HttpGet]
        public async Task<IActionResult>GetRoleByMail(string mail)
        {
            if (string.IsNullOrEmpty(mail))
                return BadRequest("your mail maybe null or empty ");
            return Ok(await _services.GetRoleByEmail(mail));
        }


    }
}
