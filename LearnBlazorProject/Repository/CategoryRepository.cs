using LearnBlazorProject.Data;
using LearnBlazorProject.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace LearnBlazorProject.Repository;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _context;

    public CategoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Category> CreateAsync(Category category)
    {
        await _context.AddAsync(category);
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task<Category> UpdateAsync(Category category)
    {
        var categoryToUpdate = await _context.Categories.FirstOrDefaultAsync(x => x.Id == category.Id);
        if (categoryToUpdate != null)
        {
            categoryToUpdate.Name = category.Name;
            _context.Categories.Update(categoryToUpdate);
            await _context.SaveChangesAsync();
            return categoryToUpdate;
        }

        return category;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
        if (category != null)
        {
            _context.Categories.Remove(category);
            return await _context.SaveChangesAsync() > 0;
        }

        return false;
    }

    public async Task<Category> GetAsync(int id)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
        if (category != null)
        {
            return category;
        }

        return new Category();
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await _context.Categories.ToListAsync();
    }
}