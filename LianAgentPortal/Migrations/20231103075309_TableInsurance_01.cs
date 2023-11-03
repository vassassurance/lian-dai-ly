using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LianAgentPortal.Migrations
{
    /// <inheritdoc />
    public partial class TableInsurance_01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastDateUpdate",
                table: "InsuranceMasters",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3F41798D-C760-4DBB-9F5E-13F78138D565",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5ccd9e25-c8fb-4b49-8845-69f2f8672bc7", "AQAAAAIAAYagAAAAEGhBhX8E3V63tngy5YXHbNaUubuIKNf6T7huJlOUu89Gp4QQlfgefA3stXxyW3ic6A==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastDateUpdate",
                table: "InsuranceMasters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3F41798D-C760-4DBB-9F5E-13F78138D565",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8fd936d2-5745-4ba3-907b-b7011da148a1", "AQAAAAIAAYagAAAAEK0LDX+xaCeZKzJFh36oYYire40kg3l4eYLVvl4fRxH1oLM/h7LtfYVHZvdeprKmlQ==" });
        }
    }
}
