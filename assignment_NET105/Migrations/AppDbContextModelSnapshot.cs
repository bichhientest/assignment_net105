﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using assignment_NET105.Models;

#nullable disable

namespace assignment_NET105.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("assignment_NET105.Models.Combo", b =>
                {
                    b.Property<int>("ComboId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ComboId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ComboId");

                    b.ToTable("Combo");
                });

            modelBuilder.Entity("assignment_NET105.Models.ComboFastfood", b =>
                {
                    b.Property<int>("ComboId")
                        .HasColumnType("int");

                    b.Property<int>("FastfoodId")
                        .HasColumnType("int");

                    b.HasKey("ComboId", "FastfoodId");

                    b.HasIndex("FastfoodId");

                    b.ToTable("ComboFastfood");
                });

            modelBuilder.Entity("assignment_NET105.Models.Fastfood", b =>
                {
                    b.Property<int>("FastfoodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FastfoodId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FastfoodId");

                    b.ToTable("Fastfood");
                });

            modelBuilder.Entity("assignment_NET105.Models.OrderCombo", b =>
                {
                    b.Property<int>("OrderComboId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderComboId"));

                    b.Property<int>("ComboId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Orderdate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Quatity")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TotalAmount")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("OrderComboId");

                    b.HasIndex("ComboId");

                    b.HasIndex("UserId");

                    b.ToTable("OrderCombos");
                });

            modelBuilder.Entity("assignment_NET105.Models.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderDetailId"));

                    b.Property<int>("FastfoodId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Quatity")
                        .HasColumnType("int");

                    b.Property<string>("TotalAmount")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderDetailId");

                    b.HasIndex("FastfoodId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderDetail");
                });

            modelBuilder.Entity("assignment_NET105.Models.OrderFastfood", b =>
                {
                    b.Property<int>("OrderFastfoodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderFastfoodId"));

                    b.Property<DateTime>("Orderdate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Quatity")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TotalAmount")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("OrderFastfoodId");

                    b.HasIndex("UserId");

                    b.ToTable("OrderFastfoods");
                });

            modelBuilder.Entity("assignment_NET105.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("assignment_NET105.Models.ComboFastfood", b =>
                {
                    b.HasOne("assignment_NET105.Models.Combo", "Combo")
                        .WithMany("ComboFastfood")
                        .HasForeignKey("ComboId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("assignment_NET105.Models.Fastfood", "Fastfood")
                        .WithMany("ComboFastfood")
                        .HasForeignKey("FastfoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Combo");

                    b.Navigation("Fastfood");
                });

            modelBuilder.Entity("assignment_NET105.Models.OrderCombo", b =>
                {
                    b.HasOne("assignment_NET105.Models.Combo", "Combo")
                        .WithMany("OrderCombos")
                        .HasForeignKey("ComboId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("assignment_NET105.Models.User", "User")
                        .WithMany("OrderCombos")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Combo");

                    b.Navigation("User");
                });

            modelBuilder.Entity("assignment_NET105.Models.OrderDetail", b =>
                {
                    b.HasOne("assignment_NET105.Models.Fastfood", "Fastfood")
                        .WithMany()
                        .HasForeignKey("FastfoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("assignment_NET105.Models.OrderFastfood", "Orders")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fastfood");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("assignment_NET105.Models.OrderFastfood", b =>
                {
                    b.HasOne("assignment_NET105.Models.User", "User")
                        .WithMany("OrderFastfoods")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("assignment_NET105.Models.Combo", b =>
                {
                    b.Navigation("ComboFastfood");

                    b.Navigation("OrderCombos");
                });

            modelBuilder.Entity("assignment_NET105.Models.Fastfood", b =>
                {
                    b.Navigation("ComboFastfood");
                });

            modelBuilder.Entity("assignment_NET105.Models.User", b =>
                {
                    b.Navigation("OrderCombos");

                    b.Navigation("OrderFastfoods");
                });
#pragma warning restore 612, 618
        }
    }
}
