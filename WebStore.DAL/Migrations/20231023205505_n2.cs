using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebStore.DAL.Migrations
{
    public partial class n2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_StationaryStores_AddressId",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "Addresses",
                newName: "StationaryStoreId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_AddressId",
                table: "Addresses",
                newName: "IX_Addresses_StationaryStoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_StationaryStores_StationaryStoreId",
                table: "Addresses",
                column: "StationaryStoreId",
                principalTable: "StationaryStores",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_StationaryStores_StationaryStoreId",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "StationaryStoreId",
                table: "Addresses",
                newName: "AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_StationaryStoreId",
                table: "Addresses",
                newName: "IX_Addresses_AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_StationaryStores_AddressId",
                table: "Addresses",
                column: "AddressId",
                principalTable: "StationaryStores",
                principalColumn: "Id");
        }
    }
}
