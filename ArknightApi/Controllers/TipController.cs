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
    [Route("api/tip/")]
    public class TipController : ControllerBase
    {
        private readonly ITipService tipService;
        public TipController(ITipService _tipService)
        {
            tipService = _tipService;
        }
        [Route("list")]
        [HttpPost]
        public async Task<ActionResult> GetTipCategory()
        {
            try
            {
                List<string> categories=await tipService.GetTipCatalog();
                return Ok(categories);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("category/{category}")]
        [HttpPost]
        public async Task<ActionResult> GetTipByCategory(string category)
        {
            try
            {
                TipResponse res = await tipService.GetTipByCatalog(category);
                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
