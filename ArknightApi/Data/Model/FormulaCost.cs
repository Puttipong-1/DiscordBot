using ArknightApi.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArknightApi.Data.Model
{
    public class FormulaCost
    {
        [Key,ForeignKey("Formula")]
        public int FormulaCostId { get; set; }
        public Formula Formula { get; set; }
        [Key,ForeignKey("Item")]
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public int Count { get; set; }
        public FormulaCost() { }
        public FormulaCost(DTO.ArknightData.Cost cost)
        {
            ItemId = int.Parse(cost.Id);
            Count = cost.Count;
        }
    }
}
