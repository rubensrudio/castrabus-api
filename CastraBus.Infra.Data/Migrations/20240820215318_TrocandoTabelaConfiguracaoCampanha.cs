using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CastraBus.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class TrocandoTabelaConfiguracaoCampanha : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_Configuracao_configuracao_id",
                schema: "public",
                table: "Agendamento");

            migrationBuilder.DropTable(
                name: "Configuracao",
                schema: "public");

            migrationBuilder.RenameColumn(
                name: "configuracao_id",
                schema: "public",
                table: "Agendamento",
                newName: "campanha_id");

            migrationBuilder.RenameIndex(
                name: "IX_Agendamento_configuracao_id",
                schema: "public",
                table: "Agendamento",
                newName: "IX_Agendamento_campanha_id");

            migrationBuilder.CreateTable(
                name: "Campanha",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'1', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nomecampanha = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    estadoId = table.Column<long>(type: "bigint", nullable: false),
                    cidadeId = table.Column<long>(type: "bigint", nullable: false),
                    bairroId = table.Column<long>(type: "bigint", nullable: false),
                    dataInicio = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    dataFim = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    horaInicio = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    horaFim = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    horaInicioIntervalo = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    horaFimIntervalo = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    domingo = table.Column<bool>(type: "boolean", nullable: false),
                    segunda = table.Column<bool>(type: "boolean", nullable: false),
                    terca = table.Column<bool>(type: "boolean", nullable: false),
                    quarta = table.Column<bool>(type: "boolean", nullable: false),
                    quinta = table.Column<bool>(type: "boolean", nullable: false),
                    sexta = table.Column<bool>(type: "boolean", nullable: false),
                    sabado = table.Column<bool>(type: "boolean", nullable: false),
                    pontuacaoDia = table.Column<long>(type: "bigint", nullable: false),
                    caninoManha = table.Column<bool>(type: "boolean", nullable: false),
                    caninoTarde = table.Column<bool>(type: "boolean", nullable: false),
                    felinoManha = table.Column<bool>(type: "boolean", nullable: false),
                    felinoTarde = table.Column<bool>(type: "boolean", nullable: false),
                    empresa_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campanha", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Campanha_Empresa_empresa_id",
                        column: x => x.empresa_id,
                        principalSchema: "public",
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Campanha_empresa_id",
                schema: "public",
                table: "Campanha",
                column: "empresa_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_Campanha_campanha_id",
                schema: "public",
                table: "Agendamento",
                column: "campanha_id",
                principalSchema: "public",
                principalTable: "Campanha",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_Campanha_campanha_id",
                schema: "public",
                table: "Agendamento");

            migrationBuilder.DropTable(
                name: "Campanha",
                schema: "public");

            migrationBuilder.RenameColumn(
                name: "campanha_id",
                schema: "public",
                table: "Agendamento",
                newName: "configuracao_id");

            migrationBuilder.RenameIndex(
                name: "IX_Agendamento_campanha_id",
                schema: "public",
                table: "Agendamento",
                newName: "IX_Agendamento_configuracao_id");

            migrationBuilder.CreateTable(
                name: "Configuracao",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'1', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    empresa_id = table.Column<long>(type: "bigint", nullable: false),
                    nomecampanha = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    bairroId = table.Column<long>(type: "bigint", nullable: false),
                    caninoManha = table.Column<bool>(type: "boolean", nullable: false),
                    caninoTarde = table.Column<bool>(type: "boolean", nullable: false),
                    cidadeId = table.Column<long>(type: "bigint", nullable: false),
                    dataFim = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    dataInicio = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    domingo = table.Column<bool>(type: "boolean", nullable: false),
                    estadoId = table.Column<long>(type: "bigint", nullable: false),
                    felinoManha = table.Column<bool>(type: "boolean", nullable: false),
                    felinoTarde = table.Column<bool>(type: "boolean", nullable: false),
                    horaFim = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    horaFimIntervalo = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    horaInicio = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    horaInicioIntervalo = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    pontuacaoDia = table.Column<long>(type: "bigint", nullable: false),
                    quarta = table.Column<bool>(type: "boolean", nullable: false),
                    quinta = table.Column<bool>(type: "boolean", nullable: false),
                    sabado = table.Column<bool>(type: "boolean", nullable: false),
                    segunda = table.Column<bool>(type: "boolean", nullable: false),
                    sexta = table.Column<bool>(type: "boolean", nullable: false),
                    terca = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configuracao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Configuracao_Empresa_empresa_id",
                        column: x => x.empresa_id,
                        principalSchema: "public",
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Configuracao_empresa_id",
                schema: "public",
                table: "Configuracao",
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
        }
    }
}
