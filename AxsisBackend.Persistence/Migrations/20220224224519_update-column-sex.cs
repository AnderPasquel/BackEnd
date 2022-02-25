using Microsoft.EntityFrameworkCore.Migrations;

namespace AxsisBackend.Persistence.Migrations
{
    public partial class updatecolumnsex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Sex",
                table: "User",
                type: "varchar(4)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Sex",
                table: "User",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(4)");
        }
    }
}
