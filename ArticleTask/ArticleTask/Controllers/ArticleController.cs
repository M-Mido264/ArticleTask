using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArticleTask.Controllers.Resources;
using ArticleTask.Models;
using ArticleTask.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArticleTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleRepository articleRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ArticleController(IArticleRepository articleRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.articleRepository = articleRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpPost]
        [Authorize] //accessed with admin only
        //http://localhost:50357/api/article
        public async Task<IActionResult> AddArticle(Article article)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            articleRepository.AddArticle(article);
            await unitOfWork.Complete();//to save changes in database
            return Ok(article);
        }
        
        [HttpDelete("{id}")]
        [Authorize] //accessed with admin only
        //http://localhost:50357/api/article/id
        public async Task<IActionResult> RemoveArticle(int id)
        {
            //includRelated variable to differentiate between get article to delete or to list it.
            var article = await articleRepository.GetArticle(id, includeRelated: false);
            if (article == null)
                return NotFound();
            articleRepository.RemoveArticle(article);
            await unitOfWork.Complete();
            return Ok(id);
        }

        [HttpGet("{id}")]
        //http://localhost:50357/api/article/id
        public async Task<IActionResult> GetArticle(int id)
        {
            var article = await articleRepository.GetArticle(id);
            if (article == null)
                return NotFound();
            var articleResource = mapper.Map<Article, ArticleResource>(article);
            return Ok(articleResource);
        }

        [HttpPost("AddComment")]
        //http://localhost:50357/api/article/addcomment
        public async Task<IActionResult> AddComment(Comment comment)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            articleRepository.AddComment(comment);
            await unitOfWork.Complete();
            return Ok(comment);
        }
    }
}