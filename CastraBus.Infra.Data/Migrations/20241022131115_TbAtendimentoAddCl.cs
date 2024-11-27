using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CastraBus.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class TbAtendimentoAddCl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "antiCio",
                schema: "public",
                table: "Atendimento",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "cioRecente",
                schema: "public",
                table: "Atendimento",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "criseEpileptica",
                schema: "public",
                table: "Atendimento",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "desmaios",
                schema: "public",
                table: "Atendimento",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "filhoteRecente",
                schema: "public",
                table: "Atendimento",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "historicoDoencas",
                schema: "public",
                table: "Atendimento",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "historicoVeterinario",
                schema: "public",
                table: "Atendimento",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "horarioPreso",
                schema: "public",
                table: "Atendimento",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "idadeFilhote",
                schema: "public",
                table: "Atendimento",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "jejum",
                schema: "public",
                table: "Atendimento",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "observacoesComportamento",
                schema: "public",
                table: "Atendimento",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "presoDuranteNoite",
                schema: "public",
                table: "Atendimento",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "quandoCruzou",
                schema: "public",
                table: "Atendimento",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "quandoTratamentoCirurgico",
                schema: "public",
                table: "Atendimento",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "soltoDuranteNoite",
                schema: "public",
                table: "Atendimento",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "tratamentoCirurgico",
                schema: "public",
                table: "Atendimento",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ultimaAlimentacao",
                schema: "public",
                table: "Atendimento",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ultimaAplicacao",
                schema: "public",
                table: "Atendimento",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ultimaIngestaoLiquidos",
                schema: "public",
                table: "Atendimento",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "urinandoNormalmente",
                schema: "public",
                table: "Atendimento",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "vermifugado",
                schema: "public",
                table: "Atendimento",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "antiCio",
                schema: "public",
                table: "Atendimento");

            migrationBuilder.DropColumn(
                name: "cioRecente",
                schema: "public",
                table: "Atendimento");

            migrationBuilder.DropColumn(
                name: "criseEpileptica",
                schema: "public",
                table: "Atendimento");

            migrationBuilder.DropColumn(
                name: "desmaios",
                schema: "public",
                table: "Atendimento");

            migrationBuilder.DropColumn(
                name: "filhoteRecente",
                schema: "public",
                table: "Atendimento");

            migrationBuilder.DropColumn(
                name: "historicoDoencas",
                schema: "public",
                table: "Atendimento");

            migrationBuilder.DropColumn(
                name: "historicoVeterinario",
                schema: "public",
                table: "Atendimento");

            migrationBuilder.DropColumn(
                name: "horarioPreso",
                schema: "public",
                table: "Atendimento");

            migrationBuilder.DropColumn(
                name: "idadeFilhote",
                schema: "public",
                table: "Atendimento");

            migrationBuilder.DropColumn(
                name: "jejum",
                schema: "public",
                table: "Atendimento");

            migrationBuilder.DropColumn(
                name: "observacoesComportamento",
                schema: "public",
                table: "Atendimento");

            migrationBuilder.DropColumn(
                name: "presoDuranteNoite",
                schema: "public",
                table: "Atendimento");

            migrationBuilder.DropColumn(
                name: "quandoCruzou",
                schema: "public",
                table: "Atendimento");

            migrationBuilder.DropColumn(
                name: "quandoTratamentoCirurgico",
                schema: "public",
                table: "Atendimento");

            migrationBuilder.DropColumn(
                name: "soltoDuranteNoite",
                schema: "public",
                table: "Atendimento");

            migrationBuilder.DropColumn(
                name: "tratamentoCirurgico",
                schema: "public",
                table: "Atendimento");

            migrationBuilder.DropColumn(
                name: "ultimaAlimentacao",
                schema: "public",
                table: "Atendimento");

            migrationBuilder.DropColumn(
                name: "ultimaAplicacao",
                schema: "public",
                table: "Atendimento");

            migrationBuilder.DropColumn(
                name: "ultimaIngestaoLiquidos",
                schema: "public",
                table: "Atendimento");

            migrationBuilder.DropColumn(
                name: "urinandoNormalmente",
                schema: "public",
                table: "Atendimento");

            migrationBuilder.DropColumn(
                name: "vermifugado",
                schema: "public",
                table: "Atendimento");
        }
    }
}
