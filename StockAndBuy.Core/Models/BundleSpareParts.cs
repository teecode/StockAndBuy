using System.ComponentModel.DataAnnotations.Schema;

namespace StockAndBuy.Core.Models
{
    public class BundleSpareParts : BaseEntity
    {
        public Guid BundleId { get; set; }

        [ForeignKey(nameof(BundleId))]
        public Bundle Bundle { get; set; }
        public Guid SparePartId { get; set; }

        [ForeignKey(nameof(SparePartId))]
        public SparePart SparePart { get; set; }
        public int RequiredUnits { get; set; }
    }

   
}