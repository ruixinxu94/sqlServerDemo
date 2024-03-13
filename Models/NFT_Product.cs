using System.ComponentModel.DataAnnotations;

namespace sqlServerDemo.Models
{
    public class NFT_Product
    {
        [Key] public int ID { get; set; }

        public int Rank { get; set; }
        public string CollectionName { get; set; }
        public string ImageUrls { get; set; }
        public decimal FloorPrice { get; set; }
        public int Volume { get; set; }
    }
}