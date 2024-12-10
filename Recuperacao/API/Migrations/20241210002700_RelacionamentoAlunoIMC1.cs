using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class RelacionamentoAlunoIMC1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IMC_Alunos_Alunoid",
                table: "IMC");

            migrationBuilder.AlterColumn<int>(
                name: "Alunoid",
                table: "IMC",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_IMC_Alunos_Alunoid",
                table: "IMC",
                column: "Alunoid",
                principalTable: "Alunos",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IMC_Alunos_Alunoid",
                table: "IMC");

            migrationBuilder.AlterColumn<int>(
                name: "Alunoid",
                table: "IMC",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_IMC_Alunos_Alunoid",
                table: "IMC",
                column: "Alunoid",
                principalTable: "Alunos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
