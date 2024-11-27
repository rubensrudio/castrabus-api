using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CastraBus.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoTabelaAtendimento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "agendamento_Id",
                schema: "public",
                table: "Atendimento",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "animal_Id",
                schema: "public",
                table: "Atendimento",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "receita",
                schema: "public",
                table: "Atendimento",
                type: "character varying(4000)",
                maxLength: 4000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "senhaAtendimento",
                schema: "public",
                table: "Atendimento",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "statusAtendimento",
                schema: "public",
                table: "Atendimento",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "tipoCirurgia",
                schema: "public",
                table: "Atendimento",
                type: "character varying(4000)",
                maxLength: 4000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "tutor_Id",
                schema: "public",
                table: "Atendimento",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "veterinario_Id",
                schema: "public",
                table: "Atendimento",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_agendamento_Id",
                schema: "public",
                table: "Atendimento",
                column: "agendamento_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_animal_Id",
                schema: "public",
                table: "Atendimento",
                column: "animal_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_tutor_Id",
                schema: "public",
                table: "Atendimento",
                column: "tutor_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_veterinario_Id",
                schema: "public",
                table: "Atendimento",
                column: "veterinario_Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimento_Agendamento_agendamento_Id",
                schema: "public",
                table: "Atendimento",
                column: "agendamento_Id",
                principalSchema: "public",
                principalTable: "Agendamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimento_Animal_animal_Id",
                schema: "public",
                table: "Atendimento",
                column: "animal_Id",
                principalSchema: "public",
                principalTable: "Animal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimento_Pessoa_tutor_Id",
                schema: "public",
                table: "Atendimento",
                column: "tutor_Id",
                principalSchema: "public",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atendimento_Agendamento_agendamento_Id",
                schema: "public",
                table: "Atendimento");

            migrationBuilder.DropForeignKey(
                name: "FK_Atendimento_Animal_animal_Id",
                schema: "public",
                table: "Atendimento");

            migrationBuilder.DropForeignKey(
                name: "FK_Atendimento_Pessoa_tutor_Id",
                schema: "public",
                table: "Atendimento");

            migrationBuilder.DropForeignKey(
                name: "FK_Atendimento_Pessoa_veterinario_Id",
                schema: "public",
                table: "Atendimento");

            migrationBuilder.DropIndex(
                name: "IX_Atendimento_agendamento_Id",
                schema: "public",
                table: "Atendimento");

            migrationBuilder.DropIndex(
                name: "IX_Atendimento_animal_Id",
                schema: "public",
                table: "Atendimento");

            migrationBuilder.DropIndex(
                name: "IX_Atendimento_tutor_Id",
                schema: "public",
                table: "Atendimento");

            migrationBuilder.DropIndex(
                name: "IX_Atendimento_veterinario_Id",
                schema: "public",
                table: "Atendimento");

            migrationBuilder.DropColumn(
                name: "agendamento_Id",
                schema: "public",
                table: "Atendimento");

            migrationBuilder.DropColumn(
                name: "animal_Id",
                schema: "public",
                table: "Atendimento");

            migrationBuilder.DropColumn(
                name: "receita",
                schema: "public",
                table: "Atendimento");

            migrationBuilder.DropColumn(
                name: "senhaAtendimento",
                schema: "public",
                table: "Atendimento");

            migrationBuilder.DropColumn(
                name: "statusAtendimento",
                schema: "public",
                table: "Atendimento");

            migrationBuilder.DropColumn(
                name: "tipoCirurgia",
                schema: "public",
                table: "Atendimento");

            migrationBuilder.DropColumn(
                name: "tutor_Id",
                schema: "public",
                table: "Atendimento");

            migrationBuilder.DropColumn(
                name: "veterinario_Id",
                schema: "public",
                table: "Atendimento");
        }
    }
}
