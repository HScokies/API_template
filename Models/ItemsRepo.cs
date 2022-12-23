using API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    public class ItemsRepo : I_ItemsRepo
    {
        private readonly AppDBcontext appDBcontext;

        public ItemsRepo(AppDBcontext appDBcontext)
        {
            this.appDBcontext = appDBcontext;
        }

        public async Task<Item> AddItem(Item item)
        {
            item.Category.CategoryID = item.CategoryID;
            var res = await appDBcontext.Items.AddAsync(item);
            await appDBcontext.SaveChangesAsync();
            return res.Entity;
        }

        public async Task DeleteItem(int ItemID)
        {
            var res = await appDBcontext.Items.FirstOrDefaultAsync(e => e.ItemID == ItemID);
            if (res != null)
            {
                appDBcontext.Items.Remove(res);
                await appDBcontext.SaveChangesAsync();
            }

        }

        public async Task<Item> GetItem(int ItemID)//
        {
            return await appDBcontext.Items.Include(i => i.Category).FirstOrDefaultAsync(i => i.ItemID == ItemID);
        }

        public async Task<IEnumerable<Item>> GetItems()
        {
            return await appDBcontext.Items.Include(i => i.Category).ToListAsync();
        }

        public async Task<IEnumerable<Item>> Search(string ItemName)
        {
            IQueryable<Item> query = appDBcontext.Items;
            if (!string.IsNullOrEmpty(ItemName))
            {
                query = query.Where(e => e.ItemName.Contains(ItemName)).Include(i => i.Category);
            }
            return await query.ToListAsync();
        }

        public async Task<Item> UpdateItem(Item item)
        {
            var res = await appDBcontext.Items.FirstOrDefaultAsync(e => e.ItemID == item.ItemID);
            if (res != null )
            {
                res.ItemName = item.ItemName;
                res.ItemPrice = item.ItemPrice;
                res.CategoryID= item.CategoryID;

                await appDBcontext.SaveChangesAsync();
                return res;
            }
            return null;
        }
    }
}
