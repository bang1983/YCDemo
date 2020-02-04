using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GRUDDemo.Models.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DemoCode",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    Code = table.Column<string>(maxLength: 5, nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Remark = table.Column<string>(nullable: true),
                    CreateUser = table.Column<string>(maxLength: 8, nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DemoCode", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "UX_DemoCode",
                table: "DemoCode",
                column: "Code",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DemoCode");
        }
    }
}
