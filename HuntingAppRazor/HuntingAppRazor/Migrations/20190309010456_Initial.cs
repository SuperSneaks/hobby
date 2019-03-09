using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HuntingAppRazor.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    uuid = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(maxLength: 50, nullable: false),
                    address = table.Column<string>(maxLength: 10, nullable: true),
                    city = table.Column<string>(maxLength: 10, nullable: true),
                    state = table.Column<string>(maxLength: 10, nullable: true),
                    zip = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.uuid);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    uuid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    first_name = table.Column<string>(maxLength: 50, nullable: false),
                    last_name = table.Column<string>(maxLength: 50, nullable: false),
                    username = table.Column<string>(maxLength: 50, nullable: false),
                    password = table.Column<string>(maxLength: 4000, nullable: false),
                    email_address = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.uuid);
                });

            migrationBuilder.CreateTable(
                name: "Stands",
                columns: table => new
                {
                    uuid = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(maxLength: 50, nullable: false),
                    property_uuid = table.Column<Guid>(nullable: false),
                    front_img = table.Column<byte[]>(type: "image", nullable: true),
                    back_img = table.Column<byte[]>(type: "image", nullable: true),
                    left_img = table.Column<byte[]>(type: "image", nullable: true),
                    right_img = table.Column<byte[]>(type: "image", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stands", x => x.uuid);
                    table.ForeignKey(
                        name: "FK_Stands_Property",
                        column: x => x.property_uuid,
                        principalTable: "Properties",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PropertyAccess",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    users_uuid = table.Column<Guid>(nullable: false),
                    property_uuid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyAccess", x => x.id);
                    table.ForeignKey(
                        name: "FK_PropertyAccess_Property",
                        column: x => x.property_uuid,
                        principalTable: "Properties",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PropertyAccess_User",
                        column: x => x.users_uuid,
                        principalTable: "Users",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Hunts",
                columns: table => new
                {
                    uuid = table.Column<Guid>(nullable: false),
                    user_uuid = table.Column<Guid>(nullable: false),
                    stand_uuid = table.Column<Guid>(nullable: false),
                    hunt_start = table.Column<DateTime>(type: "datetime", nullable: false),
                    hunt_end = table.Column<DateTime>(type: "datetime", nullable: false),
                    bucks_seen = table.Column<int>(nullable: true),
                    does_seen = table.Column<int>(nullable: true),
                    unknown_seen = table.Column<int>(nullable: true),
                    sight_details = table.Column<string>(nullable: true),
                    notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hunts", x => x.uuid);
                    table.ForeignKey(
                        name: "FK_Hunts_Stands",
                        column: x => x.stand_uuid,
                        principalTable: "Stands",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hunts_User",
                        column: x => x.uuid,
                        principalTable: "Users",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sightings",
                columns: table => new
                {
                    uuid = table.Column<Guid>(nullable: false),
                    hunt_uuid = table.Column<Guid>(nullable: false),
                    sight_dt = table.Column<DateTime>(type: "datetime", nullable: false),
                    bucks_seen = table.Column<int>(nullable: true),
                    does_seen = table.Column<int>(nullable: true),
                    unknown_seen = table.Column<int>(nullable: true),
                    notes = table.Column<string>(unicode: false, maxLength: 160, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sightings", x => x.uuid);
                    table.ForeignKey(
                        name: "FK_Sightings_Hunts",
                        column: x => x.hunt_uuid,
                        principalTable: "Hunts",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hunts_stand_uuid",
                table: "Hunts",
                column: "stand_uuid");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyAccess_property_uuid",
                table: "PropertyAccess",
                column: "property_uuid");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyAccess_users_uuid",
                table: "PropertyAccess",
                column: "users_uuid");

            migrationBuilder.CreateIndex(
                name: "IX_Sightings_hunt_uuid",
                table: "Sightings",
                column: "hunt_uuid");

            migrationBuilder.CreateIndex(
                name: "IX_Stands_property_uuid",
                table: "Stands",
                column: "property_uuid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropertyAccess");

            migrationBuilder.DropTable(
                name: "Sightings");

            migrationBuilder.DropTable(
                name: "Hunts");

            migrationBuilder.DropTable(
                name: "Stands");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Properties");
        }
    }
}
