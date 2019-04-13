using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PostOptimizer.Data.Migrations
{
    public partial class ImportOptimizationProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OptimizationRow",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Pass = table.Column<int>(nullable: false),
                    Profits = table.Column<double>(nullable: false),
                    Transations = table.Column<int>(nullable: false),
                    ProfitFactor = table.Column<double>(nullable: false),
                    ExpectedPayoff = table.Column<double>(nullable: false),
                    BalanceDrawDown = table.Column<double>(nullable: false),
                    RelativeDrawDown = table.Column<string>(nullable: true),
                    InputParameter1 = table.Column<string>(nullable: true),
                    InputParameter2 = table.Column<string>(nullable: true),
                    InputParameter3 = table.Column<string>(nullable: true),
                    InputParameter4 = table.Column<string>(nullable: true),
                    ProjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptimizationRow", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OriginalFileName = table.Column<string>(maxLength: 100, nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    FileSize = table.Column<long>(nullable: false),
                    UploadDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OptimizationRow");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
