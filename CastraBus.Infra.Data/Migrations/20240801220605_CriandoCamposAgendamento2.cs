using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CastraBus.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CriandoCamposAgendamento2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "animal_id",
                schema: "public",
                table: "Agendamento",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_animal_id",
                schema: "public",
                table: "Agendamento",
                column: "animal_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_Animal_animal_id",
                schema: "public",
                table: "Agendamento",
                column: "animal_id",
                principalSchema: "public",
                principalTable: "Animal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_Animal_animal_id",
                schema: "public",
                table: "Agendamento");

            migrationBuilder.DropIndex(
                name: "IX_Agendamento_animal_id",
                schema: "public",
                table: "Agendamento");

            migrationBuilder.DropColumn(
                name: "animal_id",
                schema: "public",
                table: "Agendamento");
        }
    }
}
