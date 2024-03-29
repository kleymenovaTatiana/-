﻿// <auto-generated />
using System;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(Практика10Context))]
    partial class Практика10ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Models.BasketBuyer", b =>
                {
                    b.Property<int>("IdUser")
                        .HasColumnType("int")
                        .HasColumnName("id_user");

                    b.Property<int>("LtemNumber")
                        .HasColumnType("int")
                        .HasColumnName("ltem_number");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("IdUser", "LtemNumber")
                        .HasName("PK__Basket_B__46D3E7A4A92CCF8E");

                    b.HasIndex("LtemNumber");

                    b.ToTable("Basket_Buyer", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("Category_id");

                    b.Property<string>("Aquariums")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ForBirds")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("For_birds");

                    b.Property<string>("ForCats")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("For_cats");

                    b.Property<string>("ForDogs")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("For_dogs");

                    b.HasKey("CategoryId");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Customer", b =>
                {
                    b.Property<int>("ClieNtCode")
                        .HasColumnType("int")
                        .HasColumnName("ClieNt_code");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("date");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Middle_name");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("Phone_number");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ClieNtCode")
                        .HasName("PK__Customer__39C9B6488972FDD8");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Domain.Models.Filter", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("Category_id");

                    b.Property<string>("Aquariums")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("aquariums");

                    b.Property<string>("Bowls")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Feed")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Toys")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("toys");

                    b.HasKey("CategoryId")
                        .HasName("PK__filter__6DB281365D12F919");

                    b.ToTable("filter", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Order", b =>
                {
                    b.Property<int>("OrderCode")
                        .HasColumnType("int")
                        .HasColumnName("Order_code");

                    b.Property<int>("IdUser")
                        .HasColumnType("int")
                        .HasColumnName("id_user");

                    b.Property<int>("LtemNumber")
                        .HasColumnType("int")
                        .HasColumnName("ltem_number");

                    b.Property<int>("EmployeeCode")
                        .HasColumnType("int")
                        .HasColumnName("Employee_Code");

                    b.Property<DateTime>("DateAndTime")
                        .HasColumnType("datetime")
                        .HasColumnName("Date_and_time");

                    b.Property<string>("DeliveryMethod")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Delivery_method");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("OrderCode", "IdUser", "LtemNumber", "EmployeeCode")
                        .HasName("PK__Orders__6B8A3A323F59E206");

                    b.HasIndex("EmployeeCode");

                    b.HasIndex("IdUser");

                    b.HasIndex("LtemNumber");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Domain.Models.Products1", b =>
                {
                    b.Property<int>("LtemNumber")
                        .HasColumnType("int")
                        .HasColumnName("ltem_number");

                    b.Property<int>("ArticleNumber")
                        .HasColumnType("int")
                        .HasColumnName("Article_number");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("Category_id");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(25,2)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("NumberInClade")
                        .HasColumnType("int")
                        .HasColumnName("Number_in_clade");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("LtemNumber")
                        .HasName("PK__Products__402A1938C04A35E2");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products1", (string)null);
                });

            modelBuilder.Entity("Domain.Models.staff", b =>
                {
                    b.Property<int>("EmployeeCode")
                        .HasColumnType("int")
                        .HasColumnName("Employee_code");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("date");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Middle_name");

                    b.Property<string>("Namee")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("Phone_number");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("EmployeeCode")
                        .HasName("PK__Staff__AB80DE19E61BAA15");

                    b.ToTable("Staff", (string)null);
                });

            modelBuilder.Entity("Domain.Models.BasketBuyer", b =>
                {
                    b.HasOne("Domain.Models.Customer", "IdUserNavigation")
                        .WithMany("BasketBuyers")
                        .HasForeignKey("IdUser")
                        .IsRequired()
                        .HasConstraintName("FK__Basket_Bu__id_us__46E78A0C");

                    b.HasOne("Domain.Models.Products1", "LtemNumberNavigation")
                        .WithMany("BasketBuyers")
                        .HasForeignKey("LtemNumber")
                        .IsRequired()
                        .HasConstraintName("FK__Basket_Bu__ltem___47DBAE45");

                    b.Navigation("IdUserNavigation");

                    b.Navigation("LtemNumberNavigation");
                });

            modelBuilder.Entity("Domain.Models.Filter", b =>
                {
                    b.HasOne("Domain.Models.Category", "Category")
                        .WithOne("Filter")
                        .HasForeignKey("Domain.Models.Filter", "CategoryId")
                        .IsRequired()
                        .HasConstraintName("FK__filter__Category__4AB81AF0");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Domain.Models.Order", b =>
                {
                    b.HasOne("Domain.Models.staff", "EmployeeCodeNavigation")
                        .WithMany("Orders")
                        .HasForeignKey("EmployeeCode")
                        .IsRequired()
                        .HasConstraintName("FK__Orders__Employee__4F7CD00D");

                    b.HasOne("Domain.Models.Customer", "IdUserNavigation")
                        .WithMany("Orders")
                        .HasForeignKey("IdUser")
                        .IsRequired()
                        .HasConstraintName("FK__Orders__id_user__4D94879B");

                    b.HasOne("Domain.Models.Products1", "LtemNumberNavigation")
                        .WithMany("Orders")
                        .HasForeignKey("LtemNumber")
                        .IsRequired()
                        .HasConstraintName("FK__Orders__ltem_num__4E88ABD4");

                    b.Navigation("EmployeeCodeNavigation");

                    b.Navigation("IdUserNavigation");

                    b.Navigation("LtemNumberNavigation");
                });

            modelBuilder.Entity("Domain.Models.Products1", b =>
                {
                    b.HasOne("Domain.Models.Category", "Category")
                        .WithMany("Products1s")
                        .HasForeignKey("CategoryId")
                        .IsRequired()
                        .HasConstraintName("FK__Products1__Numbe__440B1D61");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Domain.Models.Category", b =>
                {
                    b.Navigation("Filter");

                    b.Navigation("Products1s");
                });

            modelBuilder.Entity("Domain.Models.Customer", b =>
                {
                    b.Navigation("BasketBuyers");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Domain.Models.Products1", b =>
                {
                    b.Navigation("BasketBuyers");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Domain.Models.staff", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
