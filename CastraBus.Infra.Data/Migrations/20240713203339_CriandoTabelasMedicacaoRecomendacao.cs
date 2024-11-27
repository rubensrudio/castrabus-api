using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CastraBus.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CriandoTabelasMedicacaoRecomendacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medicacao",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'1', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    dosagem = table.Column<long>(type: "bigint", nullable: false),
                    unidadeMedida = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    capsulaComprimido = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recomendacao",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'1', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    peso = table.Column<double>(type: "double precision", nullable: false),
                    quantidadeComprimidos = table.Column<int>(type: "integer", nullable: false),
                    dose = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    dias = table.Column<int>(type: "integer", nullable: false),
                    uso = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    medicacao_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recomendacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recomendacao_Medicacao_medicacao_Id",
                        column: x => x.medicacao_Id,
                        principalSchema: "public",
                        principalTable: "Medicacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recomendacao_medicacao_Id",
                schema: "public",
                table: "Recomendacao",
                column: "medicacao_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recomendacao",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Medicacao",
                schema: "public");
        }
    }
}
