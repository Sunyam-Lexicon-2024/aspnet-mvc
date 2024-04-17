using Microsoft.EntityFrameworkCore;
using MVC.Web.Models;

namespace MVC.Web.Data
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
