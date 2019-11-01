using Microsoft.EntityFrameworkCore.Migrations;

namespace SalesWebMVC.Migrations
{
    public partial class DepartmentForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seller_Department_departmentid",
                table: "Seller");

            migrationBuilder.AlterColumn<int>(
                name: "departmentid",
                table: "Seller",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Seller_Department_departmentid",
                table: "Seller",
                column: "departmentid",
                principalTable: "Department",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seller_Department_departmentid",
                table: "Seller");

            migrationBuilder.AlterColumn<int>(
                name: "departmentid",
                table: "Seller",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Seller_Department_departmentid",
                table: "Seller",
                column: "departmentid",
                principalTable: "Department",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
