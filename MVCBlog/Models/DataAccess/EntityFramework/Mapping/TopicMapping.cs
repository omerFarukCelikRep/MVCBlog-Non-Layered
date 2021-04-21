using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCBlog.Models.DataAccess.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBlog.Models.DataAccess.EntityFramework.Mapping
{
    public class TopicMapping : IEntityTypeConfiguration<Topic>
    {
        public void Configure(EntityTypeBuilder<Topic> builder)
        {
            builder.HasKey(tp => tp.ID);

            builder.Property(tp => tp.ID)
                .ValueGeneratedOnAdd();

            builder.Property(tp => tp.Image)
                .IsRequired();

            builder.Property(tp => tp.Name)
                .IsRequired();
        }
    }
}
