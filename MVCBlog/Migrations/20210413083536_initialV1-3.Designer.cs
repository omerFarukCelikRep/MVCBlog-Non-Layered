﻿// <auto-generated />
using System;
using MVCBlog.Models.DataAccess.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MVCBlog.Migrations
{
    [DbContext(typeof(BlogDbContext))]
    [Migration("20210413083536_initialV1-3")]
    partial class initialV13
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MVCBlog.Models.DataAccess.Entities.Concrete.Article", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2021, 4, 13, 11, 35, 36, 160, DateTimeKind.Local).AddTicks(2709));

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<bool>("IsPublished")
                        .HasColumnType("bit");

                    b.Property<int>("MemberID")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2021, 4, 13, 11, 35, 36, 160, DateTimeKind.Local).AddTicks(3346));

                    b.Property<int>("ReadTime")
                        .HasColumnType("int");

                    b.Property<int>("ReadingCount")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("MemberID");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("MVCBlog.Models.DataAccess.Entities.Concrete.ArticleTopics", b =>
                {
                    b.Property<int>("TopicID")
                        .HasColumnType("int");

                    b.Property<int>("ArticleID")
                        .HasColumnType("int");

                    b.HasKey("TopicID", "ArticleID");

                    b.HasIndex("ArticleID");

                    b.ToTable("ArticleTopics");
                });

            modelBuilder.Entity("MVCBlog.Models.DataAccess.Entities.Concrete.Member", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Biography")
                        .HasColumnType("nvarchar(180)")
                        .HasMaxLength(180);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2021, 4, 13, 11, 35, 36, 148, DateTimeKind.Local).AddTicks(3174));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("varchar(32)");

                    b.HasKey("ID");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("MVCBlog.Models.DataAccess.Entities.Concrete.MemberFollowedTopic", b =>
                {
                    b.Property<int>("MemberID")
                        .HasColumnType("int");

                    b.Property<int>("TopicID")
                        .HasColumnType("int");

                    b.HasKey("MemberID", "TopicID");

                    b.HasIndex("TopicID");

                    b.ToTable("MemberFollowedTopics");
                });

            modelBuilder.Entity("MVCBlog.Models.DataAccess.Entities.Concrete.Topic", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Topics");
                });

            modelBuilder.Entity("MVCBlog.Models.DataAccess.Entities.Concrete.Article", b =>
                {
                    b.HasOne("MVCBlog.Models.DataAccess.Entities.Concrete.Member", "Member")
                        .WithMany("Articles")
                        .HasForeignKey("MemberID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MVCBlog.Models.DataAccess.Entities.Concrete.ArticleTopics", b =>
                {
                    b.HasOne("MVCBlog.Models.DataAccess.Entities.Concrete.Article", "Article")
                        .WithMany("ArticleTopics")
                        .HasForeignKey("ArticleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVCBlog.Models.DataAccess.Entities.Concrete.Topic", "Topic")
                        .WithMany("ArticleTopics")
                        .HasForeignKey("TopicID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MVCBlog.Models.DataAccess.Entities.Concrete.MemberFollowedTopic", b =>
                {
                    b.HasOne("MVCBlog.Models.DataAccess.Entities.Concrete.Member", "Member")
                        .WithMany("MemberFollowedTopics")
                        .HasForeignKey("MemberID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVCBlog.Models.DataAccess.Entities.Concrete.Topic", "Topic")
                        .WithMany("MemberFollowedTopics")
                        .HasForeignKey("TopicID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
