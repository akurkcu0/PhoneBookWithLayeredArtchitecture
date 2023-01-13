using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.Context
{
    public class PhoneBookDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=PhoneBookDb;Trusted_Connection=true;");
        }
        public DbSet<PhoneBook> phoneBooks { get; set; }
        public DbSet<ContactInformation> contactInformations { get; set; }
    }
}
