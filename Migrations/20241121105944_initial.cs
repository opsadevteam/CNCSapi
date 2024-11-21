using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CNCSapi.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivityLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogActivity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LogUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LogTime = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true),
                    LogDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogLocation = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    UserGroup = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblActivityLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Descriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductVendorID = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    LogID = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProdDescLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    LogID = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    LogDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogActivity = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    LogUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LogDate = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductVendor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductVendor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    LogID = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVendor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblUserAccount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserGroup = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AddedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    LogId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUserAccount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransactionLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CustomerID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PickUpDate = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true),
                    TakeOffDate = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true),
                    Duration = table.Column<long>(type: "bigint", nullable: true),
                    ProductVenderID = table.Column<int>(type: "int", nullable: true),
                    DescriptionID = table.Column<int>(type: "int", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RepliedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true),
                    Shift = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TransactionType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    LogID = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    LogBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LogDate = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true),
                    LogType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CustomerID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PickUpDate = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true),
                    TakeOffDate = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true),
                    Duration = table.Column<long>(type: "bigint", nullable: true),
                    ProductVenderID = table.Column<int>(type: "int", nullable: true),
                    DescriptionID = table.Column<int>(type: "int", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RepliedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true),
                    Shift = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TransactionType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    LogID = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityLog");

            migrationBuilder.DropTable(
                name: "Descriptions");

            migrationBuilder.DropTable(
                name: "ProdDescLog");

            migrationBuilder.DropTable(
                name: "ProductVendor");

            migrationBuilder.DropTable(
                name: "tblUserAccount");

            migrationBuilder.DropTable(
                name: "TransactionLogs");

            migrationBuilder.DropTable(
                name: "Transactions");
        }
    }
}
