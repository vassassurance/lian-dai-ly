using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LianAgentPortal.Migrations
{
    /// <inheritdoc />
    public partial class TableLianAgent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "LianAgentId",
                table: "AspNetUsers",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LianAgents",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecretKey = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LianAgents", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3F41798D-C760-4DBB-9F5E-13F78138D565",
                columns: new[] { "ConcurrencyStamp", "LianAgentId", "PasswordHash" },
                values: new object[] { "00dcfd15-7443-4cb6-8bfb-a87beab57349", null, "AQAAAAIAAYagAAAAEJLoWE3XlDo9FEwXiJx8WzDbILVMObFSZ5+YkKvodgqEggXnqBZg1umZIOrwLQRcrQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_LianAgentId",
                table: "AspNetUsers",
                column: "LianAgentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_LianAgents_LianAgentId",
                table: "AspNetUsers",
                column: "LianAgentId",
                principalTable: "LianAgents",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_LianAgents_LianAgentId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "LianAgents");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_LianAgentId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LianAgentId",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3F41798D-C760-4DBB-9F5E-13F78138D565",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a7a6e040-f860-4f1f-a859-e6a235aad0a4", "AQAAAAIAAYagAAAAEKb1F9pof+zSgE40J/w//ovNhFUMyRzuD2hzr9mhkiVGYOfHaFlDi5MHWICe9xmUfg==" });
        }
    }
}
