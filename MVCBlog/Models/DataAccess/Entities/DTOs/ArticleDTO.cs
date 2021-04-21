using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBlog.Models.DataAccess.Entities.DTOs
{
    public class ArticleDTO
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Başlık Zorunlu Alandır.")]
        [Display(Name = "Başlık")]
        public string Title { get; set; }

        [Required(ErrorMessage = "İçerik Zorunlu Alandır.")]
        [Display(Name = "İçerik")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        [Required(ErrorMessage = "İçerik Zorunlu Alandır.")]
        [Display(Name = "Resim")]
        public IFormFile Image { get; set; }

        public List<SelectListItem> Topics { get; set; }
        public List<int> TopicIDs { get; set; }
    }
}
