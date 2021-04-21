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
        /// <summary>
        /// Get all item in db.
        /// </summary>
        /// <response code="200">Found items</response>
        /// <response code="400">Not found items</response>
        [Route("list")]
        [HttpPost]
        [ProducesResponseType(typeof(List<string>),200)]
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
        /// <summary>
        /// Get a item by name;
        /// </summary>
        /// <param name="name">Item's name</param>
        /// <response code="200">Found item</response>
        /// <response code="400">Not found item</response>
        [Route("name/{name}")]
        [HttpPost]
        [ProducesResponseType(typeof(ItemResponse),200)]
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
