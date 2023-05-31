using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VG_Library_Api.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookCategory",
                columns: table => new
                {
                    BC_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BC_Category = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    BC_SubCategory = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCategory", x => x.BC_Id);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    Member_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Member_Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Member_Surname = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Member_Email = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Member_Password = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Member_Address = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Member_ContactDetails = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Member_Status = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Member_Block = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Member_DateCreate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.Member_Id);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Book_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Book_Title = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Book_Author = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Book_Status = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Book_Fine = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Book_Ordered = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Book_Quantity = table.Column<int>(type: "int", nullable: true),
                    BC_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Book_Id);
                    table.ForeignKey(
                        name: "FK_Book_BookCategory",
                        column: x => x.BC_Id,
                        principalTable: "BookCategory",
                        principalColumn: "BC_Id");
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Notification_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Notification_Type = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Notification_Details = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Notification_Status = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Member_Id = table.Column<int>(type: "int", nullable: false),
                    Notification_Date = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Notification_Id);
                    table.ForeignKey(
                        name: "FK_Notification_Member",
                        column: x => x.Member_Id,
                        principalTable: "Member",
                        principalColumn: "Member_Id");
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Room_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Room_Name = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Room_Type = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Room_Status = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Room_URL = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Member_Id = table.Column<int>(type: "int", nullable: false),
                    Room_Date = table.Column<DateTime>(type: "date", nullable: true),
                    Room_Availability = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Room_ID);
                    table.ForeignKey(
                        name: "FK_Room_Member",
                        column: x => x.Member_Id,
                        principalTable: "Member",
                        principalColumn: "Member_Id");
                });

            migrationBuilder.CreateTable(
                name: "Borrow",
                columns: table => new
                {
                    Borrow_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Borrow_Date = table.Column<DateTime>(type: "date", nullable: true),
                    Borrow_ReturnDate = table.Column<DateTime>(type: "date", nullable: true),
                    Borrow_URL = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Borrow_URLScanner = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Borrow_Status = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Book_Id = table.Column<int>(type: "int", nullable: false),
                    Member_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Borrow", x => x.Borrow_Id);
                    table.ForeignKey(
                        name: "FK_Borrow_Book",
                        column: x => x.Book_Id,
                        principalTable: "Book",
                        principalColumn: "Book_Id");
                    table.ForeignKey(
                        name: "FK_Borrow_Member",
                        column: x => x.Member_Id,
                        principalTable: "Member",
                        principalColumn: "Member_Id");
                });

            migrationBuilder.CreateTable(
                name: "Fine",
                columns: table => new
                {
                    Fine_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fine_Amount = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Fine_Date = table.Column<DateTime>(type: "date", nullable: true),
                    Borrow_Id = table.Column<int>(type: "int", nullable: false),
                    Member_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fine", x => x.Fine_Id);
                    table.ForeignKey(
                        name: "FK_Fine_Borrow",
                        column: x => x.Borrow_Id,
                        principalTable: "Borrow",
                        principalColumn: "Borrow_Id");
                    table.ForeignKey(
                        name: "FK_Fine_Member",
                        column: x => x.Member_Id,
                        principalTable: "Member",
                        principalColumn: "Member_Id");
                });

            migrationBuilder.CreateTable(
                name: "Transcaction",
                columns: table => new
                {
                    Transc_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Transc_Date = table.Column<DateTime>(type: "date", nullable: true),
                    Transc_Payment = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Transc_Status = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Member_Id = table.Column<int>(type: "int", nullable: false),
                    Fine_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transcaction", x => x.Transc_Id);
                    table.ForeignKey(
                        name: "FK_Transcaction_Fine",
                        column: x => x.Fine_Id,
                        principalTable: "Fine",
                        principalColumn: "Fine_Id");
                    table.ForeignKey(
                        name: "FK_Transcaction_Member",
                        column: x => x.Member_Id,
                        principalTable: "Member",
                        principalColumn: "Member_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_BC_Id",
                table: "Book",
                column: "BC_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Borrow_Book_Id",
                table: "Borrow",
                column: "Book_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Borrow_Member_Id",
                table: "Borrow",
                column: "Member_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Fine_Borrow_Id",
                table: "Fine",
                column: "Borrow_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Fine_Member_Id",
                table: "Fine",
                column: "Member_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_Member_Id",
                table: "Notification",
                column: "Member_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Room_Member_Id",
                table: "Room",
                column: "Member_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Transcaction_Fine_Id",
                table: "Transcaction",
                column: "Fine_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Transcaction_Member_Id",
                table: "Transcaction",
                column: "Member_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Transcaction");

            migrationBuilder.DropTable(
                name: "Fine");

            migrationBuilder.DropTable(
                name: "Borrow");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "BookCategory");
        }
    }
}
