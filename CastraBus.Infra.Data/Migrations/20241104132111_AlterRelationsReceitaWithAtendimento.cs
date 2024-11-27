using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CastraBus.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AlterRelationsReceitaWithAtendimento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receita_Atendimento_atendimento_Id",
                schema: "public",
                table: "Receita");

            migrationBuilder.DropIndex(
                name: "IX_Receita_atendimento_Id",
                schema: "public",
                table: "Receita");

            migrationBuilder.DropColumn(
                name: "receita",
                schema: "public",
                table: "Atendimento");

            migrationBuilder.AddColumn<long>(
                name: "receita_Id",
                schema: "public",
                table: "Atendimento",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_receita_Id",
                schema: "public",
                table: "Atendimento",
                column: "receita_Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimento_Receita_receita_Id",
                schema: "public",
                table: "Atendimento",
                column: "receita_Id",
                principalSchema: "public",
                principalTable: "Receita",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atendimento_Receita_receita_Id",
                schema: "public",
                table: "Atendimento");

            migrationBuilder.DropIndex(
                name: "IX_Atendimento_receita_Id",
                schema: "public",
                table: "Atendimento");

            migrationBuilder.DropColumn(
                name: "receita_Id",
                schema: "public",
                table: "Atendimento");

            migrationBuilder.AddColumn<string>(
                name: "receita",
                schema: "public",
                table: "Atendimento",
                type: "character varying(4000)",
                maxLength: 4000,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Receita_atendimento_Id",
                schema: "public",
                table: "Receita",
                column: "atendimento_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Receita_Atendimento_atendimento_Id",
                schema: "public",
                table: "Receita",
                column: "atendimento_Id",
                principalSchema: "public",
                principalTable: "Atendimento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
