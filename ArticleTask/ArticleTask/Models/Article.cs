using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleTask.Models
{
    public class Article
    {
        public int Id { get; set; }
        [Required]
        [StringLength(500)]
        public string Content { get; set; }

        public Category Category { get; set; }

        public int CategoryId { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public Article()
        {
            Comments = new Collection<Comment>();
        }
    }
}
