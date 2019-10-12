using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArticleTask.Models;
using Microsoft.EntityFrameworkCore;

namespace ArticleTask.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly ArticleDbContext dbContext;

        public ArticleRepository(ArticleDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void AddArticle(Article article)
        {
            dbContext.Articles.Add(article);
        }

        public async Task<Article> GetArticle(int id, bool includeRelated = true)
        {
            if (!includeRelated)
               return await dbContext.Articles.FindAsync(id);
            return await dbContext.Articles.Include(c => c.Comments)
                .SingleOrDefaultAsync(a=>a.Id == id);
        }

        public void RemoveArticle(Article article)
        {
            dbContext.Remove(article);
        }

        public void AddComment(Comment comment)
        {
            dbContext.Comments.Add(comment);
        }
    }
}
