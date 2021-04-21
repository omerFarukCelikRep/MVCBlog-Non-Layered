using MVCBlog.Models.DataAccess.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBlog.ViewModels
{
    public class TopicAndMemberViewModel
    {
        public Member Member { get; set; }
        public List<Topic> Topics { get; set; }
    }
}
