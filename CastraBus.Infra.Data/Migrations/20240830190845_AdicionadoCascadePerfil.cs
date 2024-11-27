using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CastraBus.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionadoCascadePerfil : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissoes_Perfil_perfil_id",
                schema: "public",
                table: "Permissoes");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissoes_Perfil_perfil_id",
                schema: "public",
                table: "Permissoes",
                column: "perfil_id",
                principalSchema: "public",
                principalTable: "Perfil",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissoes_Perfil_perfil_id",
                schema: "public",
                table: "Permissoes");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissoes_Perfil_perfil_id",
                schema: "public",
                table: "Permissoes",
                column: "perfil_id",
                principalSchema: "public",
                principalTable: "Perfil",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
