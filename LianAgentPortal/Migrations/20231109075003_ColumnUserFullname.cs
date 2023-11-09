using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LianAgentPortal.Migrations
{
    /// <inheritdoc />
    public partial class ColumnUserFullname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fullname",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                columns: new[] { "ConcurrencyStamp", "Description", "Fullname", "PasswordHash" },
                values: new object[] { "a53cae17-303c-4b99-bdbc-78b4cc3ad6a6", null, null, "AQAAAAIAAYagAAAAEAKYBjF5+eBTEL9KUg+NrmMhwjP0QMWpD01RJcfA4+svguELmuRHS6IuHSDYHc9PrQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Fullname",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e3f4073e-32fe-4114-a35f-3c006bd1be11", "AQAAAAIAAYagAAAAEDFipV5tc8aoO5e+HBUe73+LurpMM1QIEZxLkE38b6JPyaohZh7wYDRo4Gv8rV3xAw==" });
        }
    }
}
