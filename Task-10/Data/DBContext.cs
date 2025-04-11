using Microsoft.EntityFrameworkCore;
using Task_10.Models;

namespace Task_10.Data
{
    public class DBContext: DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        { 
        }
    }
}
