using Blogs.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogs.Controllers
{
    public class CategoryController : Controller
    {
        private IServices _services;
        public CategoryController(IServices services)
        {
            _services = services;
        }
        [HttpPost]
        public IActionResult Create([FromBody]Category category)
        {
            if (category == null)
                return BadRequest("error happened");
            Category category1 = _services.CreateCategory(category);
            return Ok(category1);

                
        }
        [HttpGet]
        public IActionResult GetCategorybyName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest();
            }
            return Ok(_services.GetCategoryByName(name));
        }
        [HttpGet]
        public IActionResult GetAllCategories()
        {
           IList<Category> categories= _services.GetCategories();
            if (categories.Count <= 0)
                return NoContent();
            return Ok(categories);
        }

    }
}
