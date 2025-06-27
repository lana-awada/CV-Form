using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace homework5_CV.Migrations
{
    /// <inheritdoc />
    public partial class m8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "IdUser",
                keyValue: 1,
                column: "Email",
                value: "awadalana1@gmail.com");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "IdUser",
                keyValue: 1,
                column: "Email",
                value: "alisweidan1@gmail.com");
        }
    }
}
