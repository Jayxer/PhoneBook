using Microsoft.EntityFrameworkCore;
namespace PhoneBook.Models
{
    public class PhoneBookContext : DbContext
    {
        public PhoneBookContext(DbContextOptions<PhoneBookContext> options)
            : base(options)
        {
        }

        public DbSet<Entry> Entries { get; set; }
    }
}