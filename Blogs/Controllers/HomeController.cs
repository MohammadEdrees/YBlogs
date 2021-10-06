using Blogs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Blogs.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IServices _IServices;
        public HomeController(ILogger<HomeController> logger,IServices IServices)
        {
            _logger = logger;
            _IServices = IServices;
        }

        public IActionResult Index()
        {
            return View();
        }

     
        public IActionResult GetAllRoles()
        {
            var roles = _IServices.GetAllRoles();
            if (roles.Count > 0)
            return Ok(roles);
            return BadRequest("Empty");
        }
        public async Task<IActionResult> AddRole(string r)
        {
            await _IServices.AddRole(r);
            return Ok();
        }
        public async Task<IActionResult> AssignRole(string id,string role)
        {
            var result = await _IServices.AssignRoleToUser(id, role);
            if (result)
                return Ok("Done");
            return BadRequest("Something Went Wrong");
        }


      
    }
}
