using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCBlog.Models.DataAccess.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBlog.Models.DataAccess.EntityFramework.Mapping
{
    public class ArticleTopicsMapping : IEntityTypeConfiguration<ArticleTopics>
    {
        public void Configure(EntityTypeBuilder<ArticleTopics> builder)
        {
            builder.HasKey(at => new { at.TopicID, at.ArticleID });

            builder.HasOne(t => t.Topic)
                .WithMany(at => at.ArticleTopics)
                .HasForeignKey(at => at.TopicID);


            builder.HasOne(t => t.Article)
                .WithMany(at => at.ArticleTopics)
                .HasForeignKey(at => at.ArticleID);
        }
    }
}
