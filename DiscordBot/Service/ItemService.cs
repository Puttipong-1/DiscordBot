using DiscordBot.Model.Response.Item;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Service
{
    class ItemService
    {
        private readonly ApiService api;
        public ItemService(ApiService _api)
        {
            api = _api;
        }
        public async Task<List<Item>> GetItemList()
        {
            try
            {
                return await api.PostAsync<List<Item>>("item/list", null,null);
            }catch(Exception e)
            {
                throw e;
            }
        }
        public async Task<ItemDetail> GetItemDetail(string name)
        {
            try
            {
                return await api.PostAsync<ItemDetail>("item/name/" + name, null, null);
            }catch(Exception e)
            {
                throw e;
            }
        }
    }
}
