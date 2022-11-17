using Microsoft.EntityFrameworkCore;
using ModelToDatabase.Models;

namespace ModelToDatabase.Data
{
    public class MyDatabaseContext : DbContext
    {
        public MyDatabaseContext(DbContextOptions<MyDatabaseContext> options) : base(options)
        {

        }

        public DbSet<VideoGames> VideoGames { get; set; }
    }
}
