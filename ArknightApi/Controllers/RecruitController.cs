using ArknightApi.Data.DTO;
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
    [Route("api/recruit/")]
    public class RecruitController : ControllerBase
    {
        private readonly IRecruitService recruitService;
        public RecruitController(IRecruitService _recruitService)
        {
            recruitService = _recruitService;
        }
        /// <summary>
        /// Get possible operator tag Combinations.
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        [Route("recruit")]
        [HttpPost]
        [ProducesResponseType(typeof(Dictionary<string,List<string>>),200)]
        public async Task<ActionResult> GetResult([FromBody] TagJson json)
        {
            try
            {
                if (json.Tags is null) return BadRequest("Please enter one or more tags.");
                else if (json.Tags.Count > 6) return BadRequest("Plase enter no more than 6 tags");
                else
                {
                    Dictionary<string, List<string>> dic = await recruitService.GetOperatorByTag(json.Tags);
                    if (dic.Count == 0) return NotFound();
                    return Ok(dic);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Get all tags.
        /// </summary>
        /// <returns></returns>
        [Route("tags")]
        [HttpPost]
        [ProducesResponseType(typeof(List<string>),200)]
        public async Task<ActionResult> GetTags()
        {
            try
            {
                List<string> tags = await recruitService.GetTags();
                return Ok(tags);
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Get all possible recruit operators!
        /// </summary>
        /// <returns></returns>
        [Route("list")]
        [HttpPost]
        [ProducesResponseType(typeof(List<Operators>),200)]
        public async Task<ActionResult> GetRecruitOperators()
        {
            try
            {
                List<Operators> operators = await recruitService.GetRecruitOperators();
                return Ok(operators);

            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Get operator's recruit tags.
        /// </summary>
        /// <param name="name">Operator's name</param>
        /// <returns></returns>
        [Route("name/{name}")]
        [HttpPost]
        [ProducesResponseType(typeof(RecruitResponse),200)]
        public async Task<ActionResult> GetOperatorsTag(string name)
        {
            try
            {
                RecruitResponse res = await recruitService.GetOperatorTags(name);
                return Ok(res);
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
