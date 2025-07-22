using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RotaViagem.Infra.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbRota",
                columns: table => new
                {
                    RotId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RotOrigem = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RotDestino = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RotPreco = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbRota", x => x.RotId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbRota");
        }
    }
}
