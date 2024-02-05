using polichousehold.Models;

namespace polichousehold.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ShoppingContext context)
        {
            if (context.Items.Any())
            {
                return;
            }

            var testItem = new ShoppingItem{ Name = "Test Item", Amount = 3};

            context.Items.Add(testItem);
            context.SaveChanges();
        }
    }
}

