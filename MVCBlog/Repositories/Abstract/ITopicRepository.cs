using MVCBlog.Models.DataAccess.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBlog.Repositories.Abstract
{
    public interface ITopicRepository
    {
        List<Topic> MemberFollowedTopics(int id);
    }
}
