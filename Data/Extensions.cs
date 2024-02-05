namespace polichousehold.Data;

public static class Extensions
{
    // Makes sure the DB exists, and will seed it with a test item if it is empty afterwards
    public static void CreateDbIfNotExists(this IHost host)
    {
        {
            var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<ShoppingContext>();
            context.Database.EnsureCreated();
            DbInitializer.Initialize(context);
        }
    }
}