﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Telegram.BOT.Infrastructure.Database;

#nullable disable

namespace Telegram.BOT.Infrastructure.Database.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Telegram.BOT.Infrastructure.Database.Entities.Products.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Category", "Products");
                });

            modelBuilder.Entity("Telegram.BOT.Infrastructure.Database.Entities.Products.Groups", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Tags")
                        .IsRequired()
                        .HasMaxLength(1500)
                        .HasColumnType("character varying(1500)");

                    b.HasKey("Id");

                    b.ToTable("Group", "Products");
                });

            modelBuilder.Entity("Telegram.BOT.Infrastructure.Database.Entities.Products.Marc", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("IdCategory")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("IdCategory");

                    b.ToTable("Marc", "Products");
                });

            modelBuilder.Entity("Telegram.BOT.Infrastructure.Database.Entities.Products.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("IdMarc")
                        .HasColumnType("uuid");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("MarcId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<string>("Tags")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("IdMarc");

                    b.HasIndex("MarcId");

                    b.ToTable("Product", "Products");
                });

            modelBuilder.Entity("Telegram.BOT.Infrastructure.Database.Entities.Products.ProductGroups", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("Product25Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("Product50Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("Product75Id")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("Product25Id");

                    b.HasIndex("Product50Id");

                    b.HasIndex("Product75Id");

                    b.ToTable("ProductGroups", "Products");
                });

            modelBuilder.Entity("Telegram.BOT.Infrastructure.Database.Entities.Products.Marc", b =>
                {
                    b.HasOne("Telegram.BOT.Infrastructure.Database.Entities.Products.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("Telegram.BOT.Infrastructure.Database.Entities.Products.Category", null)
                        .WithMany("marcs")
                        .HasForeignKey("IdCategory");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Telegram.BOT.Infrastructure.Database.Entities.Products.Product", b =>
                {
                    b.HasOne("Telegram.BOT.Infrastructure.Database.Entities.Products.Marc", null)
                        .WithMany("products")
                        .HasForeignKey("IdMarc")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Telegram.BOT.Infrastructure.Database.Entities.Products.Marc", "Marc")
                        .WithMany()
                        .HasForeignKey("MarcId");

                    b.Navigation("Marc");
                });

            modelBuilder.Entity("Telegram.BOT.Infrastructure.Database.Entities.Products.ProductGroups", b =>
                {
                    b.HasOne("Telegram.BOT.Infrastructure.Database.Entities.Products.Groups", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Telegram.BOT.Infrastructure.Database.Entities.Products.Product", "Product25")
                        .WithMany("Group25")
                        .HasForeignKey("Product25Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Telegram.BOT.Infrastructure.Database.Entities.Products.Product", "Product50")
                        .WithMany("Group50")
                        .HasForeignKey("Product50Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Telegram.BOT.Infrastructure.Database.Entities.Products.Product", "Product75")
                        .WithMany("Group75")
                        .HasForeignKey("Product75Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("Product25");

                    b.Navigation("Product50");

                    b.Navigation("Product75");
                });

            modelBuilder.Entity("Telegram.BOT.Infrastructure.Database.Entities.Products.Category", b =>
                {
                    b.Navigation("marcs");
                });

            modelBuilder.Entity("Telegram.BOT.Infrastructure.Database.Entities.Products.Marc", b =>
                {
                    b.Navigation("products");
                });

            modelBuilder.Entity("Telegram.BOT.Infrastructure.Database.Entities.Products.Product", b =>
                {
                    b.Navigation("Group25");

                    b.Navigation("Group50");

                    b.Navigation("Group75");
                });
#pragma warning restore 612, 618
        }
    }
}
