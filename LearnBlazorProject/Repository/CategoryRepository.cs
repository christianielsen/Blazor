using LearnBlazorProject.Data;
using LearnBlazorProject.Repository.IRepository;

namespace LearnBlazorProject.Repository;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _context;

    public CategoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Category Create(Category category)
    {
        _context.Add(category);
        _context.SaveChanges();
        return category;
    }

    public Category Update(Category category)
    {
        var categoryToUpdate = _context.Categories.SingleOrDefault(x => x.Id == category.Id);
        if (categoryToUpdate != null)
        {
            categoryToUpdate.Name = category.Name;
            _context.Categories.Update(categoryToUpdate);
            _context.SaveChanges();
            return categoryToUpdate;
        }

        return category;
    } 

    public bool Delete(int id)
    {
        var category = _context.Categories.FirstOrDefault(x => x.Id == id);
        if (category != null)
        {
            _context.Categories.Remove(category);
            return _context.SaveChanges() > 0;
        }

        return false;
    }

    public Category Get(int id)
    {
        var category = _context.Categories.FirstOrDefault(x => x.Id == id);
        if (category != null)
        {
            return category;
        }

        return new Category();
    }

    public IEnumerable<Category> GetAll()
    {
        return _context.Categories.ToList();
    }
}