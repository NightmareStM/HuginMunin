using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorCrudDotNet7.Server.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tag = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    Update = table.Column<DateTime>(type: "datetime", nullable: false),
                    Create = table.Column<DateTime>(type:"datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "Description", "Tag", "Title", "Update", "Create" },
                values: new object[,]
                {
                    { 1, "Immos a las pipas", "pipette", "PorcaPipetta", new DateTime(7013, 07, 17, 18, 59, 34), new DateTime(7013, 07, 17, 18, 59, 34)},
                    { 2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "Lorem", "Lorem Ipsum", new DateTime(2023, 05, 16, 17, 04, 00), new DateTime(2023, 05, 16, 17, 04, 00)},
                    { 3, "boh", "boh", "boh", new DateTime(2023, 05, 17, 12, 30, 00), new DateTime(2023, 05, 17, 12, 30, 00)},
                    { 4, "boh1", "boh", "boh1", new DateTime(2023, 05, 17, 12, 31, 00), new DateTime(2023, 05, 17, 12, 31, 00)}
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes");
        }
    }
}
