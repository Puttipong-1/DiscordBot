using ArknightApi.Data.DTO.Response;
using ArknightApi.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArknightApi.Controllers
{
    [ApiController]
    [Route("api/item/")]
    public class ItemController : ControllerBase
    {
        private readonly IItemService itemService;
        public ItemController(IItemService _itemService)
        {
            itemService = _itemService;
        }
        [Route("list")]
        [HttpPost]
        public async Task<ActionResult> GetItemList()
        {
            try
            {
                List<Items> items = await itemService.GetItemList();
                return Ok(items);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("name/{name}")]
        [HttpPost]
        public async Task<ActionResult> GetItemDetail(string name)
        {
            try
            {
                ItemResponse response = await itemService.GetItemDetail(name);
                return Ok(response);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
