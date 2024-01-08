using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StockAndBuy.Data.Migrations
{
    /// <inheritdoc />
    public partial class bundleschemav1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Bundles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsMainBundle = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bundles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SpareParts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    InventoryCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpareParts", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BundleParts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    BundleId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    BundlePartId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    RequiredUnits = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BundleParts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BundleParts_Bundles_BundleId",
                        column: x => x.BundleId,
                        principalTable: "Bundles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BundleParts_Bundles_BundlePartId",
                        column: x => x.BundlePartId,
                        principalTable: "Bundles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BundleSpareParts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    BundleId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    SparePartId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    RequiredUnits = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BundleSpareParts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BundleSpareParts_Bundles_BundleId",
                        column: x => x.BundleId,
                        principalTable: "Bundles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BundleSpareParts_SpareParts_SparePartId",
                        column: x => x.SparePartId,
                        principalTable: "SpareParts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Bundles",
                columns: new[] { "Id", "IsMainBundle", "Name" },
                values: new object[,]
                {
                    { new Guid("6128354f-2e07-4063-901a-b60c02930e6d"), false, "Wheel" },
                    { new Guid("6128354f-2e07-4063-901a-b60c02930e6e"), true, "Bicycle" }
                });

            migrationBuilder.InsertData(
                table: "SpareParts",
                columns: new[] { "Id", "InventoryCount", "Name" },
                values: new object[,]
                {
                    { new Guid("6128354f-2e07-4063-901a-b60c02930e6a"), 60, "Frame" },
                    { new Guid("6128354f-2e07-4063-901a-b60c02930e6b"), 35, "Tube" },
                    { new Guid("6128354f-2e07-4063-901a-b60c02930e6c"), 50, "Seat" },
                    { new Guid("6128354f-2e07-4063-901a-b60c02930e6d"), 60, "Pedals" }
                });

            migrationBuilder.InsertData(
                table: "BundleParts",
                columns: new[] { "Id", "BundleId", "BundlePartId", "RequiredUnits" },
                values: new object[] { new Guid("6128354f-2e07-4063-901a-b60c02930e61"), new Guid("6128354f-2e07-4063-901a-b60c02930e6e"), new Guid("6128354f-2e07-4063-901a-b60c02930e6d"), 2 });

            migrationBuilder.InsertData(
                table: "BundleSpareParts",
                columns: new[] { "Id", "BundleId", "RequiredUnits", "SparePartId" },
                values: new object[,]
                {
                    { new Guid("6128354f-2e07-4063-901a-b60c02930e61"), new Guid("6128354f-2e07-4063-901a-b60c02930e6d"), 1, new Guid("6128354f-2e07-4063-901a-b60c02930e6a") },
                    { new Guid("6128354f-2e07-4063-901a-b60c02930e62"), new Guid("6128354f-2e07-4063-901a-b60c02930e6d"), 1, new Guid("6128354f-2e07-4063-901a-b60c02930e6b") },
                    { new Guid("6128354f-2e07-4063-901a-b60c02930e63"), new Guid("6128354f-2e07-4063-901a-b60c02930e6e"), 1, new Guid("6128354f-2e07-4063-901a-b60c02930e6c") },
                    { new Guid("6128354f-2e07-4063-901a-b60c02930e64"), new Guid("6128354f-2e07-4063-901a-b60c02930e6e"), 2, new Guid("6128354f-2e07-4063-901a-b60c02930e6d") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BundleParts_BundleId_BundlePartId",
                table: "BundleParts",
                columns: new[] { "BundleId", "BundlePartId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BundleParts_BundlePartId",
                table: "BundleParts",
                column: "BundlePartId");

            migrationBuilder.CreateIndex(
                name: "IX_Bundles_Name",
                table: "Bundles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BundleSpareParts_BundleId_SparePartId",
                table: "BundleSpareParts",
                columns: new[] { "BundleId", "SparePartId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BundleSpareParts_SparePartId",
                table: "BundleSpareParts",
                column: "SparePartId");

            migrationBuilder.CreateIndex(
                name: "IX_SpareParts_Name",
                table: "SpareParts",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BundleParts");

            migrationBuilder.DropTable(
                name: "BundleSpareParts");

            migrationBuilder.DropTable(
                name: "Bundles");

            migrationBuilder.DropTable(
                name: "SpareParts");
        }
    }
}
