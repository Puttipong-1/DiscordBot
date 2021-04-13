using ArknightApi.Data.Model;
using ArknightApi.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ArknightApi.Data.DTO.Response
{
    public class ProfileResponse
    {
        public string Name { get; set; }
        public int Rarity { get; set; }
        public string Artist { get; set; }
        public string CV { get; set; }
        public BasicFile BasicFile { get; set; }
        public PhysicalExam PhysicalExam { get; set; }
        public List<Profile> Profiles { get; set; }
        public ProfileResponse() { }
        public ProfileResponse(Operator op)
        {
            Name = op.Name;
            Rarity = op.Rarity;
            Artist = op.Artist;
            CV = op.CV;
            Profiles = new List<Profile>();
            if (op.CharInfos != null)
            {
                foreach(CharInfo c in op.CharInfos)
                {
                    switch (c.StoryTitle)
                    {
                        case "Basic Info":{
                                Console.WriteLine(c.StoryTitle);
                                BasicFile = new BasicFile(c);
                                break;
                            }
                        case "Physical Exam":
                            {
                                Console.WriteLine(c.StoryTitle);
                                PhysicalExam = new PhysicalExam(c);
                                break;
                            }
                        default:
                            {
                                Profiles.Add(new Profile(c));
                                break;
                            }
                    }
                }
            }
        }
    }
    public class BasicFile
    {
        public string CodeName { get; set; }
        public string Gender { get; set; }
        public string CombatExperience { get; set; }
        public string PlaceOfBirth { get; set; }
        public string DateOfBirth { get; set; }
        public string Race { get; set; }
        public string Height { get; set; }
        public string InfectionStatus { get; set; }
        public BasicFile() { }
        public BasicFile(CharInfo charInfo)
        {
            string[] text = charInfo.StoryText.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            string pattern = "\\[(.*?)\\]";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            foreach(string t in text)
            {
                Match m = regex.Match(t);
                Console.WriteLine("Basic" + "  " + m.Value);
                if (m.Success)
                {
                    if (m.Value.Contains("Code Name")) CodeName = ArknightUtil.GetInfoText(t);
                    else if (m.Value.Contains("Gender")) Gender = ArknightUtil.GetInfoText(t);
                    else if (m.Value.Contains("Combat Experience")) CombatExperience = ArknightUtil.GetInfoText(t);
                    else if (m.Value.Contains("Place of Birth")) PlaceOfBirth = ArknightUtil.GetInfoText(t);
                    else if (m.Value.Contains("Date of Birth")) DateOfBirth = ArknightUtil.GetInfoText(t);
                    else if (m.Value.Contains("Race")) Race = ArknightUtil.GetInfoText(t);
                    else if (m.Value.Contains("Height")) Height = ArknightUtil.GetInfoText(t);
                    else if (m.Value.Contains("Infection Status")) InfectionStatus = text.Last().Trim();
                }
            }
        }
    }
    public class PhysicalExam
    {
        public string PhysicalStrength { get; set; }
        public string Mobility { get; set; }
        public string PhysicalResilience { get; set; }
        public string TacticalAcumen { get; set; }
        public string CombatSkill { get; set; }
        public string OriginiumAdaptability { get; set; }
        public PhysicalExam() { }
        public PhysicalExam(CharInfo info) {
            string[] text = info.StoryText.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            string pattern = "\\[(.*?)\\]";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            foreach (string t in text)
            {
                Match m = regex.Match(t);
                if (m.Success)
                {
                    if (m.Value.Contains("Physical Strength")) PhysicalStrength = ArknightUtil.GetInfoText(t);
                    else if (m.Value.Contains("Mobility")) Mobility = ArknightUtil.GetInfoText(t);
                    else if (m.Value.Contains("Physical Resilience")) PhysicalResilience = ArknightUtil.GetInfoText(t);
                    else if (m.Value.Contains("Tactical Acumen")) TacticalAcumen = ArknightUtil.GetInfoText(t);
                    else if (m.Value.Contains("Combat Skill")) CombatSkill = ArknightUtil.GetInfoText(t);
                    else if (m.Value.Contains("Originium Arts Assimilation")) OriginiumAdaptability = ArknightUtil.GetInfoText(t);
                }
            }
        }
    }
    public class Profile
    {
        public string Text { get; set; }
        public string Title { get; set; }
        public Profile() { }
        public Profile(CharInfo c)
        {
            Text = c.StoryText;
            Title = c.StoryTitle;
        }
    }
}
