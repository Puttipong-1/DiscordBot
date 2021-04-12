using ArknightApi.Data.DTO.Response;
using ArknightApi.Data.Model;
using ArknightApi.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ArknightApi.Controllers
{
    [ApiController]
    [Route("api/operator/")]
    public class OperatorController : ControllerBase
    {
        private readonly IOperatorServcie operatorServcie;
        public OperatorController(IOperatorServcie _operatorService)
        {
            operatorServcie = _operatorService;
        }
        [Route("name/{name}")]
        [HttpPost]
        public async Task<ActionResult> GetOperatorByName(string name)
        {
            try
            {
                OperatorResponse op= await operatorServcie.GetOperatorByName(name);
                return Ok(op);
            }
            catch (Exception e)
            {
               return BadRequest(e.Message);
            }
        }
        [Route("list")]
        [HttpPost]
        public async Task<ActionResult> GetOperatorList()
        {
            try
            {
                var operators = await operatorServcie.GetOperatorList();
                return Ok(operators);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("skin/{name}")]
        [HttpPost]
        public async Task<ActionResult> GetSkinByName(string name)
        {
            try
            {
                SkinResponse op = await operatorServcie.GetSkin(name);
                return Ok(op);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("class/{c}")]
        [HttpPost]
        public async Task<ActionResult> GetOperatorByClass(string c)
        {
            try
            {
                List<Operators> op = await operatorServcie.GetOperatorsByClass(c);
                return Ok(op);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("rarity/{r}")]
        [HttpPost]
        public async Task<ActionResult> GetOperatorsByRarity(int r)
        {
            try
            {
                List<Operators> operators= await operatorServcie.GetOperatorsByRarity(r);
                return Ok(operators);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("words/{name}")]
        [HttpPost]
        public async Task<ActionResult> GetWord(string name)
        {
            try
            {
                WordResponse word = await operatorServcie.GetWords(name);
                return Ok(word);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
