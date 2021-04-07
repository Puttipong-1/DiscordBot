using ArknightApi.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArknightApi.Service
{
    public interface IOperatorServcie
    {
        public Task<Operator> GetOperatorByName(string name);
        public Task<List<Operator>> GetOperatorList();
    }
}
