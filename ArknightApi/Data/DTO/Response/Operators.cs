using ArknightApi.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArknightApi.Data.DTO.Response
{
    public class Operators
    {
        public int Id { get; set; }
        public string Name{get;set;}
        public Operators(Operator op)
        {
            Id = op.OperatorId;
            Name = op.Name;
        }
    }
}
