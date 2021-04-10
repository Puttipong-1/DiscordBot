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
                .Include(o => o.Elites)
                .ThenInclude(e=>e.EvolveCosts)
                .Include(o=>o.Talents)
                .Include(o=>o.Potentials)
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
                List<Operator> op=await applicationDbContext.Operators
                    .Select(o => new Operator()
                      {
                        OperatorId = o.OperatorId,
                        Name = o.Name
                      })
                    .OrderByDescending(o=>o.OperatorId)
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
                    .Include(o => o.Skins)
                    .SingleAsync();
                SkinResponse res = new SkinResponse(op);
                return res;
            }catch(Exception e)
            {
                throw e;
            }
        }
        public async Task<Operator> GetWords(string name)
        {
            try
            {
                return await applicationDbContext.Operators
                    .Where(o => o.Name.ToLower().Contains(name.ToLower()))
                    .Select(o => new Operator()
                    {
                        OperatorId = o.OperatorId,
                        Name = o.Name
                    })
                    .Include(o => o.CharWords)
                    .SingleAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<List<Operator>> GetOperatorsByClass(string c){
            try
            {
                return await applicationDbContext.Operators
                    .Where(o => o.Profession.Equals(c.ToUpper()))
                    .ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<List<Operator>> GetOperatorsByRarity(int rarity)
        {
            try
            {
                return await applicationDbContext.Operators
                    .Where(o => o.Rarity==rarity)
                    .ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
