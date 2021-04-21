using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBlog.Models.DataAccess.Entities.DTOs
{
    public class ArticleWithMemberDetail
    {
        public int MemberID { get; set; }
        public string MemberName { get; set; }
        public string Username { get; set; }
        public byte[] MemberImage { get; set; }
        public string Biography { get; set; }

        [Key]
        public int ArticleID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int ReadingTime { get; set; }
    }
}
