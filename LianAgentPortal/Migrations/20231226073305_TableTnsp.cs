using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LianAgentPortal.Migrations
{
    /// <inheritdoc />
    public partial class TableTnsp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InsuranceTnspMasters",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserCreate = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalRows = table.Column<int>(type: "int", nullable: false),
                    TotalIssuedRows = table.Column<int>(type: "int", nullable: false),
                    TotalPremium = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalInsuranceAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceTnspMasters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceTnspDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CertificateDigitalLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsuranceTnspMasterId = table.Column<long>(type: "bigint", nullable: false),
                    OrderId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentityNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InsuranceNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Premium = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InsuranceAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceTnspDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InsuranceTnspDetails_InsuranceTnspMasters_InsuranceTnspMasterId",
                        column: x => x.InsuranceTnspMasterId,
                        principalTable: "InsuranceTnspMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b19941b8-f63c-4686-b602-60838c0fe127", "AQAAAAIAAYagAAAAEO1OHdiDkFmKrrdhYBCPSBY+2WuLkl9sRV1nUKNmhk5fZUxcGHCwemfd9cwQ0Ic+tQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceTnspDetails_InsuranceTnspMasterId",
                table: "InsuranceTnspDetails",
                column: "InsuranceTnspMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceTnspMasters_DateCreate",
                table: "InsuranceTnspMasters",
                column: "DateCreate");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceTnspMasters_IsDeleted",
                table: "InsuranceTnspMasters",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceTnspMasters_UserCreate",
                table: "InsuranceTnspMasters",
                column: "UserCreate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InsuranceTnspDetails");

            migrationBuilder.DropTable(
                name: "InsuranceTnspMasters");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b6d22123-222a-4399-8545-7d19bf7a7526", "AQAAAAIAAYagAAAAELKuQ1HXYwQXul+nxsw7j2LUsC3F+8Vnf0DIcxpeEYuZbSRZrF+iWHfBSx2sR9O7RQ==" });
        }
    }
}
