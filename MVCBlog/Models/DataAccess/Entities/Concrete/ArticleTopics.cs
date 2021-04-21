using MVCBlog.Models.DataAccess.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBlog.Models.DataAccess.Entities.Concrete
{
    public class ArticleTopics : IEntity
    {
        public int TopicID { get; set; }
        public Topic Topic { get; set; }
        public int ArticleID { get; set; }
        public Article Article { get; set; }
    }
}
