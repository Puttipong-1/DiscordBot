using ArknightApi.Data.DTO.ArknightData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArknightApi.Data.Model
{
    public class Tag
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TagId { get; set; }
        public string TagName { get; set; }
        public List<OperatorTag> OperatorTags { get; set; }
        public Tag() { }
        public Tag(int id)
        {
            TagId = id;
            TagName = "";
        }
        public Tag(GachaJson g)
        {
            TagId = g.TagId;
            TagName = g.TagName;
        }
    }
}
