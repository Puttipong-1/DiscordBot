using ArknightApi.Data;
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
        public async Task<Operator> GetOperatorByName(string name)
        {
            try
            {
                return await applicationDbContext.Operators
                .Where(o => o.Name.ToLower().Contains(name.ToLower()))
                .SingleAsync();
            }catch(Exception e)
            {
                throw e;
            }
            
        }

        public async Task<List<Operator>> GetOperatorList()
        {
            try
            {
                return await applicationDbContext.Operators
                    .Select(o => new Operator()
                      {
                        OperatorId = o.OperatorId,
                        Name = o.Name
                      })
                    .ToListAsync();
            }catch(Exception e)
            {
                throw e;
            }
        }
    }
}
