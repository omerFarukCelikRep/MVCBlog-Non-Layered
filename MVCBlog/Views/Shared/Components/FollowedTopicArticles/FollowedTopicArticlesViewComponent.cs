using Microsoft.AspNetCore.Mvc;
using MVCBlog.Models.DataAccess.Entities.Concrete;
using MVCBlog.Models.DataAccess.Entities.DTOs;
using MVCBlog.Repositories.Abstract;
using MVCBlog.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBlog.Views.Shared.Components.FollowedTopicArticles
{
    public class FollowedTopicArticlesViewComponent : ViewComponent
    {
        private ArticleRepository _articleRepository;

        public FollowedTopicArticlesViewComponent(IArticleRepository articleRepository)
        {
            _articleRepository = (ArticleRepository)articleRepository;
        }

        public IViewComponentResult Invoke(int id)
        {
            List<ArticleWithMemberDetail> articles = _articleRepository.MemberFollowedTopicArticles(id).Take(6).ToList();

            return View(articles);
        }
    }
}
