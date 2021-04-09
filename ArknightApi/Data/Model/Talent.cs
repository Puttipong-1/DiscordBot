using ArknightApi.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArknightApi.Data.Model
{
    public class Talent
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TalentId { get; set; }
        public int Phase { get; set; }
        public int RequirePotential { get;set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [ForeignKey("Operator")]
        public int OperatorId { get; set; }
        public Operator Operator { get; set; }
        public Talent() { }
        public Talent(DTO.ArknightData.Candidate c)
        {
            Phase = c.UnlockCondition.Phase;
            RequirePotential = c.RequiredPotentialRank;
            Name = c.Name;
            Description = ArknightUtil.RemoveBrackets(c.Description);
        }
    }
}
