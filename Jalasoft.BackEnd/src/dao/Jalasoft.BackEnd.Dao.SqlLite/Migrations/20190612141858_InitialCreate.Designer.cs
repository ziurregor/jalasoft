﻿// <auto-generated />
using System;
using Jalasoft.BackEnd.Dao.SqlLite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Jalasoft.BackEnd.Dao.SqlLite.Migrations
{
    [DbContext(typeof(EntityFrameworkSQLite))]
    [Migration("20190612141858_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity("Jalasoft.BackEnd.Model.ChatMessage", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ChatUserid");

                    b.Property<int>("idUser");

                    b.Property<string>("message");

                    b.HasKey("id");

                    b.HasIndex("ChatUserid");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("Jalasoft.BackEnd.Model.chatUser", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("email");

                    b.HasKey("id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Jalasoft.BackEnd.Model.ChatMessage", b =>
                {
                    b.HasOne("Jalasoft.BackEnd.Model.chatUser")
                        .WithMany("messages")
                        .HasForeignKey("ChatUserid");
                });
#pragma warning restore 612, 618
        }
    }
}
