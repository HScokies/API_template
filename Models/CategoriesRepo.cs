using API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    public class CategoriesRepo : I_CategoriesRepo
    {
        private readonly AppDBcontext appDBcontext;

        public CategoriesRepo(AppDBcontext appDBcontext)
        {
            this.appDBcontext = appDBcontext;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await appDBcontext.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await appDBcontext.Categories.FirstOrDefaultAsync(c => c.CategoryID == id);
        }
    }
}
