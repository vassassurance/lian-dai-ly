using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LianAgentPortal.Migrations
{
    /// <inheritdoc />
    public partial class AutomobilesAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "InsuranceAutomobileDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b6d22123-222a-4399-8545-7d19bf7a7526", "AQAAAAIAAYagAAAAELKuQ1HXYwQXul+nxsw7j2LUsC3F+8Vnf0DIcxpeEYuZbSRZrF+iWHfBSx2sR9O7RQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "InsuranceAutomobileDetails");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3fbca1da-a4ea-449d-ae8c-67445e6da324", "AQAAAAIAAYagAAAAEGGQgIlWSMZwzd7k7N7jRxA3eFu4d/OjCH59ZYeuzH9eBmiuHHYBIk+FW8vP4O7CdQ==" });
        }
    }
}
