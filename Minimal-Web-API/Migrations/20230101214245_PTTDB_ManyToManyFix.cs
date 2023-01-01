using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinimalWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class PTTDBManyToManyFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stops",
                columns: table => new
                {
                    StopId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZoneName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stops", x => x.StopId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Login = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Login);
                });

            migrationBuilder.CreateTable(
                name: "UserStops",
                columns: table => new
                {
                    UserLogin = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StopId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStops", x => new { x.UserLogin, x.StopId });
                    table.ForeignKey(
                        name: "FK_UserStops_Stops_StopId",
                        column: x => x.StopId,
                        principalTable: "Stops",
                        principalColumn: "StopId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserStops_Users_UserLogin",
                        column: x => x.UserLogin,
                        principalTable: "Users",
                        principalColumn: "Login",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserStops_StopId",
                table: "UserStops",
                column: "StopId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserStops");

            migrationBuilder.DropTable(
                name: "Stops");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
