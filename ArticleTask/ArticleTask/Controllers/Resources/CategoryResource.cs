using ArticleTask.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleTask.Controllers.Resources
{
    public class CategoryResource
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ArticleResource> Articles { get; set; }

        public CategoryResource()
        {
            Articles = new Collection<ArticleResource>();
        }
    }
}
