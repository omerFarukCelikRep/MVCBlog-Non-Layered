using Microsoft.EntityFrameworkCore;
using MVCBlog.Helpers;
using MVCBlog.Models.DataAccess.Entities.Concrete;
using MVCBlog.Models.DataAccess.Entities.DTOs;
using MVCBlog.Models.DataAccess.EntityFramework;
using MVCBlog.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MVCBlog.Repositories.Concrete
{
    public class MemberRepository : BaseRepository<Member>, IMemberRepository
    {
        BlogDbContext _context;

        public MemberRepository(BlogDbContext context):base(context)
        {
            _context = context;
        }

        public override List<Member> GetAll(Expression<Func<Member, bool>> filter = null)
        {
            return filter == null ? _context.Members.ToList() : _context.Members.Where(filter).ToList();
        }

        public override Member Get(Expression<Func<Member, bool>> filter)
        {
            return _context.Members.Include(a => a.Articles).ThenInclude(a => a.Member).FirstOrDefault(filter);
        }

        public override void Add(Member entity)
        {
            string username = UserHelper.UserNameHelper(entity.Email);

            while (UsernameExists(username))
            {
                UserHelper.ChangeUserName(username);
            }

            entity.CreatedDate = DateTime.Now;
            entity.Image = UserHelper.EmptyImage();
            entity.Name = UserHelper.NameHelper(entity.Email);
            entity.Username = username;
            entity.Url = "localhost:57577/" + username;

            

            base.Add(entity);
        }

        public override void Delete(Member entity)
        {
            base.Delete(entity);
        }

        public override void Update(Member entity)
        {
            base.Update(entity);
        }

        /// <summary>
        /// Üye Detayları ve üyeye ait makaleleri döndüren method
        /// </summary>
        /// <param name="memberID"></param>
        /// <returns></returns>
        public MemberDetail GetMemberWithArticles(int memberID)
        {

            //var result = context.Members.GroupJoin(context.Articles,
            //     m => m.ID,
            //     a => a.MemberID,
            //     (m, a) => new MemberDetail
            //     {
            //         MemberID = m.ID,
            //         MemberName = m.Name,
            //         Username = m.Username,
            //         Biography = m.Biography,
            //         Article = a.ToList()
            //     }).Single(a => a.MemberID == memberID);

            var result = _context.Members.Where(a => a.ID == memberID).Include(a => a.Articles).Select(a => new MemberDetail
            {
                MemberID = a.ID,
                MemberName = a.Name,
                Username = a.Username,
                Biography = a.Biography,
                Image = a.Image,
                Articles = a.Articles.ToList()
            });

            return (MemberDetail)result;
        }

        /// <summary>
        /// Üye Detaylarını, Takip Ettiği Konuları ve Okunma Sırasına Göre Makaleleri içeren MemberDetailsWithArticlesAndTopics nesnesini döndüren method
        /// </summary>
        /// <param name="memberID"></param>
        /// <returns></returns>
        public MemberDetailsWithArticlesAndTopics GetMemberDetails(int memberID)
        {

            var articles = _context.Articles.OrderByDescending(a => a.ReadingCount).ToList();
            var topics = _context.Topics.ToList();
            var result = _context.Members.Include(a => a.MemberFollowedTopics).ThenInclude(a => a.Topic).Select(a => new MemberDetailsWithArticlesAndTopics
            {
                MemberID = a.ID,
                MemberName = a.Name,
                Username = a.Username,
                //Image = a.Image,
                Articles = articles,
                MemberFollowedTopics = a.MemberFollowedTopics.Where(a => a.MemberID == memberID).Select(a => a.Topic).ToList(),
                Topics = topics
            });

            return (MemberDetailsWithArticlesAndTopics)result;
        }

        /// <summary>
        /// Parametre olarak gönderilen email database'de kayıtlı olup olmama durumuna göre true yada false döndüren method
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool MemberExists(string email)
        {
            if (Get(a => a.Email == email) != null)
            {
                return true;
            }

            return false;
        }

        public void SendEmail(string email)
        {
            string link = "https://localhost:57577/Member/Action/" + email;

            MailMessage mail = new MailMessage();
            mail.To.Add(email);
            mail.From = new MailAddress("farukcelik2534@gmail.com");
            mail.Subject = "Verification Mail for MyBlog";
            string Body = "Giriş Yapabilmek için Lütfen Linke Tıklayınız" + " <a href='" + link + "' >Sakın Tıklama</a>";
            mail.Body = Body;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("eposta@gmail.com", "Sifre");
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }

        private bool UsernameExists(string username)
        {
            if (Get(a => a.Username == username) != null)
            {
                return true;
            }

            return false;
        }

        public bool IsEmailChanged(Member member)
        {
            bool result = Get(a => a.ID == member.ID).Email == member.Email;

            return result;
        }
    }
}
