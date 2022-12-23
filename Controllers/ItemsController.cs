using API.Models;
using API.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly I_ItemsRepo itemsRepo;

        public ItemsController(I_ItemsRepo itemsRepo)
        {
            this.itemsRepo = itemsRepo;
        }
        [HttpGet]
        public async Task<ActionResult> GetItems()
        {
            try
            {
                return Ok(await itemsRepo.GetItems());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Err retrieving data from DB; {ex}");
            }
        }
        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<Item>>> Search(string ItemName)
        {
            try
            {
                var res = await itemsRepo.Search(ItemName);
                if (res.Any())
                {
                    return Ok(res);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Err retrieving data from DB; {ex}");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Item>> GetItem(int id)
        {
            try
            {
                var res = await itemsRepo.GetItem(id);
                if (res == null)
                {
                    return NotFound();
                }
                return res;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Err retrieving data from DB; {ex}");
            }
        }
        [HttpPost]
        public async Task<ActionResult<Item>> AddItem(Item item)
        {
            try
            {
                if (item == null)
                {
                    return BadRequest();
                }
                var NewItem = await itemsRepo.AddItem(item);
                return CreatedAtAction(nameof(GetItem), new { id = NewItem.ItemID }, NewItem);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Err creating new item; {ex}");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Item>> UpdateItem(int id, Item item)
        {
            try
            {
                if (id != item.ItemID)
                    return BadRequest();
                var Target = await itemsRepo.GetItem(id);
                if (Target == null)
                {
                    return NotFound($"Item id={id} NOT FOUND");
                }
                return await itemsRepo.UpdateItem(item);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Err updating record; {ex}");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var Target = await itemsRepo.GetItem(id);
                if (Target == null)
                {
                    return NotFound($"Item id={id} NOT FOUND");
                }
                await itemsRepo.DeleteItem(id);
                return Ok($"Item id={id} Succesefully deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Err deleting record; {ex}");
            }
        }

    }
}
