using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ArknightApi.Data.DTO.ArknightData
{
    public class Data
    {
        [JsonPropertyName("maxHp")]
        public int MaxHp { get; set; }

        [JsonPropertyName("atk")]
        public int Atk { get; set; }

        [JsonPropertyName("def")]
        public int Def { get; set; }

        [JsonPropertyName("magicResistance")]
        public double MagicResistance { get; set; }

        [JsonPropertyName("cost")]
        public int Cost { get; set; }

        [JsonPropertyName("blockCnt")]
        public int BlockCnt { get; set; }

        [JsonPropertyName("moveSpeed")]
        public double MoveSpeed { get; set; }

        [JsonPropertyName("attackSpeed")]
        public double AttackSpeed { get; set; }

        [JsonPropertyName("baseAttackTime")]
        public double BaseAttackTime { get; set; }

        [JsonPropertyName("respawnTime")]
        public int RespawnTime { get; set; }

        [JsonPropertyName("hpRecoveryPerSec")]
        public double HpRecoveryPerSec { get; set; }

        [JsonPropertyName("spRecoveryPerSec")]
        public double SpRecoveryPerSec { get; set; }

        [JsonPropertyName("maxDeployCount")]
        public int MaxDeployCount { get; set; }

        [JsonPropertyName("maxDeckStackCnt")]
        public int MaxDeckStackCnt { get; set; }

        [JsonPropertyName("tauntLevel")]
        public int TauntLevel { get; set; }

        [JsonPropertyName("massLevel")]
        public int MassLevel { get; set; }

        [JsonPropertyName("baseForceLevel")]
        public int BaseForceLevel { get; set; }

        [JsonPropertyName("stunImmune")]
        public bool StunImmune { get; set; }

        [JsonPropertyName("silenceImmune")]
        public bool SilenceImmune { get; set; }

        [JsonPropertyName("sleepImmune")]
        public bool SleepImmune { get; set; }
    }

    public class AttributesKeyFrame
    {
        [JsonPropertyName("level")]
        public int Level { get; set; }

        [JsonPropertyName("data")]
        public Data Data { get; set; }
    }

    public class EvolveCost
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }

    public class Phase
    {
        [JsonPropertyName("characterPrefabKey")]
        public string CharacterPrefabKey { get; set; }

        [JsonPropertyName("rangeId")]
        public string RangeId { get; set; }

        [JsonPropertyName("maxLevel")]
        public int MaxLevel { get; set; }

        [JsonPropertyName("attributesKeyFrames")]
        public List<AttributesKeyFrame> AttributesKeyFrames { get; set; }

        [JsonPropertyName("evolveCost")]
        public List<EvolveCost> EvolveCost { get; set; }
    }

    public class UnlockCond
    {
        [JsonPropertyName("phase")]
        public int Phase { get; set; }

        [JsonPropertyName("level")]
        public int Level { get; set; }
    }

    public class LevelUpCost
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }

    public class LevelUpCostCond
    {
        [JsonPropertyName("unlockCond")]
        public UnlockCond UnlockCond { get; set; }

        [JsonPropertyName("lvlUpTime")]
        public int LvlUpTime { get; set; }

        [JsonPropertyName("levelUpCost")]
        public List<LevelUpCost> LevelUpCost { get; set; }
    }

    public class Skill
    {
        [JsonPropertyName("skillId")]
        public string SkillId { get; set; }

        [JsonPropertyName("overridePrefabKey")]
        public object OverridePrefabKey { get; set; }

        [JsonPropertyName("overrideTokenKey")]
        public object OverrideTokenKey { get; set; }

        [JsonPropertyName("levelUpCostCond")]
        public List<LevelUpCostCond> LevelUpCostCond { get; set; }

        [JsonPropertyName("unlockCond")]
        public UnlockCond UnlockCond { get; set; }
    }

    public class UnlockCondition
    {
        [JsonPropertyName("phase")]
        public int Phase { get; set; }

        [JsonPropertyName("level")]
        public int Level { get; set; }
    }

    public class Blackboard
    {
        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("value")]
        public double Value { get; set; }
    }

    public class Candidate
    {
        [JsonPropertyName("unlockCondition")]
        public UnlockCondition UnlockCondition { get; set; }

        [JsonPropertyName("requiredPotentialRank")]
        public int RequiredPotentialRank { get; set; }

        [JsonPropertyName("prefabKey")]
        public string PrefabKey { get; set; }
        [JsonPropertyName("overrideDescripton")]
        public string OverrideDescription { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("rangeId")]
        public object RangeId { get; set; }

        [JsonPropertyName("blackboard")]
        public List<Blackboard> Blackboard { get; set; }
    }

    public class Talent
    {
        [JsonPropertyName("candidates")]
        public List<Candidate> Candidates { get; set; }
    }

    public class AttributeModifier
    {
        [JsonPropertyName("attributeType")]
        public int AttributeType { get; set; }

        [JsonPropertyName("formulaItem")]
        public int FormulaItem { get; set; }

        [JsonPropertyName("value")]
        public double Value { get; set; }

        [JsonPropertyName("loadFromBlackboard")]
        public bool LoadFromBlackboard { get; set; }

        [JsonPropertyName("fetchBaseValueFromSourceEntity")]
        public bool FetchBaseValueFromSourceEntity { get; set; }
    }

    public class Attributes
    {
        [JsonPropertyName("abnormalFlags")]
        public object AbnormalFlags { get; set; }

        [JsonPropertyName("abnormalImmunes")]
        public object AbnormalImmunes { get; set; }

        [JsonPropertyName("abnormalCombos")]
        public object AbnormalCombos { get; set; }

        [JsonPropertyName("abnormalComboImmunes")]
        public object AbnormalComboImmunes { get; set; }

        [JsonPropertyName("attributeModifiers")]
        public List<AttributeModifier> AttributeModifiers { get; set; }
    }

    public class Buff
    {
        [JsonPropertyName("attributes")]
        public Attributes Attributes { get; set; }
    }

    public class PotentialRank
    {
        [JsonPropertyName("type")]
        public int Type { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("buff")]
        public Buff Buff { get; set; }

        [JsonPropertyName("equivalentCost")]
        public object EquivalentCost { get; set; }
    }

    public class FavorKeyFrame
    {
        [JsonPropertyName("level")]
        public int Level { get; set; }

        [JsonPropertyName("data")]
        public Data Data { get; set; }
    }

    public class LvlUpCost
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }

    public class AllSkillLvlup
    {
        [JsonPropertyName("unlockCond")]
        public UnlockCond UnlockCond { get; set; }

        [JsonPropertyName("lvlUpCost")]
        public List<LvlUpCost> LvlUpCost { get; set; }
    }

    public class Character
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("canUseGeneralPotentialItem")]
        public bool CanUseGeneralPotentialItem { get; set; }

        [JsonPropertyName("potentialItemId")]
        public string PotentialItemId { get; set; }

        [JsonPropertyName("team")]
        public int Team { get; set; }

        [JsonPropertyName("displayNumber")]
        public string DisplayNumber { get; set; }

        [JsonPropertyName("tokenKey")]
        public object TokenKey { get; set; }

        [JsonPropertyName("appellation")]
        public string Appellation { get; set; }

        [JsonPropertyName("position")]
        public string Position { get; set; }

        [JsonPropertyName("tagList")]
        public List<string> TagList { get; set; }

        [JsonPropertyName("displayLogo")]
        public string DisplayLogo { get; set; }

        [JsonPropertyName("itemUsage")]
        public string ItemUsage { get; set; }

        [JsonPropertyName("itemDesc")]
        public string ItemDesc { get; set; }

        [JsonPropertyName("itemObtainApproach")]
        public string ItemObtainApproach { get; set; }

        [JsonPropertyName("isNotObtainable")]
        public bool IsNotObtainable { get; set; }

        [JsonPropertyName("maxPotentialLevel")]
        public int MaxPotentialLevel { get; set; }

        [JsonPropertyName("rarity")]
        public int Rarity { get; set; }

        [JsonPropertyName("profession")]
        public string Profession { get; set; }

        [JsonPropertyName("trait")]
        public Candidate Trait { get; set; }

        [JsonPropertyName("phases")]
        public List<Phase> Phases { get; set; }

        [JsonPropertyName("skills")]
        public List<Skill> Skills { get; set; }

        [JsonPropertyName("talents")]
        public List<Talent> Talents { get; set; }

        [JsonPropertyName("potentialRanks")]
        public List<PotentialRank> PotentialRanks { get; set; }

        [JsonPropertyName("favorKeyFrames")]
        public List<FavorKeyFrame> FavorKeyFrames { get; set; }

        [JsonPropertyName("allSkillLvlup")]
        public List<AllSkillLvlup> AllSkillLvlup { get; set; }
    }

}
