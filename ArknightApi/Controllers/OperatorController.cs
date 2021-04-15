using ArknightApi.Data.DTO;
using ArknightApi.Data.DTO.Response;
using ArknightApi.Data.Model;
using ArknightApi.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
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
        [Route("word/{name}")]
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
        [Route("skill/{name}")]
        [HttpPost]
        public async Task<ActionResult> GetSkill(string name)
        {
            try
            {
                SkillResponse skill = await operatorServcie.GetOperatorSkill(name);
                return Ok(skill);
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("profile/{name}")]
        [HttpPost]
        public async Task<ActionResult> GetProfile(string name)
        {
            try
            {
                ProfileResponse profile = await operatorServcie.GetOperatorProfile(name);
                return Ok(profile);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("buff/{name}")]
        [HttpPost]
        public async Task<ActionResult> GetBuff(string name)
        {
            try
            {
                BuffResponse buff = await operatorServcie.GetOperatorBuff(name);
                return Ok(buff);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("recruit")]
        [HttpPost]
        public async Task<ActionResult> GetResult([FromBody]TagJson json)
        {
            try
            {
                if (json.Tags is null) return BadRequest();
                else
                {
                    Dictionary<string,List<string>> dic = await operatorServcie.GetOperatorByTag(json.Tags);
                    if (dic.Count == 0) return NotFound();
                    return Ok(dic);
                }
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
