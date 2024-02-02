using polichousehold.Models;
using polichousehold.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace polichousehold.Services;

public class ShoppingService
{
    private readonly ShoppingContext _context;

    public ShoppingService(ShoppingContext context)
    {
        _context = context;
    }

    public IEnumerable<ShoppingItem> GetAll()
    {
        return _context.Items
            .AsNoTracking()
            .ToList();
    }

    public ShoppingItem? GetById(int id)
    {
        return _context.Items
            .AsNoTracking()
            .SingleOrDefault(i => i.ID == id);
    }

    public ShoppingItem Create(ShoppingItem newItem)
    {
        _context.Items.Add(newItem);
        _context.SaveChanges();

        return newItem;
    }

    public void DeleteById(int id)
    {
        var delItem = _context.Items.Find(id);
        if (delItem is not null)
        {
            _context.Items.Remove(delItem);
            _context.SaveChanges();
        }        
    }

    public void UpdateQuantity(int id, int newQuant)
    {
        var item = _context.Items.Find(id);

        if (item is null || newQuant <= 0)
        {
            throw new InvalidOperationException("Invalid item or quantity");
        }

        item.Amount = newQuant;

        _context.SaveChanges();
    }

    public void UpdateName(int id, string newName)
    {
        var item = _context.Items.Find(id);

        if (item is null || newName.IsNullOrEmpty())
        {
            throw new InvalidOperationException("Invalid item or name");
        }

        item.Name = newName;

        _context.SaveChanges();
    }
}