using Microsoft.EntityFrameworkCore;

namespace Azure_HW_VVP.Model
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<VVP> VVPs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                 .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                 .AddJsonFile("appsettings.json").Build();

            string connectionString = configuration.GetConnectionString("CloudDbConnection");

            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}
