using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebStore.DAL.Migrations
{
    public partial class Initial10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_StationaryStores_AddressId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_StationaryStores_StationaryStoreId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_AddressId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Addresses");

            migrationBuilder.AddColumn<int>(
                name: "StationaryStoreId",
                table: "Addresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_StationaryStoreId",
                table: "Addresses",
                column: "StationaryStoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_StationaryStores_StationaryStoreId",
                table: "Addresses",
                column: "StationaryStoreId",
                principalTable: "StationaryStores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_StationaryStores_StationaryStoreId",
                table: "AspNetUsers",
                column: "StationaryStoreId",
                principalTable: "StationaryStores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_StationaryStores_StationaryStoreId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_StationaryStores_StationaryStoreId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_StationaryStoreId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "StationaryStoreId",
                table: "Addresses");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Addresses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_AddressId",
                table: "Addresses",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_StationaryStores_AddressId",
                table: "Addresses",
                column: "AddressId",
                principalTable: "StationaryStores",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_StationaryStores_StationaryStoreId",
                table: "AspNetUsers",
                column: "StationaryStoreId",
                principalTable: "StationaryStores",
                principalColumn: "Id");
        }
    }
}
