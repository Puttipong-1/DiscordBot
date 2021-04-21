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
    public class RecruitService : IRecruitService
    {
        private readonly ApplicationDbContext applicationDbContext;
        public RecruitService(ApplicationDbContext _applicationDbContext)
        {
            applicationDbContext = _applicationDbContext;
        }
        public async Task<Dictionary<string, List<string>>> GetOperatorByTag(List<string> tags)
        {
            try
            {
                List<List<string>> recruit = new List<List<string>>();
                List<string> tagName = new List<string>();
                foreach (string s in tags)
                {
                    Tag res = await applicationDbContext.Tags
                        .Where(t => t.TagName.ToLower().Contains(s.ToLower()))
                        .Include(t => t.OperatorTags.OrderBy(o=>o.Operator.Name))
                        .ThenInclude(o => o.Operator)      
                        .SingleOrDefaultAsync();
                    List<string> name = new List<string>();
                    if (res != null && res.OperatorTags != null)
                    {
                        foreach (OperatorTag t in res.OperatorTags)
                        {
                            name.Add(t.Operator.Name);
                        }
                        recruit.Add(name);
                        tagName.Add(res.TagName);
                    }
                }
                return ArknightUtil.CreateRecruit(recruit, tagName);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<RecruitResponse> GetOperatorTags(string name)
        {
            try
            {
                Operator op = await applicationDbContext.Operators
                    .Where(o => o.Name.ToLower().Contains(name.ToLower()))
                    .Include(o => o.OperatorTags)
                    .ThenInclude(o => o.Tag)
                    .SingleAsync();
                return new RecruitResponse(op);
            }catch(Exception e)
            {
                throw e;
            }
        }

        public async Task<List<Operators>> GetRecruitOperators()
        {
            try {
                List<OperatorTag> ot = await applicationDbContext.OperatorTags
                      .Include(o => o.Operator)
                      .Select(o => new OperatorTag()
                      {
                          OperatorId = o.OperatorId,
                          Operator = o.Operator
                      })
                      .Distinct()
                      .OrderBy(o => o.Operator.Name)
                      .ToListAsync();
                List<Operators> operators = new List<Operators>();
                if (ot != null)
                {
                    foreach (OperatorTag t in ot)
                    {
                        operators.Add(new Operators(t.Operator));
                    }
                }
                return operators;
            }catch(Exception e)
            {
                throw e;
            }
        }

        public async Task<List<string>> GetTags()
        {
            try
            {
                List<string> tags = await applicationDbContext.Tags
                   .Select(t => t.TagName)
                   .Distinct()
                   .ToListAsync();
                tags.RemoveAll(s => string.IsNullOrEmpty(s));
                tags.Sort();
                return tags;
            }catch(Exception e)
            {
                throw e;
            }
        }
    }
}
