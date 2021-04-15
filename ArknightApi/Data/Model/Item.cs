using ArknightApi.Utility;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArknightApi.Data.Model
{
    public class Item
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public string IconId { get; set; }
        public int Rarity { get; set; }
        public string Usage { get; set; }
        public string ClassifyType { get; set; }
        public string ItemType { get; set; }
        public List<Formula> Formula { get; set; }
        public List<DropStage> DropStages {get;set;}
        public Item() { }
        public Item(DTO.ArknightData.ItemDetail item)
        {
            ItemId = int.Parse(item.ItemId);
            Name = item.Name;
            Desc = item.Description;
            IconId = item.IconId;
            Rarity = ArknightUtil.CalculateRarity(item.Rarity);
            Usage = item.Usage;
            ClassifyType = item.ClassifyType;
            ItemType = item.ItemType;
        }
    }
}
