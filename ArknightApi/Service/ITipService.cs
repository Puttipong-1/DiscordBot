using ArknightApi.Data.DTO.Response;
using ArknightApi.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArknightApi.Service
{
    public interface ITipService
    {
        Task<List<string>> GetTipCatalog();
        Task<TipResponse> GetTipByCatalog(string catalog);
        Task<Dictionary<string, List<Tip>>> GetAllTips();
    }
}
