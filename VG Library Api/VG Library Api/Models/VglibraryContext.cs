using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace VG_Library_Api.Models;

public partial class VglibraryContext : DbContext
{
    public VglibraryContext()
    {
    }

    public VglibraryContext(DbContextOptions<VglibraryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BookCategory> BookCategories { get; set; }

    public virtual DbSet<Borrow> Borrows { get; set; }

    public virtual DbSet<Fine> Fines { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Transcaction> Transcactions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-K9P6HGH\\SQLEXPRESS;Database=VGLibrary;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.ToTable("Book");

            entity.Property(e => e.BookId).HasColumnName("Book_Id");
            entity.Property(e => e.BcId).HasColumnName("BC_Id");
            entity.Property(e => e.BookAuthor)
                .IsUnicode(false)
                .HasColumnName("Book_Author");
            entity.Property(e => e.BookFine)
                .IsUnicode(false)
                .HasColumnName("Book_Fine");
            entity.Property(e => e.BookOrdered)
                .IsUnicode(false)
                .HasColumnName("Book_Ordered");
            entity.Property(e => e.BookQuantity).HasColumnName("Book_Quantity");
            entity.Property(e => e.BookStatus)
                .IsUnicode(false)
                .HasColumnName("Book_Status");
            entity.Property(e => e.BookTitle)
                .IsUnicode(false)
                .HasColumnName("Book_Title");

            entity.HasOne(d => d.Bc).WithMany(p => p.Books)
                .HasForeignKey(d => d.BcId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Book_BookCategory");
        });

        modelBuilder.Entity<BookCategory>(entity =>
        {
            entity.HasKey(e => e.BcId);

            entity.ToTable("BookCategory");

            entity.Property(e => e.BcId).HasColumnName("BC_Id");
            entity.Property(e => e.BcCategory)
                .IsUnicode(false)
                .HasColumnName("BC_Category");
            entity.Property(e => e.BcSubCategory)
                .IsUnicode(false)
                .HasColumnName("BC_SubCategory");
        });

        modelBuilder.Entity<Borrow>(entity =>
        {
            entity.ToTable("Borrow");

            entity.Property(e => e.BorrowId).HasColumnName("Borrow_Id");
            entity.Property(e => e.BookId).HasColumnName("Book_Id");
            entity.Property(e => e.BorrowDate)
                .HasColumnType("date")
                .HasColumnName("Borrow_Date");
            entity.Property(e => e.BorrowReturnDate)
                .HasColumnType("date")
                .HasColumnName("Borrow_ReturnDate");
            entity.Property(e => e.BorrowStatus)
                .IsUnicode(false)
                .HasColumnName("Borrow_Status");
            entity.Property(e => e.BorrowUrl)
                .IsUnicode(false)
                .HasColumnName("Borrow_URL");
            entity.Property(e => e.BorrowUrlscanner)
                .IsUnicode(false)
                .HasColumnName("Borrow_URLScanner");
            entity.Property(e => e.MemberId).HasColumnName("Member_Id");

            entity.HasOne(d => d.Book).WithMany(p => p.Borrows)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Borrow_Book");

            entity.HasOne(d => d.Member).WithMany(p => p.Borrows)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Borrow_Member");
        });

        modelBuilder.Entity<Fine>(entity =>
        {
            entity.ToTable("Fine");

            entity.Property(e => e.FineId).HasColumnName("Fine_Id");
            entity.Property(e => e.BorrowId).HasColumnName("Borrow_Id");
            entity.Property(e => e.FineAmount)
                .IsUnicode(false)
                .HasColumnName("Fine_Amount");
            entity.Property(e => e.FineDate)
                .HasColumnType("date")
                .HasColumnName("Fine_Date");
            entity.Property(e => e.MemberId).HasColumnName("Member_Id");

            entity.HasOne(d => d.Borrow).WithMany(p => p.Fines)
                .HasForeignKey(d => d.BorrowId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Fine_Borrow");

            entity.HasOne(d => d.Member).WithMany(p => p.Fines)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Fine_Member");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.ToTable("Member");

            entity.Property(e => e.MemberId).HasColumnName("Member_Id");
            entity.Property(e => e.MemberAddress)
                .IsUnicode(false)
                .HasColumnName("Member_Address");
            entity.Property(e => e.MemberBlock)
                .IsUnicode(false)
                .HasColumnName("Member_Block");
            entity.Property(e => e.MemberContactDetails)
                .IsUnicode(false)
                .HasColumnName("Member_ContactDetails");
            entity.Property(e => e.MemberDateCreate)
                .HasColumnType("date")
                .HasColumnName("Member_DateCreate");
            entity.Property(e => e.MemberEmail)
                .IsUnicode(false)
                .HasColumnName("Member_Email");
            entity.Property(e => e.MemberName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Member_Name");
            entity.Property(e => e.MemberPassword)
                .IsUnicode(false)
                .HasColumnName("Member_Password");
            entity.Property(e => e.MemberStatus)
                .IsUnicode(false)
                .HasColumnName("Member_Status");
            entity.Property(e => e.MemberSurname)
                .IsUnicode(false)
                .HasColumnName("Member_Surname");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.ToTable("Notification");

            entity.Property(e => e.NotificationId).HasColumnName("Notification_Id");
            entity.Property(e => e.MemberId).HasColumnName("Member_Id");
            entity.Property(e => e.NotificationDate)
                .HasColumnType("date")
                .HasColumnName("Notification_Date");
            entity.Property(e => e.NotificationDetails)
                .IsUnicode(false)
                .HasColumnName("Notification_Details");
            entity.Property(e => e.NotificationStatus)
                .IsUnicode(false)
                .HasColumnName("Notification_Status");
            entity.Property(e => e.NotificationType)
                .IsUnicode(false)
                .HasColumnName("Notification_Type");

            entity.HasOne(d => d.Member).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Notification_Member");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.ToTable("Room");

            entity.Property(e => e.RoomId).HasColumnName("Room_ID");
            entity.Property(e => e.MemberId).HasColumnName("Member_Id");
            entity.Property(e => e.RoomAvailability)
                .IsUnicode(false)
                .HasColumnName("Room_Availability");
            entity.Property(e => e.RoomDate)
                .HasColumnType("date")
                .HasColumnName("Room_Date");
            entity.Property(e => e.RoomName)
                .IsUnicode(false)
                .HasColumnName("Room_Name");
            entity.Property(e => e.RoomStatus)
                .IsUnicode(false)
                .HasColumnName("Room_Status");
            entity.Property(e => e.RoomType)
                .IsUnicode(false)
                .HasColumnName("Room_Type");
            entity.Property(e => e.RoomUrl)
                .IsUnicode(false)
                .HasColumnName("Room_URL");

            entity.HasOne(d => d.Member).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Room_Member");
        });

        modelBuilder.Entity<Transcaction>(entity =>
        {
            entity.HasKey(e => e.TranscId);

            entity.ToTable("Transcaction");

            entity.Property(e => e.TranscId).HasColumnName("Transc_Id");
            entity.Property(e => e.FineId).HasColumnName("Fine_Id");
            entity.Property(e => e.MemberId).HasColumnName("Member_Id");
            entity.Property(e => e.TranscDate)
                .HasColumnType("date")
                .HasColumnName("Transc_Date");
            entity.Property(e => e.TranscPayment)
                .IsUnicode(false)
                .HasColumnName("Transc_Payment");
            entity.Property(e => e.TranscStatus)
                .IsUnicode(false)
                .HasColumnName("Transc_Status");

            entity.HasOne(d => d.Fine).WithMany(p => p.Transcactions)
                .HasForeignKey(d => d.FineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transcaction_Fine");

            entity.HasOne(d => d.Member).WithMany(p => p.Transcactions)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transcaction_Member");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
