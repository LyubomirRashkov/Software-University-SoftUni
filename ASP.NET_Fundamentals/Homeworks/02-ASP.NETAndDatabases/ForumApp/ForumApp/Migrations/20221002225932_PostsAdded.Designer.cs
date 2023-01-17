﻿// <auto-generated />
using ForumApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ForumApp.Migrations
{
    [DbContext(typeof(ForumDbContext))]
    [Migration("20221002225932_PostsAdded")]
    partial class PostsAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ForumApp.Data.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Post identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(1500)
                        .HasColumnType("nvarchar(1500)")
                        .HasComment("Post content");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Post title");

                    b.HasKey("Id");

                    b.ToTable("Posts");

                    b.HasComment("Published posts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "My first post will be about performing CRUD operations in MVC. It's so much fun!",
                            Title = "My first post"
                        },
                        new
                        {
                            Id = 2,
                            Content = "This is my second post. CRUD operations in MVC are getting more and more interesting!",
                            Title = "My second post"
                        },
                        new
                        {
                            Id = 3,
                            Content = "Hello there! I'm getting better and better with the CRUD operations in MVC. Stay tuned!",
                            Title = "My third post"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
