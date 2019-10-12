using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleTask.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string CommentContent { get; set; }

        public Article Article { get; set; }

        public int ArticleId { get; set; }
    }
}
