using Microsoft.EntityFrameworkCore;
using mvc_crud_with_dotnet_core.Models.Domain;

namespace mvc_crud_with_dotnet_core.Data
{
	public class MVCDemoDbContext : DbContext
	{
		public MVCDemoDbContext(DbContextOptions options) : base(options)
		{
		}

        public DbSet<Employee> Employees { get; set; }
    }
}
