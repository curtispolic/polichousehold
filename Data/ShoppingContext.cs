using Microsoft.EntityFrameworkCore;
using polichousehold.Models;

namespace polichousehold.Data;

/*
The context just provides the options and connections to the database tables.
*/
public class ShoppingContext : DbContext
{
    public ShoppingContext (DbContextOptions<ShoppingContext> options)
        :base(options)
    {
    }

    public DbSet<ShoppingItem> Items => Set<ShoppingItem>();
}