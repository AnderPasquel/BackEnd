using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AxsisBackend.Persistence.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "varchar(250)", nullable: false),
                    UserName = table.Column<string>(type: "varchar(250)", nullable: false),
                    Password = table.Column<string>(type: "varchar(250)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Sex = table.Column<bool>(type: "bit", nullable: false),
                    Creation = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
