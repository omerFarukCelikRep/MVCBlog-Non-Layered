using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCBlog.Models.DataAccess.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBlog.Models.DataAccess.EntityFramework.Mapping
{
    public class MemberMapping : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.HasKey(m => m.ID);

            builder.Property(m => m.ID)
                .ValueGeneratedOnAdd();

            builder.Property(m => m.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(m => m.CreatedDate)
                .HasDefaultValue(DateTime.Now);

            builder.Property(m => m.Email)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(m => m.Url)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(m => m.Username)
                .HasColumnType("varchar(32)")
                .IsRequired();

        }
    }
}
