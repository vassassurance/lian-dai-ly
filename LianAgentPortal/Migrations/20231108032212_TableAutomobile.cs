using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LianAgentPortal.Migrations
{
    /// <inheritdoc />
    public partial class TableAutomobile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InsuranceAutomobileDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicensePlates = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AutomobilesType = table.Column<int>(type: "int", nullable: false),
                    Attributes_Seat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Attributes_Category = table.Column<int>(type: "int", nullable: false),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChassisNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MachineNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassengerFee = table.Column<long>(type: "bigint", nullable: false),
                    PassengerCount = table.Column<long>(type: "bigint", nullable: false),
                    LiabilityInsuranceFee = table.Column<long>(type: "bigint", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CertificateDigitalLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsuranceMasterId = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    StatusMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgentPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartnerTransaction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EffectiveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeCoverage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceAutomobileDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InsuranceAutomobileDetails_InsuranceMasters_InsuranceMasterId",
                        column: x => x.InsuranceMasterId,
                        principalTable: "InsuranceMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e3f4073e-32fe-4114-a35f-3c006bd1be11", "AQAAAAIAAYagAAAAEDFipV5tc8aoO5e+HBUe73+LurpMM1QIEZxLkE38b6JPyaohZh7wYDRo4Gv8rV3xAw==" });

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceAutomobileDetails_InsuranceMasterId",
                table: "InsuranceAutomobileDetails",
                column: "InsuranceMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceAutomobileDetails_Status",
                table: "InsuranceAutomobileDetails",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceAutomobileDetails_Type",
                table: "InsuranceAutomobileDetails",
                column: "Type");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InsuranceAutomobileDetails");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "049b10bf-85db-4afd-bbec-6b60942a36ce", "AQAAAAIAAYagAAAAEGL9Hnw/u1T3AXAUMDenByUi9nTARBf4YEM9a8hqoUoIMYlbEUuV4TNqyl9Pp5z9Fw==" });
        }
    }
}
