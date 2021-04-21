using Microsoft.EntityFrameworkCore;
using MVCBlog.Models.DataAccess.Entities.Concrete;
using MVCBlog.Models.DataAccess.EntityFramework.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCBlog.Models.DataAccess.Entities.DTOs;

namespace MVCBlog.Models.DataAccess.EntityFramework
{
    public class BlogDbContext : DbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<MemberFollowedTopic> MemberTopics { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleTopics> ArticleTopics { get; set; }

        public BlogDbContext(DbContextOptions<BlogDbContext> options) :base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=.; Database=MyBlog; Trusted_Connection=True;");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleTopicsMapping());
            modelBuilder.ApplyConfiguration(new MemberFollowedTopicMapping());
            modelBuilder.ApplyConfiguration(new MemberMapping());
            modelBuilder.ApplyConfiguration(new TopicMapping());
            modelBuilder.ApplyConfiguration(new ArticleMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
