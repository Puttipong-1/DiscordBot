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

        public Task AddBaseBuff(JsonElement json)
        {
            throw new NotImplementedException();
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
