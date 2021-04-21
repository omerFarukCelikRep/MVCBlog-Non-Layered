using Microsoft.EntityFrameworkCore;
using MVCBlog.Helpers;
using MVCBlog.Models.DataAccess.Entities.Concrete;
using MVCBlog.Models.DataAccess.Entities.DTOs;
using MVCBlog.Models.DataAccess.EntityFramework;
using MVCBlog.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MVCBlog.Repositories.Concrete
{
    public class ArticleRepository : BaseRepository<Article>, IArticleRepository
    {
        BlogDbContext _context;

        public ArticleRepository(BlogDbContext context): base(context)
        {
            _context = context;
        }

        public override void Add(Article entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.ReadingCount = 1;
            entity.ReadTime = ArticleHelper.CalculateReadTime(entity.Content);
            entity.IsPublished = false;
            base.Add(entity);
        }

        public override void Delete(Article entity)
        {
            base.Delete(entity);
        }

        public override void Update(Article entity)
        {
            entity.ReadTime = ArticleHelper.CalculateReadTime(entity.Content);
            base.Update(entity);
        }


        /// <summary>
        /// Makaleleri Listeleyen method 
        /// 
        /// Eğer filtre verilirse bu filtereye göre makaleleri getirir
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>List</Article></returns>
        public override List<Article> GetAll(Expression<Func<Article, bool>> filter = null)
        {
            return filter == null ? _context.Articles.ToList() : _context.Articles.Where(filter).ToList();
        }

        /// <summary>
        /// Filtreye göre tek bir makale döndüren method
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>Article</returns>
        public override Article Get(Expression<Func<Article, bool>> filter)
        {
            return _context.Articles.SingleOrDefault(filter);
        }


        /// <summary>
        /// Makaleleri Okunma Sayılarına Göre En Çok Okunandan En Az Okunana Sıralayıp Liste Olarak Döndüren Method
        /// </summary>
        /// <returns>List</returns>
        public List<ArticleWithMemberDetail> MostReadArticles()
        {
            return _context.Articles.Where(a => a.IsPublished == true).OrderByDescending(a => a.ReadingCount).Take(6).Include(a => a.Member).Select(a => new ArticleWithMemberDetail 
            {
                ArticleID = a.ID,
                Title = a.Title,
                CreatedDate = a.CreatedDate,
                ReadingTime = a.ReadTime,
                MemberID = a.Member.ID,
                MemberName = a.Member.Name,
                MemberImage = a.Member.Image
            }).ToList();
        }


        /// <summary>
        /// Parametre olarak verilen Numarasına Göre Üyenin Takip Ettiği Konuları Filtreleyerek Bu Konulara Ait Makaleleri Liste Olarak Döndüren Method
        /// </summary>
        /// <param name="memberID"></param>
        /// <returns>List</returns>
        public List<ArticleWithMemberDetail> MemberFollowedTopicArticles(int memberID)
        {

            //var memberTopics = context.MemberTopics.Where(t => t.MemberID == memberID);

            //var articles = context.Articles.Join(memberTopics,
            //    a => a.TopicID,
            //    mt => mt.TopicID,
            //    (a, mt) => new
            //    {
            //        a
            //    }).Select(t => t.a).ToList();


            var topics = _context.MemberTopics.Where(a => a.MemberID == memberID).Include(a => a.Topic).Select(a => a.Topic);

            var articles = _context.ArticleTopics.Include(a => a.Article).ThenInclude(a => a.Member).Where(a => a.Article.IsPublished == true).Join(topics,
                at => at.TopicID,
                t => t.ID,
                (at, t) => at.Article).Select(a => new ArticleWithMemberDetail
                {
                    ArticleID = a.ID,
                    Biography = a.Member.Biography,
                    Content = a.Content,
                    CreatedDate = a.CreatedDate,
                    MemberID = a.Member.ID,
                    MemberImage = a.Member.Image,
                    MemberName = a.Member.Name,
                    ModifiedDate = a.ModifiedDate,
                    ReadingTime = a.ReadingCount,
                    Title = a.Title,
                    Username = a.Member.Username
                }).OrderByDescending(a => a.CreatedDate).ToList();

            return articles;
        }


        /// <summary>
        /// Üye ID'sine Göre Bu Üyeye Ait Makaleleri Liste Olarak Döndüren Method
        /// </summary>
        /// <param name="memberID"></param>
        /// <returns>List</returns>
        public List<Article> GetMembersArticles(int memberID)
        {
            return _context.Articles.Where(a => a.MemberID == memberID).ToList();
        }

        /// <summary>
        /// Yazar Detaylarıyla Beraber Makaleyi Döndüren Method
        /// </summary>
        /// <param name="article"></param>
        /// <returns>ArticleWithMemberDetail</returns>
        public ArticleWithMemberDetail GetArticleWithDetails(int articleID)
        {

            //var articleDetail = context.Articles.Join(context.Members,
            //    a => a.MemberID,
            //    m => m.ID,
            //    (a, m) => new ArticleWithMemberDetail
            //    {
            //        MemberID = m.ID,
            //        ArticleID = a.ID,
            //        Title = a.Title,
            //        Content = a.Content,
            //        MemberName = m.Name,
            //        MemberImage = m.Image,
            //        CreatedDate = a.CreatedDate,
            //        ReadingTime = a.ReadTime
            //    });

            var article = _context.Articles.Where(a => a.ID == articleID).Include(a => a.Member).Select(a => new ArticleWithMemberDetail {
                MemberID = a.Member.ID,
                MemberName = a.Member.Name,
                Username = a.Member.Username,
                MemberImage = a.Member.Image,
                Biography = a.Member.Biography,
                ArticleID = a.ID,
                Title = a.Title,
                Content = a.Content,
                CreatedDate = a.CreatedDate,
                ReadingTime = a.ReadTime
            });



            return (ArticleWithMemberDetail)article;
        }

        public List<ArticleWithMemberDetail> LastAddedArticles()
        {
            var articleList = _context.Articles.Where(a => a.IsPublished == true).OrderByDescending(a => a.CreatedDate).Include(a => a.Member).Select(a => new ArticleWithMemberDetail
            {
                ArticleID = a.ID,
                Title = a.Title,
                CreatedDate = a.CreatedDate,
                ReadingTime = a.ReadTime,
                MemberID = a.Member.ID,
                MemberName = a.Member.Name,
                MemberImage = a.Member.Image
            }).ToList();

            return articleList;
        }

        public ArticleAndMemberWithArticles GetArticle(int id)
        {
            var articles = _context.Articles.Where(a => a.ID == id).Include(a => a.Member).ThenInclude(a => a.Articles).Select(a => new ArticleAndMemberWithArticles { Article = a, Member = a.Member}).First();

            return articles;
        }

        public Article GetArticleWithTopics(Expression<Func<Article, bool>> filter)
        {
            Article article = _context.Articles.Include(a => a.ArticleTopics).FirstOrDefault(filter);

            return article;
        }

        public List<Article> GetTopicArticles(int topicID)
        {
            var articles = _context.ArticleTopics.Where(a => a.TopicID == topicID).Include(a => a.Article).ThenInclude(a => a.Member).Select(a => a.Article).ToList();

            return articles;
        }

        public void RemoveTopics(List<ArticleTopics> articleTopics)
        {
            _context.ArticleTopics.RemoveRange(articleTopics);
            _context.SaveChanges();
        }

        public void AddTopics(Article article, List<ArticleTopics> articleTopics)
        {
            article.ArticleTopics = articleTopics;
            _context.SaveChanges();
        }
    }
}
