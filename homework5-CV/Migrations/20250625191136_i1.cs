using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace homework5_CV.Migrations
{
    /// <inheritdoc />
    public partial class i1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "CV");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "CV",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
