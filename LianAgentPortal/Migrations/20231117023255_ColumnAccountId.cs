using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LianAgentPortal.Migrations
{
    /// <inheritdoc />
    public partial class ColumnAccountId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccountId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                columns: new[] { "AccountId", "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { null, "3cef7f6b-cc64-49ab-811f-847ddec9e24c", "AQAAAAIAAYagAAAAEEHM+pE2lSP7AbyE+0detxv9dc2Vg7FSvdFI+hgD/PZBWoU4t0iJ6De70XJH2mDgoQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c4b02587-fc9f-46ca-ad03-9771df012ff9", "AQAAAAIAAYagAAAAEBos/oI4oChprgNDkabdG3QL+4Imu0hnVc8SzQIOtp4UNe18JNZPUwIpo+pN2CruCA==" });
        }
    }
}
