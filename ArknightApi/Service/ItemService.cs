using ArknightApi.Data;
using ArknightApi.Data.DTO.Response;
using ArknightApi.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArknightApi.Service
{
    public class ItemService : IItemService
    {
        private readonly ApplicationDbContext applicationDbContext;
        public ItemService(ApplicationDbContext _applicationDbContext)
        {
            applicationDbContext = _applicationDbContext;
        }
        public async Task<ItemResponse> GetItemDetail(string name)
        {
            try
            {
                Item item = await applicationDbContext.Items
                    .Where(i => i.Name.ToLower().Contains(name.ToLower()))
                    .Include(i => i.Formula)
                    .ThenInclude(f => f.FormulaCosts)
                    .ThenInclude(f => f.Item)
                    .SingleAsync();
                return new ItemResponse(item);

            }catch(Exception e)
            {
                throw e;
            }
        }

        public async Task<List<Items>> GetItemList()
        {
            try
            {
                List<Item> item = await applicationDbContext.Items
                    .Select(i => new Item()
                    {
                        ItemId = i.ItemId,
                        Name = i.Name
                    })
                    .ToListAsync();
                List<Items> items = new List<Items>();
                foreach(Item i in item)
                {
                    items.Add(new Items(i));
                }
                return items;
            }catch(Exception e)
            {
                throw e;
            }
        }
    }
}
