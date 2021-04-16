using ArknightApi.Data.DTO.ArknightData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArknightApi.Data.Model
{
    public class Stage
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string StageId { get; set; }
        public string StageCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<DropStage> DropStages { get; set; }
        public Stage() { }
        public Stage(string key,StageJson s)
        {
            StageId = s.Code;
            StageCode = key;
            Name = s.Name;
            Description = s.Description;
            DropStages = new List<DropStage>();
            if (s.StageDropInfo != null)
            {
                if (s.StageDropInfo.DisplayDetailRewards != null)
                {
                    foreach(DisplayDetailReward d in s.StageDropInfo.DisplayDetailRewards)
                    {
                        if (int.TryParse(d.Id, out int id) && d.Type.Equals("MATERIAL"))
                        {
                            if (!DropStages.Exists(f => f.ItemId == id && f.StageId.Equals(s.Code))){
                                DropStages.Add(new DropStage(s.Code,id, d.OccPercent));
                            }
                        }
                    }
                }
            }
        }
    }
}
