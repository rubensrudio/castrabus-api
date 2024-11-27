using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CastraBus.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class TbAtendimentoRemoveFKVeterinario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atendimento_Pessoa_veterinario_Id",
                schema: "public",
                table: "Atendimento");

            migrationBuilder.AlterColumn<long>(
                name: "veterinario_Id",
                schema: "public",
                table: "Atendimento",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimento_Pessoa_veterinario_Id",
                schema: "public",
                table: "Atendimento",
                column: "veterinario_Id",
                principalSchema: "public",
                principalTable: "Pessoa",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atendimento_Pessoa_veterinario_Id",
                schema: "public",
                table: "Atendimento");

            migrationBuilder.AlterColumn<long>(
                name: "veterinario_Id",
                schema: "public",
                table: "Atendimento",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimento_Pessoa_veterinario_Id",
                schema: "public",
                table: "Atendimento",
                column: "veterinario_Id",
                principalSchema: "public",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
