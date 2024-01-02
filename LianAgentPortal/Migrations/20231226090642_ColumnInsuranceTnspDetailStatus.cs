using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LianAgentPortal.Migrations
{
    /// <inheritdoc />
    public partial class ColumnInsuranceTnspDetailStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "InsuranceTnspDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "11626a68-2d41-4b61-b011-23032b8835bc", "AQAAAAIAAYagAAAAEMDQUCxQTlDzJWIt5ldud7alC1cKAsrfpDERVCYsP4LDkpfD97yIbZGFEj723Xp+kA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "InsuranceTnspDetails");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b19941b8-f63c-4686-b602-60838c0fe127", "AQAAAAIAAYagAAAAEO1OHdiDkFmKrrdhYBCPSBY+2WuLkl9sRV1nUKNmhk5fZUxcGHCwemfd9cwQ0Ic+tQ==" });
        }
    }
}
