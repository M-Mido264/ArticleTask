using ArticleTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleTask.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ArticleDbContext dbContext;

        public UnitOfWork(ArticleDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Complete()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
