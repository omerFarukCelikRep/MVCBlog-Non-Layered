using Microsoft.EntityFrameworkCore;
using MVCBlog.Models.DataAccess.Entities.Concrete;
using MVCBlog.Models.DataAccess.EntityFramework;
using MVCBlog.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MVCBlog.Repositories.Concrete
{
    public class TopicRepository : BaseRepository<Topic>, ITopicRepository
    {
        private readonly BlogDbContext _context;

        public TopicRepository(BlogDbContext context): base(context)
        {
            _context = context;
        }

        public override void Add(Topic entity)
        {
            base.Add(entity);
        }

        public override void Delete(Topic entity)
        {
            base.Delete(entity);
        }

        public override void Update(Topic entity)
        {
            base.Update(entity);
        }

        public override Topic Get(Expression<Func<Topic, bool>> filter)
        {
            return _context.Topics.SingleOrDefault(filter);
        }

        public override List<Topic> GetAll(Expression<Func<Topic, bool>> filter = null)
        {
            return filter == null ? _context.Topics.ToList() : _context.Topics.Where(filter).ToList();
        }

        /// <summary>
        /// Üyenin takip ettiği konuları liste olarak döndüren method
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Topic> MemberFollowedTopics(int id)
        {
            var topicList = _context.MemberTopics.Include(a => a.Member).Include(a => a.Topic).Where(a => a.Member.ID == id).Select(a => a.Topic).ToList();

            return topicList;
        }

        public bool IsTopicFollowed(int memberID, int topicID)
        {
            bool isExist = _context.MemberTopics.Any(a => a.MemberID == memberID && a.TopicID == topicID);

            if (isExist)
            {
                return true;
            }
            return false;
        }
    }
}
