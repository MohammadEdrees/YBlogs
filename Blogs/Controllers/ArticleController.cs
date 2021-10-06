using Blogs.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogs.Controllers
{
    [Authorize]
    public class ArticleController : Controller
    {
        private IServices _services;
        public ArticleController(IServices services)
        {
            _services = services;
        }

        [HttpPost, Authorize(Roles = "Admin")]
        public IActionResult Create(Article art)
        {
            if (art == null)
            {
                return BadRequest("Something Went Wrong");
            }
            bool v = _services.CreateArticle(art);
            return Ok(v);
        }

        [HttpGet, Authorize(Roles ="Admin,Moderator,Visitor" )]
        public IActionResult GetAllArticles()
        {
            IList<Article> arts =  _services.GetAllArticles();
            if (arts.Count <= 0)
                return BadRequest("No Articles Found");
            return Ok(arts);
        }

        [HttpPut,Authorize("Admin,Moderator")]
        public IActionResult UpdateArticle(int oldId,Article NewArticle)
        {
            Article article = _services.UpdateArticle(oldId, NewArticle);
            return Ok(article);
        }

        [HttpGet, Authorize(Roles = "Admin,Moderator,Visitor")]
        public IActionResult ArticlesByCategory(string category)
        {
            if (string.IsNullOrEmpty(category))
                return BadRequest();
            return Ok(_services.FilterArticlesByCategory(category));
        }


    }
}
