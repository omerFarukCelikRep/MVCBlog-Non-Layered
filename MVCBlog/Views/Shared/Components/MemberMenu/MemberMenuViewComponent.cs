using Microsoft.AspNetCore.Mvc;
using MVCBlog.Repositories.Abstract;
using MVCBlog.Repositories.Concrete;
using MVCBlog.Models.DataAccess.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBlog.Views.Shared.Components.MemberMenu
{
    public class MemberMenuViewComponent : ViewComponent
    {
        private readonly MemberRepository _memberRepository;

        public MemberMenuViewComponent(IMemberRepository memberRepository)
        {
            _memberRepository = (MemberRepository)memberRepository;
        }

        public IViewComponentResult Invoke()
        {
            if (!HttpContext.Request.Cookies.ContainsKey("ID"))
            {
                return View();
            }
            int id = int.Parse(HttpContext.Request.Cookies["ID"]);
            Member member = _memberRepository.Get(a => a.ID == id);
            return View(member);
        }
    }
}
