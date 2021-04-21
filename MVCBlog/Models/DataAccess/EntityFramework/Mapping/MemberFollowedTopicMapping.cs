using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCBlog.Models.DataAccess.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBlog.Models.DataAccess.EntityFramework.Mapping
{
    public class MemberFollowedTopicMapping : IEntityTypeConfiguration<MemberFollowedTopic>
    {
        public void Configure(EntityTypeBuilder<MemberFollowedTopic> builder)
        {
            builder.ToTable("MemberFollowedTopics");

            builder.HasKey(mt => new { mt.MemberID, mt.TopicID });

            builder.HasOne(mt => mt.Member)
                .WithMany(m => m.MemberFollowedTopics)
                .HasForeignKey(mt => mt.MemberID);

            builder.HasOne(mt => mt.Topic)
                .WithMany(t => t.MemberFollowedTopics)
                .HasForeignKey(mt => mt.TopicID);
        }
    }
}
