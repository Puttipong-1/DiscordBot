using ArknightApi.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArknightApi.Data.Model
{
    public class BaseBuff
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BaseBuffId { get; set; }
        public string BuffCode { get; set; }
        [ForeignKey("Operator")]
        public int OperatorId { get; set; }
        public Operator Operator { get; set; }
        public string BuffName { get; set; }
        public string BuffIcon { get; set; }
        public string SkillIcon { get; set; }
        public string BuffCategory { get; set; }
        public string Description { get; set; }
        public BaseBuff() {}
        public BaseBuff(DTO.ArknightData.BaseBuff baseBuff,DTO.ArknightData.CharBuff charBuff)
        {
            OperatorId = ArknightUtil.GetId(charBuff.CharId);
            BuffCode = baseBuff.BuffId;
            BuffName = baseBuff.BuffName;
            BuffIcon = baseBuff.BuffIcon;
            SkillIcon = baseBuff.SkillIcon;
            BuffCategory = baseBuff.BuffCategory;
            Description = ArknightUtil.RemoveBrackets(baseBuff.Description);
        }
    }
}
