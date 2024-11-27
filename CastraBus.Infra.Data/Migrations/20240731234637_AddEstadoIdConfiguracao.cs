using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CastraBus.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddEstadoIdConfiguracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "estadoId",
                schema: "public",
                table: "Configuracao",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "estadoId",
                schema: "public",
                table: "Configuracao");
        }
    }
}
