﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class MigratonName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Category_id = table.Column<int>(type: "int", nullable: false),
                    For_dogs = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    For_cats = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Aquariums = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    For_birds = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Category_id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    ClieNt_code = table.Column<int>(type: "int", nullable: false),
                    Nickname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Middle_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone_number = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Birthdate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Customer__39C9B6488972FDD8", x => x.ClieNt_code);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    Employee_code = table.Column<int>(type: "int", nullable: false),
                    Nickname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Namee = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Middle_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone_number = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Birthdate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Staff__AB80DE19E61BAA15", x => x.Employee_code);
                });

            migrationBuilder.CreateTable(
                name: "filter",
                columns: table => new
                {
                    Category_id = table.Column<int>(type: "int", nullable: false),
                    Feed = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    toys = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Bowls = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    aquariums = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__filter__6DB281365D12F919", x => x.Category_id);
                    table.ForeignKey(
                        name: "FK__filter__Category__4AB81AF0",
                        column: x => x.Category_id,
                        principalTable: "Category",
                        principalColumn: "Category_id");
                });

            migrationBuilder.CreateTable(
                name: "Products1",
                columns: table => new
                {
                    ltem_number = table.Column<int>(type: "int", nullable: false),
                    Category_id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(25,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Article_number = table.Column<int>(type: "int", nullable: false),
                    Number_in_clade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Products__402A1938C04A35E2", x => x.ltem_number);
                    table.ForeignKey(
                        name: "FK__Products1__Numbe__440B1D61",
                        column: x => x.Category_id,
                        principalTable: "Category",
                        principalColumn: "Category_id");
                });

            migrationBuilder.CreateTable(
                name: "Basket_Buyer",
                columns: table => new
                {
                    id_user = table.Column<int>(type: "int", nullable: false),
                    ltem_number = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Basket_B__46D3E7A4A92CCF8E", x => new { x.id_user, x.ltem_number });
                    table.ForeignKey(
                        name: "FK__Basket_Bu__id_us__46E78A0C",
                        column: x => x.id_user,
                        principalTable: "Customers",
                        principalColumn: "ClieNt_code");
                    table.ForeignKey(
                        name: "FK__Basket_Bu__ltem___47DBAE45",
                        column: x => x.ltem_number,
                        principalTable: "Products1",
                        principalColumn: "ltem_number");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Order_code = table.Column<int>(type: "int", nullable: false),
                    id_user = table.Column<int>(type: "int", nullable: false),
                    ltem_number = table.Column<int>(type: "int", nullable: false),
                    Employee_Code = table.Column<int>(type: "int", nullable: false),
                    Date_and_time = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Delivery_method = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Orders__6B8A3A323F59E206", x => new { x.Order_code, x.id_user, x.ltem_number, x.Employee_Code });
                    table.ForeignKey(
                        name: "FK__Orders__Employee__4F7CD00D",
                        column: x => x.Employee_Code,
                        principalTable: "Staff",
                        principalColumn: "Employee_code");
                    table.ForeignKey(
                        name: "FK__Orders__id_user__4D94879B",
                        column: x => x.id_user,
                        principalTable: "Customers",
                        principalColumn: "ClieNt_code");
                    table.ForeignKey(
                        name: "FK__Orders__ltem_num__4E88ABD4",
                        column: x => x.ltem_number,
                        principalTable: "Products1",
                        principalColumn: "ltem_number");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Basket_Buyer_ltem_number",
                table: "Basket_Buyer",
                column: "ltem_number");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Employee_Code",
                table: "Orders",
                column: "Employee_Code");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_id_user",
                table: "Orders",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ltem_number",
                table: "Orders",
                column: "ltem_number");

            migrationBuilder.CreateIndex(
                name: "IX_Products1_Category_id",
                table: "Products1",
                column: "Category_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Basket_Buyer");

            migrationBuilder.DropTable(
                name: "filter");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Products1");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
