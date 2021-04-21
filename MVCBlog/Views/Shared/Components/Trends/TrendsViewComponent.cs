using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCBlog.Models.DataAccess.Entities.DTOs;
using MVCBlog.Repositories.Abstract;
using MVCBlog.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBlog.Views.Shared.Components.Trends
{
    public class TrendsViewComponent : ViewComponent
    {
        private ArticleRepository _articleRepository;

        public TrendsViewComponent(IArticleRepository articleRepository)
        {
            _articleRepository = (ArticleRepository)articleRepository;
        }

        public IViewComponentResult Invoke()
        {
            List<ArticleWithMemberDetail> trendArticles = _articleRepository.MostReadArticles();

            return View(trendArticles);
        }
    }
}
