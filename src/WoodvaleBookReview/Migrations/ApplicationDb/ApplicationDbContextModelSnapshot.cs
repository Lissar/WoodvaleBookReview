using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WoodvaleBookReview.Models;

namespace WoodvaleBookReview.Migrations.ApplicationDb
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WoodvaleBookReview.Models.Author", b =>
                {
                    b.Property<int>("AuthorID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BookID");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("AuthorID");

                    b.HasIndex("BookID");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("WoodvaleBookReview.Models.Book", b =>
                {
                    b.Property<int>("BookID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Genre");

                    b.Property<string>("Title");

                    b.HasKey("BookID");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("WoodvaleBookReview.Models.Comment", b =>
                {
                    b.Property<int>("CommentID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<string>("Commenter");

                    b.Property<int?>("ReviewID");

                    b.HasKey("CommentID");

                    b.HasIndex("ReviewID");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("WoodvaleBookReview.Models.Review", b =>
                {
                    b.Property<int>("ReviewID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<int?>("BookID");

                    b.Property<int?>("ReviewerUserID");

                    b.Property<string>("Title");

                    b.HasKey("ReviewID");

                    b.HasIndex("BookID");

                    b.HasIndex("ReviewerUserID");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("WoodvaleBookReview.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("DisplayName");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("Id");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("Quote");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName");

                    b.HasKey("UserID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("WoodvaleBookReview.Models.Author", b =>
                {
                    b.HasOne("WoodvaleBookReview.Models.Book")
                        .WithMany("Authors")
                        .HasForeignKey("BookID");
                });

            modelBuilder.Entity("WoodvaleBookReview.Models.Comment", b =>
                {
                    b.HasOne("WoodvaleBookReview.Models.Review")
                        .WithMany("Comments")
                        .HasForeignKey("ReviewID");
                });

            modelBuilder.Entity("WoodvaleBookReview.Models.Review", b =>
                {
                    b.HasOne("WoodvaleBookReview.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookID");

                    b.HasOne("WoodvaleBookReview.Models.User", "Reviewer")
                        .WithMany()
                        .HasForeignKey("ReviewerUserID");
                });
        }
    }
}
