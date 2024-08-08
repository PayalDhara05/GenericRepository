using Microsoft.EntityFrameworkCore;
using GenericRepositoryPattern.Models;

namespace GenericRepositoryPattern.AppCode
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options): base(options)
        {

        }

        public DbSet<BookModel> Books { get; set; }
        public DbSet<AuthorModel> Authors { get; set; }
        public DbSet<OrderModel> Orders { get; set; }
    }
}
