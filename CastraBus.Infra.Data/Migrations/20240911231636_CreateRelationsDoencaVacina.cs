using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CastraBus.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateRelationsDoencaVacina : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoa_TipoPessoaEntity_tipo_pessoa_id",
                schema: "public",
                table: "Pessoa");

            migrationBuilder.DropForeignKey(
                name: "FK_Recomendacao_Medicacao_medicacao_Id",
                schema: "public",
                table: "Recomendacao");

            migrationBuilder.DropTable(
                name: "AnimalEntityTipoDoencaEntity",
                schema: "public");

            migrationBuilder.DropTable(
                name: "AnimalEntityTipoVacinaEntity",
                schema: "public");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoPessoaEntity",
                schema: "public",
                table: "TipoPessoaEntity");

            migrationBuilder.RenameTable(
                name: "TipoPessoaEntity",
                schema: "public",
                newName: "TipoPessoaEntities",
                newSchema: "public");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoPessoaEntities",
                schema: "public",
                table: "TipoPessoaEntities",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Doenca",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'1', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    diagnostico = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: false),
                    tratamento = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: false),
                    Animal_Id = table.Column<long>(type: "bigint", nullable: false),
                    TipoDoenca_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doenca", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doenca_Animal_Animal_Id",
                        column: x => x.Animal_Id,
                        principalSchema: "public",
                        principalTable: "Animal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Doenca_TipoDoenca_TipoDoenca_Id",
                        column: x => x.TipoDoenca_Id,
                        principalSchema: "public",
                        principalTable: "TipoDoenca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vacina",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'1', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    data_vacinacao = table.Column<string>(type: "text", nullable: false),
                    data_proxima_vacinacao = table.Column<string>(type: "text", nullable: false),
                    observacao = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: false),
                    Animal_Id = table.Column<long>(type: "bigint", nullable: false),
                    TipoVacina_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacina", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vacina_Animal_Animal_Id",
                        column: x => x.Animal_Id,
                        principalSchema: "public",
                        principalTable: "Animal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vacina_TipoVacina_TipoVacina_Id",
                        column: x => x.TipoVacina_Id,
                        principalSchema: "public",
                        principalTable: "TipoVacina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doenca_Animal_Id",
                schema: "public",
                table: "Doenca",
                column: "Animal_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Doenca_TipoDoenca_Id",
                schema: "public",
                table: "Doenca",
                column: "TipoDoenca_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Vacina_Animal_Id",
                schema: "public",
                table: "Vacina",
                column: "Animal_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Vacina_TipoVacina_Id",
                schema: "public",
                table: "Vacina",
                column: "TipoVacina_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoa_TipoPessoaEntities_tipo_pessoa_id",
                schema: "public",
                table: "Pessoa",
                column: "tipo_pessoa_id",
                principalSchema: "public",
                principalTable: "TipoPessoaEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recomendacao_Medicacao_medicacao_Id",
                schema: "public",
                table: "Recomendacao",
                column: "medicacao_Id",
                principalSchema: "public",
                principalTable: "Medicacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoa_TipoPessoaEntities_tipo_pessoa_id",
                schema: "public",
                table: "Pessoa");

            migrationBuilder.DropForeignKey(
                name: "FK_Recomendacao_Medicacao_medicacao_Id",
                schema: "public",
                table: "Recomendacao");

            migrationBuilder.DropTable(
                name: "Doenca",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Vacina",
                schema: "public");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoPessoaEntities",
                schema: "public",
                table: "TipoPessoaEntities");

            migrationBuilder.RenameTable(
                name: "TipoPessoaEntities",
                schema: "public",
                newName: "TipoPessoaEntity",
                newSchema: "public");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoPessoaEntity",
                schema: "public",
                table: "TipoPessoaEntity",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AnimalEntityTipoDoencaEntity",
                schema: "public",
                columns: table => new
                {
                    AnimalsId = table.Column<long>(type: "bigint", nullable: false),
                    DoencasId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalEntityTipoDoencaEntity", x => new { x.AnimalsId, x.DoencasId });
                    table.ForeignKey(
                        name: "FK_AnimalEntityTipoDoencaEntity_Animal_AnimalsId",
                        column: x => x.AnimalsId,
                        principalSchema: "public",
                        principalTable: "Animal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnimalEntityTipoDoencaEntity_TipoDoenca_DoencasId",
                        column: x => x.DoencasId,
                        principalSchema: "public",
                        principalTable: "TipoDoenca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnimalEntityTipoVacinaEntity",
                schema: "public",
                columns: table => new
                {
                    AnimalsId = table.Column<long>(type: "bigint", nullable: false),
                    VacinasId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalEntityTipoVacinaEntity", x => new { x.AnimalsId, x.VacinasId });
                    table.ForeignKey(
                        name: "FK_AnimalEntityTipoVacinaEntity_Animal_AnimalsId",
                        column: x => x.AnimalsId,
                        principalSchema: "public",
                        principalTable: "Animal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnimalEntityTipoVacinaEntity_TipoVacina_VacinasId",
                        column: x => x.VacinasId,
                        principalSchema: "public",
                        principalTable: "TipoVacina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimalEntityTipoDoencaEntity_DoencasId",
                schema: "public",
                table: "AnimalEntityTipoDoencaEntity",
                column: "DoencasId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalEntityTipoVacinaEntity_VacinasId",
                schema: "public",
                table: "AnimalEntityTipoVacinaEntity",
                column: "VacinasId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoa_TipoPessoaEntity_tipo_pessoa_id",
                schema: "public",
                table: "Pessoa",
                column: "tipo_pessoa_id",
                principalSchema: "public",
                principalTable: "TipoPessoaEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recomendacao_Medicacao_medicacao_Id",
                schema: "public",
                table: "Recomendacao",
                column: "medicacao_Id",
                principalSchema: "public",
                principalTable: "Medicacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
