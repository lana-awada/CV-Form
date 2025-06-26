using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace homework5_CV.Migrations
{
    /// <inheritdoc />
    public partial class m2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "url",
                table: "CV",
                newName: "Pdfurl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Pdfurl",
                table: "CV",
                newName: "url");
        }
    }
}
