using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PropertyInventorySystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateRelationContactProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactProperty_Contacts_ContactId",
                table: "ContactProperty");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactProperty_Properties_PropertyId",
                table: "ContactProperty");

            migrationBuilder.DropIndex(
                name: "IX_ContactProperty_ContactId",
                table: "ContactProperty");

            migrationBuilder.DropIndex(
                name: "IX_ContactProperty_PropertyId",
                table: "ContactProperty");

            migrationBuilder.DropColumn(
                name: "ContactId",
                table: "ContactProperty");

            migrationBuilder.DropColumn(
                name: "PropertyId",
                table: "ContactProperty");

            migrationBuilder.CreateIndex(
                name: "IX_ContactProperty_ContactsId",
                table: "ContactProperty",
                column: "ContactsId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactProperty_PropertiesId",
                table: "ContactProperty",
                column: "PropertiesId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactProperty_Contacts_ContactsId",
                table: "ContactProperty",
                column: "ContactsId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactProperty_Properties_PropertiesId",
                table: "ContactProperty",
                column: "PropertiesId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactProperty_Contacts_ContactsId",
                table: "ContactProperty");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactProperty_Properties_PropertiesId",
                table: "ContactProperty");

            migrationBuilder.DropIndex(
                name: "IX_ContactProperty_ContactsId",
                table: "ContactProperty");

            migrationBuilder.DropIndex(
                name: "IX_ContactProperty_PropertiesId",
                table: "ContactProperty");

            migrationBuilder.AddColumn<Guid>(
                name: "ContactId",
                table: "ContactProperty",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PropertyId",
                table: "ContactProperty",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ContactProperty_ContactId",
                table: "ContactProperty",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactProperty_PropertyId",
                table: "ContactProperty",
                column: "PropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactProperty_Contacts_ContactId",
                table: "ContactProperty",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactProperty_Properties_PropertyId",
                table: "ContactProperty",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
