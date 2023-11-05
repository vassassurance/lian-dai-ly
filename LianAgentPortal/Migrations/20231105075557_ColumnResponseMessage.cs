using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LianAgentPortal.Migrations
{
    /// <inheritdoc />
    public partial class ColumnResponseMessage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StatusMessage",
                table: "InsurancePersonalAccidentDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StatusMessage",
                table: "InsuranceMotorDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StatusMessage",
                table: "InsuranceFamilyBreadwinnerDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f293058d-3fe5-4715-8ec1-c8802f0277df", "AQAAAAIAAYagAAAAEKTOnyI7vWtTxoZB8cljzqlPAyk/2mWc96YuUxKERpxfNqq61a3hZRgiTqsxTkuHRg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusMessage",
                table: "InsurancePersonalAccidentDetails");

            migrationBuilder.DropColumn(
                name: "StatusMessage",
                table: "InsuranceMotorDetails");

            migrationBuilder.DropColumn(
                name: "StatusMessage",
                table: "InsuranceFamilyBreadwinnerDetails");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4cf84b04-0131-4bd8-9dd2-6ecb59b81d49", "AQAAAAIAAYagAAAAEKdp1jlfbEfZEiR0FO9x/dScyuXSS0RJ8+MOjBseuCO8O7jShmtxWL1zrZI88oiQBQ==" });
        }
    }
}
