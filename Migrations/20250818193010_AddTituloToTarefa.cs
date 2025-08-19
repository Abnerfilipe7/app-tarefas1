using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app_tarefas1.Migrations
{
    /// <inheritdoc />
    public partial class AddTituloToTarefa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Titulo",
                table: "Tarefa",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Titulo",
                table: "Tarefa");
        }
    }
}
