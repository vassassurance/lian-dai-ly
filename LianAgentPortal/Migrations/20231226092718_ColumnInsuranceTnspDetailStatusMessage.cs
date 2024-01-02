using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LianAgentPortal.Migrations
{
    /// <inheritdoc />
    public partial class ColumnInsuranceTnspDetailStatusMessage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StatusMessage",
                table: "InsuranceTnspDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1ff15a05-0444-43ab-9c8f-c384ef904f86", "AQAAAAIAAYagAAAAEOaZzAmHC4RCD8SVWo3+QJ/pYzHwi4bDdUKRIBoKShGeF2XE5nfNqFqq+DIPQdbzpA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusMessage",
                table: "InsuranceTnspDetails");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "11626a68-2d41-4b61-b011-23032b8835bc", "AQAAAAIAAYagAAAAEMDQUCxQTlDzJWIt5ldud7alC1cKAsrfpDERVCYsP4LDkpfD97yIbZGFEj723Xp+kA==" });
        }
    }
}
