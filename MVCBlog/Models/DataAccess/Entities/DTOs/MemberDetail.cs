using MVCBlog.Models.DataAccess.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBlog.Models.DataAccess.Entities.DTOs
{
    public class MemberDetail
    {
        public int MemberID { get; set; }
        public string MemberName { get; set; }
        public string Username { get; set; }
        public string Biography { get; set; }
        public byte[] Image { get; set; }
        public List<Article> Articles { get; set; }
    }
}
