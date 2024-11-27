using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CastraBus.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class TbAtendimentoRemoveVeterinarioFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atendimento_Pessoa_veterinario_Id",
                schema: "public",
                table: "Atendimento");

            migrationBuilder.DropIndex(
                name: "IX_Atendimento_veterinario_Id",
                schema: "public",
                table: "Atendimento");

            migrationBuilder.AddColumn<long>(
                name: "AtendimentoVeterinarioId",
                schema: "public",
                table: "Pessoa",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_AtendimentoVeterinarioId",
                schema: "public",
                table: "Pessoa",
                column: "AtendimentoVeterinarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoa_Atendimento_AtendimentoVeterinarioId",
                schema: "public",
                table: "Pessoa",
                column: "AtendimentoVeterinarioId",
                principalSchema: "public",
                principalTable: "Atendimento",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoa_Atendimento_AtendimentoVeterinarioId",
                schema: "public",
                table: "Pessoa");

            migrationBuilder.DropIndex(
                name: "IX_Pessoa_AtendimentoVeterinarioId",
                schema: "public",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "AtendimentoVeterinarioId",
                schema: "public",
                table: "Pessoa");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_veterinario_Id",
                schema: "public",
                table: "Atendimento",
                column: "veterinario_Id",
                unique: true);

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
    }
}
