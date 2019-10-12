using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleTask.Repository
{
    public interface IUnitOfWork
    {
        Task Complete();
    }
}
