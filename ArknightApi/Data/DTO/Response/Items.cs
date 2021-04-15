using ArknightApi.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArknightApi.Data.DTO.Response
{
    public class Items
    {
        public int Rarity { get; set; }
        public int ItemId { get; set; }
        public string Name { get; set; }
        public Items() { }
        public Items(Item item) {
            Rarity = item.Rarity;
            ItemId = item.ItemId;
            Name = item.Name;
        }
    }
}
