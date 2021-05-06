using ArknightApi.Data;
using ArknightApi.Data.DTO.Response;
using ArknightApi.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArknightApi.Service
{
    public class TipService : ITipService
    {
        private readonly ApplicationDbContext applicationDb;
        public TipService(ApplicationDbContext _applicationDb)
        {
            applicationDb = _applicationDb;
        }
        public async Task<TipResponse> GetTipByCatalog(string catalog)
        {
            try
            {
                List<Tip> tips = await applicationDb.Tips
                     .Where(t => t.Category.ToLower().Contains(catalog.ToLower()))
                     .ToListAsync();
                return new TipResponse(tips);
            }catch(Exception e)
            {
                throw e;
            }
        }
        public async Task<List<string>> GetTipCatalog()
        {
            try
            {
                return await applicationDb.Tips
                    .Select(t => t.Category)
                    .Distinct()
                    .ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<Dictionary<string,List<Tip>>> GetAllTips()
        {
            try
            {
                var tips = await applicationDb.Tips.ToListAsync();
                return tips.GroupBy(t => t.Category).Select(t => t).ToDictionary(t=>t.Key,t=>t.ToList());
            }catch(Exception e)
            {
                throw e;
            }
        }
    }
}
