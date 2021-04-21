using MVCBlog.Models.DataAccess.Entities.Abstract;
using MVCBlog.Models.DataAccess.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBlog.Models.DataAccess.Entities.Concrete
{
    public class Member : IEntity
    {
        public Member()
        {
            MemberFollowedTopics = new HashSet<MemberFollowedTopic>();
            Articles = new HashSet<Article>();
        }
        public int ID { get; set; }

        [Required]
        [Display(Name = "İsim Soyisim")]
        [MinLength(3, ErrorMessage = "İsminiz min 3 Karakter Olmalıdır")]
        public string Name { get; set; }

        [Display(Name = "Biyografi")]
        [StringLength(180, ErrorMessage ="Biyografiniz max. 180 karakter olmalıdır.")]
        [DataType(DataType.MultilineText)]
        public string Biography { get; set; }
        public byte[] Image { get; set; }

        [Required]
        [Display(Name = "Kullanıcı Adı")]
        [MinLength(3, ErrorMessage = "Kullanıcı Adı min 3 Karakter Olmalıdır")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Url Adresi Boş Bırakılamaz")]
        [DataType(DataType.Url)]
        public string Url { get; set; }
        public DateTime CreatedDate { get; set; }

        [Required(ErrorMessage = "Eposta Adresi Boş Bırakılamaz")]
        [Display(Name = "Eposta Adresi")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        //Navigation Prop.
        public ICollection<Article> Articles { get; set; }
        public ICollection<MemberFollowedTopic> MemberFollowedTopics { get; set; }
    }
}
