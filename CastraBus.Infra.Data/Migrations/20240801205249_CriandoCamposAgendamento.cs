using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CastraBus.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CriandoCamposAgendamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "configuracao_id",
                schema: "public",
                table: "Agendamento",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "data",
                schema: "public",
                table: "Agendamento",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "empresa_id",
                schema: "public",
                table: "Agendamento",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "hora",
                schema: "public",
                table: "Agendamento",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_configuracao_id",
                schema: "public",
                table: "Agendamento",
                column: "configuracao_id");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_empresa_id",
                schema: "public",
                table: "Agendamento",
                column: "empresa_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_Configuracao_configuracao_id",
                schema: "public",
                table: "Agendamento",
                column: "configuracao_id",
                principalSchema: "public",
                principalTable: "Configuracao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_Empresa_empresa_id",
                schema: "public",
                table: "Agendamento",
                column: "empresa_id",
                principalSchema: "public",
                principalTable: "Empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_Configuracao_configuracao_id",
                schema: "public",
                table: "Agendamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_Empresa_empresa_id",
                schema: "public",
                table: "Agendamento");

            migrationBuilder.DropIndex(
                name: "IX_Agendamento_configuracao_id",
                schema: "public",
                table: "Agendamento");

            migrationBuilder.DropIndex(
                name: "IX_Agendamento_empresa_id",
                schema: "public",
                table: "Agendamento");

            migrationBuilder.DropColumn(
                name: "configuracao_id",
                schema: "public",
                table: "Agendamento");

            migrationBuilder.DropColumn(
                name: "data",
                schema: "public",
                table: "Agendamento");

            migrationBuilder.DropColumn(
                name: "empresa_id",
                schema: "public",
                table: "Agendamento");

            migrationBuilder.DropColumn(
                name: "hora",
                schema: "public",
                table: "Agendamento");
        }
    }
}
