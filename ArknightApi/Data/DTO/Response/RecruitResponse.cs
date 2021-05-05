using ArknightApi.Data.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArknightApi.Data.DTO.Response
{
    public class RecruitResponse
    {
        public int Id { get; set; }
        public int Rarity { get; set; }
        public string Name { get; set; }
        public string OperatorCode { get; set; }
        public List<string> Tags { get; set; }
        public RecruitResponse() { }
        public RecruitResponse(Operator op)
        {
            Id = op.OperatorId;
            Rarity = op.Rarity;
            Name = op.Name;
            OperatorCode = op.OperatorCode;
            Tags = new List<string>();
            if (op.OperatorTags != null)
            {
                foreach(OperatorTag t in op.OperatorTags)
                {
                    Tags.Add(t.Tag.TagName);
                }
            }
        }
    }
}
