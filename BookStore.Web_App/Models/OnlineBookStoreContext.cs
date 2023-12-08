using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BookStore.Web_App.Models
{
    public partial class OnlineBookStoreContext : DbContext
    {
        public OnlineBookStoreContext()
        {
        }

        public OnlineBookStoreContext(DbContextOptions<OnlineBookStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Orderitem> Orderitems { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("AUTHORS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Bio)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("BIO");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("NAME");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("BOOKS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Authorid).HasColumnName("AUTHORID");

                entity.Property(e => e.Coverimageurl)
                    .IsUnicode(false)
                    .HasColumnName("COVERIMAGEURL");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Genre)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("GENRE");

                entity.Property(e => e.Price).HasColumnName("PRICE");

                entity.Property(e => e.Publicationdate)
                    .HasColumnType("datetime")
                    .HasColumnName("PUBLICATIONDATE");

                entity.Property(e => e.Title)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("TITLE");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.Authorid)
                    .HasConstraintName("FK__BOOKS__AUTHORID__4D94879B");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("ORDERS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Orderdate)
                    .HasColumnType("datetime")
                    .HasColumnName("ORDERDATE");

                entity.Property(e => e.Totalamount).HasColumnName("TOTALAMOUNT");

                entity.Property(e => e.Userid).HasColumnName("USERID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("FK__ORDERS__USERID__3E52440B");
            });

            modelBuilder.Entity<Orderitem>(entity =>
            {
                entity.ToTable("ORDERITEMS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Bookid).HasColumnName("BOOKID");

                entity.Property(e => e.Orderid).HasColumnName("ORDERID");

                entity.Property(e => e.Quantity).HasColumnName("QUANTITY");

                entity.Property(e => e.Subtotal).HasColumnName("SUBTOTAL");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Orderitems)
                    .HasForeignKey(d => d.Bookid)
                    .HasConstraintName("FK__ORDERITEM__BOOKI__5165187F");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Orderitems)
                    .HasForeignKey(d => d.Orderid)
                    .HasConstraintName("FK__ORDERITEM__ORDER__5070F446");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("REVIEWS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Bookid).HasColumnName("BOOKID");

                entity.Property(e => e.Comment)
                    .IsUnicode(false)
                    .HasColumnName("COMMENT");

                entity.Property(e => e.Rating).HasColumnName("RATING");

                entity.Property(e => e.Reviewdate)
                    .HasColumnType("datetime")
                    .HasColumnName("REVIEWDATE");

                entity.Property(e => e.Userid).HasColumnName("USERID");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.Bookid)
                    .HasConstraintName("FK__REVIEWS__BOOKID__5535A963");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("FK__REVIEWS__USERID__5441852A");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USERS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Password)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Role)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ROLE");

                entity.Property(e => e.Username)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
