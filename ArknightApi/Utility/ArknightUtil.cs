using ArknightApi.Data.DTO.ArknightData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ArknightApi.Utility
{
    public class ArknightUtil
    {
        public static string JoinListTag(List<string> tags)
        {
            if (tags is null) return "";
            return string.Join(",", tags);
        }
        public static string RemoveBrackets(string text)
        {
            if (string.IsNullOrEmpty(text)) return "";
            return Regex.Replace(text, @"\<(@|[A-z]|\.|\/)*\>","");
        }
        public static int CalculateRarity(int rarity)
        {
            rarity += 1;
            if (rarity == 0) rarity += 1;
            return rarity;
        }
        public static int GetId(string key)
        {
            var myRegex = new Regex(@"(?<=_)([0-9]*)(?=_)");
            string resultString = myRegex.Match(key).Value;
            return int.Parse(resultString);
        }
        public static string GetTeam(int t)
        {
            return t switch
            {
                -1 => "No Team",
                1 => "Op Team A4",
                2 => "Reserve Op Team A1",
                3 => "Reserve Op Team A4",
                4 => "Rhine Lab",
                5 => "S.W.E.E.P Prototype",
                6 => "Karlan Commercial",
                8 => "Ursus Student Self-Government Group",
                9 => "Followers",
                10 => "Glasgow",
                11 => "Penguin Logistics",
                12 => "Lungmen Guard Department",
                13 => "Blacksteel",
                15 => "Abyssal Hunters",
                19 => "Reserve Op Team A6",
                _ => ""
            };
        }
        public static string GetClass(string prof)
        {
            return prof switch
            {
                "WARRIOR" => "GUARD",
                "SPECIAL" => "SPECIALIST",
                "TANK" => "DEFENDER",
                "PIONEER" => "VANGUARD",
                "SUPPORT" => "SUPPORTER",
                _ => prof
            };
        }
        public static int GetTagId(string tag)
        {
            switch (tag)
            {
                case "Guard":return 1;
                case "Sniper": return 2;
                case "Defender": return 3;
                case "Medic": return 4;
                case "Supporter": return 5;
                case "Caster": return 6;
                case "Specialist": return 7;
                case "Vanguard": return 8;
                case "Melee": return 9;
                case "Ranged": return 10;
                case "Top Operator":return 11;
                case "Crowd-Control":return 12;
                case "Nuker":return 13;
                case "Senior Operator":return 14;
                case "Healing":return 15;
                case "Support":return 16;
                case "Starter":return 17;
                case "DP-Recovery":return 18;
                case "DPS":return 19;
                case "Survival":return 20;
                case "AoE":return 21;
                case "Defense":return 22;
                case "Slow":return 23;
                case "Debuff":return 24;
                case "Fast-Redeploy":return 25;
                case "shift":return 26;
                case "Summon":return 27;
                case "Robot":return 28;
                default:return 0;
            }
        }
        public static string ReplaceSkillDesc(string desc,List<BB> first,List<BB> last)
        {
            string pattern = "\\{(.*?)\\}";
            string pattern2 = "(?<=\\{).*?((?=\\})|(?=\\:))";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            Match match = regex.Match(desc);
            while (match.Success)
            {
                Regex regex2 = new Regex(pattern2, RegexOptions.IgnoreCase);
                Match match2 = regex2.Match(match.Value);
                bool flag = match.Value.Contains("%");
                string text = "";
                if (match2.Success)
                {
                    foreach (BB b in first)
                    {
                        if (b.Key.Equals(match2.Value))
                        {
                            if (flag) text +=ConvertToPercent(b.Value) + "%";
                            else text += b.Value.ToString();
                        }
                    }
                    foreach (BB b in last)
                    {
                        if (b.Key.Equals(match2.Value))
                        {
                            if (flag) text += String.Format("({0}%)",ConvertToPercent(b.Value));
                            else text += String.Format("({0})", b.Value);
                        }
                    }
                }
                desc = desc.Replace(match.Value, text);
                match = match.NextMatch();
            }
            return RemoveBrackets(desc);
        }
        public static int ConvertToPercent(double value)
        {
            value *= 100;
            return Convert.ToInt32(value);
        }
    }
}
