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
        public int Formula { get; set; }
        [Key,ForeignKey("item")]
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public int Count { get; set; }
        public FormulaCost() { }
        public FormulaCost(int id,DTO.ArknightData.Cost cost)
        {
            FormulaCostId = id;
            ItemId = int.Parse(cost.Id);
            Count = cost.Count;
        }
    }
}
