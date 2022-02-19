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
                    u_id = table.Column<string>(nullable: false),
                    fullname = table.Column<string>(maxLength: 60, nullable: false),
                    email = table.Column<string>(nullable: true),
                    password = table.Column<string>(unicode: false, nullable: false),
                    is_active = table.Column<bool>(nullable: false, defaultValue: true),
                    create_time = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2022, 2, 19, 22, 55, 46, 898, DateTimeKind.Local).AddTicks(5834))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.u_id);
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    d_id = table.Column<string>(nullable: false),
                    u_id = table.Column<string>(nullable: true),
                    device_name = table.Column<string>(maxLength: 100, nullable: false),
                    device_description = table.Column<string>(maxLength: 300, nullable: true),
                    img_url = table.Column<string>(unicode: false, nullable: true),
                    is_active = table.Column<bool>(nullable: false, defaultValue: true),
                    create_time = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2022, 2, 19, 22, 55, 46, 902, DateTimeKind.Local).AddTicks(239))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.d_id);
                    table.ForeignKey(
                        name: "FK_Devices_User_u_id",
                        column: x => x.u_id,
                        principalTable: "User",
                        principalColumn: "u_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Attributes",
                columns: table => new
                {
                    a_id = table.Column<string>(nullable: false),
                    d_id = table.Column<string>(nullable: true),
                    a_name = table.Column<int>(nullable: false),
                    a_description = table.Column<string>(maxLength: 300, nullable: true),
                    is_active = table.Column<bool>(nullable: false, defaultValue: false),
                    create_time = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2022, 2, 19, 22, 55, 46, 911, DateTimeKind.Local).AddTicks(4888)),
                    last_update = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attributes", x => x.a_id);
                    table.ForeignKey(
                        name: "FK_Attributes_Devices_d_id",
                        column: x => x.d_id,
                        principalTable: "Devices",
                        principalColumn: "d_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Datas",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    a_id = table.Column<string>(nullable: true),
                    value = table.Column<float>(nullable: false),
                    update_time = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2022, 2, 19, 22, 55, 46, 913, DateTimeKind.Local).AddTicks(1644))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Datas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Datas_Attributes_a_id",
                        column: x => x.a_id,
                        principalTable: "Attributes",
                        principalColumn: "a_id",
                        onDelete: ReferentialAction.Restrict);
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
