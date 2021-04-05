using ArknightApi.Data.DTO.ArknightData;
using ArknightApi.Data.Model;
using ArknightApi.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace ArknightApi.Controllers
{
    [ApiController]
    [Route("api/arknightdata/")]
    public class ArknightDataController : ControllerBase
    {
        private readonly IArknightDataServicecs arknightDataServicecs;
        public ArknightDataController(IArknightDataServicecs _arknightDataService)
        {
            arknightDataServicecs = _arknightDataService;
        }
        [Route("addbuilding")]
        [HttpPost]
        public async Task<ActionResult> AddBuilding([FromBody] JsonElement json)
        {
            try
            {
                var root = json.GetProperty("workshopFormulas");
                var dic = JsonSerializer.Deserialize<Dictionary<string, Building>>(root.ToString());
                await arknightDataServicecs.AddBuildings(dic);
                await arknightDataServicecs.AddBaseBuff(json);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }
        [Route("addcharacter")]
        [HttpPost]
        public async Task<ActionResult> AddCharacter([FromBody]JsonElement json)
        {
            try
            {
                var dic = JsonSerializer.Deserialize<Dictionary<string, Character>>(json.ToString());
                await arknightDataServicecs.AddOperators(dic);
                return Ok();
            }catch(Exception e)
            {
                return BadRequest(e.ToString());
            }
        }
        [Route("addinfo")]
        [HttpPost]
        public ActionResult AddInfo([FromBody] JsonElement json)
        {
            try
            {
                var p = json.GetProperty("handbookDict");
                var dic = JsonSerializer.Deserialize<Dictionary<string,Data.DTO.ArknightData.CharInfo>>(json.ToString());
                var info = new List<Data.Model.CharInfo>();
                foreach (var item in dic)
                {
                    info.Add(new Data.Model.CharInfo(item.Value));
                }
                return Ok(info);

            }catch(Exception e)
            {
                return BadRequest(e.ToString());
            }
        }
        [Route("addword")]
        [HttpPost]
        public ActionResult<List<CharWordJson>> AddCharWord([FromBody]JsonElement json)
        {
            try
            {
                var dic = JsonSerializer.Deserialize<Dictionary<string, CharWordJson>>(json.ToString());
                List<CharWord> chars = new List<CharWord>();
                foreach (var item in dic)
                {
                    chars.Add(new CharWord(item.Value));
                }
                return Ok();
            }catch(Exception e)
            {
                return BadRequest(e.ToString());
            }
            
        }
        [Route("additem")]
        [HttpPost]
        public async Task<ActionResult> AddItem([FromBody] JsonElement json)
        {
            try
            {
                var items = json.GetProperty("items");
                var dic = JsonSerializer.Deserialize<Dictionary<string, ItemDetail>>(items.ToString());
                await arknightDataServicecs.AddItem(dic);
                return Ok();
            }catch(Exception e)
            {
                return BadRequest(e);
            }
        }
        [Route("addskin")]
        [HttpPost]
        public async Task<ActionResult> AddSkin([FromBody] JsonElement json)
        {
            try
            {
                var items = json.GetProperty("charSkins");
                var dic = JsonSerializer.Deserialize<Dictionary<string, SkinJson>>(items.ToString());
                await arknightDataServicecs.AddSkin(dic);
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest(e.ToString());
            }
        }
        [Route("addtip")]
        [HttpPost]
        public async Task<ActionResult> Addtip([FromBody]RootTip json)
        {
            try
            {
                await arknightDataServicecs.AddTip(json);
                return Ok();
            }catch(Exception e)
            {
                return BadRequest(e.ToString());
            }
        }
    }
}
