using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCBlog.Helpers;
using MVCBlog.Models.DataAccess.Entities.Concrete;
using MVCBlog.Models.DataAccess.Entities.DTOs;
using MVCBlog.Models.DataAccess.EntityFramework;
using MVCBlog.Repositories.Abstract;
using MVCBlog.Repositories.Concrete;

namespace MVCBlog.Controllers
{
    public class ArticleController : Controller
    {
        private readonly ArticleRepository _articleRepository;
        private readonly TopicRepository _topicRepository;

        public ArticleController(IArticleRepository articleRepository, ITopicRepository topicRepository)
        {
            _articleRepository = (ArticleRepository)articleRepository;
            _topicRepository = (TopicRepository)topicRepository;
        }

        //[Route("/Article/Index/{id:int}")]
        // GET: Article
        public IActionResult Index(int id)
        {
            var art = _articleRepository.Get(a => a.ID == id);

            art.ReadingCount++;
            _articleRepository.Update(art);

            var article = _articleRepository.GetArticle(id);



            return View(article);
        }

        // GET: Article/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var article = await _context.Articles
            //    .Include(a => a.Member)
            //    .Include(a => a.Topic)
            //    .FirstOrDefaultAsync(m => m.ID == id);
            //if (article == null)
            //{
            return NotFound();
            //}

            //return View(article);
        }

        // GET: Article/Create
        public IActionResult Create()
        {
            Article article = new Article();
            article.ArticleTopics = _topicRepository.GetAll().Select(x => new SelectListItem { Text = x.Name, Value = x.ID.ToString() }).ToList() as IList<ArticleTopics>;

            ViewBag.Topics = _topicRepository.GetAll().Select(a => new SelectListItem { Text = a.Name, Value = a.ID.ToString() });
            //ViewBag.Topics = new SelectList(_topicRepository.GetAll(), "ID", "Name");
            return View();
        }

        // POST: Article/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Title,Content,Image,ArticleTopics")] Article article)
        {
            if (ModelState.IsValid)
            {
                int memberID = int.Parse(HttpContext.Request.Cookies["ID"]);
                article.MemberID = memberID;
                _articleRepository.Add(article);
                return RedirectToAction(nameof(List));
            }
            ViewBag.Topics = new MultiSelectList(_topicRepository.GetAll(), "ID", "Name");
            return View(article);
        }

        public IActionResult List()
        {
            int memberID = int.Parse(HttpContext.Request.Cookies["ID"]);

            var memberArticles = _articleRepository.GetAll(a => a.MemberID == memberID);

            return View(memberArticles);
        }

        // GET: Article/Edit/5
        public IActionResult Edit(int? id)
        {
            var article = _articleRepository.Get(a => a.ID == id);
            if (article == null)
            {
                return NotFound();
            }
            //ViewData["TopicID"] = new SelectList(_topicRepository.GetAll(), "ID", "Name", article.TopicID);
            return View(article);
        }

        // POST: Article/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("ID,Title,Content,TopicID")] Article article)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    int memberID = int.Parse(HttpContext.Request.Cookies["ID"]);
                    article.MemberID = memberID;
                    _articleRepository.Update(article);
                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (!ArticleExists(article.ID))
                    //{
                    //    return NotFound();
                    //}
                    //else
                    //{
                    //    throw;
                    //}
                }
                return RedirectToAction(nameof(List));
            }
            ViewData["TopicID"] = new SelectList(_topicRepository.GetAll(), "ID", "Name", article.ArticleTopics);
            return View(article);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            var article = _articleRepository.Get(a => a.ID == id);
            _articleRepository.Delete(article);

            return RedirectToAction(nameof(List));
        }

        // POST: Article/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var article = _articleRepository.Get(a => a.ID == id);
            _articleRepository.Delete(article);

            return RedirectToAction(nameof(List));
        }


        public IActionResult Like(int id)
        {
            Article article = _articleRepository.Get(a => a.ID == id);

            article.LikeCount++;

            _articleRepository.Update(article);

            return RedirectToAction(nameof(Index), new { id });
        }

        public IActionResult RetrieveImage(int id)
        {
            byte[] image = null;
            if (id != null && id != 0)
            {
                image = _articleRepository.Get(a => a.ID == id).Image;
            }

            if (image != null)
            {
                return File(image, "image/jpg");
            }

            return null;
        }


        public IActionResult Publish(int id)
        {
            Article article = _articleRepository.Get(a => a.ID == id);

            article.IsPublished = true;
            _articleRepository.Update(article);

            return RedirectToAction(nameof(List));
        }

        public IActionResult AddArticle(int? id)
        {

            ArticleDTO model = new ArticleDTO();
            List<int> topicIDs = new List<int>();

            if (id != null)
            {
                Article article = _articleRepository.GetArticleWithTopics(a => a.ID == id);

                article.ArticleTopics.ToList().ForEach(result => topicIDs.Add(result.TopicID));

                model.Topics = _topicRepository.GetAll().Select(a => new SelectListItem { Text = a.Name, Value = a.ID.ToString() }).ToList();

                model.ID = article.ID;
                model.Title = article.Title;
                model.Content = article.Content;
                //model.Image = article.Image;
                model.TopicIDs = topicIDs;

            }
            else
            {
                model.Topics = _topicRepository.GetAll().Select(a => new SelectListItem { Text = a.Name, Value = a.ID.ToString() }).ToList();
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddArticle(ArticleDTO model)
        {
            int memberID = int.Parse(HttpContext.Request.Cookies["ID"]);

            Article article = new Article();
            List<ArticleTopics> articleTopics = new List<ArticleTopics>();

            if (model.ID > 0)
            {
                article = _articleRepository.GetArticleWithTopics(a => a.ID == model.ID);

                article.ArticleTopics.ToList().ForEach(result => articleTopics.Add(result));
                _articleRepository.RemoveTopics(articleTopics);

                article.Title = model.Title;
                article.Content = model.Content;
                article.MemberID = memberID;
                article.ModifiedDate = DateTime.Now;

                article.Image = ConvertFile(model.Image);

                if (model.TopicIDs.Count > 0)
                {
                    articleTopics = new List<ArticleTopics>();
                    foreach (var item in model.TopicIDs)
                    {
                        articleTopics.Add(new ArticleTopics { TopicID = item, ArticleID = model.ID });
                    }
                    _articleRepository.AddTopics(article, articleTopics);
                }

            }
            else
            {
                article.Title = model.Title;
                article.Content = model.Content;
                article.Image = ConvertFile(model.Image);
                article.MemberID = memberID;

                if (model.TopicIDs.Count > 0)
                {
                    foreach (var item in model.TopicIDs)
                    {
                        articleTopics.Add(new ArticleTopics { TopicID = item, ArticleID = model.ID });
                    }
                    article.ArticleTopics = articleTopics;
                }
                _articleRepository.Add(article);
            }

            return RedirectToAction(nameof(List));
        }

        private byte[] ConvertFile(IFormFile file)
        {
            if (file != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    file.CopyTo(memoryStream);
                    var fileBytes = memoryStream.ToArray();
                    return fileBytes;
                }
            }
            else
            {
                return UserHelper.EmptyImage();
            }
        }

    }
}
