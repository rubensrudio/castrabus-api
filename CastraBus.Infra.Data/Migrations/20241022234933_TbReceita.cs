using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CastraBus.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class TbReceita : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Receita",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'1', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    senhaAtendimento = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    agendamento_Id = table.Column<long>(type: "bigint", nullable: false),
                    atendimento_Id = table.Column<long>(type: "bigint", nullable: false),
                    animal_Id = table.Column<long>(type: "bigint", nullable: false),
                    veterinario_Id = table.Column<long>(type: "bigint", nullable: false),
                    tutor_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receita", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receita_Agendamento_agendamento_Id",
                        column: x => x.agendamento_Id,
                        principalSchema: "public",
                        principalTable: "Agendamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Receita_Animal_animal_Id",
                        column: x => x.animal_Id,
                        principalSchema: "public",
                        principalTable: "Animal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Receita_Atendimento_atendimento_Id",
                        column: x => x.atendimento_Id,
                        principalSchema: "public",
                        principalTable: "Atendimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Receita_Pessoa_tutor_Id",
                        column: x => x.tutor_Id,
                        principalSchema: "public",
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Receita_Pessoa_veterinario_Id",
                        column: x => x.veterinario_Id,
                        principalSchema: "public",
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Receita_agendamento_Id",
                schema: "public",
                table: "Receita",
                column: "agendamento_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Receita_animal_Id",
                schema: "public",
                table: "Receita",
                column: "animal_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Receita_atendimento_Id",
                schema: "public",
                table: "Receita",
                column: "atendimento_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Receita_tutor_Id",
                schema: "public",
                table: "Receita",
                column: "tutor_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Receita_veterinario_Id",
                schema: "public",
                table: "Receita",
                column: "veterinario_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Receita",
                schema: "public");
        }
    }
}
