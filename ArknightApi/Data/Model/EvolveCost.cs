using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ArknightApi.Data.Model
{
    public class EvolveCost
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EvolveCostId { get; set; }
        public int ItemId { get; set; }
        public int Count { get; set; }
        public string Type { get; set; }
        [ForeignKey("Elite")]
        public int EliteId { get; set; }
        public Elite Elite { get; set; }
        public EvolveCost() { }
        public EvolveCost(DTO.ArknightData.EvolveCost ec)
        {

            ItemId = int.Parse(ec.Id);
            Count = ec.Count;
            Type = ec.Type;
        }
    }
}
