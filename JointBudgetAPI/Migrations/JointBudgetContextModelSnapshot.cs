﻿// <auto-generated />
using System;
using JointBudgetAPI.JointBudgetModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JointBudgetAPI.Migrations
{
    [DbContext(typeof(JointBudgetContext))]
    partial class JointBudgetContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("JointBudgetAPI.JointBudgetModels.Expense", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(450)
                        .IsUnicode(false)
                        .HasColumnType("varchar(450)");

                    b.Property<string>("CategoryId")
                        .IsRequired()
                        .HasColumnType("varchar(450)");

                    b.Property<bool>("IsPeriodical")
                        .HasColumnType("bit");

                    b.Property<double>("Sum")
                        .HasColumnType("float");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Expense", (string)null);
                });

            modelBuilder.Entity("JointBudgetAPI.JointBudgetModels.ExpenseCategory", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(450)
                        .IsUnicode(false)
                        .HasColumnType("varchar(450)");

                    b.Property<string>("ImageId")
                        .IsRequired()
                        .HasColumnType("varchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.HasIndex("UserId");

                    b.ToTable("ExpenseCategory", (string)null);
                });

            modelBuilder.Entity("JointBudgetAPI.JointBudgetModels.ExpenseImage", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(450)
                        .IsUnicode(false)
                        .HasColumnType("varchar(450)");

                    b.Property<string>("HexColor")
                        .IsRequired()
                        .HasMaxLength(7)
                        .IsUnicode(false)
                        .HasColumnType("varchar(7)");

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("ExpenseImage", (string)null);
                });

            modelBuilder.Entity("JointBudgetAPI.JointBudgetModels.FamilyGroup", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(450)
                        .IsUnicode(false)
                        .HasColumnType("varchar(450)");

                    b.HasKey("Id");

                    b.ToTable("FamilyGroup", (string)null);
                });

            modelBuilder.Entity("JointBudgetAPI.JointBudgetModels.Income", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(450)
                        .IsUnicode(false)
                        .HasColumnType("varchar(450)");

                    b.Property<string>("CategoryId")
                        .IsRequired()
                        .HasColumnType("varchar(450)");

                    b.Property<bool>("IsPeriodical")
                        .HasColumnType("bit");

                    b.Property<double>("Sum")
                        .HasColumnType("float");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Income", (string)null);
                });

            modelBuilder.Entity("JointBudgetAPI.JointBudgetModels.IncomeCategory", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(450)
                        .IsUnicode(false)
                        .HasColumnType("varchar(450)");

                    b.Property<string>("ImageId")
                        .IsRequired()
                        .HasColumnType("varchar(7)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.HasIndex("UserId");

                    b.ToTable("IncomeCategory", (string)null);
                });

            modelBuilder.Entity("JointBudgetAPI.JointBudgetModels.IncomeImage", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(7)
                        .IsUnicode(false)
                        .HasColumnType("varchar(7)");

                    b.Property<string>("HexColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("IncomeImage", (string)null);
                });

            modelBuilder.Entity("JointBudgetAPI.JointBudgetModels.User", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(450)
                        .IsUnicode(false)
                        .HasColumnType("varchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FamilyGroupId")
                        .IsRequired()
                        .HasColumnType("varchar(450)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("FamilyGroupId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("JointBudgetAPI.JointBudgetModels.Expense", b =>
                {
                    b.HasOne("JointBudgetAPI.JointBudgetModels.ExpenseCategory", "ExpenseCategory")
                        .WithMany("Expenses")
                        .HasForeignKey("CategoryId")
                        .IsRequired()
                        .HasConstraintName("FK_Expense_ExpenseCategory");

                    b.HasOne("JointBudgetAPI.JointBudgetModels.User", "User")
                        .WithMany("Expenses")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_Expense_User");

                    b.Navigation("ExpenseCategory");

                    b.Navigation("User");
                });

            modelBuilder.Entity("JointBudgetAPI.JointBudgetModels.ExpenseCategory", b =>
                {
                    b.HasOne("JointBudgetAPI.JointBudgetModels.ExpenseImage", "ExpenseImage")
                        .WithMany("ExpenseCategories")
                        .HasForeignKey("ImageId")
                        .IsRequired()
                        .HasConstraintName("FK_ExpenseCategory_ExpenseImage");

                    b.HasOne("JointBudgetAPI.JointBudgetModels.User", "User")
                        .WithMany("ExpenseCategories")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_ExpenseCategory_User");

                    b.Navigation("ExpenseImage");

                    b.Navigation("User");
                });

            modelBuilder.Entity("JointBudgetAPI.JointBudgetModels.Income", b =>
                {
                    b.HasOne("JointBudgetAPI.JointBudgetModels.IncomeCategory", "IncomeCategory")
                        .WithMany("Incomes")
                        .HasForeignKey("CategoryId")
                        .IsRequired()
                        .HasConstraintName("FK_Income_IncomeCategory");

                    b.HasOne("JointBudgetAPI.JointBudgetModels.User", "User")
                        .WithMany("Incomes")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_Income_User");

                    b.Navigation("IncomeCategory");

                    b.Navigation("User");
                });

            modelBuilder.Entity("JointBudgetAPI.JointBudgetModels.IncomeCategory", b =>
                {
                    b.HasOne("JointBudgetAPI.JointBudgetModels.IncomeImage", "IncomeImage")
                        .WithMany("IncomeCategories")
                        .HasForeignKey("ImageId")
                        .IsRequired()
                        .HasConstraintName("FK_IncomeCategory_IncomeImage");

                    b.HasOne("JointBudgetAPI.JointBudgetModels.User", "User")
                        .WithMany("IncomeCategories")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_IncomeCategory_User");

                    b.Navigation("IncomeImage");

                    b.Navigation("User");
                });

            modelBuilder.Entity("JointBudgetAPI.JointBudgetModels.User", b =>
                {
                    b.HasOne("JointBudgetAPI.JointBudgetModels.FamilyGroup", "FamilyGroup")
                        .WithMany("Users")
                        .HasForeignKey("FamilyGroupId")
                        .IsRequired()
                        .HasConstraintName("FK_User_FamilyGroup");

                    b.Navigation("FamilyGroup");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("JointBudgetAPI.JointBudgetModels.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("JointBudgetAPI.JointBudgetModels.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JointBudgetAPI.JointBudgetModels.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("JointBudgetAPI.JointBudgetModels.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JointBudgetAPI.JointBudgetModels.ExpenseCategory", b =>
                {
                    b.Navigation("Expenses");
                });

            modelBuilder.Entity("JointBudgetAPI.JointBudgetModels.ExpenseImage", b =>
                {
                    b.Navigation("ExpenseCategories");
                });

            modelBuilder.Entity("JointBudgetAPI.JointBudgetModels.FamilyGroup", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("JointBudgetAPI.JointBudgetModels.IncomeCategory", b =>
                {
                    b.Navigation("Incomes");
                });

            modelBuilder.Entity("JointBudgetAPI.JointBudgetModels.IncomeImage", b =>
                {
                    b.Navigation("IncomeCategories");
                });

            modelBuilder.Entity("JointBudgetAPI.JointBudgetModels.User", b =>
                {
                    b.Navigation("ExpenseCategories");

                    b.Navigation("Expenses");

                    b.Navigation("IncomeCategories");

                    b.Navigation("Incomes");
                });
#pragma warning restore 612, 618
        }
    }
}