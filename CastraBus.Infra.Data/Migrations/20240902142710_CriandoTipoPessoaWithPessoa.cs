using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CastraBus.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CriandoTipoPessoaWithPessoa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "tipo_pessoa_id",
                schema: "public",
                table: "Pessoa",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "TipoPessoaEntity",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'1', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPessoaEntity", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_tipo_pessoa_id",
                schema: "public",
                table: "Pessoa",
                column: "tipo_pessoa_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoa_TipoPessoaEntity_tipo_pessoa_id",
                schema: "public",
                table: "Pessoa",
                column: "tipo_pessoa_id",
                principalSchema: "public",
                principalTable: "TipoPessoaEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoa_TipoPessoaEntity_tipo_pessoa_id",
                schema: "public",
                table: "Pessoa");

            migrationBuilder.DropTable(
                name: "TipoPessoaEntity",
                schema: "public");

            migrationBuilder.DropIndex(
                name: "IX_Pessoa_tipo_pessoa_id",
                schema: "public",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "tipo_pessoa_id",
                schema: "public",
                table: "Pessoa");
        }
    }
}
