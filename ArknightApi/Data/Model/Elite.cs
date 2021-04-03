using ArknightApi.Data.DTO.ArknightData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArknightApi.Data.Model
{
    public class Elite
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EliteId { get; set; }
        public string CharacterPrefabKey { get; set; }
        public string RangeId { get; set; }
        public int MaxLevel { get; set; }
        public int Hp { get; set; }
        public int MaxHp { get; set; }
        public int Atk { get; set; }
        public int MaxAtk { get; set; }
        public int Def { get; set; }
        public int MaxDef { get; set; }
        public Double MagicResistance { get; set; }
        public int Cost { get; set; }
        public int BlockCnt { get; set; }
        public int RespawnTime { get; set; }
        public List<EvolveCost> EvolveCosts { get; set; }
        [ForeignKey("Operator")]
        public int OperatorId { get; set; }
        public Operator Operator { get; set; }
        public Elite() { }
        public Elite(Phase phase,int id)
        {
            CharacterPrefabKey = phase.CharacterPrefabKey;
            RangeId = phase.RangeId;
            MaxLevel = phase.MaxLevel;
            Hp = phase.AttributesKeyFrames[0].Data.MaxHp;
            MaxHp=phase.AttributesKeyFrames[1].Data.MaxHp;
            Atk = phase.AttributesKeyFrames[0].Data.Atk;
            MaxAtk = phase.AttributesKeyFrames[1].Data.Atk;
            Def = phase.AttributesKeyFrames[0].Data.Def;
            MaxDef = phase.AttributesKeyFrames[1].Data.Def;
            MagicResistance = phase.AttributesKeyFrames[0].Data.MagicResistance;
            Cost = phase.AttributesKeyFrames[0].Data.Cost;
            BlockCnt = phase.AttributesKeyFrames[0].Data.BlockCnt;
            RespawnTime = phase.AttributesKeyFrames[0].Data.RespawnTime;
            EvolveCosts = new List<EvolveCost>();
            OperatorId = id;
            if (phase.EvolveCost != null)
            {
                foreach (DTO.ArknightData.EvolveCost e in phase.EvolveCost)
                {
                    EvolveCost ec = new EvolveCost(e);
                    EvolveCosts.Add(ec);
                }
            }
        }
    }
}
