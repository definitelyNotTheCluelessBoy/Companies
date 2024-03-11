using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Companies.Migrations
{
    /// <inheritdoc />
    public partial class CompanyTablesAddition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "companies",
                columns: table => new
                {
                    IdCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DirectorOfNodeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companies", x => x.IdCode);
                    table.ForeignKey(
                        name: "FK_companies_employees_DirectorOfNodeId",
                        column: x => x.DirectorOfNodeId,
                        principalTable: "employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "divisions",
                columns: table => new
                {
                    IdCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DirectorOfNodeId = table.Column<int>(type: "int", nullable: true),
                    MotherCompanyId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_divisions", x => x.IdCode);
                    table.ForeignKey(
                        name: "FK_divisions_companies_MotherCompanyId",
                        column: x => x.MotherCompanyId,
                        principalTable: "companies",
                        principalColumn: "IdCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_divisions_employees_DirectorOfNodeId",
                        column: x => x.DirectorOfNodeId,
                        principalTable: "employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "projects",
                columns: table => new
                {
                    IdCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DirectorOfNodeId = table.Column<int>(type: "int", nullable: true),
                    MotherDivisionId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projects", x => x.IdCode);
                    table.ForeignKey(
                        name: "FK_projects_divisions_MotherDivisionId",
                        column: x => x.MotherDivisionId,
                        principalTable: "divisions",
                        principalColumn: "IdCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_projects_employees_DirectorOfNodeId",
                        column: x => x.DirectorOfNodeId,
                        principalTable: "employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    IdCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DirectorOfNodeId = table.Column<int>(type: "int", nullable: true),
                    MotherProjectId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.IdCode);
                    table.ForeignKey(
                        name: "FK_departments_employees_DirectorOfNodeId",
                        column: x => x.DirectorOfNodeId,
                        principalTable: "employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_departments_projects_MotherProjectId",
                        column: x => x.MotherProjectId,
                        principalTable: "projects",
                        principalColumn: "IdCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_companies_DirectorOfNodeId",
                table: "companies",
                column: "DirectorOfNodeId");

            migrationBuilder.CreateIndex(
                name: "IX_departments_DirectorOfNodeId",
                table: "departments",
                column: "DirectorOfNodeId");

            migrationBuilder.CreateIndex(
                name: "IX_departments_MotherProjectId",
                table: "departments",
                column: "MotherProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_divisions_DirectorOfNodeId",
                table: "divisions",
                column: "DirectorOfNodeId");

            migrationBuilder.CreateIndex(
                name: "IX_divisions_MotherCompanyId",
                table: "divisions",
                column: "MotherCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_projects_DirectorOfNodeId",
                table: "projects",
                column: "DirectorOfNodeId");

            migrationBuilder.CreateIndex(
                name: "IX_projects_MotherDivisionId",
                table: "projects",
                column: "MotherDivisionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "departments");

            migrationBuilder.DropTable(
                name: "projects");

            migrationBuilder.DropTable(
                name: "divisions");

            migrationBuilder.DropTable(
                name: "companies");
        }
    }
}
