using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CastraBus.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class IncluindoChaveUsuarioTabelaImportacaoArquivo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "usuario",
                schema: "public",
                table: "ImportacaoArquivo");

            migrationBuilder.AddColumn<long>(
                name: "usuario_id",
                schema: "public",
                table: "ImportacaoArquivo",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_ImportacaoArquivo_usuario_id",
                schema: "public",
                table: "ImportacaoArquivo",
                column: "usuario_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImportacaoArquivo_Usuario_usuario_id",
                schema: "public",
                table: "ImportacaoArquivo",
                column: "usuario_id",
                principalSchema: "public",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImportacaoArquivo_Usuario_usuario_id",
                schema: "public",
                table: "ImportacaoArquivo");

            migrationBuilder.DropIndex(
                name: "IX_ImportacaoArquivo_usuario_id",
                schema: "public",
                table: "ImportacaoArquivo");

            migrationBuilder.DropColumn(
                name: "usuario_id",
                schema: "public",
                table: "ImportacaoArquivo");

            migrationBuilder.AddColumn<string>(
                name: "usuario",
                schema: "public",
                table: "ImportacaoArquivo",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
