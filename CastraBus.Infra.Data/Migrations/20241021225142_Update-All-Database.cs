using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CastraBus.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAllDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Atendimento_animal_Id",
                schema: "public",
                table: "Atendimento");

            migrationBuilder.DropIndex(
                name: "IX_Atendimento_tutor_Id",
                schema: "public",
                table: "Atendimento");

            migrationBuilder.DropColumn(
                name: "quantidadeComprimidos",
                schema: "public",
                table: "Recomendacao");

            migrationBuilder.RenameColumn(
                name: "peso",
                schema: "public",
                table: "Recomendacao",
                newName: "pesoInicial");

            migrationBuilder.AddColumn<double>(
                name: "pesoFinal",
                schema: "public",
                table: "Recomendacao",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<long>(
                name: "qtdComprimidos",
                schema: "public",
                table: "Recomendacao",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_animal_Id",
                schema: "public",
                table: "Atendimento",
                column: "animal_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_tutor_Id",
                schema: "public",
                table: "Atendimento",
                column: "tutor_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Atendimento_animal_Id",
                schema: "public",
                table: "Atendimento");

            migrationBuilder.DropIndex(
                name: "IX_Atendimento_tutor_Id",
                schema: "public",
                table: "Atendimento");

            migrationBuilder.DropColumn(
                name: "pesoFinal",
                schema: "public",
                table: "Recomendacao");

            migrationBuilder.DropColumn(
                name: "qtdComprimidos",
                schema: "public",
                table: "Recomendacao");

            migrationBuilder.RenameColumn(
                name: "pesoInicial",
                schema: "public",
                table: "Recomendacao",
                newName: "peso");

            migrationBuilder.AddColumn<string>(
                name: "quantidadeComprimidos",
                schema: "public",
                table: "Recomendacao",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_animal_Id",
                schema: "public",
                table: "Atendimento",
                column: "animal_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_tutor_Id",
                schema: "public",
                table: "Atendimento",
                column: "tutor_Id",
                unique: true);
        }
    }
}
