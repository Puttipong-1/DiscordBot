using ArknightApi.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArknightApi.Data.Model
{
    public class CharWord
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CharWordId { get; set; }
        [ForeignKey("Operator")]
        public int OperatorId { get; set; }
        public Operator Operator { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public CharWord() { }
        public CharWord(DTO.ArknightData.CharWordJson word) 
        {
            OperatorId = ArknightUtil.GetId(word.CharId);
            Title = word.VoiceTitle;
            Text = word.VoiceText;
        }
    }
}
