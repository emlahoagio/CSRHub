using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class AddedCSRTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Organizations_OrganizationId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Sponsors_SponsorId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_OrganizationId",
                table: "Projects");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e23d633-4dcc-4ae0-bbcf-ff0630ead1eb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b1f1c35-e37d-4644-874e-5cb4e1b46abf");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "Projects");

            migrationBuilder.AlterColumn<Guid>(
                name: "SponsorId",
                table: "Projects",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "aa846f4c-b10d-4387-9077-b40d8fd2f1f5", "e481df4f-fbad-4a74-acee-34d3696dc148", "Manager", "MANAGER" },
                    { "ea02c635-aef6-43d9-ade1-5b4f202e2be3", "77b4626a-3e98-4ef0-9f23-774add30f7f7", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_OrgId",
                table: "Projects",
                column: "OrgId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Organizations_OrgId",
                table: "Projects",
                column: "OrgId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Sponsors_SponsorId",
                table: "Projects",
                column: "SponsorId",
                principalTable: "Sponsors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Organizations_OrgId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Sponsors_SponsorId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_OrgId",
                table: "Projects");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa846f4c-b10d-4387-9077-b40d8fd2f1f5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea02c635-aef6-43d9-ade1-5b4f202e2be3");

            migrationBuilder.AlterColumn<Guid>(
                name: "SponsorId",
                table: "Projects",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "OrganizationId",
                table: "Projects",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6e23d633-4dcc-4ae0-bbcf-ff0630ead1eb", "d1fc9b0e-1c4c-484a-aba5-21bf7041760e", "Administrator", "ADMINISTRATOR" },
                    { "9b1f1c35-e37d-4644-874e-5cb4e1b46abf", "d21f7cbe-d565-48e6-a7c5-1ef64bc83302", "Manager", "MANAGER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_OrganizationId",
                table: "Projects",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Organizations_OrganizationId",
                table: "Projects",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Sponsors_SponsorId",
                table: "Projects",
                column: "SponsorId",
                principalTable: "Sponsors",
                principalColumn: "Id");
        }
    }
}
