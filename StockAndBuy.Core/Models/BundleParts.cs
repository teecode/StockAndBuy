using System.ComponentModel.DataAnnotations.Schema;

namespace StockAndBuy.Core.Models
{
    public class BundleParts : BaseEntity
    {
        public Guid BundleId { get; set; }

        [ForeignKey(nameof(BundleId))]
        public Bundle Bundle { get; set; }
        public Guid BundlePartId { get; set; }

        [ForeignKey(nameof(BundlePartId))]
        public Bundle BundlePart { get; set; }
        public int RequiredUnits { get; set; }
    }

   
}