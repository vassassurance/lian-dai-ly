using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LianAgentPortal.Migrations
{
    /// <inheritdoc />
    public partial class ColumnRegistedPhone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RegistedPhone",
                table: "LianAgents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3F41798D-C760-4DBB-9F5E-13F78138D565",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2e5db6a7-15ab-49fe-9a30-d0b12af7e80f", "AQAAAAIAAYagAAAAED40O0mBGw1lXL1tGz+mBaYFce2K1L5ybQfqRThpmOden3Mjzm5MK5PUDsDKkhvl3Q==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegistedPhone",
                table: "LianAgents");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3F41798D-C760-4DBB-9F5E-13F78138D565",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5ccd9e25-c8fb-4b49-8845-69f2f8672bc7", "AQAAAAIAAYagAAAAEGhBhX8E3V63tngy5YXHbNaUubuIKNf6T7huJlOUu89Gp4QQlfgefA3stXxyW3ic6A==" });
        }
    }
}
