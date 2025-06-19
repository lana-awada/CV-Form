using Microsoft.EntityFrameworkCore;
using homework5_CV.Models;
namespace homework5_CV.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<DataModel> CV { get; set; }
    }
}
