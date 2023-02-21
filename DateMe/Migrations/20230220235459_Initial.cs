using Microsoft.EntityFrameworkCore.Migrations;

namespace DateMe.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Majors",
                columns: table => new
                {
                    MajorId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MajorName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Majors", x => x.MajorId);
                });

            migrationBuilder.CreateTable(
                name: "responses",
                columns: table => new
                {
                    ApplicationID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: false),
                    Age = table.Column<byte>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    CreeperStalker = table.Column<bool>(nullable: false),
                    MajorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_responses", x => x.ApplicationID);
                    table.ForeignKey(
                        name: "FK_responses_Majors_MajorId",
                        column: x => x.MajorId,
                        principalTable: "Majors",
                        principalColumn: "MajorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Majors",
                columns: new[] { "MajorId", "MajorName" },
                values: new object[] { 1, "Information Systems" });

            migrationBuilder.InsertData(
                table: "Majors",
                columns: new[] { "MajorId", "MajorName" },
                values: new object[] { 2, "Accounting" });

            migrationBuilder.InsertData(
                table: "Majors",
                columns: new[] { "MajorId", "MajorName" },
                values: new object[] { 3, "Neuroscience" });

            migrationBuilder.InsertData(
                table: "Majors",
                columns: new[] { "MajorId", "MajorName" },
                values: new object[] { 4, "Actuarial Science" });

            migrationBuilder.InsertData(
                table: "Majors",
                columns: new[] { "MajorId", "MajorName" },
                values: new object[] { 5, "Psychology" });

            migrationBuilder.InsertData(
                table: "Majors",
                columns: new[] { "MajorId", "MajorName" },
                values: new object[] { 6, "Undeclared" });

            migrationBuilder.InsertData(
                table: "responses",
                columns: new[] { "ApplicationID", "Age", "CreeperStalker", "FirstName", "LastName", "MajorId", "Phone" },
                values: new object[] { 1, (byte)45, false, "Michael", "Scott", 4, "555-123-2356" });

            migrationBuilder.InsertData(
                table: "responses",
                columns: new[] { "ApplicationID", "Age", "CreeperStalker", "FirstName", "LastName", "MajorId", "Phone" },
                values: new object[] { 2, (byte)60, true, "Creed", "Bratton", 6, "555-234-5646" });

            migrationBuilder.CreateIndex(
                name: "IX_responses_MajorId",
                table: "responses",
                column: "MajorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "responses");

            migrationBuilder.DropTable(
                name: "Majors");
        }
    }
}
