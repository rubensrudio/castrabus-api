using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CastraBus.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoCamposUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "password",
                schema: "public",
                table: "Usuario",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "username",
                schema: "public",
                table: "Usuario",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "password",
                schema: "public",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "username",
                schema: "public",
                table: "Usuario");
        }
    }
}
