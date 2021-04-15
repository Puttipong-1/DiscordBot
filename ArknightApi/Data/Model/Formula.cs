using ArknightApi.Data.DTO.ArknightData;
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
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FormulaId { get; set; }
        [ForeignKey("Item")]
        public int ItemId { get; set; }
        public Item Item{get;set;}
        public int Count { get; set; }
        public string RoomType { get; set; }
        public List<FormulaCost> FormulaCosts { get; set; }
        public Formula() { }
        public Formula(Building build)
        {
            ItemId = int.Parse(build.ItemId);
            FormulaCosts = new List<FormulaCost>();
            if (build.RequireRooms != null)
            {
               foreach(RequireRoom r in build.RequireRooms)
                {
                    if (r.RoomId.Equals("WORKSHOP") || r.RoomId.Equals("MANUFACTURE"))
                    {
                        RoomType = r.RoomId;
                    }
                }
            }
            if (build.Costs != null)
            {
                foreach(Cost c in build.Costs)
                {
                    FormulaCosts.Add(new FormulaCost(c));
                }
            }
        }
    }
}
