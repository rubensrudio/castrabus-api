using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CastraBus.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class TbAtendimentoRemoveFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atendimento_Pessoa_veterinario_Id",
                schema: "public",
                table: "Atendimento");

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimento_Pessoa_veterinario_Id",
                schema: "public",
                table: "Atendimento",
                column: "veterinario_Id",
                principalSchema: "public",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atendimento_Pessoa_veterinario_Id",
                schema: "public",
                table: "Atendimento");

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimento_Pessoa_veterinario_Id",
                schema: "public",
                table: "Atendimento",
                column: "veterinario_Id",
                principalSchema: "public",
                principalTable: "Pessoa",
                principalColumn: "Id");
        }
    }
}
