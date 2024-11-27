using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CastraBus.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class TbAtendimentoAddClTransOp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "esterilizacao",
                schema: "public",
                table: "Atendimento",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "intercorrencia",
                schema: "public",
                table: "Atendimento",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "motivo_esterilizacao",
                schema: "public",
                table: "Atendimento",
                type: "character varying(4000)",
                maxLength: 4000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "motivo_intercorrencia",
                schema: "public",
                table: "Atendimento",
                type: "character varying(4000)",
                maxLength: 4000,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "esterilizacao",
                schema: "public",
                table: "Atendimento");

            migrationBuilder.DropColumn(
                name: "intercorrencia",
                schema: "public",
                table: "Atendimento");

            migrationBuilder.DropColumn(
                name: "motivo_esterilizacao",
                schema: "public",
                table: "Atendimento");

            migrationBuilder.DropColumn(
                name: "motivo_intercorrencia",
                schema: "public",
                table: "Atendimento");
        }
    }
}
