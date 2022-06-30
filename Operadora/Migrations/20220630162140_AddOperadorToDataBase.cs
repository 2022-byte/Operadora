using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Operadora.Migrations
{
    public partial class AddOperadorToDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Operadors",
                columns: table => new
                {
                    IdOperador = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeOperador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailOperador = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operadors", x => x.IdOperador);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Operadors");
        }
    }
}
