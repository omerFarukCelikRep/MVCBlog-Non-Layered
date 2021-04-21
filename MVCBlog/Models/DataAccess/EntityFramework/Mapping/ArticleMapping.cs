using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCBlog.Models.DataAccess.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBlog.Models.DataAccess.EntityFramework.Mapping
{
    public class ArticleMapping : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(a => a.ID);

            builder.Property(a => a.ID)
                .ValueGeneratedOnAdd();

            builder.Property(a => a.Title)
                .IsRequired();

            builder.Property(a => a.Content)
                .IsRequired();

            builder.Property(a => a.CreatedDate)
                .HasDefaultValue(DateTime.Now);

            builder.Property(a => a.ModifiedDate)
                .HasDefaultValue(DateTime.Now);

            builder.HasOne(a => a.Member)
                .WithMany(a => a.Articles)
                .HasForeignKey(a => a.MemberID);
        }
    }
}
