using Microsoft.EntityFrameworkCore;

namespace polichousehold.Models;

public class ShoppingItem
{
    public string? Name { get; set; }
    public int? Amount {get; set; }
    public int ID {get; set; }
}