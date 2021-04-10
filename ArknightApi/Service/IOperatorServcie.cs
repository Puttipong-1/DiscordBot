using ArknightApi.Data.DTO.Response;
using ArknightApi.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArknightApi.Service
{
    public interface IOperatorServcie
    {
        public Task<OperatorResponse> GetOperatorByName(string name);
        public Task<List<Operators>> GetOperatorList();
        public Task<SkinResponse> GetSkin(string name);
        public Task<Operator> GetWords(string name);
        public Task<List<Operator>> GetOperatorsByClass(string c);
        public Task<List<Operator>> GetOperatorsByRarity(int rarity);
    }
}
