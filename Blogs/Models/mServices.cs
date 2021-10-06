using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Blogs.Models
{
    public class mServices : IServices
    {
        private UserManager<ApplicationUser> _userManager;
        private  RoleManager<IdentityRole> _roleManager;
        private  SignInManager<ApplicationUser> _signInManager;
        private DBContext _db;
        private IConfiguration _configuration;


        public mServices(UserManager<ApplicationUser> userManager,
                         RoleManager<IdentityRole> roleManager,
                         SignInManager<ApplicationUser> signInManager,
                         IConfiguration configuration,
                         DBContext db
                         
                         )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _db = db;
            
            
        }
        public async Task AddRole(string role)
        {
            if (!string.IsNullOrEmpty(role))
            {
                IdentityRole newRole = new IdentityRole { Name = role };
                await _roleManager.CreateAsync(newRole);
            }
            
        }

        public async Task<bool> AssignRoleToUser(string userId, string role)
        {
            bool res=false;
            var user = _db.Users.FirstOrDefault(o => o.Id == userId);
            if(user!=null && !string.IsNullOrEmpty(role))
            {

                var result = await _userManager.AddToRoleAsync(user, role);
                if (result.Succeeded)
                    res =  true;
            }
            
            return res;
        }

        public bool CreateArticle(Article article)
        {
            if (article != null)
            {
              _db.Articles.Add(article);
              _db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteArticle(int articleId)
        {
            var article = _db.Articles.FirstOrDefault(obj => obj.ArticleId == articleId);
            if (article != null)
            {
                _db.Articles.Remove(article);
                _db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public IList<Article> GetAllArticles()
        {
            IList<Article> articles = _db.Articles.ToList();
            if (articles.Count > 0)
            {
                return articles;
            }
            else
            {
                return null;
            }
        }

        public IList<IdentityRole> GetAllRoles()=> _db.Roles.ToList();

    
        public Article UpdateArticle(int oldArticleId, Article newArticle)
        {
            var oldArticle = _db.Articles.FirstOrDefault(a => a.ArticleId == oldArticleId);
            if(oldArticle!=null && newArticle!= null)
            {
                oldArticle.ArticleBody = newArticle.ArticleBody;
                oldArticle.ArticleTitle = newArticle.ArticleTitle;
                oldArticle.Author = newArticle.Author;
                _db.SaveChanges();
                
            }

            return oldArticle;
        }

    
        public string GenerateJWT()
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: new List<Claim>(),
                expires: DateTime.Now.AddDays(5),
                signingCredentials: signinCredentials
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return tokenString;
        }

        public async Task<bool> RegisterUser(ApplicationUser user, string role)
        {
            bool value = false;
           
            if (user != null && !string.IsNullOrEmpty(role))
            {
                ApplicationUser nUser = new ApplicationUser { Email = user.Email, UserName = user.UserName,Password=user.Password};
                IdentityResult userCreation = await _userManager.CreateAsync(nUser, user.Password);
                
                if (userCreation.Succeeded)
                {
                    IdentityResult roleAdding = await _userManager.AddToRoleAsync(nUser, role);
                    if (roleAdding.Succeeded)
                    {
                        value = true;
                    }
                }
                
            }
            return value;
        }

        public async Task<ApplicationUser> Login(string email, string password)
        {
            
                var user = _db.Users.FirstOrDefault(o => o.Email == email);

                SignInResult signInResult = await _signInManager.PasswordSignInAsync(user, password,false,false);
            if (signInResult.Succeeded)
            {
                user.Token = GenerateJWT();
                _db.SaveChanges();
               
            }
            return user ;
        }

        public IList<Article> FilterArticlesByCategory(string category)
        {
            return _db.Articles.Where(o => o.Category.CategoryTitle == category).ToList();
                
        }
    }
}
