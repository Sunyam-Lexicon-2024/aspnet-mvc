using Microsoft.EntityFrameworkCore;
using Storage.Models;

namespace Storage.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext (DbContextOptions<ProductContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Product { get; set; } = default!;
    }
}
