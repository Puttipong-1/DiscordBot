﻿using ArknightApi.Data.DTO.ArknightData;
using ArknightApi.Data.Model;
using ArknightApi.Service;
using ArknightApi.Utility;
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
using Skill = ArknightApi.Data.Model.Skill;

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
                return BadRequest(e.Message);
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
                return BadRequest(e.Message);
            }
        }
        [Route("addinfo")]
        [HttpPost]
        public async Task<ActionResult> AddInfo([FromBody] JsonElement json)
        {
            try
            {
                var p = json.GetProperty("handbookDict");
                var dic = JsonSerializer.Deserialize<Dictionary<string,Data.DTO.ArknightData.CharInfo>>(p.ToString());
                await arknightDataServicecs.AddInfo(dic);
                return Ok();

            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("addword")]
        [HttpPost]
        public async Task<ActionResult> AddCharWord([FromBody]JsonElement json)
        {
            try
            {
                var dic = JsonSerializer.Deserialize<Dictionary<string, CharWordJson>>(json.ToString());
                await arknightDataServicecs.AddWords(dic);
                return Ok();
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }
        [Route("additem")]
        [HttpPost]
        public async Task<ActionResult> AddItem([FromBody] JsonElement json)
        {
            try
            {
                var items = json.GetProperty("items");
                Dictionary<string,ItemDetail> dic = JsonSerializer.Deserialize<Dictionary<string, ItemDetail>>(items.ToString());
                await arknightDataServicecs.AddItem(dic);
                return Ok();
            }catch(Exception e)
            {
                return BadRequest(e.Message);
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
                return BadRequest(e.Message);
            }
        }
        [Route("addskill")]
        [HttpPost]
        public async Task<ActionResult> AddSkill([FromBody] JsonElement json)
        {
            try
            {
                var dic = JsonSerializer.Deserialize<Dictionary<string, SkillJson>>(json.ToString());
                await arknightDataServicecs.AddSkill(dic);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("addtag")]
        [HttpPost]
        public async Task<ActionResult> AddTag([FromBody]JsonElement json)
        {
            try
            {
                var element = json.GetProperty("gachaTags");
                var gacha = JsonSerializer.Deserialize<List<GachaJson>>(element.ToString());
                await arknightDataServicecs.AddTag(gacha);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
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
                return BadRequest(e.Message);
            }
        }
        [Route("addoperatortag")]
        [HttpPost]
        public async Task<ActionResult> AddOperatorTag([FromBody] JsonElement json)
        {
            try
            {
                JsonElement root = json.GetProperty("recruits");
                List<RecruitJson> recruits = JsonSerializer.Deserialize<List<RecruitJson>>(root.ToString());
                await arknightDataServicecs.AddOpTag(recruits);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }
    }
}
