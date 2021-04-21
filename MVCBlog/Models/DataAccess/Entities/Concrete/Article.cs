using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MVCBlog.Models.DataAccess.Entities.Abstract;

namespace MVCBlog.Models.DataAccess.Entities.Concrete
{
    public class Article : IEntity
    {
        public Article()
        {
            ArticleTopics = new HashSet<ArticleTopics>();
        }

        public int ID { get; set; }

        [Required(ErrorMessage = "Başlık Zorunlu Alandır.")]
        [Display(Name = "Başlık")]
        public string Title { get; set; }

        [Required(ErrorMessage = "İçerik Zorunlu Alandır.")]
        [Display(Name = "İçerik")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int ReadingCount { get; set; }
        public int ReadTime { get; set; }
        public byte[] Image { get; set; }
        public bool IsPublished { get; set; }
        public int LikeCount { get; set; }

        //Navigation Prop.
        public int MemberID { get; set; }
        public Member Member { get; set; }
        public ICollection<ArticleTopics> ArticleTopics { get; set; }
    }
}
