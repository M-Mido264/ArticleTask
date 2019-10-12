using ArticleTask.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleTask.Controllers.Resources
{
    public class ArticleResource
    {
        public int Id { get; set; }
      
        public string Content { get; set; }

        public ICollection<CommentResource> Comments { get; set; }

        public ArticleResource()
        {
            Comments = new Collection<CommentResource>();
        }
    }
}
