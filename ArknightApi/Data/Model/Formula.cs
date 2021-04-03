using ArknightApi.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArknightApi.Data.Model
{
    public class Formula
    {
        [Key,Column(Order = 0)]
        public int FormulaId { get; set; }
        [ForeignKey("Item")]
        public int ItemId { get; set; }
        public Item Item{get;set;}
        public List<FormulaCost> FormulaCosts { get; set; }
        public Formula() { }
        public Formula(DTO.ArknightData.Building build)
        {
            FormulaId = int.Parse(build.FormulaId);
            ItemId = int.Parse(build.ItemId);
            FormulaCosts = new List<FormulaCost>();
            if (build.Costs != null)
            {
                foreach (DTO.ArknightData.Cost c in build.Costs)
                {
                    FormulaCosts.Add(new FormulaCost(FormulaId, c));
                }
            }
        }
    }
}
