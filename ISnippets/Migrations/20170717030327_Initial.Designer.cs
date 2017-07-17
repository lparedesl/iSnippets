using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ISnippets.Models;

namespace ISnippets.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20170717030327_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("ISnippets.Models.Snippet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CodeSnippet");

                    b.Property<string>("Description");

                    b.Property<string>("Language");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Snippets");
                });
        }
    }
}
