using MVCBlog.Models.DataAccess.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBlog.Models.DataAccess.Entities.DTOs
{
    public class ArticleAndMemberWithArticles
    {
        public Article Article { get; set; }
        public Member Member { get; set; }
    }
}
