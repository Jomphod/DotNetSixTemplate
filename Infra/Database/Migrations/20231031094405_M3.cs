using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Database.Migrations
{
    /// <inheritdoc />
    public partial class M3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SystemQuery",
                table: "SystemQuery");

            migrationBuilder.DropColumn(
                name: "QueryName",
                table: "SystemQuery");

            migrationBuilder.RenameColumn(
                name: "QueryValue",
                table: "SystemQuery",
                newName: "query_value");

            migrationBuilder.AddColumn<string>(
                name: "query_name",
                table: "SystemQuery",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "query_name",
                table: "SystemQuery");

            migrationBuilder.RenameColumn(
                name: "query_value",
                table: "SystemQuery",
                newName: "QueryValue");

            migrationBuilder.AddColumn<string>(
                name: "QueryName",
                table: "SystemQuery",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SystemQuery",
                table: "SystemQuery",
                column: "QueryName");
        }
    }
}
