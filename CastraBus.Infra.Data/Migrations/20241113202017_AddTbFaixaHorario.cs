using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CastraBus.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTbFaixaHorario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FaixaHorario",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'1', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    horario_inicio = table.Column<string>(type: "text", nullable: false),
                    horario_fim = table.Column<string>(type: "text", nullable: false),
                    tipoEspecie_id = table.Column<long>(type: "bigint", nullable: false),
                    campanha_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaixaHorario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FaixaHorario_Campanha_campanha_id",
                        column: x => x.campanha_id,
                        principalSchema: "public",
                        principalTable: "Campanha",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FaixaHorario_TipoEspecie_tipoEspecie_id",
                        column: x => x.tipoEspecie_id,
                        principalSchema: "public",
                        principalTable: "TipoEspecie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FaixaHorario_campanha_id",
                schema: "public",
                table: "FaixaHorario",
                column: "campanha_id");

            migrationBuilder.CreateIndex(
                name: "IX_FaixaHorario_tipoEspecie_id",
                schema: "public",
                table: "FaixaHorario",
                column: "tipoEspecie_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FaixaHorario",
                schema: "public");
        }
    }
}
