using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCBlog.Models.DataAccess.Entities.Concrete;
using MVCBlog.Models.DataAccess.Entities.DTOs;
using MVCBlog.Models.DataAccess.EntityFramework;
using MVCBlog.Repositories.Abstract;
using MVCBlog.Repositories.Concrete;
using MVCBlog.ViewModels;
using Newtonsoft.Json;

namespace MVCBlog.Controllers
{
    public class TopicController : Controller
    {
        private readonly TopicRepository _topicRepository;
        private readonly MemberRepository _memberRepository;
        private readonly ArticleRepository _articleRepository;

        public TopicController(ITopicRepository topicRepository, IMemberRepository memberRepository, IArticleRepository articleRepository)
        {
            _topicRepository = (TopicRepository)topicRepository;
            _memberRepository = (MemberRepository)memberRepository;
            _articleRepository = (ArticleRepository)articleRepository;
        }

        // GET: Topic
        public IActionResult Index()
        {
            TopicAndMemberViewModel model = new TopicAndMemberViewModel();

            if (!HttpContext.Request.Cookies.ContainsKey("ID") || HttpContext.Request.Cookies["ID"] == "")
            {
                model.Member = null;
            }
            else
            {
                int id = int.Parse(HttpContext.Request.Cookies["ID"]);
                model.Member = _memberRepository.Get(a => a.ID == id);
            }

            model.Topics = _topicRepository.GetAll();

            return View(model);
        }

        

        // GET: Topic/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var topic = await _context.Topics
            //    .FirstOrDefaultAsync(m => m.ID == id);
            //if (topic == null)
            //{
            //    return NotFound();
            //}

            return View(/*topic*/);
        }

        // GET: Topic/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Topic/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("ID,Name,Image")] Topic topic)
        //{
        //    //if (ModelState.IsValid)
        //    //{
        //    //    _context.Add(topic);
        //    //    await _context.SaveChangesAsync();
        //    //    return RedirectToAction(nameof(Index));
        //    //}
        //    return View(topic);
        //}



        // GET: Topic/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var topic = await _context.Topics.FindAsync(id);
            //if (topic == null)
            //{
            //    return NotFound();
            //}
            return View(/*topic*/);
        }

        // POST: Topic/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Image")] Topic topic)
        {
            if (id != topic.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(topic);
                    //await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (!TopicExists(topic.ID))
                    //{
                    //    return NotFound();
                    //}
                    //else
                    //{
                    //    throw;
                    //}
                }
                return RedirectToAction(nameof(Index));
            }
            return View(topic);
        }

        // GET: Topic/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var topic = await _context.Topics
            //    .FirstOrDefaultAsync(m => m.ID == id);
            //if (topic == null)
            //{
            //    return NotFound();
            //}

            return View(/*topic*/);
        }

        // POST: Topic/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var topic = await _context.Topics.FindAsync(id);
            //_context.Topics.Remove(topic);
            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Add(int memberID, int topicID)
        {
            var topic = _topicRepository.Get(a => a.ID == topicID);
            topic.MemberFollowedTopics.Add(new MemberFollowedTopic() { MemberID = memberID, TopicID = topicID });

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Create(FileUpload fileObj)
        {
            Topic oTopic = JsonConvert.DeserializeObject<Topic>(fileObj.Entity);
            if (fileObj.File.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    fileObj.File.CopyTo(memoryStream);
                    var fileBytes = memoryStream.ToArray();
                    oTopic.Image = fileBytes;

                  _topicRepository.Add(oTopic);

                    return View();
                }
            }

            return View();
        }

        public IActionResult List(int id)
        {
            var list = _articleRepository.GetTopicArticles(id);

            return View(list);
        }


        public IActionResult RetrieveImage(int id)
        {
            byte[] image = _topicRepository.Get(a => a.ID == id).Image;

            if (image != null)
            {
                return File(image, "image/jpg");
            }

            return null;
        }

        public IActionResult  FollowTopic(int topicID)
        {
            int memberID = int.Parse(HttpContext.Request.Cookies["ID"]);

            Member member = _memberRepository.Get(a => a.ID == memberID);
            Topic topic = _topicRepository.Get(a => a.ID == topicID);
            topic.MemberFollowedTopics.Add(new MemberFollowedTopic { Member = member, Topic = topic });

            _topicRepository.Update(topic);

            return RedirectToAction(nameof(Index));
        }
    }
}
