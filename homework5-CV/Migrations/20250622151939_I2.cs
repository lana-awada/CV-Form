using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace homework5_CV.Migrations
{
    /// <inheritdoc />
    public partial class I2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "IdUser", "Email", "Password" },
                values: new object[] { 1, "alisweidan1@gmail.com", "12345" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "IdUser",
                keyValue: 1);
        }
    }
}
