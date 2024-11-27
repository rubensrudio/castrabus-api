using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CastraBus.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class ImplemantandoColunaNomeCampanhaConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "nomecampanha",
                schema: "public",
                table: "Configuracao",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nomecampanha",
                schema: "public",
                table: "Configuracao");
        }
    }
}
