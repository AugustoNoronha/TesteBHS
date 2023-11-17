using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesteTecnicoBHS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatecollumnname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Produtos",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Produtos",
                newName: "Nome");
        }
    }
}
