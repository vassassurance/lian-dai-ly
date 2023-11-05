using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LianAgentPortal.Migrations
{
    /// <inheritdoc />
    public partial class ColumnCertificateDigitalLink : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CertificateDigitalLink",
                table: "InsurancePersonalAccidentDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CertificateDigitalLink",
                table: "InsuranceMotorDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CertificateDigitalLink",
                table: "InsuranceFamilyBreadwinnerDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "52492879-ae22-4559-ad71-649c4856a833", "AQAAAAIAAYagAAAAEJqxDyQNnA1AKO0BVVJm/EYP90qCDSGCskUvYPIKqpoF8Gpo0RVa8ngi7E9LolhO/A==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CertificateDigitalLink",
                table: "InsurancePersonalAccidentDetails");

            migrationBuilder.DropColumn(
                name: "CertificateDigitalLink",
                table: "InsuranceMotorDetails");

            migrationBuilder.DropColumn(
                name: "CertificateDigitalLink",
                table: "InsuranceFamilyBreadwinnerDetails");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f293058d-3fe5-4715-8ec1-c8802f0277df", "AQAAAAIAAYagAAAAEKTOnyI7vWtTxoZB8cljzqlPAyk/2mWc96YuUxKERpxfNqq61a3hZRgiTqsxTkuHRg==" });
        }
    }
}
