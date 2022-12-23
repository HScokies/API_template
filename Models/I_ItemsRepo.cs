using API.Models.Entities;

namespace API.Models
{
    public interface I_ItemsRepo
    {
        Task<IEnumerable<Item>> Search(string ItemName);
        Task<IEnumerable<Item>> GetItems();

        Task<Item> AddItem(Item item);
        Task<Item> UpdateItem(Item item);
        Task DeleteItem(int ItemID);
        Task<Item> GetItem(int ItemID);
    }
}
