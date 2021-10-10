using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogs.Models
{
      public interface IServices
    {
        public Task AddRole(string role);
        public IList<IdentityRole> GetAllRoles();
        public Task<bool> AssignRoleToUser(string userId,string role);
        public Task<bool> RegisterUser(ApplicationUser user, string role);
        public Task< ApplicationUser> Login(string email, string password);
        public bool CreateArticle(Article article);
        public IList<Article> GetAllArticles();
        public IList<Article> GetArticlesByCategoryName(string catName);
        public Article UpdateArticle(int oldArticleId, Article newArticle);
        public bool DeleteArticle(int articleId);
        public string GenerateJWT();
        public IList<Article> FilterArticlesByCategory(string category);
        public Task<string> GetRoleByEmail(string email);
        public Category CreateCategory(Category category);
        public Category GetCategoryByName(string name);

        public IList<Category> GetCategories();
        public Article GetArticleById(int Id);

    }
}
