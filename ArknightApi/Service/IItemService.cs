using ArknightApi.Data.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArknightApi.Service
{
    public interface IItemService
    {
        Task<List<Items>> GetItemList();
        Task<ItemResponse> GetItemDetail(string name);
    }
}
