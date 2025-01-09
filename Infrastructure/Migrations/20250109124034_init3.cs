using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menu_Restaurant_RestaurantId",
                table: "Menu");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Menu_MenuItemId",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Orders_OrderId",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Courier_CourierId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Restaurant_RestaurantId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Restaurant",
                table: "Restaurant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetail",
                table: "OrderDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Menu",
                table: "Menu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courier",
                table: "Courier");

            migrationBuilder.RenameTable(
                name: "Restaurant",
                newName: "Restaurants");

            migrationBuilder.RenameTable(
                name: "OrderDetail",
                newName: "OrderDetails");

            migrationBuilder.RenameTable(
                name: "Menu",
                newName: "Menus");

            migrationBuilder.RenameTable(
                name: "Courier",
                newName: "Couriers");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetail_OrderId",
                table: "OrderDetails",
                newName: "IX_OrderDetails_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetail_MenuItemId",
                table: "OrderDetails",
                newName: "IX_OrderDetails_MenuItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Menu_RestaurantId",
                table: "Menus",
                newName: "IX_Menus_RestaurantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Restaurants",
                table: "Restaurants",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Menus",
                table: "Menus",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Couriers",
                table: "Couriers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Couriers_UserId",
                table: "Couriers",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Couriers_Users_UserId",
                table: "Couriers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Restaurants_RestaurantId",
                table: "Menus",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Menus_MenuItemId",
                table: "OrderDetails",
                column: "MenuItemId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Orders_OrderId",
                table: "OrderDetails",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Couriers_CourierId",
                table: "Orders",
                column: "CourierId",
                principalTable: "Couriers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Restaurants_RestaurantId",
                table: "Orders",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Couriers_Users_UserId",
                table: "Couriers");

            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Restaurants_RestaurantId",
                table: "Menus");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Menus_MenuItemId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Orders_OrderId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Couriers_CourierId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Restaurants_RestaurantId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Restaurants",
                table: "Restaurants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Menus",
                table: "Menus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Couriers",
                table: "Couriers");

            migrationBuilder.DropIndex(
                name: "IX_Couriers_UserId",
                table: "Couriers");

            migrationBuilder.RenameTable(
                name: "Restaurants",
                newName: "Restaurant");

            migrationBuilder.RenameTable(
                name: "OrderDetails",
                newName: "OrderDetail");

            migrationBuilder.RenameTable(
                name: "Menus",
                newName: "Menu");

            migrationBuilder.RenameTable(
                name: "Couriers",
                newName: "Courier");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetail",
                newName: "IX_OrderDetail_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_MenuItemId",
                table: "OrderDetail",
                newName: "IX_OrderDetail_MenuItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Menus_RestaurantId",
                table: "Menu",
                newName: "IX_Menu_RestaurantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Restaurant",
                table: "Restaurant",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetail",
                table: "OrderDetail",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Menu",
                table: "Menu",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courier",
                table: "Courier",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Menu_Restaurant_RestaurantId",
                table: "Menu",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Menu_MenuItemId",
                table: "OrderDetail",
                column: "MenuItemId",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Orders_OrderId",
                table: "OrderDetail",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Courier_CourierId",
                table: "Orders",
                column: "CourierId",
                principalTable: "Courier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Restaurant_RestaurantId",
                table: "Orders",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
