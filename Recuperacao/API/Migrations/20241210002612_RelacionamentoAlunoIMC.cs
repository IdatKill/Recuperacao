using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class RelacionamentoAlunoIMC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Alunoid",
                table: "IMC",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_IMC_Alunoid",
                table: "IMC",
                column: "Alunoid");

            migrationBuilder.AddForeignKey(
                name: "FK_IMC_Alunos_Alunoid",
                table: "IMC",
                column: "Alunoid",
                principalTable: "Alunos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IMC_Alunos_Alunoid",
                table: "IMC");

            migrationBuilder.DropIndex(
                name: "IX_IMC_Alunoid",
                table: "IMC");

            migrationBuilder.DropColumn(
                name: "Alunoid",
                table: "IMC");
        }
    }
}
