﻿// <auto-generated />
using Crito.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Crito.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231007121646_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("Crito.Models.ContactFormEntity", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Email");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("Crito.Models.SubscriberEntity", b =>
                {
                    b.Property<string>("SubscribersEmail")
                        .HasColumnType("TEXT");

                    b.HasKey("SubscribersEmail");

                    b.ToTable("Subscribers");
                });
#pragma warning restore 612, 618
        }
    }
}