using Microsoft.EntityFrameworkCore;
using polichousehold.Models;

namespace polichousehold.Data;

public class ShoppingContext : DbContext
{
    public ShoppingContext (DbContextOptions<ShoppingContext> options)
        :base(options)
    {
    }

    public DbSet<ShoppingItem> Items => Set<ShoppingItem>();
}