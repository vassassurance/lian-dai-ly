using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LianAgentPortal.Migrations
{
    /// <inheritdoc />
    public partial class TableInsurance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InsuranceMasters",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserCreate = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUserUpdate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastDateUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalRows = table.Column<int>(type: "int", nullable: false),
                    TotalIssuedRows = table.Column<int>(type: "int", nullable: false),
                    TotalPremium = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalInsuranceAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceMasters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceFamilyBreadwinnerDetails",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    IdentityNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birhtday = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ranking = table.Column<int>(type: "int", nullable: false),
                    InsuranceMasterId = table.Column<long>(type: "bigint", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    AgentPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartnerTransaction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EffectiveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeCoverage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceFamilyBreadwinnerDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InsuranceFamilyBreadwinnerDetails_InsuranceMasters_InsuranceMasterId",
                        column: x => x.InsuranceMasterId,
                        principalTable: "InsuranceMasters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InsuranceMotorDetails",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicensePlates = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotorType = table.Column<int>(type: "int", nullable: false),
                    ChassisNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MachineNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentityNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassengerInsurance = table.Column<bool>(type: "bit", nullable: false),
                    Birhtday = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsuranceMasterId = table.Column<long>(type: "bigint", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    AgentPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartnerTransaction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EffectiveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeCoverage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceMotorDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InsuranceMotorDetails_InsuranceMasters_InsuranceMasterId",
                        column: x => x.InsuranceMasterId,
                        principalTable: "InsuranceMasters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InsurancePersonalAccidentDetails",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentityNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birhtday = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ranking = table.Column<int>(type: "int", nullable: false),
                    InsuranceMasterId = table.Column<long>(type: "bigint", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    AgentPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartnerTransaction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EffectiveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeCoverage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsurancePersonalAccidentDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InsurancePersonalAccidentDetails_InsuranceMasters_InsuranceMasterId",
                        column: x => x.InsuranceMasterId,
                        principalTable: "InsuranceMasters",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3F41798D-C760-4DBB-9F5E-13F78138D565",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8fd936d2-5745-4ba3-907b-b7011da148a1", "AQAAAAIAAYagAAAAEK0LDX+xaCeZKzJFh36oYYire40kg3l4eYLVvl4fRxH1oLM/h7LtfYVHZvdeprKmlQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceFamilyBreadwinnerDetails_InsuranceMasterId",
                table: "InsuranceFamilyBreadwinnerDetails",
                column: "InsuranceMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceFamilyBreadwinnerDetails_Status",
                table: "InsuranceFamilyBreadwinnerDetails",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceFamilyBreadwinnerDetails_Type",
                table: "InsuranceFamilyBreadwinnerDetails",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceMasters_DateCreate",
                table: "InsuranceMasters",
                column: "DateCreate");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceMasters_Type",
                table: "InsuranceMasters",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceMasters_UserCreate",
                table: "InsuranceMasters",
                column: "UserCreate");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceMotorDetails_InsuranceMasterId",
                table: "InsuranceMotorDetails",
                column: "InsuranceMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceMotorDetails_Status",
                table: "InsuranceMotorDetails",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceMotorDetails_Type",
                table: "InsuranceMotorDetails",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_InsurancePersonalAccidentDetails_InsuranceMasterId",
                table: "InsurancePersonalAccidentDetails",
                column: "InsuranceMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_InsurancePersonalAccidentDetails_Status",
                table: "InsurancePersonalAccidentDetails",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_InsurancePersonalAccidentDetails_Type",
                table: "InsurancePersonalAccidentDetails",
                column: "Type");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InsuranceFamilyBreadwinnerDetails");

            migrationBuilder.DropTable(
                name: "InsuranceMotorDetails");

            migrationBuilder.DropTable(
                name: "InsurancePersonalAccidentDetails");

            migrationBuilder.DropTable(
                name: "InsuranceMasters");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3F41798D-C760-4DBB-9F5E-13F78138D565",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "00dcfd15-7443-4cb6-8bfb-a87beab57349", "AQAAAAIAAYagAAAAEJLoWE3XlDo9FEwXiJx8WzDbILVMObFSZ5+YkKvodgqEggXnqBZg1umZIOrwLQRcrQ==" });
        }
    }
}
