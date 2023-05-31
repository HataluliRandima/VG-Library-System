﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VG_Library_Api.Models;

#nullable disable

namespace VG_Library_Api.Migrations
{
    [DbContext(typeof(VglibraryContext))]
    partial class VglibraryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("VG_Library_Api.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Book_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"));

                    b.Property<int>("BcId")
                        .HasColumnType("int")
                        .HasColumnName("BC_Id");

                    b.Property<string>("BookAuthor")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Book_Author");

                    b.Property<string>("BookFine")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Book_Fine");

                    b.Property<string>("BookOrdered")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Book_Ordered");

                    b.Property<int?>("BookQuantity")
                        .HasColumnType("int")
                        .HasColumnName("Book_Quantity");

                    b.Property<string>("BookStatus")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Book_Status");

                    b.Property<string>("BookTitle")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Book_Title");

                    b.HasKey("BookId");

                    b.HasIndex("BcId");

                    b.ToTable("Book", (string)null);
                });

            modelBuilder.Entity("VG_Library_Api.Models.BookCategory", b =>
                {
                    b.Property<int>("BcId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("BC_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BcId"));

                    b.Property<string>("BcCategory")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("BC_Category");

                    b.Property<string>("BcSubCategory")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("BC_SubCategory");

                    b.HasKey("BcId");

                    b.ToTable("BookCategory", (string)null);
                });

            modelBuilder.Entity("VG_Library_Api.Models.Borrow", b =>
                {
                    b.Property<int>("BorrowId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Borrow_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BorrowId"));

                    b.Property<int>("BookId")
                        .HasColumnType("int")
                        .HasColumnName("Book_Id");

                    b.Property<DateTime?>("BorrowDate")
                        .HasColumnType("date")
                        .HasColumnName("Borrow_Date");

                    b.Property<DateTime?>("BorrowReturnDate")
                        .HasColumnType("date")
                        .HasColumnName("Borrow_ReturnDate");

                    b.Property<string>("BorrowStatus")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Borrow_Status");

                    b.Property<string>("BorrowUrl")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Borrow_URL");

                    b.Property<string>("BorrowUrlscanner")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Borrow_URLScanner");

                    b.Property<int>("MemberId")
                        .HasColumnType("int")
                        .HasColumnName("Member_Id");

                    b.HasKey("BorrowId");

                    b.HasIndex("BookId");

                    b.HasIndex("MemberId");

                    b.ToTable("Borrow", (string)null);
                });

            modelBuilder.Entity("VG_Library_Api.Models.Fine", b =>
                {
                    b.Property<int>("FineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Fine_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FineId"));

                    b.Property<int>("BorrowId")
                        .HasColumnType("int")
                        .HasColumnName("Borrow_Id");

                    b.Property<string>("FineAmount")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Fine_Amount");

                    b.Property<DateTime?>("FineDate")
                        .HasColumnType("date")
                        .HasColumnName("Fine_Date");

                    b.Property<int>("MemberId")
                        .HasColumnType("int")
                        .HasColumnName("Member_Id");

                    b.HasKey("FineId");

                    b.HasIndex("BorrowId");

                    b.HasIndex("MemberId");

                    b.ToTable("Fine", (string)null);
                });

            modelBuilder.Entity("VG_Library_Api.Models.Member", b =>
                {
                    b.Property<int>("MemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Member_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MemberId"));

                    b.Property<string>("MemberAddress")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Member_Address");

                    b.Property<string>("MemberBlock")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Member_Block");

                    b.Property<string>("MemberContactDetails")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Member_ContactDetails");

                    b.Property<DateTime?>("MemberDateCreate")
                        .HasColumnType("date")
                        .HasColumnName("Member_DateCreate");

                    b.Property<string>("MemberEmail")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Member_Email");

                    b.Property<string>("MemberName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("Member_Name");

                    b.Property<string>("MemberPassword")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Member_Password");

                    b.Property<string>("MemberStatus")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Member_Status");

                    b.Property<string>("MemberSurname")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Member_Surname");

                    b.HasKey("MemberId");

                    b.ToTable("Member", (string)null);
                });

            modelBuilder.Entity("VG_Library_Api.Models.Notification", b =>
                {
                    b.Property<int>("NotificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Notification_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NotificationId"));

                    b.Property<int>("MemberId")
                        .HasColumnType("int")
                        .HasColumnName("Member_Id");

                    b.Property<DateTime?>("NotificationDate")
                        .HasColumnType("date")
                        .HasColumnName("Notification_Date");

                    b.Property<string>("NotificationDetails")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Notification_Details");

                    b.Property<string>("NotificationStatus")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Notification_Status");

                    b.Property<string>("NotificationType")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Notification_Type");

                    b.HasKey("NotificationId");

                    b.HasIndex("MemberId");

                    b.ToTable("Notification", (string)null);
                });

            modelBuilder.Entity("VG_Library_Api.Models.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Room_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomId"));

                    b.Property<int>("MemberId")
                        .HasColumnType("int")
                        .HasColumnName("Member_Id");

                    b.Property<string>("RoomAvailability")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Room_Availability");

                    b.Property<DateTime?>("RoomDate")
                        .HasColumnType("date")
                        .HasColumnName("Room_Date");

                    b.Property<string>("RoomName")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Room_Name");

                    b.Property<string>("RoomStatus")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Room_Status");

                    b.Property<string>("RoomType")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Room_Type");

                    b.Property<string>("RoomUrl")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Room_URL");

                    b.HasKey("RoomId");

                    b.HasIndex("MemberId");

                    b.ToTable("Room", (string)null);
                });

            modelBuilder.Entity("VG_Library_Api.Models.Transcaction", b =>
                {
                    b.Property<int>("TranscId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Transc_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TranscId"));

                    b.Property<int>("FineId")
                        .HasColumnType("int")
                        .HasColumnName("Fine_Id");

                    b.Property<int>("MemberId")
                        .HasColumnType("int")
                        .HasColumnName("Member_Id");

                    b.Property<DateTime?>("TranscDate")
                        .HasColumnType("date")
                        .HasColumnName("Transc_Date");

                    b.Property<string>("TranscPayment")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Transc_Payment");

                    b.Property<string>("TranscStatus")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Transc_Status");

                    b.HasKey("TranscId");

                    b.HasIndex("FineId");

                    b.HasIndex("MemberId");

                    b.ToTable("Transcaction", (string)null);
                });

            modelBuilder.Entity("VG_Library_Api.Models.Book", b =>
                {
                    b.HasOne("VG_Library_Api.Models.BookCategory", "Bc")
                        .WithMany("Books")
                        .HasForeignKey("BcId")
                        .IsRequired()
                        .HasConstraintName("FK_Book_BookCategory");

                    b.Navigation("Bc");
                });

            modelBuilder.Entity("VG_Library_Api.Models.Borrow", b =>
                {
                    b.HasOne("VG_Library_Api.Models.Book", "Book")
                        .WithMany("Borrows")
                        .HasForeignKey("BookId")
                        .IsRequired()
                        .HasConstraintName("FK_Borrow_Book");

                    b.HasOne("VG_Library_Api.Models.Member", "Member")
                        .WithMany("Borrows")
                        .HasForeignKey("MemberId")
                        .IsRequired()
                        .HasConstraintName("FK_Borrow_Member");

                    b.Navigation("Book");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("VG_Library_Api.Models.Fine", b =>
                {
                    b.HasOne("VG_Library_Api.Models.Borrow", "Borrow")
                        .WithMany("Fines")
                        .HasForeignKey("BorrowId")
                        .IsRequired()
                        .HasConstraintName("FK_Fine_Borrow");

                    b.HasOne("VG_Library_Api.Models.Member", "Member")
                        .WithMany("Fines")
                        .HasForeignKey("MemberId")
                        .IsRequired()
                        .HasConstraintName("FK_Fine_Member");

                    b.Navigation("Borrow");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("VG_Library_Api.Models.Notification", b =>
                {
                    b.HasOne("VG_Library_Api.Models.Member", "Member")
                        .WithMany("Notifications")
                        .HasForeignKey("MemberId")
                        .IsRequired()
                        .HasConstraintName("FK_Notification_Member");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("VG_Library_Api.Models.Room", b =>
                {
                    b.HasOne("VG_Library_Api.Models.Member", "Member")
                        .WithMany("Rooms")
                        .HasForeignKey("MemberId")
                        .IsRequired()
                        .HasConstraintName("FK_Room_Member");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("VG_Library_Api.Models.Transcaction", b =>
                {
                    b.HasOne("VG_Library_Api.Models.Fine", "Fine")
                        .WithMany("Transcactions")
                        .HasForeignKey("FineId")
                        .IsRequired()
                        .HasConstraintName("FK_Transcaction_Fine");

                    b.HasOne("VG_Library_Api.Models.Member", "Member")
                        .WithMany("Transcactions")
                        .HasForeignKey("MemberId")
                        .IsRequired()
                        .HasConstraintName("FK_Transcaction_Member");

                    b.Navigation("Fine");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("VG_Library_Api.Models.Book", b =>
                {
                    b.Navigation("Borrows");
                });

            modelBuilder.Entity("VG_Library_Api.Models.BookCategory", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("VG_Library_Api.Models.Borrow", b =>
                {
                    b.Navigation("Fines");
                });

            modelBuilder.Entity("VG_Library_Api.Models.Fine", b =>
                {
                    b.Navigation("Transcactions");
                });

            modelBuilder.Entity("VG_Library_Api.Models.Member", b =>
                {
                    b.Navigation("Borrows");

                    b.Navigation("Fines");

                    b.Navigation("Notifications");

                    b.Navigation("Rooms");

                    b.Navigation("Transcactions");
                });
#pragma warning restore 612, 618
        }
    }
}
