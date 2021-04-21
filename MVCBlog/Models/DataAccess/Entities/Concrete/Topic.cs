using MVCBlog.Models.DataAccess.Entities.Abstract;
using MVCBlog.Models.DataAccess.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBlog.Models.DataAccess.Entities.Concrete
{
    public class Topic : IEntity
    {
        public Topic()
        {
            MemberFollowedTopics = new HashSet<MemberFollowedTopic>();
            ArticleTopics = new HashSet<ArticleTopics>();
        }
        public int ID { get; set; }

        [Required]
        [Display(Name = "Topic Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Topic Image")]
        public byte[] Image { get; set; }

        //Navigation Prop.
        public ICollection<ArticleTopics> ArticleTopics { get; set; }
        public ICollection<MemberFollowedTopic> MemberFollowedTopics { get; set; }
    }
}
