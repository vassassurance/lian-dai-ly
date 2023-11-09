using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LianAgentPortal.Migrations
{
    /// <inheritdoc />
    public partial class FeatureDeleteInsuranceMaster : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Transaction",
                table: "InsurancePersonalAccidentDetails",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Transaction",
                table: "InsuranceMotorDetails",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "InsuranceMasters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Transaction",
                table: "InsuranceFamilyBreadwinnerDetails",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Transaction",
                table: "InsuranceAutomobileDetails",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bc8f8f1b-9eaf-40a2-8e8d-3f84237b9bb9", "AQAAAAIAAYagAAAAEPN4oApYj/S5pnvJPK/qOcLPn4rZqqy/zWn2pPa9OvRpYmQOJodzZ7qVyaGsSi8yeA==" });

            migrationBuilder.CreateIndex(
                name: "IX_InsurancePersonalAccidentDetails_Transaction",
                table: "InsurancePersonalAccidentDetails",
                column: "Transaction");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceMotorDetails_Transaction",
                table: "InsuranceMotorDetails",
                column: "Transaction");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceMasters_IsDeleted",
                table: "InsuranceMasters",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceFamilyBreadwinnerDetails_Transaction",
                table: "InsuranceFamilyBreadwinnerDetails",
                column: "Transaction");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceAutomobileDetails_Transaction",
                table: "InsuranceAutomobileDetails",
                column: "Transaction");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_InsurancePersonalAccidentDetails_Transaction",
                table: "InsurancePersonalAccidentDetails");

            migrationBuilder.DropIndex(
                name: "IX_InsuranceMotorDetails_Transaction",
                table: "InsuranceMotorDetails");

            migrationBuilder.DropIndex(
                name: "IX_InsuranceMasters_IsDeleted",
                table: "InsuranceMasters");

            migrationBuilder.DropIndex(
                name: "IX_InsuranceFamilyBreadwinnerDetails_Transaction",
                table: "InsuranceFamilyBreadwinnerDetails");

            migrationBuilder.DropIndex(
                name: "IX_InsuranceAutomobileDetails_Transaction",
                table: "InsuranceAutomobileDetails");

            migrationBuilder.DropColumn(
                name: "Transaction",
                table: "InsurancePersonalAccidentDetails");

            migrationBuilder.DropColumn(
                name: "Transaction",
                table: "InsuranceMotorDetails");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "InsuranceMasters");

            migrationBuilder.DropColumn(
                name: "Transaction",
                table: "InsuranceFamilyBreadwinnerDetails");

            migrationBuilder.DropColumn(
                name: "Transaction",
                table: "InsuranceAutomobileDetails");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a53cae17-303c-4b99-bdbc-78b4cc3ad6a6", "AQAAAAIAAYagAAAAEAKYBjF5+eBTEL9KUg+NrmMhwjP0QMWpD01RJcfA4+svguELmuRHS6IuHSDYHc9PrQ==" });
        }
    }
}
