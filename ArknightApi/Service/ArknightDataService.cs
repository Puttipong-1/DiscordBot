using ArknightApi.Data;
using ArknightApi.Data.DTO.ArknightData;
using ArknightApi.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ArknightApi.Service
{
    public class ArknightDataService:IArknightDataServicecs
    {
        private readonly ApplicationDbContext applicationDb;
        public ArknightDataService(ApplicationDbContext _applicationDb)
        {
            applicationDb = _applicationDb;
        }

        public async Task AddBaseBuff(JsonElement json)
        {
            var chars = json.GetProperty("chars");
            var dic2 = JsonSerializer.Deserialize<Dictionary<string, CharBuff>>(chars.ToString());
            JsonElement b = json.GetProperty("buffs");
            var buffs = JsonSerializer.Deserialize<Dictionary<string, Data.DTO.ArknightData.BaseBuff>>(b.ToString());
            List<Data.Model.BaseBuff> baseBuffs = new List<Data.Model.BaseBuff>();
            foreach (var item in dic2)
            {
                CharBuff charBuff = item.Value;
                if (charBuff.BuffChar != null)
                {
                    foreach (BuffChar buffChar in charBuff.BuffChar)
                    {
                        if (buffChar.BuffData != null)
                        {
                            foreach (BuffData buffData in buffChar.BuffData)
                            {
                                Data.DTO.ArknightData.BaseBuff bb = buffs[buffData.BuffId];
                                baseBuffs.Add(new Data.Model.BaseBuff(bb, charBuff));
                            }
                        }
                    }
                }
            }
            await applicationDb.AddRangeAsync(baseBuffs);
            await applicationDb.SaveChangesAsync();
        }

        public async Task AddBuildings(Dictionary<string, Building> dic)
        {
            try
            {
                var formulas = new List<Formula>();
                foreach (var item in dic)
                {
                    var f = new Formula(item.Value);
                    formulas.Add(f);
                }
                await applicationDb.AddRangeAsync(formulas);
                await applicationDb.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task  AddInfo(Dictionary<string, Data.DTO.ArknightData.CharInfo> dic)
        {
            try
            {
                var info = new List<Data.Model.CharInfo>();
                foreach(var item in dic)
                {
                    info.Add(new Data.Model.CharInfo(item.Value));
                }
                await applicationDb.AddRangeAsync(info);
                await applicationDb.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task AddItem(Dictionary<string, ItemDetail> dic)
        {
            try
            {
                List<Item> itemList = new List<Item>();
                foreach (var item in dic)
                {
                    if (int.TryParse(item.Value.ItemId, out _) && item.Value.ItemType == "MATERIAL") itemList.Add(new Item(item.Value));
                }
                await applicationDb.AddRangeAsync(itemList);
                await applicationDb.SaveChangesAsync();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public async Task AddOperators(Dictionary<string, Character> dic)
        {
            try
            {
                var ops = new List<Operator>();
                foreach (var item in dic)
                {
                    var op = new Operator(item.Key, item.Value);
                    ops.Add(op);
                }
                await applicationDb.AddRangeAsync(ops);
                await applicationDb.SaveChangesAsync();
            }catch(Exception e)
            {
                throw e;
            }
        }

        public async Task AddSkin(Dictionary<string, SkinJson> dic)
        {
            try
            {
                List<Skin> skins = new List<Skin>();
                foreach (var item in dic)
                {
                    skins.Add(new Skin(item.Value));
                }
                await applicationDb.AddRangeAsync(skins);
                await applicationDb.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task AddTip(RootTip root)
        {
            try
            {
                List<Data.Model.Tip> tips = new List<Data.Model.Tip>();
                foreach (Data.DTO.ArknightData.Tip t in root.Tips)
                {
                    tips.Add(new Data.Model.Tip(t));
                }
                foreach (Data.DTO.ArknightData.WorldViewTip t in root.WorldViewTips)
                {
                    tips.Add(new Data.Model.Tip(t));
                }
                await applicationDb.AddRangeAsync(tips);
                await applicationDb.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task AddWords(Dictionary<string, CharWordJson> dic)
        {
            try
            {
                List<CharWord> chars = new List<CharWord>();
                foreach (var item in dic)
                {
                    chars.Add(new CharWord(item.Value));
                }
                await applicationDb.AddRangeAsync(chars);
                await applicationDb.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
