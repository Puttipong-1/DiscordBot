using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ArknightApi.Data.DTO.ArknightData;

namespace ArknightApi.Service
{
    public interface IArknightDataServicecs
    {
        Task AddBuildings(Dictionary<string, Building> dic);
        Task AddWords(Dictionary<string, CharWordJson> dic);
        Task AddItem(Dictionary<string, ItemDetail> dic);
        Task AddTip(RootTip dic);
        Task AddSkin(Dictionary<string, SkinJson> dic);
        Task AddOperators(Dictionary<string, Character> dic);
        Task AddInfo(Dictionary<string, CharInfo> dic);
        Task AddBaseBuff(JsonElement json);
    }
}
