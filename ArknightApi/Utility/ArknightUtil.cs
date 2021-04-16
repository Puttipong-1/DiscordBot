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
        public static string GetRoom(string room)
        {
            return room switch
            {
                "control" => "Control Center",
                "dorm" => "Dormitory",
                "hire" => "Office",
                "manufacture"=>"Factory",
                "meeting"=>"Reception Room",
                "power" => "Power Plant",
                "trading"=>"Trading Post",
                "training"=>"Traning Room",
                "workshop"=>"Workshop",
                _ => room
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
            return tag.ToLower() switch
            {
                "guard" => 1,
                "sniper" => 2,
                "defender" => 3,
                "medic" => 4,
                "supporter" => 5,
                "caster" => 6,
                "specialist" => 7,
                "vanguard" => 8,
                "melee" => 9,
                "ranged" => 10,
                "top operator" => 11,
                "crowd-control" => 12,
                "nuker" => 13,
                "senior operator" => 14,
                "healing" => 15,
                "support" => 16,
                "starter" => 17,
                "dp-recovery" => 18,
                "dps" => 19,
                "survival" => 20,
                "aoe" => 21,
                "defense" => 22,
                "slow" => 23,
                "debuff" => 24,
                "fast-redeploy" => 25,
                "shift" => 26,
                "summon" => 27,
                "robot" => 28,
                _ => 0,
            };
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
        public static string GetInfoText(string text)
        {
            string pattern = "(?<=\\[.*\\]).*";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            Match match = regex.Match(text);
            Console.WriteLine("getInfo" + "  " + match.Value);
            if (match.Success) return match.Value.Trim();
            else return "";
        }
        public static int ConvertToPercent(double value)
        {
            value *= 100;
            return Convert.ToInt32(value);
        }
        public static Dictionary<string,List<string>> CreateRecruit(List<List<string>> recruit,List<string> tags)
        {
            Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();
            for(int i = 0; i < recruit.Count; i++)
            {
                dic.Add(tags[i], recruit[i]);
                string tempTag = tags[i];
                List<string> tempList = recruit[i];
                for(int j=i+1 ; j < recruit.Count; j++)
                {
                    tempTag = tempTag + "," + tags[j];
                    tempList = tempList.Intersect(recruit[j]).ToList();
                    dic.Add(tags[i]+","+tags[j], recruit[i].Intersect(recruit[j]).ToList());
                }
                if (!dic.ContainsKey(tempTag))
                {
                    dic.Add(tempTag, tempList);
                }
            }
            return dic;
        }
        public static string GetDropType(int type)
        {
            return type switch
            {
                0=>"Guaranteed",
                1=>"Common",
                2=>"Uncommon",
                3=>"Rare",
                4=>"Very Rare",
                _=>""
            };
        }
    }
}
