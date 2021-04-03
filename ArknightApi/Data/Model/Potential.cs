using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArknightApi.Data.Model
{
    public class Potential
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PotentialId { get; set;}
        [ForeignKey("Operator")]
        public int OperatorId { get; set; }
        public Operator Operator { get; set; }
        public string Desc { get; set; }
        public Potential() { }
        public Potential(DTO.ArknightData.PotentialRank p,int id)
        {
            OperatorId = id;
            Desc = p.Description;
        } 
    }
}
