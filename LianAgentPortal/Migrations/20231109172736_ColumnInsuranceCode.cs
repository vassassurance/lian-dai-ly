using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LianAgentPortal.Migrations
{
    /// <inheritdoc />
    public partial class ColumnInsuranceCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InsuranceCode",
                table: "InsurancePersonalAccidentDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsuranceCode",
                table: "InsuranceMotorDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsuranceCode",
                table: "InsuranceFamilyBreadwinnerDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsuranceCode",
                table: "InsuranceAutomobileDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c4b02587-fc9f-46ca-ad03-9771df012ff9", "AQAAAAIAAYagAAAAEBos/oI4oChprgNDkabdG3QL+4Imu0hnVc8SzQIOtp4UNe18JNZPUwIpo+pN2CruCA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InsuranceCode",
                table: "InsurancePersonalAccidentDetails");

            migrationBuilder.DropColumn(
                name: "InsuranceCode",
                table: "InsuranceMotorDetails");

            migrationBuilder.DropColumn(
                name: "InsuranceCode",
                table: "InsuranceFamilyBreadwinnerDetails");

            migrationBuilder.DropColumn(
                name: "InsuranceCode",
                table: "InsuranceAutomobileDetails");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bc8f8f1b-9eaf-40a2-8e8d-3f84237b9bb9", "AQAAAAIAAYagAAAAEPN4oApYj/S5pnvJPK/qOcLPn4rZqqy/zWn2pPa9OvRpYmQOJodzZ7qVyaGsSi8yeA==" });
        }
    }
}
