using polichousehold.Models;
using polichousehold.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace polichousehold.Services;

/*
The service provides integration to the context and allows the commands to be simplified.
This is where I'd keep all the logic for how I plan to interact with the context
Also stops me from manually typing context.SaveChanges() a million times
*/

public class ShoppingService
{
    private readonly ShoppingContext _context;

    public ShoppingService(ShoppingContext context)
    {
        _context = context;
    }

    public List<ShoppingItem> GetAll()
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

    public void Update(int id, string newName, int newQuant)
    {
        UpdateQuantity(id, newQuant);
        UpdateName(id, newName);
        // Yes I know this saves changes twice and is time and access inefficient
        // But at the moment I am being my time efficient
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

    public void UpdateImage(int id, string imageName)
    {
        var item = _context.Items.Find(id);

        if (item is null || imageName.IsNullOrEmpty())
        {
            throw new InvalidOperationException("Invalid item or image");
        }

        item.ImagePath = imageName;

        _context.SaveChanges();
    }
}