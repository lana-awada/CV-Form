using Microsoft.EntityFrameworkCore;
using homework5_CV.Models.CV;
using homework5_CV.Models.User;
namespace homework5_CV.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<DataModel> CV { get; set; }
        public DbSet<DataModelUser> User { get; set; }

        //seed Data for Admin
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DataModelUser>().HasData(
                new DataModelUser
                { 
                    IdUser=1,
                    Email="awadalana1@gmail.com",
                    Password="12345",
                    Role="Admin"
                }
    
                );
        }
    }
}
