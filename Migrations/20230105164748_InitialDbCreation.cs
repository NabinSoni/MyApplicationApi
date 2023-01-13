using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyApplicationApi.Migrations
{
    public partial class InitialDbCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    DOB = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "DOB", "FirstName", "LastName" },
                values: new object[] { 1, new DateTime(1995, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sam", "Lary" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "DOB", "FirstName", "LastName" },
                values: new object[] { 2, new DateTime(1985, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Malcom", "D" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "AuthorId", "Price", "Title" },
                values: new object[,]
                {
                    { 1, 1, 800.0, "Sql Server 2019" },
                    { 3, 1, 750.0, "Java For Beginners" },
                    { 2, 2, 980.0, "Azure Fundamentals" },
                    { 4, 2, 510.0, "Python" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
