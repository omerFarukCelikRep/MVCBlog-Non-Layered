using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCBlog.Models.DataAccess.Entities.Concrete;
using MVCBlog.Models.DataAccess.Entities.DTOs;
using MVCBlog.Repositories.Abstract;
using MVCBlog.Repositories.Concrete;

namespace MVCBlog.Controllers
{
    public class MemberController : Controller
    {
        private readonly MemberRepository _memberRepository;

        public MemberController(IMemberRepository memberRepository)
        {
            _memberRepository = (MemberRepository)memberRepository;
        }

        [Route("/Member/Action/{email}")]
        // GET: Member/Action/{email}
        public IActionResult Action(string email)
        {
            if (_memberRepository.MemberExists(email))
            {
                Member member = _memberRepository.Get(a => a.Email == email);

                if (!HttpContext.Request.Cookies.ContainsKey("ID") || HttpContext.Request.Cookies["ID"] == "")
                {
                    HttpContext.Response.Cookies.Append("ID", member.ID.ToString());
                }
                return RedirectToAction("Index");
            }

            return NotFound();
        }

        [Route("/me/")]

        public IActionResult Index()
        {
            if (HttpContext.Request.Cookies.ContainsKey("ID"))
            {
                int id = int.Parse(HttpContext.Request.Cookies["ID"]);
                Member member = _memberRepository.Get(a => a.ID == id);
                return View(member);
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult SignIn([Bind("Email")] Member member)
        {
            //_memberRepository.SendEmail(member.Email);
            return RedirectToAction("Index");
        }

        public IActionResult SignOut()
        {
            //Cookiden silinecek
            HttpContext.Response.Cookies.Delete("ID");

            return RedirectToAction("Index");
        }

        // GET: Member/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = _memberRepository.Get(a => a.ID == id);

            return View(member);
        }

        // POST: Member/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Email")] Member member)
        {
            if (!_memberRepository.MemberExists(member.Email))
            {
                _memberRepository.Add(member);

                //_memberRepository.SendEmail(member.Email);

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("Email", "Bu Email ile daha önce Kayıt İşlemi Gerçekleşmiştir");

            //return View(member);
            return ViewComponent("Login");

        }


        //[Route("/me/settings")]
        [HttpGet]
        // GET: me/settings/5
        public IActionResult Settings()
        {
            if (HttpContext.Request.Cookies.ContainsKey("ID"))
            {
                int id = int.Parse(HttpContext.Request.Cookies["ID"]);
                Member member = _memberRepository.Get(a => a.ID == id);
                return View(member);
            }

            return RedirectToAction("About", "Home");
        }

        // POST: me/settings/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Settings([Bind("ID,Name,Biography,Image,Username,Url,Email")] Member member)
        {
            try
            {
                _memberRepository.Update(member);

                member = _memberRepository.Get(a => a.ID == member.ID);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (true)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToAction("Settings");
        }

        // GET: Member/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var member = await _context.Members
            //    .FirstOrDefaultAsync(m => m.ID == id);
            //if (member == null)
            //{
            //    return NotFound();
            //}

            return View(/*member*/);
        }

        // POST: Member/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Member member = _memberRepository.Get(a => a.ID == id);
            _memberRepository.Delete(member);
            return RedirectToAction(nameof(SignOut));
        }

        public IActionResult AddTopic(int memberID, int topicID)
        {

            return RedirectToAction("Add", "Topic", new { memberID, topicID });
        }

        [HttpPost]
        public IActionResult SaveImage(FileUpload fileObj)
        {
            if (fileObj.File.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    fileObj.File.CopyTo(memoryStream);
                    var fileBytes = memoryStream.ToArray();
                    //oMember.Image = fileBytes;

                    int id = int.Parse(HttpContext.Request.Cookies["ID"]);
                    Member member = _memberRepository.Get(a => a.ID == id);

                    //member.Image = oMember.Image;
                    member.Image = fileBytes;
                    _memberRepository.Update(member);
                }
            }

            return RedirectToAction(nameof(Settings));

        }


        public IActionResult RetrieveImage(int id)
        {
            byte[] image = null;
            if (id != null && id != 0)
            {
                image = _memberRepository.Get(a => a.ID == id).Image;
            }

            if (image != null)
            {
                return File(image, "image/jpg");
            }

            return null;
        }
    }
}
