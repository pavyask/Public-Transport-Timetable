using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinimalWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class PTTDBinit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransportStops",
                columns: table => new
                {
                    StopId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZoneName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportStops", x => x.StopId);
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
                name: "TransportStopUser",
                columns: table => new
                {
                    TransportStopsStopId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UsersLogin = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportStopUser", x => new { x.TransportStopsStopId, x.UsersLogin });
                    table.ForeignKey(
                        name: "FK_TransportStopUser_TransportStops_TransportStopsStopId",
                        column: x => x.TransportStopsStopId,
                        principalTable: "TransportStops",
                        principalColumn: "StopId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransportStopUser_Users_UsersLogin",
                        column: x => x.UsersLogin,
                        principalTable: "Users",
                        principalColumn: "Login",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransportStopUser_UsersLogin",
                table: "TransportStopUser",
                column: "UsersLogin");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransportStopUser");

            migrationBuilder.DropTable(
                name: "TransportStops");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
