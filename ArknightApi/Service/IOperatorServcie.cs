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
        public Task<WordResponse> GetWords(string name);
        public Task<List<Operators>> GetOperatorsByClass(string c);
        public Task<List<Operators>> GetOperatorsByRarity(int rarity);
        public Task<SkillResponse> GetOperatorSkill(string name);
        public Task<ProfileResponse> GetOperatorProfile(string name);
        public Task<BuffResponse> GetOperatorBuff(string name);
        public Task<Dictionary<string, List<string>>> GetOperatorByTag(List<string> tags);
    }
}
