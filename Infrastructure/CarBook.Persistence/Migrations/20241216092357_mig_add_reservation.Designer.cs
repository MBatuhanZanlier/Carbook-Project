﻿// <auto-generated />
using System;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarBook.Persistence.Migrations
{
    [DbContext(typeof(CarbookContext))]
    [Migration("20241216092357_mig_add_reservation")]
    partial class mig_add_reservation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CarBook.Domain.Entities.About", b =>
                {
                    b.Property<int>("AboutId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AboutId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AboutId");

                    b.ToTable("Abouts");
                });

            modelBuilder.Entity("CarBook.Domain.Entities.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuthorId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuthorId");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("CarBook.Domain.Entities.Banner", b =>
                {
                    b.Property<int>("BannerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BannerId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VideoDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VideoUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BannerId");

                    b.ToTable("Banners");
                });

            modelBuilder.Entity("CarBook.Domain.Entities.Blog", b =>
                {
                    b.Property<int>("BlogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BlogId"));

                    b.Property<int>("AuthorID")
                        .HasColumnType("int");

                    b.Property<int?>("BlogId1")
                        .HasColumnType("int");

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("CoverImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BlogId");

                    b.HasIndex("AuthorID");

                    b.HasIndex("BlogId1");

                    b.HasIndex("CategoryID");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("CarBook.Domain.Entities.Brand", b =>
                {
                    b.Property<int>("BrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BrandId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BrandId");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("CarBook.Domain.Entities.Car", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarId"));

                    b.Property<string>("BigImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<string>("CoverImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fuel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Km")
                        .HasColumnType("int");

                    b.Property<byte>("Luggage")
                        .HasColumnType("tinyint");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("Seat")
                        .HasColumnType("tinyint");

                    b.Property<string>("Transmission")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CarId");

                    b.HasIndex("BrandId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("CarBook.Domain.Entities.CarDescription", b =>
                {
                    b.Property<int>("CarDescriptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarDescriptionId"));

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CarDescriptionId");

                    b.HasIndex("CarId");

                    b.ToTable("CarDescriptions");
                });

            modelBuilder.Entity("CarBook.Domain.Entities.CarFeature", b =>
                {
                    b.Property<int>("CarFeatureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarFeatureId"));

                    b.Property<bool>("Available")
                        .HasColumnType("bit");

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("FeatureID")
                        .HasColumnType("int");

                    b.HasKey("CarFeatureId");

                    b.HasIndex("CarId");

                    b.HasIndex("FeatureID");

                    b.ToTable("CarFeatures");
                });

            modelBuilder.Entity("CarBook.Domain.Entities.CarPricing", b =>
                {
                    b.Property<int>("CarPricingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarPricingId"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("PricingId")
                        .HasColumnType("int");

                    b.HasKey("CarPricingId");

                    b.HasIndex("CarId");

                    b.HasIndex("PricingId");

                    b.ToTable("CarPricings");
                });

            modelBuilder.Entity("CarBook.Domain.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("CarBook.Domain.Entities.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentId"));

                    b.Property<int>("BlogId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CommentId");

                    b.HasIndex("BlogId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("CarBook.Domain.Entities.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContactId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SendDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContactId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("CarBook.Domain.Entities.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerID"));

                    b.Property<string>("CustomerMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerSurname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("CarBook.Domain.Entities.Feature", b =>
                {
                    b.Property<int>("FeatureID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FeatureID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FeatureID");

                    b.ToTable("Features");
                });

            modelBuilder.Entity("CarBook.Domain.Entities.FooterAddress", b =>
                {
                    b.Property<int>("FooterAddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FooterAddressId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FooterAddressId");

                    b.ToTable("FooterAddresses");
                });

            modelBuilder.Entity("CarBook.Domain.Entities.Location", b =>
                {
                    b.Property<int>("LocationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LocationID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LocationID");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("CarBook.Domain.Entities.Pricing", b =>
                {
                    b.Property<int>("PricingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PricingId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PricingId");

                    b.ToTable("Pricings");
                });

            modelBuilder.Entity("CarBook.Domain.Entities.RentACarProcess", b =>
                {
                    b.Property<int>("RentACarProcessID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RentACarProcessID"));

                    b.Property<int>("CarID")
                        .HasColumnType("int");

                    b.Property<int?>("CustomerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DropOffDate")
                        .HasColumnType("Date");

                    b.Property<string>("DropOffDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DropOffLocation")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("DropOffTime")
                        .HasColumnType("time");

                    b.Property<DateTime>("PickUpDate")
                        .HasColumnType("Date");

                    b.Property<string>("PickUpDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PickUpLocation")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("PickUpTime")
                        .HasColumnType("time");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("RentACarProcessID");

                    b.HasIndex("CarID");

                    b.HasIndex("CustomerID");

                    b.ToTable("RentACarProcesses");
                });

            modelBuilder.Entity("CarBook.Domain.Entities.RentaCar", b =>
                {
                    b.Property<int>("RentACarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RentACarId"));

                    b.Property<bool>("Available")
                        .HasColumnType("bit");

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("LocationID")
                        .HasColumnType("int");

                    b.HasKey("RentACarId");

                    b.HasIndex("CarId");

                    b.HasIndex("LocationID");

                    b.ToTable("RentaCars");
                });

            modelBuilder.Entity("CarBook.Domain.Entities.Reservation", b =>
                {
                    b.Property<int>("ReservationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationID"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("CarID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DriverLicenseYear")
                        .HasColumnType("int");

                    b.Property<int?>("DropOffLocationID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PickUpLocationID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReservationID");

                    b.HasIndex("CarID");

                    b.HasIndex("DropOffLocationID");

                    b.HasIndex("PickUpLocationID");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("CarBook.Domain.Entities.Service", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServiceId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IcounUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ServiceId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("CarBook.Domain.Entities.SocialMedia", b =>
                {
                    b.Property<int>("SocialMediaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SocialMediaID"));

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SocialMediaID");

                    b.ToTable("SocialMedia");
                });

            modelBuilder.Entity("CarBook.Domain.Entities.TagCloud", b =>
                {
                    b.Property<int>("TagCloudId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TagCloudId"));

                    b.Property<int>("BlogId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TagCloudId");

                    b.HasIndex("BlogId");

                    b.ToTable("TagClouds");
                });

            modelBuilder.Entity("CarBook.Domain.Entities.Testimonial", b =>
                {
                    b.Property<int>("TestimonialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TestimonialId"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TestimonialId");

                    b.ToTable("Testimonials");
                });

            modelBuilder.Entity("CarBook.Domain.Entities.Blog", b =>
                {
                    b.HasOne("CarBook.Domain.Entities.Author", "Author")
                        .WithMany("Blogs")
                        .HasForeignKey("AuthorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarBook.Domain.Entities.Blog", null)
                        .WithMany("Blogs")
                        .HasForeignKey("BlogId1");

                    b.HasOne("CarBook.Domain.Entities.Category", "Category")
                        .WithMany("Blogs")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("CarBook.Domain.Entities.Car", b =>
                {
                    b.HasOne("CarBook.Domain.Entities.Brand", "Brand")
                        .WithMany("Cars")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("CarBook.Domain.Entities.CarDescription", b =>
                {
                    b.HasOne("CarBook.Domain.Entities.Car", "Car")
                        .WithMany("CarDescriptions")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("CarBook.Domain.Entities.CarFeature", b =>
                {
                    b.HasOne("CarBook.Domain.Entities.Car", "Car")
                        .WithMany("CarFeatures")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarBook.Domain.Entities.Feature", "Feature")
                        .WithMany("CarFeatures")
                        .HasForeignKey("FeatureID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Feature");
                });

            modelBuilder.Entity("CarBook.Domain.Entities.CarPricing", b =>
                {
                    b.HasOne("CarBook.Domain.Entities.Car", "Car")
                        .WithMany("CarPricings")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarBook.Domain.Entities.Pricing", "Pricing")
                        .WithMany("CarPricings")
                        .HasForeignKey("PricingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Pricing");
                });

            modelBuilder.Entity("CarBook.Domain.Entities.Comment", b =>
                {
                    b.HasOne("CarBook.Domain.Entities.Blog", "Blog")
                        .WithMany()
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Blog");
                });

            modelBuilder.Entity("CarBook.Domain.Entities.RentACarProcess", b =>
                {
                    b.HasOne("CarBook.Domain.Entities.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarBook.Domain.Entities.Customer", null)
                        .WithMany("RentACarProcesses")
                        .HasForeignKey("CustomerID");

                    b.Navigation("Car");
                });

            modelBuilder.Entity("CarBook.Domain.Entities.RentaCar", b =>
                {
                    b.HasOne("CarBook.Domain.Entities.Car", "Car")
                        .WithMany("RentaCars")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarBook.Domain.Entities.Location", "Location")
                        .WithMany("RentaCars")
                        .HasForeignKey("LocationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("CarBook.Domain.Entities.Reservation", b =>
                {
                    b.HasOne("CarBook.Domain.Entities.Car", "Car")
                        .WithMany("Reservations")
                        .HasForeignKey("CarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarBook.Domain.Entities.Location", "DropOffLocation")
                        .WithMany("DropOffReservation")
                        .HasForeignKey("DropOffLocationID")
                        .IsRequired();

                    b.HasOne("CarBook.Domain.Entities.Location", "PickUpLocation")
                        .WithMany("PickUpReservation")
                        .HasForeignKey("PickUpLocationID")
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("DropOffLocation");

                    b.Navigation("PickUpLocation");
                });

            modelBuilder.Entity("CarBook.Domain.Entities.TagCloud", b =>
                {
                    b.HasOne("CarBook.Domain.Entities.Blog", "Blog")
                        .WithMany("TagClouds")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Blog");
                });

            modelBuilder.Entity("CarBook.Domain.Entities.Author", b =>
                {
                    b.Navigation("Blogs");
                });

            modelBuilder.Entity("CarBook.Domain.Entities.Blog", b =>
                {
                    b.Navigation("Blogs");

                    b.Navigation("TagClouds");
                });

            modelBuilder.Entity("CarBook.Domain.Entities.Brand", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("CarBook.Domain.Entities.Car", b =>
                {
                    b.Navigation("CarDescriptions");

                    b.Navigation("CarFeatures");

                    b.Navigation("CarPricings");

                    b.Navigation("RentaCars");

                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("CarBook.Domain.Entities.Category", b =>
                {
                    b.Navigation("Blogs");
                });

            modelBuilder.Entity("CarBook.Domain.Entities.Customer", b =>
                {
                    b.Navigation("RentACarProcesses");
                });

            modelBuilder.Entity("CarBook.Domain.Entities.Feature", b =>
                {
                    b.Navigation("CarFeatures");
                });

            modelBuilder.Entity("CarBook.Domain.Entities.Location", b =>
                {
                    b.Navigation("DropOffReservation");

                    b.Navigation("PickUpReservation");

                    b.Navigation("RentaCars");
                });

            modelBuilder.Entity("CarBook.Domain.Entities.Pricing", b =>
                {
                    b.Navigation("CarPricings");
                });
#pragma warning restore 612, 618
        }
    }
}
