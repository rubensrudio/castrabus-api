using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CastraBus.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class TbRecomendacaoAltQtdComprimidoDouble1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "qtdComprimidos",
                schema: "public",
                table: "Recomendacao",
                newName: "quantidadeComprimidos");

            migrationBuilder.AlterColumn<double>(
                name: "quantidadeComprimidos",
                schema: "public",
                table: "Recomendacao",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "quantidadeComprimidos",
                schema: "public",
                table: "Recomendacao",
                newName: "qtdComprimidos");

            migrationBuilder.AlterColumn<long>(
                name: "qtdComprimidos",
                schema: "public",
                table: "Recomendacao",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");
        }
    }
}
