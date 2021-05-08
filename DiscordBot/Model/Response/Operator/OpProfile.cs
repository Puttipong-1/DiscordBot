using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DiscordBot.Model.Response.Operator
{
    public class OpProfile
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("rarity")]
        public int Rarity { get; set; }

        [JsonPropertyName("artist")]
        public string Artist { get; set; }

        [JsonPropertyName("cv")]
        public string Cv { get; set; }
        [JsonPropertyName("operatorCode")]
        public string OperatorCode { get; set; }

        [JsonPropertyName("basicFile")]
        public BasicFile BasicFile { get; set; }

        [JsonPropertyName("physicalExam")]
        public PhysicalExam PhysicalExam { get; set; }

        [JsonPropertyName("profiles")]
        public List<Profile> Profiles { get; set; }
    }
    public class BasicFile
    {
        [JsonPropertyName("codeName")]
        public string CodeName { get; set; }

        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("combatExperience")]
        public string CombatExperience { get; set; }

        [JsonPropertyName("placeOfBirth")]
        public string PlaceOfBirth { get; set; }

        [JsonPropertyName("dateOfBirth")]
        public string DateOfBirth { get; set; }

        [JsonPropertyName("race")]
        public string Race { get; set; }

        [JsonPropertyName("height")]
        public string Height { get; set; }

        [JsonPropertyName("infectionStatus")]
        public string InfectionStatus { get; set; }
    }

    public class PhysicalExam
    {
        [JsonPropertyName("physicalStrength")]
        public string PhysicalStrength { get; set; }

        [JsonPropertyName("mobility")]
        public string Mobility { get; set; }

        [JsonPropertyName("physicalResilience")]
        public string PhysicalResilience { get; set; }

        [JsonPropertyName("tacticalAcumen")]
        public string TacticalAcumen { get; set; }

        [JsonPropertyName("combatSkill")]
        public string CombatSkill { get; set; }

        [JsonPropertyName("originiumAdaptability")]
        public string OriginiumAdaptability { get; set; }
    }

    public class Profile
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}
