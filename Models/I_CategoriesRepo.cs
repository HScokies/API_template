using API.Models.Entities;

namespace API.Models
{
    public interface I_CategoriesRepo
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategoryById(int id);
    }
}
