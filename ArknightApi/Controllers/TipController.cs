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
        /// <summary>
        /// Get all tip category
        /// </summary>
        /// <returns></returns>
        [Route("category/list")]
        [HttpPost]
        [ProducesResponseType(typeof(List<string>),200)]
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
        /// <summary>
        /// Get all tip by category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [Route("category/{category}")]
        [HttpPost]
        [ProducesResponseType(typeof(TipResponse),200)]
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
        /// <summary>
        /// Get all tips
        /// </summary>
        /// <returns></returns>
        [Route("list")]
        [HttpPost]
        [ProducesResponseType(typeof(Dictionary<string,List<ArknightApi.Data.Model.Tip>>),200)]
        public async Task<ActionResult> GetAllTip()
        {
            try
            {
                var dic=await tipService.GetAllTips();
                if (dic is null || dic.Count == 0) return NotFound();
                return Ok(dic);
                
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
