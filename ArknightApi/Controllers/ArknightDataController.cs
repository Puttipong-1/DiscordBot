using ArknightApi.Data.DTO.ArknightData;
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
        /// <summary>
        /// Add workshop formula and operator's base buff.
        /// </summary>
        /// <remarks>Data from <a href="https://github.com/Aceship/AN-EN-Tags/blob/master/json/gamedata/en_US/gamedata/excel/building_data.json">here</a> or <a href="https://github.com/Kengxxiao/ArknightsGameData/blob/master/en_US/gamedata/excel/building_data.json">here</a> </remarks>
        /// <param name="json"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Add operator.
        /// </summary>
        /// <remarks>Data from <a href="https://github.com/Kengxxiao/ArknightsGameData/blob/master/en_US/gamedata/excel/character_table.json">here</a> or <a href="https://github.com/Aceship/AN-EN-Tags/blob/master/json/gamedata/en_US/gamedata/excel/character_table.json">here</a> </remarks>
        /// <param name="json"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Add operator's info.
        /// </summary>
        /// <remarks>Data from <a href="https://github.com/Kengxxiao/ArknightsGameData/blob/master/en_US/gamedata/excel/handbook_info_table.json">here</a> or <a href="https://github.com/Aceship/AN-EN-Tags/blob/master/json/gamedata/en_US/gamedata/excel/handbook_info_table.json">here</a> </remarks>
        /// <param name="json"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Add operator's words.
        /// </summary>
        /// <remarks>Data from <a href="https://github.com/Kengxxiao/ArknightsGameData/blob/master/en_US/gamedata/excel/charword_table.json">here</a> or <a href="https://github.com/Aceship/AN-EN-Tags/blob/master/json/gamedata/en_US/gamedata/excel/charword_table.json">here</a> </remarks>
        /// <param name="json"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Add items.
        /// </summary>
        /// <remarks>Data from <a href="https://github.com/Kengxxiao/ArknightsGameData/blob/master/en_US/gamedata/excel/item_table.json">here</a> or <a href="https://github.com/Aceship/AN-EN-Tags/blob/master/json/gamedata/en_US/gamedata/excel/item_table.json">here</a> </remarks>
        /// <param name="json"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Add operator's skins.
        /// </summary>
        /// <remarks>Data from <a href="https://github.com/Kengxxiao/ArknightsGameData/blob/master/en_US/gamedata/excel/skin_table.json">here</a> or <a href="https://github.com/Aceship/AN-EN-Tags/blob/master/json/gamedata/en_US/gamedata/excel/skin_table.json">here</a> </remarks>
        /// <param name="json"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Add operator's skill.
        /// </summary>
        /// <remarks>Data from <a href="https://github.com/Kengxxiao/ArknightsGameData/blob/master/en_US/gamedata/excel/skill_table.json">here</a> or <a href="https://github.com/Aceship/AN-EN-Tags/blob/master/json/gamedata/en_US/gamedata/excel/skill_table.json">here</a> </remarks>
        /// <param name="json"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Add recruit tags.
        /// </summary>
        /// <remarks>Data from <a href="https://github.com/Kengxxiao/ArknightsGameData/blob/master/en_US/gamedata/excel/gacha_table.json">here</a> or <a href="https://github.com/Aceship/AN-EN-Tags/blob/master/json/gamedata/en_US/gamedata/excel/gacha_table.json">here</a> </remarks>
        /// <param name="json"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Add game's tip.
        /// </summary>
        /// <remarks>Data from <a href="https://github.com/Kengxxiao/ArknightsGameData/blob/master/en_US/gamedata/excel/tip_table.json">here</a> or <a href="https://github.com/Aceship/AN-EN-Tags/blob/master/json/gamedata/en_US/gamedata/excel/tip_table.json">here</a> </remarks>
        /// <param name="json"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Add operator's tags.
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
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
                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Add stage.
        /// </summary>
        /// <remarks>Data from <a href="https://github.com/Kengxxiao/ArknightsGameData/blob/master/en_US/gamedata/excel/stage_table.json">here</a> or <a href="https://github.com/Aceship/AN-EN-Tags/blob/master/json/gamedata/en_US/gamedata/excel/stage_table.json">here</a> </remarks>
        /// <param name="json"></param>
        /// <returns></returns>
        [Route("addstage")]
        [HttpPost]
        public async Task<ActionResult> AddStage([FromBody] JsonElement json)
        {
            try
            {
                JsonElement root = json.GetProperty("stages");
                Dictionary<string, StageJson> dic = JsonSerializer.Deserialize<Dictionary<string, StageJson>>(root.ToString());
                await arknightDataServicecs.AddStage(dic);
                return Ok();

            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
