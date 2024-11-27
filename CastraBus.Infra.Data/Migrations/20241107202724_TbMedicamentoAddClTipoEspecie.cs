using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CastraBus.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class TbMedicamentoAddClTipoEspecie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "tipoEspecie_Id",
                schema: "public",
                table: "Medicacao",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Medicacao_tipoEspecie_Id",
                schema: "public",
                table: "Medicacao",
                column: "tipoEspecie_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicacao_TipoEspecie_tipoEspecie_Id",
                schema: "public",
                table: "Medicacao",
                column: "tipoEspecie_Id",
                principalSchema: "public",
                principalTable: "TipoEspecie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicacao_TipoEspecie_tipoEspecie_Id",
                schema: "public",
                table: "Medicacao");

            migrationBuilder.DropIndex(
                name: "IX_Medicacao_tipoEspecie_Id",
                schema: "public",
                table: "Medicacao");

            migrationBuilder.DropColumn(
                name: "tipoEspecie_Id",
                schema: "public",
                table: "Medicacao");
        }
    }
}
