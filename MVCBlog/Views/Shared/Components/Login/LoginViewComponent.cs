using Microsoft.AspNetCore.Mvc;
using MVCBlog.Repositories.Abstract;
using MVCBlog.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MVCBlog.Views.Shared.Components.Login
{
    public class LoginViewComponent : ViewComponent
    {
        private MemberRepository _memberRepository;

        public LoginViewComponent(IMemberRepository memberRepository)
        {
            _memberRepository = (MemberRepository)memberRepository;
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }

        
    }
}
