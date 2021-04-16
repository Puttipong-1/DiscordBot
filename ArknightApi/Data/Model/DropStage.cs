using ArknightApi.Data.DTO.ArknightData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArknightApi.Data.Model
{
    public class DropStage
    {
        [Key, ForeignKey("Item")]
        public int ItemId { get; set; }
        public Item Item {get;set;}
        [Key,ForeignKey("Stage")]
        public string StageId { get; set; }
        public Stage Stage { get; set; }
        public int OccPercent { get; set; }
        public decimal DropPercent { get; set; }
        public DropStage(){}
        public DropStage(string key,int id,int occPercent) {
            StageId = key;
            ItemId = id;
            OccPercent = occPercent;
        }
        
    }
}
