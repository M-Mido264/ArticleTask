using ArticleTask.Controllers.Resources;
using ArticleTask.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleTask.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryResource>();
            CreateMap<Article, ArticleResource>();
            CreateMap<Comment, CommentResource>();
            CreateMap<Article, AllArticlesResource>();
        }
    }
}
