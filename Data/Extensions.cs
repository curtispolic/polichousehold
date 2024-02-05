namespace polichousehold.Data;

public static class Extensions
{
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