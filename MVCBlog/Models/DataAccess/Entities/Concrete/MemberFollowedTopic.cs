using MVCBlog.Models.DataAccess.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBlog.Models.DataAccess.Entities.Concrete
{
    public class MemberFollowedTopic : IEntity
    {
        public int MemberID { get; set; }
        public Member Member { get; set; }
        public int TopicID { get; set; }
        public Topic Topic { get; set; }
    }
}
