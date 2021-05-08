using ArknightApi.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArknightApi.Data.DTO.Response
{
    public class WordResponse
    {
        public string Name { get; set; }
        public int Rarity { get; set; }
        public string OperatorCode { get; set; }
        public List<Word> Words { get; set; }
        public WordResponse(){}
        public WordResponse(Operator op)
        {
            Name = op.Name;
            Rarity = op.Rarity;
            OperatorCode = op.OperatorCode;
            Words = new List<Word>();
            foreach (CharWord c in op.CharWords)
            {
                Words.Add(new Word(c));
            }
        }
    }
    public class Word
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public Word()
        {
        }
        public Word(CharWord c)
        {
            Title = c.Title;
            Text = c.Text;
        }
    }
}
