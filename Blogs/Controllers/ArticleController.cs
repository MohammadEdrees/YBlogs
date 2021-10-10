using Blogs.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogs.Controllers
{
    //[Authorize]
    public class ArticleController : Controller
    {
        private IServices _services;
        public ArticleController(IServices services)
        {
            _services = services;
        }

        [HttpPost]
        public IActionResult Create([FromBody]Article art)
        {
            if (art == null)
            {
                return BadRequest("Something Went Wrong");
            }
            bool v = _services.CreateArticle(art);
            return Ok(v);
        }


        public IActionResult GetAllArticles()
        {
            IList<Article> arts = new List<Article>();
            if (arts != null)
            {
                arts = _services.GetAllArticles();
                return Ok(arts);
            }
            return NotFound("");

        }

       [HttpPut]
        public IActionResult UpdateArticle(int oldId,[FromBody]Article NewArticle)
        {
            Article article = _services.UpdateArticle(oldId, NewArticle);
            return Ok(article);
        }


        public IActionResult ArticlesByCategory(string category)
        {
            if (string.IsNullOrEmpty(category))
                return BadRequest();
            return Ok(_services.FilterArticlesByCategory(category));
        }
        [HttpGet]
        public IActionResult GetArticleById(int id)
        {
      
     
            Article article = _services.GetArticleById(id);
            if (article != null)
            {
                return Ok(article);
            }
            return BadRequest();


        }


    }
}
