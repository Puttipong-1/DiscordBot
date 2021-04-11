using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArknightApi.Data.Model
{
    public class OperatorTag
    {
        [Key,ForeignKey("Operator")]
        public int OperatorId { get; set; }
        public Operator Operator { get; set; }
        [Key,ForeignKey("Tag")]
        public int TagId { get; set; }
        public Tag Tag { get; set; }
        public OperatorTag() { }
        public OperatorTag(int opId,int tagId)
        {
            OperatorId = opId;
            TagId = tagId;
        }
    }
}
