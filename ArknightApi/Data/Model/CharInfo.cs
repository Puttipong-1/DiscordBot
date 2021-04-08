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
        public CharInfo() { }
        public CharInfo(int id,DTO.ArknightData.StoryTextAudio audio)
        {
            OperatorId = id;
            if (audio != null)
            {
                StoryTitle = audio.StoryTitle;
                if (audio.Stories != null&& audio.Stories.Any())
                {
                    StoryText = audio.Stories[0].StoryText;
                }
            }
        }
    }
}
