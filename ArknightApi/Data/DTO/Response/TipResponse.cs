using ArknightApi.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArknightApi.Data.DTO.Response
{
    public class TipResponse
    {
        public List<Tips> Tips { get; set; }
        public TipResponse() { }
        public TipResponse(List<Tip> tips)
        {
            Tips = new List<Tips>();
            if (tips != null)
            {
                foreach(Tip t in tips)
                {
                    Tips.Add(new Tips(t));
                }
            }
        }
    }
    public class Tips
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Tips() { }
        public Tips(Tip tip)
        {
            Title = tip.Title;
            Description = tip.TipDesc;
        }
    }
}
