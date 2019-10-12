using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArticleTask.Controllers.Resources;
using ArticleTask.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArticleTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ArticleDbContext dbContext;
        private readonly IMapper mapper;

        public CategoryController(ArticleDbContext dbContext,IMapper mapper) {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        [HttpGet]//http://localhost:50357/api/category
        public async Task<IEnumerable<CategoryResource>> GetCategories()
        {
            var category = await dbContext.Categories.Include(a => a.Articles).ToListAsync();//filtring each category with its articles
            return mapper.Map<List<Category>, List<CategoryResource>>(category);    
        }

        [HttpGet("Categories")] //http://localhost:50357/api/category/categories
        public async Task<IEnumerable<Category>> Categories()
        {
            return await dbContext.Categories.ToListAsync();//list all categories without its articles
        }

        [HttpGet("Articles")] //http://localhost:50357/api/category/articles
        public async Task<IEnumerable<AllArticlesResource>> Articles()
        {
            var article = await dbContext.Articles.ToListAsync();//list all articles
            return mapper.Map<List<Article>, List<AllArticlesResource>>(article);
        }
    }
}