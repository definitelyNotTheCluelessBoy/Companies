using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Companies.Migrations
{
    /// <inheritdoc />
    public partial class dataseeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "employees",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Phone", "Title" },
                values: new object[,]
                {
                    { 1, "janonovak@email.com", "Jano", "Novák", "+421999888777", null },
                    { 2, "petermali@email.com", "Peter", "Malí", "+421999888666", "Mgr." },
                    { 3, "frantisekstromkoc@email.com", "František", "Stromokocur", "+421999888555", "Ing." },
                    { 4, "jaropecka@email.com", "Jaroslav", "Pecka", "+421999222777", null },
                    { 5, "ivkafialka@email.com", "Iveta", "Fialova", "+421888888777", "Doc." },
                    { 6, "hrasko.janko@email.com", "Janko", "Hrasko", "+421999888677", null },
                    { 7, "topsecret@misix.com", "James", "Bond", "+421000000007", null },
                    { 8, "unknown@mistery.com", "Jhon", "Doe", "+421000000000", "Magician" }
                });

            migrationBuilder.InsertData(
                table: "companies",
                columns: new[] { "IdCode", "DirectorOfNodeId", "Name" },
                values: new object[,]
                {
                    { "001", 1, "First Company" },
                    { "002", 2, "First Company" }
                });

            migrationBuilder.InsertData(
                table: "divisions",
                columns: new[] { "IdCode", "DirectorOfNodeId", "MotherCompanyId", "Name" },
                values: new object[,]
                {
                    { "001", 3, "001", "First division" },
                    { "002", 4, "002", "Second division" }
                });

            migrationBuilder.InsertData(
                table: "projects",
                columns: new[] { "IdCode", "DirectorOfNodeId", "MotherDivisionId", "Name" },
                values: new object[,]
                {
                    { "001", 5, "001", "First project" },
                    { "002", 6, "002", "Second project" }
                });

            migrationBuilder.InsertData(
                table: "departments",
                columns: new[] { "IdCode", "DirectorOfNodeId", "MotherProjectId", "Name" },
                values: new object[,]
                {
                    { "001", 7, "001", "First Department" },
                    { "002", 8, "002", "Second Department" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "departments",
                keyColumn: "IdCode",
                keyValue: "001");

            migrationBuilder.DeleteData(
                table: "departments",
                keyColumn: "IdCode",
                keyValue: "002");

            migrationBuilder.DeleteData(
                table: "employees",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "employees",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "projects",
                keyColumn: "IdCode",
                keyValue: "001");

            migrationBuilder.DeleteData(
                table: "projects",
                keyColumn: "IdCode",
                keyValue: "002");

            migrationBuilder.DeleteData(
                table: "divisions",
                keyColumn: "IdCode",
                keyValue: "001");

            migrationBuilder.DeleteData(
                table: "divisions",
                keyColumn: "IdCode",
                keyValue: "002");

            migrationBuilder.DeleteData(
                table: "employees",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "employees",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "companies",
                keyColumn: "IdCode",
                keyValue: "001");

            migrationBuilder.DeleteData(
                table: "companies",
                keyColumn: "IdCode",
                keyValue: "002");

            migrationBuilder.DeleteData(
                table: "employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "employees",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "employees",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
