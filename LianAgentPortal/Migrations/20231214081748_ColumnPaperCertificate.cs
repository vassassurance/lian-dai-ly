using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LianAgentPortal.Migrations
{
    /// <inheritdoc />
    public partial class ColumnPaperCertificate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PaperCertificateNo",
                table: "InsuranceMotorDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaperCertificatePath",
                table: "InsuranceMotorDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaperCertificateNo",
                table: "InsuranceAutomobileDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaperCertificatePath",
                table: "InsuranceAutomobileDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3fbca1da-a4ea-449d-ae8c-67445e6da324", "AQAAAAIAAYagAAAAEGGQgIlWSMZwzd7k7N7jRxA3eFu4d/OjCH59ZYeuzH9eBmiuHHYBIk+FW8vP4O7CdQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaperCertificateNo",
                table: "InsuranceMotorDetails");

            migrationBuilder.DropColumn(
                name: "PaperCertificatePath",
                table: "InsuranceMotorDetails");

            migrationBuilder.DropColumn(
                name: "PaperCertificateNo",
                table: "InsuranceAutomobileDetails");

            migrationBuilder.DropColumn(
                name: "PaperCertificatePath",
                table: "InsuranceAutomobileDetails");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3cef7f6b-cc64-49ab-811f-847ddec9e24c", "AQAAAAIAAYagAAAAEEHM+pE2lSP7AbyE+0detxv9dc2Vg7FSvdFI+hgD/PZBWoU4t0iJ6De70XJH2mDgoQ==" });
        }
    }
}
