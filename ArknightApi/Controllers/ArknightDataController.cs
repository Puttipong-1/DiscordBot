using ArknightApi.Data.DTO.ArknightData;
using ArknightApi.Data.Model;
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
        [Route("addbuilding")]
        [HttpPost]
        public ActionResult<List<Operator>> AddBuilding([FromBody] JsonElement json)
        {
            try
            {
                var root = json.GetProperty("workshopFormulas");
                var dic = JsonSerializer.Deserialize<Dictionary<string, Building>>(root.ToString());
                var formulas = new List<Formula>();
                foreach (var item in dic)
                {
                    var f = new Formula(item.Value);
                    formulas.Add(f);
                }
                return Ok(formulas);
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }
        [Route("addcharacter")]
        [HttpPost]
        public ActionResult<List<Operator>> AddCharacter([FromBody]JsonElement json)
        {
            try
            {
                var root = JsonSerializer.Deserialize<Dictionary<string, Character>>(json.ToString());
                var ops = new List<Operator>();
                foreach (var item in root)
                {
                    var op = new Operator(item.Key, item.Value);
                    ops.Add(op);
                }
                return Ok(ops);
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
                var root = JsonSerializer.Deserialize<Dictionary<string, CharWordJson>>(json.ToString());
                List<CharWord> chars = new List<CharWord>();
                foreach (var item in root)
                {
                    chars.Add(new CharWord(item.Value));
                }
                return Ok(chars);
            }catch(Exception e)
            {
                return BadRequest(e.ToString());
            }
            
        }
        [Route("additem")]
        [HttpPost]
        public ActionResult<List<Item>> AddItem([FromBody] JsonElement json)
        {
            try
            {
                var items = json.GetProperty("items");
                var root = JsonSerializer.Deserialize<Dictionary<string, ItemDetail>>(items.ToString());
                List<Item> itemList = new List<Item>();
                foreach (var dic in root)
                {
                    if (int.TryParse(dic.Value.ItemId, out _) && dic.Value.ItemType == "MATERIAL") itemList.Add(new Item(dic.Value));
                }
                return Ok(itemList);
            }catch(Exception e)
            {
                return BadRequest(e);
            }
        }
        [Route("addskin")]
        [HttpPost]
        public ActionResult<List<SkinJson>> AddSkin([FromBody] JsonElement json)
        {
            try
            {
                var items = json.GetProperty("charSkins");
                var root = JsonSerializer.Deserialize<Dictionary<string, SkinJson>>(items.ToString());
                List<Skin> skins = new List<Skin>();
                foreach (var item in root)
                {
                    skins.Add(new Skin(item.Value));
                }
                return Ok(skins);
            }
            catch(Exception e)
            {
                return BadRequest(e.ToString());
            }
        }
        [Route("addtip")]
        [HttpPost]
        public ActionResult<List<Data.Model.Tip>> Addtip([FromBody]RootTip json)
        {
            try
            {
                List<Data.Model.Tip> tips = new List<Data.Model.Tip>();
                foreach (Data.DTO.ArknightData.Tip t in json.Tips)
                {
                    tips.Add(new Data.Model.Tip(t));
                }
                foreach (Data.DTO.ArknightData.WorldViewTip t in json.WorldViewTips)
                {
                    tips.Add(new Data.Model.Tip(t));
                }
                return Ok(tips);
            }catch(Exception e)
            {
                return BadRequest(e.ToString());
            }
        }
    }
}
