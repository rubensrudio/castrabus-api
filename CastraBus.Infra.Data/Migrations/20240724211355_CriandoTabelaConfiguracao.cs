using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CastraBus.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CriandoTabelaConfiguracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "bairroId",
                schema: "public",
                table: "Configuracao",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "caninoManha",
                schema: "public",
                table: "Configuracao",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "caninoTarde",
                schema: "public",
                table: "Configuracao",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "cidadeId",
                schema: "public",
                table: "Configuracao",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "dataFim",
                schema: "public",
                table: "Configuracao",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "dataInicio",
                schema: "public",
                table: "Configuracao",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "domingo",
                schema: "public",
                table: "Configuracao",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "empresa_id",
                schema: "public",
                table: "Configuracao",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "felinoManha",
                schema: "public",
                table: "Configuracao",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "felinoTarde",
                schema: "public",
                table: "Configuracao",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "horaFim",
                schema: "public",
                table: "Configuracao",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "horaFimIntervalo",
                schema: "public",
                table: "Configuracao",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "horaInicio",
                schema: "public",
                table: "Configuracao",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "horaInicioIntervalo",
                schema: "public",
                table: "Configuracao",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "pontuacaoDia",
                schema: "public",
                table: "Configuracao",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "quarta",
                schema: "public",
                table: "Configuracao",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "quinta",
                schema: "public",
                table: "Configuracao",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "sabado",
                schema: "public",
                table: "Configuracao",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "segunda",
                schema: "public",
                table: "Configuracao",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "sexta",
                schema: "public",
                table: "Configuracao",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "terca",
                schema: "public",
                table: "Configuracao",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Configuracao_empresa_id",
                schema: "public",
                table: "Configuracao",
                column: "empresa_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Configuracao_Empresa_empresa_id",
                schema: "public",
                table: "Configuracao",
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
                name: "FK_Configuracao_Empresa_empresa_id",
                schema: "public",
                table: "Configuracao");

            migrationBuilder.DropIndex(
                name: "IX_Configuracao_empresa_id",
                schema: "public",
                table: "Configuracao");

            migrationBuilder.DropColumn(
                name: "bairroId",
                schema: "public",
                table: "Configuracao");

            migrationBuilder.DropColumn(
                name: "caninoManha",
                schema: "public",
                table: "Configuracao");

            migrationBuilder.DropColumn(
                name: "caninoTarde",
                schema: "public",
                table: "Configuracao");

            migrationBuilder.DropColumn(
                name: "cidadeId",
                schema: "public",
                table: "Configuracao");

            migrationBuilder.DropColumn(
                name: "dataFim",
                schema: "public",
                table: "Configuracao");

            migrationBuilder.DropColumn(
                name: "dataInicio",
                schema: "public",
                table: "Configuracao");

            migrationBuilder.DropColumn(
                name: "domingo",
                schema: "public",
                table: "Configuracao");

            migrationBuilder.DropColumn(
                name: "empresa_id",
                schema: "public",
                table: "Configuracao");

            migrationBuilder.DropColumn(
                name: "felinoManha",
                schema: "public",
                table: "Configuracao");

            migrationBuilder.DropColumn(
                name: "felinoTarde",
                schema: "public",
                table: "Configuracao");

            migrationBuilder.DropColumn(
                name: "horaFim",
                schema: "public",
                table: "Configuracao");

            migrationBuilder.DropColumn(
                name: "horaFimIntervalo",
                schema: "public",
                table: "Configuracao");

            migrationBuilder.DropColumn(
                name: "horaInicio",
                schema: "public",
                table: "Configuracao");

            migrationBuilder.DropColumn(
                name: "horaInicioIntervalo",
                schema: "public",
                table: "Configuracao");

            migrationBuilder.DropColumn(
                name: "pontuacaoDia",
                schema: "public",
                table: "Configuracao");

            migrationBuilder.DropColumn(
                name: "quarta",
                schema: "public",
                table: "Configuracao");

            migrationBuilder.DropColumn(
                name: "quinta",
                schema: "public",
                table: "Configuracao");

            migrationBuilder.DropColumn(
                name: "sabado",
                schema: "public",
                table: "Configuracao");

            migrationBuilder.DropColumn(
                name: "segunda",
                schema: "public",
                table: "Configuracao");

            migrationBuilder.DropColumn(
                name: "sexta",
                schema: "public",
                table: "Configuracao");

            migrationBuilder.DropColumn(
                name: "terca",
                schema: "public",
                table: "Configuracao");
        }
    }
}
