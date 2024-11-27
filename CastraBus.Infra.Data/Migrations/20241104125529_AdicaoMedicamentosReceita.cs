using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CastraBus.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicaoMedicamentosReceita : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "senhaAtendimento",
                schema: "public",
                table: "Receita");

            migrationBuilder.CreateTable(
                name: "MedicacaoEntityReceitaEntity",
                schema: "public",
                columns: table => new
                {
                    MedicacoesId = table.Column<long>(type: "bigint", nullable: false),
                    ReceitasId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicacaoEntityReceitaEntity", x => new { x.MedicacoesId, x.ReceitasId });
                    table.ForeignKey(
                        name: "FK_MedicacaoEntityReceitaEntity_Medicacao_MedicacoesId",
                        column: x => x.MedicacoesId,
                        principalSchema: "public",
                        principalTable: "Medicacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedicacaoEntityReceitaEntity_Receita_ReceitasId",
                        column: x => x.ReceitasId,
                        principalSchema: "public",
                        principalTable: "Receita",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicacaoEntityReceitaEntity_ReceitasId",
                schema: "public",
                table: "MedicacaoEntityReceitaEntity",
                column: "ReceitasId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicacaoEntityReceitaEntity",
                schema: "public");

            migrationBuilder.AddColumn<string>(
                name: "senhaAtendimento",
                schema: "public",
                table: "Receita",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
