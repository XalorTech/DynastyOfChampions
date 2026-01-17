using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DynastyOfChampions.Foundation.Data.Persistence.Context
{
	public class DynastyDbContextFactory : IDesignTimeDbContextFactory<DynastyDbContext>
	{
		public DynastyDbContext CreateDbContext(string[] args)
		{
			// Build configuration from the current directory
			var config = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json", optional: true)
				.AddJsonFile("appsettings.Development.json", optional: true)
				.AddUserSecrets<DynastyDbContextFactory>(optional: true)
				.AddEnvironmentVariables()
				.Build();

			var connectionString = config.GetConnectionString("DynastyDatabase");

			var optionsBuilder = new DbContextOptionsBuilder<DynastyDbContext>();
			optionsBuilder.UseSqlServer(connectionString);

			return new DynastyDbContext(optionsBuilder.Options);
		}
	}
}