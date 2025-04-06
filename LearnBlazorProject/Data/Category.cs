using System.ComponentModel.DataAnnotations;

namespace LearnBlazorProject.Data;

public class Category
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }
}