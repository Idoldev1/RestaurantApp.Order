using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantApp.Order.API.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Orders",
                newName: "Order Id");

            migrationBuilder.RenameColumn(
                name: "FoodId",
                table: "OrderItem",
                newName: "Food Id");

            migrationBuilder.AlterColumn<string>(
                name: "Food Id",
                table: "OrderItem",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Order Id",
                table: "Orders",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "Food Id",
                table: "OrderItem",
                newName: "FoodId");

            migrationBuilder.AlterColumn<int>(
                name: "FoodId",
                table: "OrderItem",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);
        }
    }
}
