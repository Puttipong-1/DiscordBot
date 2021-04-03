using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArknightApi.Data.Model
{
    public class Tip
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TipId { get; set; }
        public string Title { get; set; }
        public string TipDesc { get; set; }
        public string Category { get; set; }
        public Tip() { }
        public Tip(DTO.ArknightData.Tip tip){
            TipDesc = tip.TipDesc;
            Category = tip.Category;
        }
        public Tip(DTO.ArknightData.WorldViewTip tip)
        {
            Title = tip.Title;
            TipDesc = tip.Description;
            Category = tip.BackgroundPicId;
        }
}
}
