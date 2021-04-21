using MVCBlog.Models.DataAccess.Entities.Concrete;
using MVCBlog.Models.DataAccess.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MVCBlog.Repositories.Abstract
{
    public interface IArticleRepository
    {
        List<ArticleWithMemberDetail> MostReadArticles();
        List<ArticleWithMemberDetail> LastAddedArticles();
        List<Article> GetMembersArticles(int memberID);
        List<ArticleWithMemberDetail> MemberFollowedTopicArticles(int memberID);
        ArticleWithMemberDetail GetArticleWithDetails(int articleID);
        ArticleAndMemberWithArticles GetArticle(int articleID);
        Article GetArticleWithTopics(Expression<Func<Article, bool>> filter);
    }
}
