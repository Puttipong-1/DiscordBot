using ArknightApi.Data;
using ArknightApi.Data.DTO.Response;
using ArknightApi.Data.Model;
using ArknightApi.Utility;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArknightApi.Service
{
    public class OperatorService : IOperatorServcie
    {
        private readonly ApplicationDbContext applicationDbContext;
        public OperatorService(ApplicationDbContext _applicationDbContext)
        {
            applicationDbContext = _applicationDbContext;
        }
        public async Task<OperatorResponse> GetOperatorByName(string name)
        {
            try
            {
                Operator op= await applicationDbContext.Operators
                .Where(o => o.Name.ToLower().Contains(name.ToLower()))
                .Include(o => o.Elites.OrderBy(e=>e.MaxLevel))
                .ThenInclude(e=>e.EvolveCosts)
                .ThenInclude(e=>e.Item)
                .Include(o=>o.Talents)
                .Include(o=>o.Potentials.OrderBy(p=>p.Level))
                .SingleAsync();
                return new OperatorResponse(op);
            }catch(Exception e)
            {
                throw e;
            }
        }
        public async Task<List<Operators>> GetOperatorList()
        {
            try
            {
                List<Operators> operators = new List<Operators>();
                List<Operator> op = await applicationDbContext.Operators
                    .Select(o => new Operator()
                    {
                        OperatorId = o.OperatorId,
                        Rarity = o.Rarity,
                        Name = o.Name
                    })
                    .OrderBy(o=>o.OperatorId)
                    .ToListAsync();
                foreach(Operator o in op)
                {
                    operators.Add(new Operators(o));
                }
                return operators;
            }catch(Exception e)
            {
                throw e;
            }
        }
        public async Task<SkinResponse> GetSkin(string name)
        {
            try
            {
                Operator op = await applicationDbContext.Operators
                    .Where(o => o.Name.ToLower().Contains(name.ToLower()))
                    .Include(o => o.Skins.OrderBy(s=>s.SkinCode))
                    .SingleAsync();
                SkinResponse res = new SkinResponse(op);
                return res;
            }catch(Exception e)
            {
                throw e;
            }
        }
        public async Task<WordResponse> GetWords(string name)
        {
            try
            {
                Operator op=await applicationDbContext.Operators
                    .Where(o => o.Name.ToLower().Contains(name.ToLower()))
                    .Include(o => o.CharWords.OrderBy(c=>c.Index))
                    .SingleAsync();
                return new WordResponse(op);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<List<Operators>> GetOperatorsByClass(string c){
            try
            {
                List<Operators> operators = new List<Operators>();
                List<Operator> op=await applicationDbContext.Operators
                    .Where(o => o.Profession.Equals(c.ToUpper()))
                    .Select(o => new Operator()
                    {
                        OperatorId = o.OperatorId,
                        Name = o.Name,
                        Rarity = o.Rarity
                    })
                    .OrderBy(o => o.OperatorId)
                    .ToListAsync();
                foreach (Operator o in op)
                {
                    operators.Add(new Operators(o));
                }
                return operators;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<List<Operators>> GetOperatorsByRarity(int rarity)
        {
            try
            {
                List<Operators> operators = new List<Operators>();
                List<Operator> op = await applicationDbContext.Operators
                    .Where(o => o.Rarity==rarity)
                     .Select(o => new Operator()
                     {
                         OperatorId = o.OperatorId,
                         Name = o.Name,
                         Rarity = o.Rarity
                     })
                    .OrderBy(o=>o.OperatorId)
                    .ToListAsync();
                foreach (Operator o in op)
                {
                    operators.Add(new Operators(o));
                }
                return operators;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<SkillResponse> GetOperatorSkill(string name)
        {
            try
            {
                Operator op = await applicationDbContext.Operators
                    .Where(o => o.Name.ToLower().Equals(name.ToLower()))
                    .Include(o => o.AllSkillUps.OrderBy(o=>o.Level))
                    .ThenInclude(a=>a.AllSkillCosts)
                    .ThenInclude(a=>a.Item)
                    .Include(o=>o.Skills.OrderBy(s=>s.SkillCode))
                    .ThenInclude(s=>s.MasteryUpCosts)
                    .ThenInclude(m=>m.Item)
                    .SingleAsync();
                return new SkillResponse(op);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<ProfileResponse> GetOperatorProfile(string name)
        {
            try
            {
                Operator op = await applicationDbContext.Operators
                   .Where(o => o.Name.ToLower().Equals(name.ToLower()))
                   .Include(o => o.CharInfos.OrderBy(c=>c.StoryTitle))
                   .SingleAsync();
                return new ProfileResponse(op);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<BuffResponse> GetOperatorBuff(string name)
        {
            try
            {
                Operator op = await applicationDbContext.Operators
                    .Where(o => o.Name.ToLower().Equals(name.ToLower()))
                    .Include(o => o.BaseBuffs)
                    .SingleAsync();
                return new BuffResponse(op);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<Dictionary<string,List<string>>> GetOperatorByTag(List<string> tags)
        {
            try
            {
                List<List<string>> recruit = new List<List<string>>();
                foreach(string s in tags)
                {
                    Tag res = await applicationDbContext.Tags
                        .Where(t => t.TagName.ToLower().Contains(s.ToLower()))
                        .Include(t => t.OperatorTags)
                        .ThenInclude(o => o.Operator)
                        .SingleOrDefaultAsync();
                    List<string> name = new List<string>();
                    if (res != null&&res.OperatorTags!=null)
                    {
                        foreach (OperatorTag t in res.OperatorTags)
                        {
                            name.Add(t.Operator.Name);
                        }
                        recruit.Add(name);
                    }
                }
                return ArknightUtil.CreateRecruit(recruit,tags);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
