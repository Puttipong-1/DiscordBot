using ArknightApi.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArknightApi.Data.Model
{
    public class CharInfo
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CharInfoId { get; set; }
        [ForeignKey("Operator")]
        public int OperatorId { get; set; }
        public Operator Operator { get; set; }
        public string StoryTitle { get; set; }
        public string StoryText { get; set; }
        public CharInfo(DTO.ArknightData.CharInfo charInfo)
        {
            OperatorId = ArknightUtil.GetId(charInfo.CharID);
            if (charInfo.StoryTextAudio != null&&charInfo.StoryTextAudio.Any())
            {
                StoryTitle = charInfo.StoryTextAudio[0].StoryTitle;
                if (charInfo.StoryTextAudio[0].Stories != null&& charInfo.StoryTextAudio.Any())
                {
                    StoryText = charInfo.StoryTextAudio[0].Stories[0].StoryText;
                }
            }
        }
    }
}
