using Microsoft.AspNetCore.Mvc;
using MVCBlog.Models.DataAccess.Entities.Concrete;
using MVCBlog.Models.DataAccess.Entities.DTOs;
using MVCBlog.Models.DataAccess.EntityFramework;
using MVCBlog.Repositories.Abstract;
using MVCBlog.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBlog.Views.Shared.Components.Articles
{
    public class ArticlesViewComponent : ViewComponent
    {
        private ArticleRepository _articleRepository;

        public ArticlesViewComponent(IArticleRepository articleRepository)
        {
            _articleRepository = (ArticleRepository)articleRepository;
        }

        public IViewComponentResult Invoke()
        {
            List<ArticleWithMemberDetail> articles = _articleRepository.LastAddedArticles();
            
            return View(articles);
        }
    }
}
