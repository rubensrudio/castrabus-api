using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CastraBus.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class ImplemantandoColunaPessoaIdAgendamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "pessoa_id",
                schema: "public",
                table: "Agendamento",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_pessoa_id",
                schema: "public",
                table: "Agendamento",
                column: "pessoa_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_Pessoa_pessoa_id",
                schema: "public",
                table: "Agendamento",
                column: "pessoa_id",
                principalSchema: "public",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_Pessoa_pessoa_id",
                schema: "public",
                table: "Agendamento");

            migrationBuilder.DropIndex(
                name: "IX_Agendamento_pessoa_id",
                schema: "public",
                table: "Agendamento");

            migrationBuilder.DropColumn(
                name: "pessoa_id",
                schema: "public",
                table: "Agendamento");
        }
    }
}
