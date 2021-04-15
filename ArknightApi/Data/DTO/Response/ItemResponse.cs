using ArknightApi.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArknightApi.Data.DTO.Response
{
    public class ItemResponse
    {
        public int Rarity { get; set; }
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string IconId { get; set; }
        public string Usage { get; set; }
        public string Description { get; set; }
        public List<FormulaDetail> FormulaDetails { get; set; }
        public List<StageDrop> StageDrops { get; set; }
        public ItemResponse() { }
        public ItemResponse(Item item)
        {
            Rarity = item.Rarity;
            ItemId = item.ItemId;
            Name = item.Name;
            IconId = item.IconId;
            Usage = item.Usage;
            Description = item.Desc;
            FormulaDetails = new List<FormulaDetail>();
            StageDrops = new List<StageDrop>();
            if(item.Formula!=null)
            {
                foreach (Formula f in item.Formula)
                {
                    if (f.FormulaCosts != null)
                    {
                        foreach(FormulaCost fc in f.FormulaCosts)
                        {
                            FormulaDetails.Add(new FormulaDetail(fc));
                        }
                    }
                }
            }
            if (item.DropStages != null)
            {
                foreach(DropStage d in item.DropStages)
                {
                    StageDrops.Add(new StageDrop(d));
                }
            }
        }
    }
    public class FormulaDetail
    {
        public int Count { get; set; }
        public string Name { get; set; }
        public FormulaDetail() { }
        public FormulaDetail(FormulaCost cost) {
            Count = cost.Count;
            Name = cost.Item.Name;
        }
    }
    public class StageDrop
    {
        public string StageId { get; set; }
        public string StageName { get; set; }
        public string DropType { get; set; }
        public decimal DropPercent { get; set; }
        public StageDrop() { }
        public StageDrop(DropStage drop) {
            StageId = drop.StageId;
            StageName = drop.Stage.Name;
            DropType = "Test";
            DropPercent = drop.DropPercent;
        }
    }
}
