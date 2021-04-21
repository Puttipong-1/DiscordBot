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
        /// <summary>
        /// Get a operator by name.
        /// </summary>
        /// <param name="name">Operator's name.</param>
        /// <response code="200">Found operator</response>
        /// <response code="400">Not found operator</response>
        [Route("name/{name}")]
        [HttpPost]
        [ProducesResponseType(typeof(OperatorResponse),200)]
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
        /// <summary>
        /// Get all operators.
        /// </summary>
        /// <response code="200">Found all operators</response>
        /// <response code="400">Not found</response>
        [Route("list")]
        [HttpPost]
        [ProducesResponseType(typeof(Operators), 200)]
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
        /// <summary>
        /// Get all operator's skins.
        /// </summary>
        /// <param name="name">Operator's name</param>
        /// <returns></returns>
        [Route("skin/{name}")]
        [HttpPost]
        [ProducesResponseType(typeof(SkinResponse),200)]
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
        }/// <summary>
        /// Get operators by class
        /// </summary>
        /// <param name="c">Class's name</param>
        /// <returns></returns>
        [Route("class/{c}")]
        [HttpPost]
        [ProducesResponseType(typeof(List<Operators>),200)]
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
        /// <summary>
        /// Get operators by rarity
        /// </summary>
        /// <param name="r">Rarity</param>
        /// <returns></returns>
        [Route("rarity/{r}")]
        [HttpPost]
        [ProducesResponseType(typeof(List<Operators>), 200)]
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
        /// <summary>
        /// Get operator's voice lines.
        /// </summary>
        /// <param name="name">Operator's name</param>
        /// <returns></returns>
        [Route("word/{name}")]
        [HttpPost]
        [ProducesResponseType(typeof(WordResponse),200)]
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
        /// <summary>
        /// Get operator's skills.
        /// </summary>
        /// <param name="name">Operator's name</param>
        /// <returns></returns>
        [Route("skill/{name}")]
        [HttpPost]
        [ProducesResponseType(typeof(SkillResponse),200)]
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
        /// <summary>
        /// Get operator's profile.
        /// </summary>
        /// <param name="name">Operator's name</param>
        /// <returns></returns>
        [Route("profile/{name}")]
        [HttpPost]
        [ProducesResponseType(typeof(ProfileResponse),200)]
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
        /// <summary>
        /// Get operator's base buff.
        /// </summary>
        /// <param name="name">Operator's name</param>
        /// <returns></returns>
        [Route("buff/{name}")]
        [HttpPost]
        [ProducesResponseType(typeof(BuffResponse),200)]
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
    }
}
