using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IoTWebAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    u_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fullname = table.Column<string>(maxLength: 50, nullable: false),
                    email = table.Column<string>(nullable: true),
                    password = table.Column<string>(unicode: false, nullable: false),
                    is_active = table.Column<bool>(nullable: false, defaultValue: true),
                    is_admin = table.Column<bool>(nullable: false, defaultValue: false),
                    create_date = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2022, 2, 21, 0, 0, 0, 0, DateTimeKind.Local))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.u_id);
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    d_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    u_id = table.Column<int>(nullable: false),
                    device_name = table.Column<string>(maxLength: 100, nullable: false),
                    device_description = table.Column<string>(maxLength: 350, nullable: true),
                    img_url = table.Column<string>(unicode: false, nullable: true),
                    is_active = table.Column<bool>(nullable: false, defaultValue: true),
                    create_date = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2022, 2, 21, 0, 0, 0, 0, DateTimeKind.Local))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.d_id);
                    table.ForeignKey(
                        name: "FK_Devices_User_u_id",
                        column: x => x.u_id,
                        principalTable: "User",
                        principalColumn: "u_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attributes",
                columns: table => new
                {
                    a_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    d_id = table.Column<int>(nullable: false),
                    a_name = table.Column<int>(nullable: false),
                    a_description = table.Column<string>(maxLength: 255, nullable: true),
                    is_active = table.Column<bool>(nullable: false, defaultValue: false),
                    active_date = table.Column<DateTime>(nullable: true),
                    last_update = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attributes", x => x.a_id);
                    table.ForeignKey(
                        name: "FK_Attributes_Devices_d_id",
                        column: x => x.d_id,
                        principalTable: "Devices",
                        principalColumn: "d_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Datas",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    a_id = table.Column<int>(nullable: false),
                    value = table.Column<float>(nullable: false),
                    update_time = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2022, 2, 21, 17, 53, 22, 385, DateTimeKind.Local).AddTicks(7680))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Datas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Datas_Attributes_a_id",
                        column: x => x.a_id,
                        principalTable: "Attributes",
                        principalColumn: "a_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attributes_d_id",
                table: "Attributes",
                column: "d_id");

            migrationBuilder.CreateIndex(
                name: "IX_Datas_a_id",
                table: "Datas",
                column: "a_id");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_u_id",
                table: "Devices",
                column: "u_id");

            migrationBuilder.CreateIndex(
                name: "IX_User_email",
                table: "User",
                column: "email",
                unique: true,
                filter: "[email] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Datas");

            migrationBuilder.DropTable(
                name: "Attributes");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
