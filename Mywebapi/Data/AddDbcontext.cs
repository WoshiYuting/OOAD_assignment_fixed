
using Microsoft.EntityFrameworkCore;
using Mywebapi.Models;
using System.Security.Cryptography.X509Certificates;

namespace Mywebapi.Data.AddDbcontext
{
    public class AddDbcontext : DbContext
    {
        public AddDbcontext(DbContextOptions options) : base(options) { }
        public DbSet<Book>Books { get; set; }
        public DbSet<Librarian>Librarians { get; set; }
        public DbSet<Reader>Readers { get; set; }
        public DbSet<Category> categories { get; set; }

    }
}
