using ArticleTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleTask.Repository
{
   public interface IArticleRepository
    {
        Task<Article> GetArticle(int id, bool includeRelated = true);
        void AddArticle(Article article);
        void RemoveArticle(Article article);

        void AddComment(Comment comment);
    }
}
