﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Telegram.BOT.Infrastructure.Database;

#nullable disable

namespace Telegram.BOT.Infrastructure.Database.Entities.Migrations
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

            modelBuilder.Entity("Telegram.BOT.Infrastructure.Database.Entities.Chat.Chat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Chat", "Chats");
                });

            modelBuilder.Entity("Telegram.BOT.Infrastructure.Database.Entities.Chat.Message", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ChatId")
                        .HasColumnType("uuid");

                    b.Property<string>("Messaging")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.ToTable("Message", "Chats");
                });

            modelBuilder.Entity("Telegram.BOT.Infrastructure.Database.Entities.Logs.Log", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("LogDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<string>("UseCase")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Logs", "public");
                });

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
                        .HasColumnType("timestamp with time zone");

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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Marc", "Products");
                });

            modelBuilder.Entity("Telegram.BOT.Infrastructure.Database.Entities.Products.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<Guid>("MarcId")
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

            modelBuilder.Entity("Telegram.BOT.Infrastructure.Database.Entities.Chat.Message", b =>
                {
                    b.HasOne("Telegram.BOT.Infrastructure.Database.Entities.Chat.Chat", "Chat")
                        .WithMany()
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chat");
                });

            modelBuilder.Entity("Telegram.BOT.Infrastructure.Database.Entities.Products.Marc", b =>
                {
                    b.HasOne("Telegram.BOT.Infrastructure.Database.Entities.Products.Category", "Category")
                        .WithMany("marcs")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Telegram.BOT.Infrastructure.Database.Entities.Products.Product", b =>
                {
                    b.HasOne("Telegram.BOT.Infrastructure.Database.Entities.Products.Marc", "Marc")
                        .WithMany("products")
                        .HasForeignKey("MarcId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Marc");
                });

            modelBuilder.Entity("Telegram.BOT.Infrastructure.Database.Entities.Products.ProductGroups", b =>
                {
                    b.HasOne("Telegram.BOT.Infrastructure.Database.Entities.Products.Groups", "Group")
                        .WithMany("Group")
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

            modelBuilder.Entity("Telegram.BOT.Infrastructure.Database.Entities.Products.Groups", b =>
                {
                    b.Navigation("Group");
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
